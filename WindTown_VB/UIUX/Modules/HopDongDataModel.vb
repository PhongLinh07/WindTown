Imports System.Data
Imports Dapper
Imports WindTown_VB.DatabaseConfig

Public Class HopDongDataModel

    Private ReadOnly _contractService As New ContractService()
    Private ReadOnly _employeeService As New EmployeeService()
    Private ReadOnly _departmentService As New BaseService(Of Department)()

    Private Class ContractDepartmentMap
        Public Property contract_id As Integer
        Public Property department_id As Integer
    End Class

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

    Public Function LoadContractDepartmentMap() As Dictionary(Of Integer, Integer)
        Using db As IDbConnection = Database.GetConnection()
            Dim sql As String = "
                SELECT 
                    c.id AS contract_id,
                    d.id AS department_id
                FROM contract c
                LEFT JOIN position p 
                    ON p.contract_id = c.id 
                    AND ISNULL(CAST(JSON_VALUE(p.datas, '$.status') AS INT), 0) <> -1
                LEFT JOIN job j ON p.job_id = j.id
                LEFT JOIN department d ON j.department_id = d.id
                WHERE ISNULL(CAST(JSON_VALUE(c.datas, '$.status') AS INT), 0) <> -1
            "

            Dim rows = db.Query(Of ContractDepartmentMap)(sql).ToList()
            Dim result As New Dictionary(Of Integer, Integer)()
            For Each row In rows
                If row.contract_id <= 0 OrElse row.department_id <= 0 Then Continue For
                result(row.contract_id) = row.department_id
            Next
            Return result
        End Using
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
