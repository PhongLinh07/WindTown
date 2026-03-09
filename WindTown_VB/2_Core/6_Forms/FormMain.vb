Imports Microsoft.Data.Common

Partial Public Class FormMain
    Inherits Form

    Private currentTab As TabPage
    Private currentTabControl As TabControl

    Public Sub New()
        InitializeComponent()
        ResetTabControl(tabControl_A)
        ResetTabControl(tabControl_B)
        UpdateLayout()
    End Sub

#Region "Helper Methods"

    Private Sub ResetTabControl(tc As TabControl)
        tc.TabPages.Clear()
        tc.Visible = False
    End Sub

    Private Sub UpdateLayout()
        Dim hasA As Boolean = tabControl_A.TabPages.Count > 0
        Dim hasB As Boolean = tabControl_B.TabPages.Count > 0

        tabControl_A.Visible = hasA
        tabControl_B.Visible = hasB

        If hasA AndAlso hasB Then
            split_main.Panel1Collapsed = False
            split_main.Panel2Collapsed = False
        ElseIf hasA Then
            split_main.Panel1Collapsed = False
            split_main.Panel2Collapsed = True
        ElseIf hasB Then
            split_main.Panel1Collapsed = True
            split_main.Panel2Collapsed = False
        Else
            split_main.Panel1Collapsed = True
            split_main.Panel2Collapsed = True
        End If
    End Sub

    Private Sub TabControl_MouseDown(sender As Object, e As MouseEventArgs) _
    Handles tabControl_A.MouseDown, tabControl_B.MouseDown

        If e.Button <> MouseButtons.Right Then Return

        Dim tabControl As TabControl = DirectCast(sender, TabControl)

        For i As Integer = 0 To tabControl.TabPages.Count - 1
            Dim rect As Rectangle = tabControl.GetTabRect(i)

            If rect.Contains(e.Location) Then
                tabControl.SelectedIndex = i
                currentTab = tabControl.TabPages(i)
                currentTabControl = tabControl

                SetupContextMenu(tabControl)
                contextMenu_tab.Show(tabControl, e.Location)
                Exit For
            End If
        Next
    End Sub

    ''' <summary>
    ''' Chỉ hiện menu di chuyển và Close All khi có >= 2 tabs.
    ''' Chỉ hiện đúng chiều chuyển (A→B hoặc B→A).
    ''' </summary>
    Private Sub SetupContextMenu(srcControl As TabControl)
        Dim isSrcA As Boolean = (srcControl Is tabControl_A)
        Dim totalTabs As Integer = srcControl.TabPages.Count
        Dim hasMultiple As Boolean = (totalTabs >= 2)

        ' Chuyển 1 tab: chỉ hiện đúng chiều VÀ có >= 2 tabs
        menu_move_to_splitB.Visible = isSrcA AndAlso hasMultiple
        menu_move_to_splitA.Visible = Not isSrcA AndAlso hasMultiple

        ' Chuyển tất cả: tương tự
        menu_move_all_to_splitB.Visible = isSrcA AndAlso hasMultiple
        menu_move_all_to_splitA.Visible = Not isSrcA AndAlso hasMultiple

        ' Close All: chỉ hiện khi có >= 2 tabs
        menu_close_all_tab.Visible = hasMultiple
    End Sub

    Private Sub OpenMultTabMode(Of T As {UserControl, New})(targetControl As TabControl)
        For Each tab As TabPage In tabControl_A.TabPages.Cast(Of TabPage)().Concat(tabControl_B.TabPages.Cast(Of TabPage)())
            If tab.Tag?.ToString() = GetType(T).Name Then
                Dim parent = DirectCast(tab.Parent, TabControl)
                parent.SelectedTab = tab
                Return
            End If
        Next

        Dim uc As New T() With {.Dock = DockStyle.Fill}
        Dim page As New TabPage() With {
            .Text = uc.Text,
            .Tag = GetType(T).Name
        }
        page.Controls.Add(uc)

        targetControl.TabPages.Add(page)
        targetControl.SelectedTab = page
        UpdateLayout()
    End Sub

    Private Sub MoveCurrentTab(targetControl As TabControl)
        If currentTab Is Nothing OrElse currentTabControl Is targetControl Then Return

        Dim tabToMove = currentTab
        currentTabControl.TabPages.Remove(tabToMove)
        targetControl.TabPages.Add(tabToMove)
        targetControl.SelectedTab = tabToMove

        UpdateLayout()
    End Sub

    Private Sub MoveAllTabs(targetControl As TabControl)
        If currentTabControl Is Nothing OrElse currentTabControl Is targetControl Then Return

        Dim tabs = currentTabControl.TabPages.Cast(Of TabPage)().ToArray()
        If tabs.Length = 0 Then Return

        targetControl.SuspendLayout()
        currentTabControl.SuspendLayout()

        For Each page In tabs
            currentTabControl.TabPages.Remove(page)
            targetControl.TabPages.Add(page)
        Next

        targetControl.ResumeLayout()
        currentTabControl.ResumeLayout()

        UpdateLayout()
    End Sub

    Private Sub menu_move_to_splitA_Click(sender As Object, e As EventArgs) Handles menu_move_to_splitA.Click
        MoveCurrentTab(tabControl_A)
    End Sub

    Private Sub menu_move_to_splitB_Click(sender As Object, e As EventArgs) Handles menu_move_to_splitB.Click
        MoveCurrentTab(tabControl_B)
    End Sub

    Private Sub menu_move_all_to_splitA_Click(sender As Object, e As EventArgs) Handles menu_move_all_to_splitA.Click
        MoveAllTabs(tabControl_A)
    End Sub

    Private Sub menu_move_all_to_splitB_Click(sender As Object, e As EventArgs) Handles menu_move_all_to_splitB.Click
        MoveAllTabs(tabControl_B)
    End Sub

    Private Sub menu_close_Click(sender As Object, e As EventArgs) Handles menu_close.Click
        If currentTab IsNot Nothing Then
            currentTabControl.TabPages.Remove(currentTab)
            UpdateLayout()
        End If
    End Sub

    Private Sub menu_close_all_tab_Click(sender As Object, e As EventArgs) Handles menu_close_all_tab.Click
        currentTabControl.TabPages.Clear()
        UpdateLayout()
    End Sub

#End Region

#Region "Menu Open Tab"

    Private Sub menu_department_Click(sender As Object, e As EventArgs) Handles menu_department.Click
        OpenMultTabMode(Of Department_List_UC)(tabControl_A)
    End Sub

    Private Sub menu_job_Click(sender As Object, e As EventArgs) Handles menu_job.Click
        OpenMultTabMode(Of Job_List_UC)(tabControl_A)
    End Sub

    Private Sub menu_level_Click(sender As Object, e As EventArgs) Handles menu_level.Click
        OpenMultTabMode(Of Level_List_UC)(tabControl_A)
    End Sub

    Private Sub menu_empolyee_Click(sender As Object, e As EventArgs) Handles menu_empolyee.Click
        OpenMultTabMode(Of Employee_List_UC)(tabControl_A)
    End Sub

    Private Sub menu_contract_Click(sender As Object, e As EventArgs) Handles menu_contract.Click
        OpenMultTabMode(Of Contract_List_UC)(tabControl_A)
    End Sub

    Private Sub menu_position_Click(sender As Object, e As EventArgs) Handles menu_position.Click
        OpenMultTabMode(Of Position_List_UC)(tabControl_A)
    End Sub

    Private Sub menu_project_Click(sender As Object, e As EventArgs) Handles menu_project.Click
        OpenMultTabMode(Of Project_List_UC)(tabControl_A)
    End Sub
    Private Sub menu_assignment_Click(sender As Object, e As EventArgs) Handles menu_assignment.Click
        OpenMultTabMode(Of Assignment_List_UC)(tabControl_A)
    End Sub

    Private Sub menu_attendance_Click(sender As Object, e As EventArgs) Handles menu_attendance.Click
        OpenMultTabMode(Of Attendance_List_UC)(tabControl_A)
    End Sub

    Private Sub menu_account_Click(sender As Object, e As EventArgs) Handles menu_account.Click
        OpenMultTabMode(Of Pay_Period_List_UC)(tabControl_A)
    End Sub

    Private Sub menu_holiday_Click(sender As Object, e As EventArgs) Handles menu_holiday.Click
        OpenMultTabMode(Of Holiday_List_UC)(tabControl_A)
    End Sub

    Private Sub menu_leave_cat_Click(sender As Object, e As EventArgs) Handles menu_leave_cat.Click
        OpenMultTabMode(Of Leave_Cat_List_UC)(tabControl_A)
    End Sub

    Private Sub menu_leave_Click(sender As Object, e As EventArgs) Handles menu_leave.Click
        OpenMultTabMode(Of Leave_List_UC)(tabControl_A)
    End Sub

    Private Sub menu_pay_period_Click(sender As Object, e As EventArgs) Handles menu_pay_period.Click
        OpenMultTabMode(Of Pay_Period_List_UC)(tabControl_A)
    End Sub

#End Region

End Class