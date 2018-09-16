<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmMaterial = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectBlockMaterialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbMaterials = New System.Windows.Forms.ToolStripComboBox()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBoxGridSize = New System.Windows.Forms.ToolStripComboBox()
        Me.RefocusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.btbTest = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.cmbLayer = New System.Windows.Forms.ComboBox()
        Me.cmbRef = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 31)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(95, 95)
        Me.TextBox1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.tsmMaterial, Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1136, 28)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.menuFileSave, Me.menuFileSaveAs, Me.menuFileOpen, Me.menuFileExport})
        Me.FileToolStripMenuItem.Image = Global.CAD_ver_1._0._1.My.Resources.Resources.Folder_Tnt_icon
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(62, 24)
        Me.FileToolStripMenuItem.Text = "file"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(135, 26)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'menuFileSave
        '
        Me.menuFileSave.Name = "menuFileSave"
        Me.menuFileSave.Size = New System.Drawing.Size(135, 26)
        Me.menuFileSave.Text = "Save"
        '
        'menuFileSaveAs
        '
        Me.menuFileSaveAs.Name = "menuFileSaveAs"
        Me.menuFileSaveAs.Size = New System.Drawing.Size(135, 26)
        Me.menuFileSaveAs.Text = "Save As"
        '
        'menuFileOpen
        '
        Me.menuFileOpen.Name = "menuFileOpen"
        Me.menuFileOpen.Size = New System.Drawing.Size(135, 26)
        Me.menuFileOpen.Text = "Open"
        '
        'menuFileExport
        '
        Me.menuFileExport.Name = "menuFileExport"
        Me.menuFileExport.Size = New System.Drawing.Size(135, 26)
        Me.menuFileExport.Text = "Export"
        Me.menuFileExport.ToolTipText = "Save a copy of your project as a lua readable file"
        '
        'tsmMaterial
        '
        Me.tsmMaterial.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectBlockMaterialToolStripMenuItem})
        Me.tsmMaterial.Name = "tsmMaterial"
        Me.tsmMaterial.Size = New System.Drawing.Size(76, 24)
        Me.tsmMaterial.Text = "Material"
        '
        'SelectBlockMaterialToolStripMenuItem
        '
        Me.SelectBlockMaterialToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmbMaterials})
        Me.SelectBlockMaterialToolStripMenuItem.Name = "SelectBlockMaterialToolStripMenuItem"
        Me.SelectBlockMaterialToolStripMenuItem.Size = New System.Drawing.Size(223, 26)
        Me.SelectBlockMaterialToolStripMenuItem.Text = "Select Block Material"
        '
        'cmbMaterials
        '
        Me.cmbMaterials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMaterials.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cmbMaterials.Items.AddRange(New Object() {"black", "red", "yellow", "green", "orange", "purple", "blue"})
        Me.cmbMaterials.Name = "cmbMaterials"
        Me.cmbMaterials.Size = New System.Drawing.Size(121, 28)
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GridSizeToolStripMenuItem, Me.RefocusToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(57, 24)
        Me.ViewToolStripMenuItem.Text = "View "
        '
        'GridSizeToolStripMenuItem
        '
        Me.GridSizeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBoxGridSize})
        Me.GridSizeToolStripMenuItem.Name = "GridSizeToolStripMenuItem"
        Me.GridSizeToolStripMenuItem.Size = New System.Drawing.Size(143, 26)
        Me.GridSizeToolStripMenuItem.Text = "Grid Size"
        '
        'ToolStripComboBoxGridSize
        '
        Me.ToolStripComboBoxGridSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBoxGridSize.Items.AddRange(New Object() {"16", "10", "5"})
        Me.ToolStripComboBoxGridSize.Name = "ToolStripComboBoxGridSize"
        Me.ToolStripComboBoxGridSize.Size = New System.Drawing.Size(121, 28)
        '
        'RefocusToolStripMenuItem
        '
        Me.RefocusToolStripMenuItem.Name = "RefocusToolStripMenuItem"
        Me.RefocusToolStripMenuItem.Size = New System.Drawing.Size(143, 26)
        Me.RefocusToolStripMenuItem.Text = "Refocus"
        '
        'toolTip
        '
        Me.toolTip.IsBalloon = True
        Me.toolTip.ToolTipTitle = "Rectangle size"
        '
        'btbTest
        '
        Me.btbTest.Location = New System.Drawing.Point(12, 183)
        Me.btbTest.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btbTest.Name = "btbTest"
        Me.btbTest.Size = New System.Drawing.Size(63, 39)
        Me.btbTest.TabIndex = 6
        Me.btbTest.Text = "TEST"
        Me.btbTest.UseVisualStyleBackColor = True
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.FullOpen = True
        Me.ColorDialog1.SolidColorOnly = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'cmbLayer
        '
        Me.cmbLayer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLayer.FormattingEnabled = True
        Me.cmbLayer.Location = New System.Drawing.Point(757, 4)
        Me.cmbLayer.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbLayer.Name = "cmbLayer"
        Me.cmbLayer.Size = New System.Drawing.Size(121, 24)
        Me.cmbLayer.TabIndex = 7
        '
        'cmbRef
        '
        Me.cmbRef.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRef.FormattingEnabled = True
        Me.cmbRef.Location = New System.Drawing.Point(1003, 4)
        Me.cmbRef.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbRef.Name = "cmbRef"
        Me.cmbRef.Size = New System.Drawing.Size(121, 24)
        Me.cmbRef.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(701, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Layer"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(888, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Reference layer"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 318)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(79, 39)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "TEST2"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 693)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbRef)
        Me.Controls.Add(Me.cmbLayer)
        Me.Controls.Add(Me.btbTest)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MinimumSize = New System.Drawing.Size(899, 698)
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "ComputerCraft CAD 1.0.1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolTip As ToolTip
    Friend WithEvents btbTest As Button
    Friend WithEvents menuFileSave As ToolStripMenuItem
    Friend WithEvents menuFileSaveAs As ToolStripMenuItem
    Friend WithEvents menuFileOpen As ToolStripMenuItem
    Friend WithEvents menuFileExport As ToolStripMenuItem
    Friend WithEvents tsmMaterial As ToolStripMenuItem
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents NewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GridSizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripComboBoxGridSize As ToolStripComboBox
    Friend WithEvents RefocusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmbLayer As ComboBox
    Friend WithEvents cmbRef As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents SelectBlockMaterialToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmbMaterials As ToolStripComboBox
    Friend WithEvents Button1 As Button
End Class
