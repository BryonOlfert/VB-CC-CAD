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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileSave = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileSaveAs = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileOpen = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuFileExport = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ExtrudeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox2 = New System.Windows.Forms.ToolStripComboBox()
        Me.tsmMaterial = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectBlockMaterialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbMaterials = New System.Windows.Forms.ToolStripComboBox()
        Me.AddMaterialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemEditBlock = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBox1 = New System.Windows.Forms.ToolStripComboBox()
        Me.SaveMaterialsAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoadMaterialsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridSizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripComboBoxGridSize = New System.Windows.Forms.ToolStripComboBox()
        Me.RefocusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.cmbLayer = New System.Windows.Forms.ComboBox()
        Me.cmbRef = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ImportDatabaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.tsmMaterial, Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(4, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(852, 28)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.menuFileSave, Me.menuFileSaveAs, Me.menuFileOpen, Me.menuFileExport})
        Me.FileToolStripMenuItem.Image = Global.CAD_ver_1._0._1.My.Resources.Resources.Folder_Tnt_icon
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(55, 24)
        Me.FileToolStripMenuItem.Text = "file"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem1})
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'FileToolStripMenuItem1
        '
        Me.FileToolStripMenuItem1.Name = "FileToolStripMenuItem1"
        Me.FileToolStripMenuItem1.Size = New System.Drawing.Size(92, 22)
        Me.FileToolStripMenuItem1.Text = "File"
        '
        'menuFileSave
        '
        Me.menuFileSave.Name = "menuFileSave"
        Me.menuFileSave.Size = New System.Drawing.Size(135, 22)
        Me.menuFileSave.Text = "Save File"
        '
        'menuFileSaveAs
        '
        Me.menuFileSaveAs.Name = "menuFileSaveAs"
        Me.menuFileSaveAs.Size = New System.Drawing.Size(135, 22)
        Me.menuFileSaveAs.Text = "Save File As"
        '
        'menuFileOpen
        '
        Me.menuFileOpen.Name = "menuFileOpen"
        Me.menuFileOpen.Size = New System.Drawing.Size(135, 22)
        Me.menuFileOpen.Text = "Open File"
        '
        'menuFileExport
        '
        Me.menuFileExport.Name = "menuFileExport"
        Me.menuFileExport.Size = New System.Drawing.Size(135, 22)
        Me.menuFileExport.Text = "Export"
        Me.menuFileExport.ToolTipText = "Save a copy of your project as a lua readable file"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolComboBox, Me.ExtrudeToolStripMenuItem, Me.DeleteSizeToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(47, 24)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'ToolComboBox
        '
        Me.ToolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolComboBox.Items.AddRange(New Object() {"point", "rectangle", "line"})
        Me.ToolComboBox.Name = "ToolComboBox"
        Me.ToolComboBox.Size = New System.Drawing.Size(121, 23)
        '
        'ExtrudeToolStripMenuItem
        '
        Me.ExtrudeToolStripMenuItem.Name = "ExtrudeToolStripMenuItem"
        Me.ExtrudeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ExtrudeToolStripMenuItem.Text = "Extrude"
        '
        'DeleteSizeToolStripMenuItem
        '
        Me.DeleteSizeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox2})
        Me.DeleteSizeToolStripMenuItem.Name = "DeleteSizeToolStripMenuItem"
        Me.DeleteSizeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.DeleteSizeToolStripMenuItem.Text = "Delete Size"
        '
        'ToolStripComboBox2
        '
        Me.ToolStripComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox2.Items.AddRange(New Object() {"1", "2", "3"})
        Me.ToolStripComboBox2.Name = "ToolStripComboBox2"
        Me.ToolStripComboBox2.Size = New System.Drawing.Size(121, 23)
        '
        'tsmMaterial
        '
        Me.tsmMaterial.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectBlockMaterialToolStripMenuItem, Me.AddMaterialToolStripMenuItem, Me.ToolStripMenuItemEditBlock, Me.SaveMaterialsAsToolStripMenuItem, Me.LoadMaterialsToolStripMenuItem, Me.ImportDatabaseToolStripMenuItem})
        Me.tsmMaterial.Name = "tsmMaterial"
        Me.tsmMaterial.Size = New System.Drawing.Size(62, 24)
        Me.tsmMaterial.Text = "Material"
        '
        'SelectBlockMaterialToolStripMenuItem
        '
        Me.SelectBlockMaterialToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmbMaterials})
        Me.SelectBlockMaterialToolStripMenuItem.Name = "SelectBlockMaterialToolStripMenuItem"
        Me.SelectBlockMaterialToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SelectBlockMaterialToolStripMenuItem.Text = "Select Block Material"
        '
        'cmbMaterials
        '
        Me.cmbMaterials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMaterials.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.cmbMaterials.Name = "cmbMaterials"
        Me.cmbMaterials.Size = New System.Drawing.Size(121, 23)
        '
        'AddMaterialToolStripMenuItem
        '
        Me.AddMaterialToolStripMenuItem.Name = "AddMaterialToolStripMenuItem"
        Me.AddMaterialToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.AddMaterialToolStripMenuItem.Text = "Add Material"
        '
        'ToolStripMenuItemEditBlock
        '
        Me.ToolStripMenuItemEditBlock.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBox1})
        Me.ToolStripMenuItemEditBlock.Name = "ToolStripMenuItemEditBlock"
        Me.ToolStripMenuItemEditBlock.Size = New System.Drawing.Size(183, 22)
        Me.ToolStripMenuItemEditBlock.Text = "Edit Block Material"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New System.Drawing.Size(121, 23)
        '
        'SaveMaterialsAsToolStripMenuItem
        '
        Me.SaveMaterialsAsToolStripMenuItem.Name = "SaveMaterialsAsToolStripMenuItem"
        Me.SaveMaterialsAsToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.SaveMaterialsAsToolStripMenuItem.Text = "Save Materials"
        '
        'LoadMaterialsToolStripMenuItem
        '
        Me.LoadMaterialsToolStripMenuItem.Name = "LoadMaterialsToolStripMenuItem"
        Me.LoadMaterialsToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.LoadMaterialsToolStripMenuItem.Text = "Load Materials"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GridSizeToolStripMenuItem, Me.RefocusToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(47, 24)
        Me.ViewToolStripMenuItem.Text = "View "
        '
        'GridSizeToolStripMenuItem
        '
        Me.GridSizeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripComboBoxGridSize})
        Me.GridSizeToolStripMenuItem.Name = "GridSizeToolStripMenuItem"
        Me.GridSizeToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.GridSizeToolStripMenuItem.Text = "Grid Size"
        '
        'ToolStripComboBoxGridSize
        '
        Me.ToolStripComboBoxGridSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBoxGridSize.Items.AddRange(New Object() {"16", "10", "5"})
        Me.ToolStripComboBoxGridSize.Name = "ToolStripComboBoxGridSize"
        Me.ToolStripComboBoxGridSize.Size = New System.Drawing.Size(121, 23)
        '
        'RefocusToolStripMenuItem
        '
        Me.RefocusToolStripMenuItem.Name = "RefocusToolStripMenuItem"
        Me.RefocusToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.RefocusToolStripMenuItem.Text = "Refocus"
        '
        'toolTip
        '
        Me.toolTip.IsBalloon = True
        Me.toolTip.ToolTipTitle = "Rectangle size"
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
        Me.cmbLayer.Location = New System.Drawing.Point(568, 3)
        Me.cmbLayer.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbLayer.Name = "cmbLayer"
        Me.cmbLayer.Size = New System.Drawing.Size(92, 21)
        Me.cmbLayer.TabIndex = 7
        '
        'cmbRef
        '
        Me.cmbRef.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRef.FormattingEnabled = True
        Me.cmbRef.Location = New System.Drawing.Point(752, 3)
        Me.cmbRef.Margin = New System.Windows.Forms.Padding(2)
        Me.cmbRef.Name = "cmbRef"
        Me.cmbRef.Size = New System.Drawing.Size(92, 21)
        Me.cmbRef.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(526, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Layer"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(666, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Reference layer"
        '
        'ImportDatabaseToolStripMenuItem
        '
        Me.ImportDatabaseToolStripMenuItem.Name = "ImportDatabaseToolStripMenuItem"
        Me.ImportDatabaseToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ImportDatabaseToolStripMenuItem.Text = "Import Database"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(852, 563)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbRef)
        Me.Controls.Add(Me.cmbLayer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.MinimumSize = New System.Drawing.Size(678, 574)
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "ComputerCraft CAD 1.0.1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolTip As ToolTip
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
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolComboBox As ToolStripComboBox
    Friend WithEvents SaveMaterialsAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadMaterialsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExtrudeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddMaterialToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemEditBlock As ToolStripMenuItem
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents FileToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents DeleteSizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripComboBox2 As ToolStripComboBox
    Friend WithEvents ImportDatabaseToolStripMenuItem As ToolStripMenuItem
End Class
