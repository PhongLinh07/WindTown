

Imports System.Globalization
Imports System.Text.RegularExpressions
Imports NCalc

Public NotInheritable Class FormulaHelper
    Private Sub New()
    End Sub

    Private Shared ReadOnly DefaultFunctions As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
        "abs", "min", "max", "pow", "round", "floor", "ceil", "ceiling", "if"
    }

    ' ============================
    ' PUBLIC METHODS
    ' ============================

    ''' <summary>
    ''' Tính toán giá trị từ công thức
    ''' VD: EvalFormula("BASE_SALARY * 0.08", maps) → 720000.0
    ''' </summary>
    Public Shared Function EvalFormula(formula As String, vars As Dictionary(Of String, Double), Optional allowedFunctions As HashSet(Of String) = Nothing) As Double

        Try
            formula = Sanitize(formula, vars, allowedFunctions)
            Dim exp = CreateExpression(formula, vars, allowedFunctions)
            Return ToDouble(exp.Evaluate())
        Catch ex As Exception
            Logger.Instance.Logging($"[FormulaHelper] Lỗi eval: [{formula}] → {ex.Message}", Logger.Error)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Tính toán điều kiện boolean
    ''' VD: EvalCondition("SUM_OFFICE_HOURS >= STD_HOURS", maps) → True
    ''' </summary>
    Public Shared Function EvalCondition(
        condition As String,
        vars As Dictionary(Of String, Double),
        Optional allowedFunctions As HashSet(Of String) = Nothing) As Boolean

        If String.IsNullOrWhiteSpace(condition) OrElse
           condition.Trim().ToLower() = "true" Then Return True

        Try
            condition = Sanitize(condition, vars, allowedFunctions)
            Dim exp = CreateExpression(condition, vars, allowedFunctions)
            Return ToDouble(exp.Evaluate()) <> 0
        Catch
            Return False
        End Try
    End Function

    ' ============================
    ' CORE LOGIC
    ' ============================

    Private Shared Function CreateExpression(
        expr As String,
        vars As Dictionary(Of String, Double),
        allowedFunctions As HashSet(Of String)) As NCalc.Expression

        Dim exp As New Expression(expr, EvaluateOptions.IgnoreCase)

        If vars IsNot Nothing Then
            For Each v In vars
                exp.Parameters(v.Key) = v.Value
            Next
        End If

        BindFunctions(exp, allowedFunctions)
        Return exp
    End Function

    Private Shared Sub BindFunctions(exp As Expression, allowed As HashSet(Of String))
        Dim allowedList = If(allowed, DefaultFunctions)

        AddHandler exp.EvaluateFunction,
            Sub(name As String, args As FunctionArgs)
                If Not allowedList.Contains(name) Then
                    Throw New Exception($"Hàm '{name}' không được phép dùng.")
                End If

                Dim getArg = Function(i As Integer) ToDouble(args.Parameters(i).Evaluate())

                Select Case name.ToLower()
                    Case "abs"
                        args.Result = Math.Abs(getArg(0))

                    Case "min"
                        args.Result = Math.Min(getArg(0), getArg(1))

                    Case "max"
                        args.Result = Math.Max(getArg(0), getArg(1))

                    Case "pow"
                        args.Result = Math.Pow(getArg(0), getArg(1))

                    Case "round"
                        args.Result = Math.Round(getArg(0))

                    Case "floor"
                        args.Result = Math.Floor(getArg(0))

                    Case "ceil", "ceiling"
                        args.Result = Math.Ceiling(getArg(0))

                    Case "if"
                        ' *** QUAN TRỌNG: Lazy eval ***
                        ' Chỉ tính nhánh được chọn, không tính nhánh kia
                        ' Tránh crash khi nhánh kia chia cho 0
                        ' VD: IF(STD_HOURS > 0, BASE_SALARY / STD_HOURS, 0)
                        '     Nếu STD_HOURS=0, nhánh đúng KHÔNG được tính
                        If args.Parameters.Length <> 3 Then
                            Throw New Exception("Cú pháp: IF(điều_kiện, nếu_đúng, nếu_sai)")
                        End If
                        Dim cond = ToDouble(args.Parameters(0).Evaluate()) <> 0
                        args.Result = If(cond,
                                         args.Parameters(1).Evaluate(),
                                         args.Parameters(2).Evaluate())
                End Select
            End Sub
    End Sub

    ' ============================
    ' SANITIZE & VALIDATION
    ' ============================

    Private Shared Function Sanitize(formula As String, vars As Dictionary(Of String, Double), allowed As HashSet(Of String)) As String

        If String.IsNullOrWhiteSpace(formula) Then Return "0"

        formula = formula.Trim()

        ' Bỏ dấu "=" ở đầu nếu người dùng gõ kiểu Excel
        If formula.StartsWith("=") Then
            formula = formula.Substring(1)
        End If

        Dim allowedList = If(allowed, DefaultFunctions)

        ' Chỉ cho phép ký tự hợp lệ trong công thức
        formula = Regex.Replace(formula, "[^0-9a-zA-Z_+\-*/%().?:<>=!&|,]", "")

        ' Kiểm tra từng token: phải là biến có trong vars hoặc hàm cho phép
        Dim matches = Regex.Matches(formula, "[a-zA-Z_][a-zA-Z0-9_]*")
        For Each m As Match In matches
            Dim token = m.Value
            If Not vars.ContainsKey(token) AndAlso
               Not allowedList.Contains(token) Then
                Throw New Exception($"Biến hoặc hàm không hợp lệ: '{token}'")
            End If
        Next

        Return formula
    End Function

    ' ============================
    ' TO DOUBLE
    ' ============================

    ''' <summary>
    ''' Chuyển mọi kiểu NCalc trả về thành Double
    ''' </summary>
    Private Shared Function ToDouble(v As Object) As Double
        If v Is Nothing Then Return 0
        If TypeOf v Is Double Then Return DirectCast(v, Double)
        If TypeOf v Is Single Then Return CDbl(DirectCast(v, Single))
        If TypeOf v Is Decimal Then Return CDbl(DirectCast(v, Decimal))
        If TypeOf v Is Integer Then Return CDbl(DirectCast(v, Integer))
        If TypeOf v Is Long Then Return CDbl(DirectCast(v, Long))
        If TypeOf v Is Boolean Then Return If(DirectCast(v, Boolean), 1.0, 0.0)
        Try
            Return Convert.ToDouble(v, CultureInfo.InvariantCulture)
        Catch
            Return 0
        End Try
    End Function

End Class