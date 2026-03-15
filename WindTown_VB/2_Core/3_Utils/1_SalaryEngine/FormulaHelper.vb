Imports System.Globalization
Imports System.Text.RegularExpressions
Imports NCalc ' Cần cài đặt thư viện NCalc từ NuGet

Public NotInheritable Class FormulaHelper
    Private Sub New()
    End Sub

    ' Sử dụng StringComparer.OrdinalIgnoreCase để hỗ trợ không phân biệt hoa thường tự động
    Private Shared ReadOnly DefaultFunctions As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase) From {
        "abs", "min", "max", "pow", "round", "floor", "ceil", "ceiling", "if"
    }

    ' ============================
    ' PUBLIC METHODS
    ' ============================

    ''' <summary>
    ''' Tính toán giá trị từ công thức (ví dụ: "BasicSalary * 0.1")
    ''' </summary>
    Public Shared Function EvalFormula(
        formula As String,
        vars As Dictionary(Of String, Double),
        Optional allowedFunctions As HashSet(Of String) = Nothing) As Double

        Try
            formula = Sanitize(formula, vars, allowedFunctions)
            Dim exp = CreateExpression(formula, vars, allowedFunctions)
            Return ToDouble(exp.Evaluate())
        Catch ex As Exception
            Console.WriteLine($"[FormulaHelper] Error: {formula} -> {ex.Message}")
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Tính toán điều kiện (ví dụ: "DaysWorked > 20")
    ''' </summary>
    Public Shared Function EvalCondition(
        condition As String,
        vars As Dictionary(Of String, Double),
        Optional allowedFunctions As HashSet(Of String) = Nothing) As Boolean

        If String.IsNullOrWhiteSpace(condition) OrElse condition.Trim().ToLower() = "true" Then
            Return True
        End If

        Try
            condition = Sanitize(condition, vars, allowedFunctions)
            Dim exp = CreateExpression(condition, vars, allowedFunctions)
            ' Trong NCalc, kết quả luận lý thường trả về số hoặc bool
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
        allowedFunctions As HashSet(Of String)) As Expression

        ' EvaluateOptions.IgnoreCase giúp không phân biệt biến hoa thường
        Dim exp As New Expression(expr, EvaluateOptions.IgnoreCase)

        ' Nạp các biến tham số
        If vars IsNot Nothing Then
            For Each v In vars
                exp.Parameters(v.Key) = v.Value
            Next
        End If

        ' Liên kết hàm tự định nghĩa
        BindFunctions(exp, allowedFunctions)
        Return exp
    End Function

    Private Shared Sub BindFunctions(exp As Expression, allowed As HashSet(Of String))
        Dim allowedList = If(allowed, DefaultFunctions)

        AddHandler exp.EvaluateFunction, Sub(name As String, args As FunctionArgs)
                                             If Not allowedList.Contains(name) Then
                                                 Throw New Exception($"Function '{name}' not allowed.")
                                             End If

                                             ' Hàm helper để lấy giá trị double từ tham số
                                             Dim getArg = Function(index As Integer) As Double
                                                              Return ToDouble(args.Parameters(index).Evaluate())
                                                          End Function

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
                                                     If args.Parameters.Length <> 3 Then
                                                         Throw New Exception("Usage: IF(condition, trueValue, falseValue)")
                                                     End If
                                                     ' Nếu tham số 1 khác 0 (True), lấy tham số 2, ngược lại lấy tham số 3
                                                     args.Result = If(getArg(0) <> 0, getArg(1), getArg(2))
                                             End Select
                                         End Sub
    End Sub

    ' ============================
    ' SANITIZE & VALIDATION
    ' ============================

    Private Shared Function Sanitize(
        formula As String,
        vars As Dictionary(Of String, Double),
        allowed As HashSet(Of String)) As String

        If String.IsNullOrWhiteSpace(formula) Then Return "0"

        formula = formula.Trim()
        ' Loại bỏ dấu "=" ở đầu nếu có (kiểu Excel)
        If formula.StartsWith("=") Then
            formula = formula.Substring(1)
        End If

        Dim allowedList = If(allowed, DefaultFunctions)

        ' Chỉ cho phép các ký tự toán học và chữ cái cơ bản
        formula = Regex.Replace(formula, "[^0-9a-zA-Z_+\-*/%().?:<>=!&|,]", "")

        ' Kiểm tra xem các từ (tokens) trong công thức có hợp lệ không
        Dim matches = Regex.Matches(formula, "[a-zA-Z_][a-zA-Z0-9_]*")
        For Each m As Match In matches
            Dim token As String = m.Value
            ' Nếu token không phải là biến truyền vào và cũng không phải hàm cho phép
            If Not vars.ContainsKey(token) AndAlso Not allowedList.Contains(token) Then
                Throw New Exception($"Invalid variable or function: {token}")
            End If
        Next

        Return formula
    End Function

    ''' <summary>
    ''' Chuyển đổi mọi kiểu dữ liệu về Double để tính toán chính xác
    ''' </summary>
    Private Shared Function ToDouble(v As Object) As Double
        If v Is Nothing Then Return 0

        ' Sử dụng Pattern Matching kiểu cũ của VB.NET (hoặc Select Case)
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