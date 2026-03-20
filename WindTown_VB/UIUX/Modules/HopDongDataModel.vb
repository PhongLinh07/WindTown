Public Class HopDongDataModel

    Private ReadOnly _contractService = AppServices.Instance.ContractSV
    Private ReadOnly _employeeService = AppServices.Instance.EmployeeSV
    Private ReadOnly _departmentService = AppServices.Instance.DepartmentSV

    Public Function LoadContracts() As List(Of Contract)
        Dim response = _contractService.Execute(DataIntent.GetList)
        If response.IsSuccess Then
            Dim data = TryCast(response.Data, IEnumerable(Of Contract))
            Return If(data IsNot Nothing, data.ToList(), New List(Of Contract)())
        End If
        Throw New Exception(response.Message)
    End Function

    Public Function LoadEmployees() As List(Of Employee)
        Dim response = _employeeService.Execute(DataIntent.GetList)
        If response.IsSuccess Then
            Dim data = TryCast(response.Data, IEnumerable(Of Employee))
            Return If(data IsNot Nothing, data.ToList(), New List(Of Employee)())
        End If
        Throw New Exception(response.Message)
    End Function

    Public Function LoadDepartments() As List(Of Department)
        Dim response = _departmentService.Execute(DataIntent.GetList)
        If response.IsSuccess Then
            Dim data = TryCast(response.Data, IEnumerable(Of Department))
            Return If(data IsNot Nothing, data.ToList(), New List(Of Department)())
        End If
        Throw New Exception(response.Message)
    End Function

    ' ✅ Viết lại bằng EF Core — bỏ Dapper + JSON_VALUE(datas) cũ
    ' Trả về: contract_id → department_id (qua Position → Salary_Mult → Job → Department)
    Public Function LoadContractDepartmentMap() As Dictionary(Of Integer, Integer)
        Dim result As New Dictionary(Of Integer, Integer)()
        Using ctx As New AppDbContext()
            Dim rows = ctx.Positions _
                .Where(Function(p) p.status <> -1 AndAlso p.Contract.status <> -1) _
                .Where(Function(p) p.Salary_Mult.Job.department_id > 0) _
                .Select(Function(p) New With {
                    Key .contract_id = p.contract_id,
                    Key .department_id = p.Salary_Mult.Job.department_id
                }) _
                .ToList()
            For Each row In rows
                If row.contract_id > 0 AndAlso row.department_id > 0 Then
                    result(row.contract_id) = row.department_id
                End If
            Next
        End Using
        Return result
    End Function

    Public Function CreateContract(data As Contract) As ServiceResponse(Of Object)
        Return _contractService.Execute(DataIntent.Insert, data)
    End Function

    Public Function UpdateContract(data As Contract) As ServiceResponse(Of Object)
        Return _contractService.Execute(DataIntent.Update, data)
    End Function

    Public Function DeleteContracts(items As List(Of Contract)) As ServiceResponse(Of Object)
        Return _contractService.Execute(DataIntent.SoftDeleteMany, items)
    End Function

End Class