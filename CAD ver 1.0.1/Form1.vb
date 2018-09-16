Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Reflection
Public Class Form1
    ' test pushing
    Dim localOffSetX As Int32 = 0
    Dim LocalOffSetY As Int32 = 0
    Dim blocksX As Int16
    Dim blocksY As Int16
    Public box As Int16 = 10
    Public tool As String = "point"
    Public recTest As Boolean = False 'variable to deside to get second point when making a rectangle
    Public lineTest As Boolean = False 'variable to deside to get second point when making a line
    Dim colorTest As Color = Color.Black
    Dim pen As Brush = New SolidBrush(Color.Black)
    Dim reccX As Int32 = 0
    Dim reccY As Int32 = 0
    Dim layer As Int32 = 1
    Dim layerRef As Int32 = 1
    Public blockDictionary As Dictionary(Of Vector, Color) = New Dictionary(Of Vector, Color)
    Dim saveFile As String = Nothing
    Dim scrollBool As Boolean = False
    Dim scrollX As Int32 = 0
    Dim scrollY As Int32 = 0
    Dim offSetX As Int32 = 0
    Dim offSetY As Int32 = 0
    Dim grid As Int16
    Dim offsetBool As Boolean
    Dim matterialDictionary As Dictionary(Of String, Color) = New Dictionary(Of String, Color)
    Dim blockStack As Stack(Of Dictionary(Of Vector, Color)) = New Stack(Of Dictionary(Of Vector, Color))
    Dim tempDictionary As Dictionary(Of Vector, Color) = New Dictionary(Of Vector, Color)

    Sub getMatterialList()
        'Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        'matterialDictionary = bf.Deserialize(My.Resources.BlockList)
    End Sub

    <Serializable>
    Public Structure Vector
        Dim X As Int32
        Dim Y As Int32
        Dim Z As Int32
    End Structure

    Private Sub ClearDictionary()
        blockDictionary.Clear()
        blockDictionary = New Dictionary(Of Vector, Color)
        clearForm()
        loadBlocks()
        loadGrid()
    End Sub

    Private Sub loadBlocks()
        Dim myRectangle As Rectangle
        Dim dictPair As KeyValuePair(Of Vector, Color)
        For Each dictPair In blockDictionary
            If dictPair.Key.Z = layerRef Then
                If dictPair.Key.X + offSetX < 110 Or dictPair.Key.Y + offSetY < 39 Then
                    'nothing
                Else
                    pen = New SolidBrush(Color.FromArgb(255, 69, 89, 226))
                    myRectangle = New Rectangle(dictPair.Key.X + offSetX, dictPair.Key.Y + offSetY, box, box)
                    CreateGraphics().FillRectangle(pen, rect:=myRectangle)
                End If
            Else
            End If
        Next

        For Each dictPair In blockDictionary
            If dictPair.Key.Z = layer Then
                If dictPair.Key.X + offSetX < 110 Or dictPair.Key.Y + offSetY < 39 Then
                    'nothing
                Else
                    pen = New SolidBrush(blockDictionary(dictPair.Key))
                    myRectangle = New Rectangle(dictPair.Key.X + offSetX, dictPair.Key.Y + offSetY, box, box)
                    CreateGraphics().FillRectangle(pen, rect:=myRectangle)
                End If
            Else
            End If
        Next
        Dim penz As Brush = New SolidBrush(BackColor())
        myRectangle = New Rectangle(0, 0, MyBase.Width, 30)
        MyBase.CreateGraphics.FillRectangle(brush:=penz, rect:=myRectangle)
    End Sub


    Sub AddToBlockDictionary(posX As Int32, posY As Int32, blockColor As Color)
        Dim blockPoint As Vector = New Vector()
        blockPoint.X = posX - offSetX
        blockPoint.Y = posY - offSetY
        blockPoint.Z = layer
        blockDictionary.Remove(blockPoint)
        blockDictionary.Add(blockPoint, blockColor)
    End Sub

    Sub RemoveBlockFromDictionary(posX, posY)
        Dim blockPoint As Vector = New Vector()
        blockPoint.X = posX - offSetX
        blockPoint.Y = posY - offSetY
        blockPoint.Z = layer
        blockDictionary.Remove(blockPoint)
    End Sub

    Public Sub formSizeChange() Handles MyBase.SizeChanged
        clearForm()
        loadBlocks()
        loadGrid()
        If MyBase.Width < 600 Then
            Label1.Hide()
            Label2.Hide()
            cmbLayer.Hide()
            cmbRef.Hide()
        Else
            Label1.Show()
            Label2.Show()
            cmbLayer.Show()
            cmbRef.Show()
        End If
    End Sub

    Public Sub clearForm()
        Dim penz As Brush = New SolidBrush(BackColor())
        Dim myRectangle As Rectangle
        myRectangle = New Rectangle(0, 0, MyBase.Width, MyBase.Height)
        MyBase.CreateGraphics.FillRectangle(brush:=penz, rect:=myRectangle)
    End Sub

    Public Sub loadGrid()
        'drawing grid

        'the tool that draws the lines
        Dim penGrid As Pen = New Pen(Color.Black)

        'Drawing Vertical lines
        blocksX = Math.Floor((MyBase.Width - 100) / box)  'stores variable for how many 10x10 blocks can fit Horizontaly
        For gridCount As Integer = 1 To blocksX
            If (gridCount - (offSetX / box) Mod grid) Mod grid = 1 Then
                penGrid.Color = Color.Black
            Else
                penGrid.Color = Color.GhostWhite
            End If
            MyBase.CreateGraphics.DrawLine(penGrid, x1:=100 + (gridCount * box), y1:=40, x2:=(100 + (gridCount * box)), y2:=(MyBase.Height - 106))
        Next
        'Drawing Horizontal lines
        blocksY = Math.Floor((MyBase.Height - 130) / box) 'stores variable for how many 10x10 blocks can fit Verticaly
        'chunksY = Math.Floor((blocksY) / 16) * 16 'stores variable for how many 16x16 blocks can fit Verticaly
        For gridCount As Integer = 1 To blocksY
            If (gridCount - (offSetY / box) Mod grid) Mod grid = 1 Then
                penGrid.Color = Color.Black
            Else
                penGrid.Color = Color.GhostWhite
            End If
            MyBase.CreateGraphics.DrawLine(penGrid, x1:=110, y1:=30 + (gridCount * box), x2:=MyBase.Width, y2:=30 + (gridCount * box))
        Next
    End Sub


    'experimental subRoutine   lol no block comments )
    Private Sub boxSize(ByVal sender As Object, ByVal pos As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseWheel
        If pos.Delta < 0 Then
            If box = 10 Then
                '''''''nothing
            Else
                offSetX = offSetX / box
                box -= 10
                offSetX = offSetX * box
            End If
        Else
            If box = 10240 Then
                ''''''''''nothing    
            Else
                offSetX = offSetX / box
                box += 10
                offSetX = offSetX * box
            End If
        End If
        clearForm()
        loadBlocks()
        loadGrid()
    End Sub

    Private Sub boxClick(ByVal sender As Object, ByVal pos As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseClick, MyBase.MouseMove
        'slecting color from menuBox
        colorTest = Color.FromName(cmbMaterials.Text)
        pen = New SolidBrush(colorTest)
        If pos.Button = MouseButtons.Left Then
            If pos.X < (TextBox1.Width + TextBox1.Left) And pos.X > (TextBox1.Left) And pos.Y < (TextBox1.Height + TextBox1.Top) And pos.Y > (TextBox1.Top) Then
                'nothing here
            Else
                If tool = "rect" Then
                    Threading.Thread.Sleep(50)
                    If recTest = False Then
                        'happens in mouseUp subroutine
                    Else
                        Dim dictPair As KeyValuePair(Of Vector, Color)
                        For Each dictPair In tempDictionary
                            AddToBlockDictionary(dictPair.Key.X, dictPair.Key.Y, colorTest)
                        Next
                        localOffSetX = 0
                        LocalOffSetY = 0
                    End If
                ElseIf tool = "point" Then
                    TextBox1.Text = (Math.Floor(pos.X / box) * box - offSetX) & " " & (Math.Floor(pos.Y / box) * box - offSetY)
                    Dim myRectangle As Rectangle
                    myRectangle = New Rectangle((Math.Floor(pos.X / box) * box), (Math.Floor(pos.Y / box) * box), box, box)
                    CreateGraphics().FillRectangle(pen, rect:=myRectangle)
                    AddToBlockDictionary((Math.Floor(pos.X / box) * box), (Math.Floor(pos.Y / box) * box), colorTest)
                ElseIf tool = "line" Then

                Else
                    Dim myRectangle As Rectangle
                    If pos.X > reccX Then
                        For index As Int16 = reccX To pos.X
                            myRectangle = New Rectangle((Math.Floor(index / box) * box), (Math.Floor(pos.Y / box) * box), box, box)
                            CreateGraphics().FillRectangle(pen, rect:=myRectangle)
                        Next
                        lineTest = False
                    End If
                End If
            End If

        ElseIf pos.Button = MouseButtons.Right Then
            Dim penz As Brush = New SolidBrush(BackColor)
            Dim myRectangle As Rectangle
            myRectangle = New Rectangle((Math.Floor(pos.X / box) * box), (Math.Floor(pos.Y / box) * box), box, box)
            CreateGraphics().FillRectangle(penz, rect:=myRectangle)
            RemoveBlockFromDictionary(Math.Floor(pos.X / box) * box, Math.Floor(pos.Y / box) * box)
        ElseIf pos.Button = MouseButtons.Middle Then
            If scrollBool = False Then
                scrollX = pos.X
                scrollY = pos.Y
                scrollBool = True
            Else
                offsetBool = False
                If Math.Floor(scrollX / box) * box <> Math.Floor(pos.X / box) * box Or Math.Floor(scrollY / box) * box <> Math.Floor(pos.Y / box) * box Then
                    scrollBool = False
                    offSetX = offSetX + (Math.Floor(pos.X / box) * box - Math.Floor(scrollX / box) * box)
                    offSetY = offSetY + (Math.Floor(pos.Y / box) * box - Math.Floor(scrollY / box) * box)
                    If recTest = True Then
                        localOffSetX = localOffSetX + (Math.Floor(pos.X / box) * box - Math.Floor(scrollX / box) * box)
                        LocalOffSetY = LocalOffSetY + (Math.Floor(pos.Y / box) * box - Math.Floor(scrollY / box) * box)
                    End If
                End If
            End If
        Else ''NO button only scroll
            If recTest = True And tool = "rect" Then
                If scrollBool = False Then
                    scrollX = pos.X
                    scrollY = pos.Y
                    scrollBool = True
                Else
                    Dim myRectangle As Rectangle
                    Dim dictPair As KeyValuePair(Of Vector, Color)
                    If Math.Floor(scrollX / box) * box <> Math.Floor(pos.X / box) * box Or Math.Floor(scrollY / box) * box <> Math.Floor(pos.Y / box) * box Then
                        For Each dictPair In tempDictionary
                            If dictPair.Key.Z = layer Then
                                If dictPair.Key.X + offSetX < 110 Or dictPair.Key.Y + offSetY < 39 Then
                                    'nothing
                                Else
                                    pen = New SolidBrush(MyBase.BackColor)
                                    myRectangle = New Rectangle(dictPair.Key.X + localOffSetX, dictPair.Key.Y + LocalOffSetY, box, box)
                                    CreateGraphics().FillRectangle(pen, rect:=myRectangle)
                                End If
                            Else
                            End If
                        Next
                        tempDictionary.Clear()
                        tempDictionary = New Dictionary(Of Vector, Color)
                        scrollBool = False
                        Dim blockPoint As Vector = New Vector()
                        blockPoint.X = reccX
                        blockPoint.Y = reccY
                        tempDictionary.Remove(blockPoint)
                        tempDictionary.Add(blockPoint, colorTest)
                        Dim posTest As Int16
                        If reccX - Math.Floor(pos.X / box) * box > 0 Then
                            posTest = -1
                        Else
                            posTest = 1
                        End If
                        For i As Int32 = 1 To Math.Abs(reccX - Math.Floor(pos.X / box) * box) / 10
                            blockPoint.X = reccX + (i * posTest) * 10
                            blockPoint.Y = reccY
                            blockPoint.Z = layer
                            tempDictionary.Remove(blockPoint)
                            tempDictionary.Add(blockPoint, colorTest)
                            blockPoint.X = reccX + (i * posTest) * 10
                            blockPoint.Y = Math.Floor(pos.Y / box) * box
                            blockPoint.Z = layer
                            tempDictionary.Remove(blockPoint)
                            tempDictionary.Add(blockPoint, colorTest)
                        Next
                        If (reccY - Math.Floor(pos.Y / box) * box) > 0 Then
                            posTest = -1
                        Else
                            posTest = 1
                        End If
                        For i As Int32 = 1 To Math.Abs(reccY - Math.Floor(pos.Y / box) * box) / 10
                            blockPoint.X = reccX
                            blockPoint.Y = reccY + (i * posTest) * 10
                            blockPoint.Z = layer
                            tempDictionary.Remove(blockPoint)
                            tempDictionary.Add(blockPoint, colorTest)
                            blockPoint.X = Math.Floor(pos.X / box) * box + localOffSetX
                            blockPoint.Y = reccY + (i * posTest) * 10 + LocalOffSetY
                            blockPoint.Z = layer
                            tempDictionary.Remove(blockPoint)
                            tempDictionary.Add(blockPoint, colorTest)
                        Next
                        For Each dictPair In tempDictionary
                            If dictPair.Key.Z = layer Then
                                If dictPair.Key.X + offSetX + localOffSetX < 110 Or dictPair.Key.Y + offSetY + LocalOffSetY < 39 Then
                                    'nothing
                                Else
                                    pen = New SolidBrush(colorTest)
                                    myRectangle = New Rectangle(dictPair.Key.X, dictPair.Key.Y, box, box)
                                    CreateGraphics().FillRectangle(pen, rect:=myRectangle)
                                End If
                            Else
                            End If
                        Next
                    End If
                End If
                localOffSetX = 0
                LocalOffSetY = 0
            End If
        End If
    End Sub

    Private Sub screenScroll(ByVal sender As Object, ByVal move As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        If move.Button = MouseButtons.Middle Then
            TextBox1.Text = offSetX & " " & offSetY
            scrollBool = False
            scrollX = 0
            scrollY = 0
            clearForm()
            loadGrid()
            loadBlocks()
        ElseIf move.Button = MouseButtons.Right Then
            clearForm()
            loadGrid()
            loadBlocks()
        ElseIf move.Button = MouseButtons.Left Then
            If recTest = True And tool = "rect" Then
                recTest = False
            ElseIf tool = "rect" Then
                Dim myRectangle As Rectangle
                myRectangle = New Rectangle((Math.Floor(move.X / box) * box), (Math.Floor(move.Y / box) * box), box, box)
                CreateGraphics().FillRectangle(pen, rect:=myRectangle)
                recTest = True
                reccX = (Math.Floor(move.X / box) * box)
                reccY = (Math.Floor(move.Y / box) * box)
                tempDictionary.Clear()
            End If
            clearForm()
            loadGrid()
            loadBlocks()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i As Int16 = -150 To 150
            cmbLayer.Items.Add(i)
            cmbRef.Items.Add(i)
        Next
        cmbLayer.SelectedIndex = 150
        cmbRef.SelectedIndex = 150
        Me.WindowState = FormWindowState.Maximized
        Threading.Thread.Sleep(2500)
        grid = 16
        cmbMaterials.SelectedIndex = 0
        ToolStripComboBoxGridSize.SelectedItem = "16"
        loadGrid()

    End Sub
    Private Sub Form_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        loadGrid()
    End Sub

    Private Sub btbTest_Click(sender As Object, e As EventArgs) Handles btbTest.Click
        Dim rando As ColorDialog

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tool = "rect"
    End Sub

    Private Sub parAddNewBlock()
        ColorDialog1.ShowDialog()
        matterialDictionary.Add(cmbMaterials.SelectedItem, ColorDialog1.Color)
        cmbMaterials.Items.Remove(cmbMaterials.SelectedItem)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        With SaveFileDialog1
            Dim fileName As IO.FileStream = Nothing
            .Filter = "CAD Files| *.cad"
            .InitialDirectory = "Desktop"
            .Title = "Save File As"
            .AddExtension = True
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    fileName = New IO.FileStream(.FileName, IO.FileMode.OpenOrCreate)
                    bf.Serialize(fileName, matterialDictionary)
                Finally
                    If fileName IsNot Nothing Then
                        saveFile = .FileName
                        fileName.Close()
                    End If
                End Try
            End If
            Me.Cursor = Cursors.Default
        End With
    End Sub

    'Save functions
    Private Sub menuFileOpen_Click(sender As Object, e As EventArgs) Handles menuFileOpen.Click
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Dim fileName As IO.FileStream
        With OpenFileDialog1
            .Filter = "CAD File | *.cad"
            .InitialDirectory = "Desktop"
            .Title = "Select a File to Open"
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                blockDictionary.Clear()
                fileName = New IO.FileStream(.FileName, IO.FileMode.Open)
                blockDictionary = bf.Deserialize(fileName)
                saveFile = .FileName
                fileName.Close()
            End If
        End With
        MyBase.Text = saveFile.Split("\").Last.Split(".").First
        ReFocus()
    End Sub

    Private Sub menuFileSaveAs_Click(sender As Object, e As EventArgs) Handles menuFileSaveAs.Click
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        With SaveFileDialog1
            Dim fileName As IO.FileStream = Nothing
            .Filter = "CAD Files| *.cad"
            .InitialDirectory = "Desktop"
            .Title = "Save File As"
            .AddExtension = True
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    fileName = New IO.FileStream(.FileName, IO.FileMode.OpenOrCreate)
                    bf.Serialize(fileName, blockDictionary)
                Finally
                    If fileName IsNot Nothing Then
                        saveFile = .FileName
                        fileName.Close()
                    End If
                End Try
            End If
            Me.Cursor = Cursors.Default
        End With
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        ClearDictionary()
        ReFocus()
        MyBase.Text = "CAD"
    End Sub

    Private Sub menuFileSave_Click(sender As Object, e As EventArgs) Handles menuFileSave.Click
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        If saveFile = Nothing Then
            menuFileSaveAs_Click(Nothing, Nothing)
        Else
            Dim fileName As IO.FileStream = New IO.FileStream(saveFile, IO.FileMode.Open)
            Try
                bf.Serialize(fileName, blockDictionary)
            Finally
                If fileName IsNot Nothing Then
                    fileName.Close()
                End If
            End Try
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ToolStripComboBoxGridSize_Click(sender As Object, e As EventArgs) Handles ToolStripComboBoxGridSize.DropDownClosed
        Threading.Thread.Sleep(100)
        ViewToolStripMenuItem.HideDropDown()
        grid = ToolStripComboBoxGridSize.SelectedItem
        loadGrid()
    End Sub

    Private Sub RefocusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefocusToolStripMenuItem.Click
        ReFocus()
    End Sub

    Private Sub ReFocus()
        Dim pair As KeyValuePair(Of Vector, Color) = New KeyValuePair(Of Vector, Color)
        Dim dictLength As Int32 = 0
        For Each pair In blockDictionary
            dictLength += 1
        Next
        If dictLength <= 1 Then
            offSetX = 0
            offSetY = 0
            clearForm()
            loadBlocks()
            loadGrid()
        ElseIf dictLength > 1 Then
            Dim smallX As Int32 = Nothing
            Dim bigX As Int32 = Nothing
            Dim smallY As Int32 = Nothing
            Dim bigY As Int32 = Nothing
            For Each pair In blockDictionary
                If smallX = Nothing And smallY = Nothing Then
                    smallX = pair.Key.X
                    smallY = pair.Key.Y
                Else
                    If smallX > pair.Key.X Then
                        smallX = pair.Key.X
                    End If
                    If smallY > pair.Key.Y Then
                        smallY = pair.Key.Y
                    End If
                End If

                If bigX = Nothing And bigY = Nothing Then
                    bigX = pair.Key.X
                    bigY = pair.Key.Y
                Else
                    If bigX < pair.Key.X Then
                        bigX = pair.Key.X
                    End If
                    If bigY < pair.Key.Y Then
                        bigY = pair.Key.Y
                    End If
                End If
            Next
            offSetX = (Math.Floor((MyBase.Width - bigX / box) / 2 / box) - smallX / box) * box
            offSetY = (Math.Floor((MyBase.Height - bigY / box) / 2 / box) - smallY / box) * box
            clearForm()
            loadBlocks()
            loadGrid()
        End If
    End Sub

    Private Sub cmbLayer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLayer.SelectedIndexChanged
        layer = cmbLayer.SelectedItem
        clearForm()
        loadBlocks()
        loadGrid()
    End Sub

    Private Sub cmbRef_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRef.SelectedIndexChanged
        layerRef = cmbRef.SelectedItem
        clearForm()
        loadBlocks()
        loadGrid()
    End Sub

    Private Sub gridLabel()

    End Sub

    Private Sub cmbMaterials_Click_1(sender As Object, e As EventArgs) Handles cmbMaterials.SelectedIndexChanged
        colorTest = Color.FromName(cmbMaterials.Text)
        Threading.Thread.Sleep(100)
        tsmMaterial.HideDropDown()
    End Sub


End Class