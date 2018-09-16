Public NotInheritable Class frmSplash

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub frmSplash_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Opacity = 0
        Me.WindowState = FormWindowState.Maximized
        If My.Application.Info.Title <> "" Then
            lblLoading.Text = "Building Designer"
        Else
            'If the application title is missing, use the application name, without the extension
            lblLoading.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        lblLoading.Left = 10
        lblLoading.Width = Me.Width - 200
    End Sub
    Private Sub formShow(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Call CenterToScreen()
        lblLoading.Left = 10
        lblLoading.Width = Me.Width - 400
        Me.FormBorderStyle = FormBorderStyle.None
        Me.WindowState = FormWindowState.Maximized
        Threading.Thread.Sleep(100)
        Me.Opacity = 1
    End Sub
End Class
