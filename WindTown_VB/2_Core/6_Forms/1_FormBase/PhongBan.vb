
Imports System.Runtime.Remoting

Public Class PhongBan
    Inherits Form

    Public Sub New()

        InitializeComponent()
        Dim _serviceEmp As New EmployeeService()

        Dim _serviceDept As New BaseService(Of Department)


        Dim empRes = _serviceEmp.Execute(DataIntent.GetList)
        Dim deptRes = _serviceDept.Execute(DataIntent.GetList)


        Dim empList As List(Of Employee) = CType(empRes.Data, List(Of Employee))

        Dim deptList As List(Of Department) = CType(deptRes.Data, List(Of Department))

        Dim Emp002 As Employee = empList.Where(Function(e) e.name = "Name Of EMP002").FirstOrDefault()

        ui_code.Text = Emp002.address
        ui_name.Text = deptList(0).name
    End Sub
End Class