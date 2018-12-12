Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Reflection
Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
    Dim setLocation As Boolean = False 'variable for testing if next click should set a in game location while exporting
    Dim setLocationX As Int32
    Dim setLocationY As Int32
    Dim setLocationZ As Int32
    Dim currentColor As Color 'variable for storing color for drawing
    Dim trueColor As Color ' variable for loading color from savefile
    Dim localOffSetX As Int32 = 0
    Dim LocalOffSetY As Int32 = 0
    Dim blocksX As Int16
    Dim blocksY As Int16
    Public box As Int16 = 10
    Public tool As String = "point" 'variable for storing the tool used when drawing. Also initializes the tool as point.
    Public recTest As Boolean = False 'variable to deside to get second point when making a rectangle
    Public lineTest As Boolean = False 'variable to deside to get second point when making a line
    Dim setMaterial As String 'holds matterial to be stored in dictionary
    Dim pen As Brush = New SolidBrush(Color.Black)
    Dim lineX As Int32 = 0 ' Stores pos.X of first click of line
    Dim LineY As Int32 = 0 ' Stores pos.Y of first click of line
    Dim reccX As Int32 = 0 ' Stores pos.X of first click of rectangle
    Dim reccY As Int32 = 0 ' Stores pos.Y of first click of rectangle
    Dim layer As Int32 = 1 ' sets the starting layer to 1 and alows all subs to use it
    Dim layerRef As Int32 = 1
    Public blockDictionary As Dictionary(Of Vector, String) = New Dictionary(Of Vector, String)
    Dim saveFile As String = Nothing 'String for storing save and save as
    Dim saveFileMat As String = Nothing ' String for storing material list save file
    Dim scrollBool As Boolean = False
    Dim scrollX As Int32 = 0 'stores final position while scrolling in x direction
    Dim scrollY As Int32 = 0 'stores final position while scrolling in y direction
    Dim shapeScrollX As Int32 = 0 'stores final position while scrolling in x direction when making a shape
    Dim shapeScrollY As Int32 = 0 'stores final position while scrolling in y direction when making a shape
    Dim scrollX1 As Int32 = 0 'stores origional position while creating offset in x direction
    Dim scrollY1 As Int32 = 0 'stores origional position while creating offset in y direction
    Dim offSetX As Int32 = 0
    Dim offSetY As Int32 = 0
    Dim grid As Int16
    Dim offsetBool As Boolean = False
    Dim matterialDictionary As Dictionary(Of String, Color) = New Dictionary(Of String, Color)
    Dim blockStack As Stack(Of Dictionary(Of Vector, Color)) = New Stack(Of Dictionary(Of Vector, Color))
    Dim tempDictionary As Dictionary(Of Vector, String) = New Dictionary(Of Vector, String)

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
        blockDictionary = New Dictionary(Of Vector, String)
        clearForm()
        loadBlocks()
        loadGrid()
    End Sub

    Private Sub loadBlocks()
        Dim myRectangle As Rectangle
        Dim dictPair As KeyValuePair(Of Vector, String)
        For Each dictPair In blockDictionary
            If dictPair.Key.Z = layerRef Then
                If Not layerRef = layer Then
                    If Not dictPair.Key.X + offSetX < 110 Or dictPair.Key.Y + offSetY < 39 Then
                        pen = New SolidBrush(Color.FromArgb(255, 69, 89, 226))
                        myRectangle = New Rectangle(dictPair.Key.X + offSetX, dictPair.Key.Y + offSetY, box, box)
                        CreateGraphics().FillRectangle(pen, rect:=myRectangle)
                    End If
                End If
            End If
        Next

        For Each dictPair In blockDictionary
            If dictPair.Key.Z = layer Then
                If dictPair.Key.X + offSetX < 110 Or dictPair.Key.Y + offSetY < 39 Then
                    'nothing
                Else
                    For Each dictPairMat In matterialDictionary
                        If dictPairMat.Key = dictPair.Value Then
                            pen = New SolidBrush(dictPairMat.Value)
                        End If
                    Next
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

    Private Sub hideBlocks()
        Dim myRectangle As Rectangle
        For Each dictPair In blockDictionary
            If dictPair.Key.Z = layerRef Then
                If dictPair.Key.X + offSetX < 110 Or dictPair.Key.Y + offSetY < 39 Then
                    'nothing
                Else
                    pen = New SolidBrush(Color.White)
                    myRectangle = New Rectangle(dictPair.Key.X + offSetX, dictPair.Key.Y + offSetY, box, box)
                    CreateGraphics().FillRectangle(pen, rect:=myRectangle)
                End If
            End If
        Next

        For Each dictPair In blockDictionary
            If dictPair.Key.Z = layer Then
                If dictPair.Key.X + offSetX < 110 Or dictPair.Key.Y + offSetY < 39 Then
                    'nothing
                Else
                    pen = New SolidBrush(Color.White)
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



    Sub AddToBlockDictionary(posX As Int32, posY As Int32, blockMat As String)
        Dim blockPoint As Vector = New Vector()
        blockPoint.X = posX - offSetX
        blockPoint.Y = posY - offSetY
        blockPoint.Z = layer
        blockDictionary.Remove(blockPoint)
        blockDictionary.Add(blockPoint, blockMat)
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

        For gridCount As Integer = 1 To blocksY
            If (gridCount - (offSetY / box) Mod grid) Mod grid = 1 Then
                penGrid.Color = Color.Black
            Else
                penGrid.Color = Color.GhostWhite
            End If
            MyBase.CreateGraphics.DrawLine(penGrid, x1:=110, y1:=30 + (gridCount * box), x2:=MyBase.Width, y2:=30 + (gridCount * box))
        Next
    End Sub


    'experimental subRoutine
    'Private Sub boxSize(ByVal sender As Object, ByVal pos As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseWheel
    '    If pos.Delta < 0 Then
    '        If box = 10 Then
    '            '''''''nothing
    '        Else
    '            offSetX = offSetX / box
    '            box -= 10
    '            offSetX = offSetX * box
    '        End If
    '    Else
    '        If box = 10240 Then
    '            ''''''''''nothing    
    '        Else
    '            offSetX = offSetX / box
    '            box += 10
    '            offSetX = offSetX * box
    '        End If
    '    End If
    '    clearForm()
    '    loadBlocks()
    '    loadGrid()
    'End Sub

    Private Sub boxClick(ByVal sender As Object, ByVal pos As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseClick, MyBase.MouseMove
        If pos.Button = MouseButtons.Left Or pos.Button = MouseButtons.Right Then
            If setLocation = True Then
                setLocationX = Math.Floor(pos.X * box) / box
                setLocationY = Math.Floor(pos.Y * box) / box
                setLocationZ = layer
                menuFileExport_Click(Nothing, Nothing)
                Exit Sub
            End If
        End If


        'selecting material from comboBox
        For Each dictpair In matterialDictionary
            If dictpair.Key = cmbMaterials.Text Then
                pen = New SolidBrush(dictpair.Value)
                currentColor = dictpair.Value
                Exit For
            End If
        Next

        If pos.Button = MouseButtons.Left Then
            If tool = "rect" Then
                Threading.Thread.Sleep(50)
                If recTest = False Then
                    'happens in mouseUp subroutine
                Else
                    Dim toFill = MessageBox.Show("Would you like to fill this Rectangle", "Fill Rectangle", MessageBoxButtons.YesNo)
                    If toFill = DialogResult.Yes Then
                        Dim isPosY = -1
                        Dim isPosX = -1
                        Dim blockPoint As Vector = New Vector
                        If Math.Floor(reccX / 10) < Math.Floor(pos.X / 10) Then
                            isPosX = 1
                        End If
                        If Math.Floor(reccY / 10) < Math.Floor(pos.Y / 10) Then
                            isPosY = 1
                        End If
                        For i = 1 To Math.Abs((reccX / 10) - Math.Floor(pos.X / 10))
                            For u As Int32 = 1 To Math.Abs((reccY / 10) - Math.Floor(pos.Y / 10))
                                blockPoint.X = (reccX + i * isPosX * box)
                                blockPoint.Y = (reccY + u * isPosY * box)
                                blockPoint.Z = layer
                                tempDictionary.Remove(blockPoint)
                                tempDictionary.Add(blockPoint, setMaterial)
                            Next
                        Next

                    End If
                    For Each dictPair In tempDictionary
                        AddToBlockDictionary(dictPair.Key.X, dictPair.Key.Y, dictPair.Value)
                    Next
                    loadBlocks()
                    Threading.Thread.Sleep(300)
                    localOffSetX = 0
                    LocalOffSetY = 0
                End If
            ElseIf tool = "point" Then
                Dim myRectangle As Rectangle
                myRectangle = New Rectangle((Math.Floor(pos.X / box) * box), (Math.Floor(pos.Y / box) * box), box, box)
                CreateGraphics().FillRectangle(pen, rect:=myRectangle)
                AddToBlockDictionary((Math.Floor(pos.X / box) * box), (Math.Floor(pos.Y / box) * box), setMaterial)
            ElseIf tool = "line" Then
                If lineTest = False Then
                    lineX = pos.X
                    LineY = pos.Y
                Else
                    Dim isLinePositive As Int32 = 1 ' tests for if line should be possitive or negative
                    If Math.Floor(pos.X / 10) = Math.Floor(lineX / 10) Then ' if the line drawn is vertical
                        If LineY > pos.Y Then
                            isLinePositive = -1
                        End If
                        For i As Int32 = 0 To Math.Abs(Math.Floor(LineY) - Math.Floor(pos.Y))
                            AddToBlockDictionary((Math.Floor((lineX) / box) * box), (Math.Floor((LineY + i * isLinePositive) / box) * box), setMaterial)
                        Next
                    Else ' if the line has a slope
                        Dim lineSlope As Double = (Math.Floor(LineY / box) * 10 - Math.Floor(pos.Y / box) * 10) / (Math.Floor(lineX / box) * 10 - Math.Floor(pos.X / box) * 10)
                        If lineX > pos.X Then
                            isLinePositive = -1
                        End If
                        For i As Int32 = 0 To Math.Abs(Math.Floor(pos.X) - Math.Floor(lineX))
                            AddToBlockDictionary((Math.Floor((lineX + i * isLinePositive) / box) * box), (Math.Floor((lineSlope * i * isLinePositive + LineY) / box) * box), setMaterial)
                        Next
                    End If
                    loadBlocks()
                    loadGrid()
                End If

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


        ElseIf pos.Button = MouseButtons.Right Then
            Dim penz As Brush = New SolidBrush(BackColor)
            Dim myRectangle As Rectangle
            If ToolStripComboBox2.SelectedIndex = 1 Then
                For i = -1 To 1
                    For u = -1 To 1
                        myRectangle = New Rectangle((Math.Floor(pos.X / box) * box + (i * box)), (Math.Floor(pos.Y / box) * box + u * box), box, box)
                        CreateGraphics().FillRectangle(penz, rect:=myRectangle)
                        RemoveBlockFromDictionary(Math.Floor(pos.X / box) * box + (i * box), Math.Floor(pos.Y / box) * box + u * box)
                    Next
                Next
            ElseIf ToolStripComboBox2.SelectedIndex = 2 Then
                For i = -3 To 3
                    For u = -2 To 2
                        myRectangle = New Rectangle((Math.Floor(pos.X / box) * box + (i * box)), (Math.Floor(pos.Y / box) * box + u * box), box, box)
                        CreateGraphics().FillRectangle(penz, rect:=myRectangle)
                        RemoveBlockFromDictionary(Math.Floor(pos.X / box) * box + (i * box), Math.Floor(pos.Y / box) * box + u * box)
                    Next
                Next
            Else
                myRectangle = New Rectangle((Math.Floor(pos.X / box) * box), (Math.Floor(pos.Y / box) * box), box, box)
                CreateGraphics().FillRectangle(penz, rect:=myRectangle)
                RemoveBlockFromDictionary(Math.Floor(pos.X / box) * box, Math.Floor(pos.Y / box) * box)
            End If
        ElseIf pos.Button = MouseButtons.Middle Then
            If offsetBool = False Then
                scrollX1 = Math.Floor(pos.X / box)
                scrollY1 = Math.Floor(pos.Y / box)
                offsetBool = True
            Else
                scrollX = Math.Floor(pos.X / box) - scrollX1
                scrollY = Math.Floor(pos.Y / box) - scrollY1

            End If
        Else ''NO button only scroll
            If recTest = True And tool = "rect" Then
                If scrollBool = False Then
                    shapeScrollX = pos.X
                    shapeScrollY = pos.Y
                    scrollBool = True
                Else
                    Dim myRectangle As Rectangle
                    If Math.Floor(shapeScrollX / box) * box <> Math.Floor(pos.X / box) * box Or Math.Floor(shapeScrollY / box) * box <> Math.Floor(pos.Y / box) * box Then
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
                        tempDictionary = New Dictionary(Of Vector, String)
                        scrollBool = False
                        Dim blockPoint As Vector = New Vector()
                        blockPoint.X = reccX
                        blockPoint.Y = reccY
                        tempDictionary.Remove(blockPoint)
                        tempDictionary.Add(blockPoint, setMaterial)
                        Dim posTest As Int16
                        loadBlocks()

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
                            tempDictionary.Add(blockPoint, setMaterial)
                            blockPoint.X = reccX + (i * posTest) * 10
                            blockPoint.Y = Math.Floor(pos.Y / box) * box
                            blockPoint.Z = layer
                            tempDictionary.Remove(blockPoint)
                            tempDictionary.Add(blockPoint, setMaterial)
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
                            tempDictionary.Add(blockPoint, setMaterial)
                            blockPoint.X = Math.Floor(pos.X / box) * box + localOffSetX
                            blockPoint.Y = reccY + (i * posTest) * 10 + LocalOffSetY
                            blockPoint.Z = layer
                            tempDictionary.Remove(blockPoint)
                            tempDictionary.Add(blockPoint, setMaterial)
                        Next
                        For Each dictPair In tempDictionary
                            If dictPair.Key.Z = layer Then
                                If dictPair.Key.X + offSetX + localOffSetX < 110 Or dictPair.Key.Y + offSetY + LocalOffSetY < 39 Then
                                    'nothing
                                Else
                                    pen = New SolidBrush(currentColor)
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
            offSetX = offSetX + (scrollX * box)
            offSetY = offSetY + (scrollY * box)
            scrollY = 0
            scrollX = 0
            offsetBool = False
            clearForm()
            loadBlocks()
            loadGrid()
        ElseIf move.Button = MouseButtons.Right Then
            clearForm()
            loadBlocks()
            loadGrid()
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
            If lineTest = False And tool = "line" Then
                Dim myRectangle As Rectangle
                myRectangle = New Rectangle((Math.Floor(lineX / box) * box), (Math.Floor(LineY / box) * box), box, box)
                CreateGraphics().FillRectangle(pen, rect:=myRectangle)
                AddToBlockDictionary((Math.Floor(lineX / box) * box), (Math.Floor(LineY / box) * box), setMaterial)
                lineTest = True
            Else
                lineTest = False
            End If
            clearForm()
            loadBlocks()
            loadGrid()
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
        ImportDatabaseToolStripMenuItem_Click(e, e)
        For Each dictpair In matterialDictionary
            cmbMaterials.Items.Add(dictpair.Key)
        Next
        cmbMaterials.SelectedIndex = 0
        ToolStripComboBoxGridSize.SelectedItem = "16"
        loadGrid()
        ToolComboBox.SelectedIndex = 0
        ToolStripComboBox2.SelectedIndex = 0
    End Sub
    Private Sub Form_show(sender As Object, e As EventArgs) Handles MyBase.Shown
        loadGrid()
    End Sub

    Private Sub btbTest_Click(sender As Object, e As EventArgs)
        LoadMaterialsToolStripMenuItem_Click(e, e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        tool = "rect"
    End Sub

    'Save functions
    Private Sub menuFileOpen_Click(sender As Object, e As EventArgs) Handles menuFileOpen.Click
        Dim message = MessageBox.Show("Would you like to open a material list first?", "Open Material List?", MessageBoxButtons.YesNo)
        Dim storeFile As String = ""
        If message = DialogResult.Yes Then
            LoadMaterialsToolStripMenuItem_Click(e, e)
        End If
        Try
            Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
            Dim fileName As IO.FileStream
            With OpenFileDialog1
                .FileName = ""
                .Filter = "CAD File | *.cad"
                .InitialDirectory = "Desktop"
                .Title = "Select a File to Open"
                storeFile = .FileName
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
        Catch ex As Exception
            If Not storeFile = "" Then
                MsgBox("file is invalid")
            End If
        End Try
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


    Private Sub cmbMaterials_Click_1(sender As Object, e As EventArgs) Handles cmbMaterials.SelectedIndexChanged
        setMaterial = cmbMaterials.Text
        Threading.Thread.Sleep(100)
        tsmMaterial.HideDropDown()
    End Sub

    Private Sub ToolComboBox_Change(sender As Object, e As EventArgs) Handles ToolComboBox.DropDownClosed
        If ToolComboBox.SelectedItem = "point" Then
            tool = "point"
        ElseIf ToolComboBox.SelectedItem = "rectangle" Then
            tool = "rect"
        ElseIf ToolComboBox.SelectedItem = "line" Then
            tool = "line"
        End If
        ToolsToolStripMenuItem.HideDropDown()
    End Sub

    Private Sub ExtrudeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtrudeToolStripMenuItem.Click
        Dim input = InputBox("Enter layer to extrude to from current layer", "Extrusion Tool")
        While True
            If IsNumeric(input) Then
                Dim isPositive As Int32 = 1
                If input < layer Then
                    isPositive = -1
                End If
                Dim tempVector As Vector = New Vector
                For i As Int32 = 0 To Math.Abs(input - layer - 1)
                    tempDictionary.Clear()
                    For Each dictPair In blockDictionary
                        If dictPair.Key.Z = layer Then
                            tempVector.X = (dictPair.Key.X)
                            tempVector.Y = (dictPair.Key.Y)
                            tempVector.Z = (dictPair.Key.Z + (i + 1) * isPositive)
                            tempDictionary.Add(tempVector, dictPair.Value)
                        End If
                    Next
                    For Each dictPair In tempDictionary
                        tempVector.X = dictPair.Key.X
                        tempVector.Y = dictPair.Key.Y
                        tempVector.Z = dictPair.Key.Z
                        blockDictionary.Add(tempVector, dictPair.Value)
                    Next
                Next
                Exit While
            Else
                If input = "" Then
                    Exit While
                End If
                input = InputBox("Please enter a number", "Extrusion Tool")
            End If
        End While
    End Sub

    Private Sub AddMaterialToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddMaterialToolStripMenuItem.Click
        Dim matName As String = InputBox("Material Name", "Add Material")
        ColorDialog1.ShowDialog()
        matterialDictionary.Remove(matName)
        matterialDictionary.Add(matName, ColorDialog1.Color)
        cmbMaterials.Items.Clear()
        For Each dictPair In matterialDictionary
            cmbMaterials.Items.Add(dictPair.Key)
        Next
    End Sub

    Private Sub SaveMaterialsAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveMaterialsAsToolStripMenuItem.Click
        With SaveFileDialog1
            Dim fileName As System.IO.StreamWriter = Nothing
            .Filter = "Text Files| *.txt"
                .InitialDirectory = "Desktop"
                .Title = "Save File As"
                .AddExtension = True
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Try
                        fileName = My.Computer.FileSystem.OpenTextFileWriter(.FileName, False)
                        For Each dictPair In matterialDictionary
                            fileName.WriteLine("{" & dictPair.Key.ToString & "; " & dictPair.Value.ToString & "}" & " ")
                        Next
                    Finally
                        saveFileMat = .FileName
                        fileName.Close()
                    End Try
                End If

                Me.Cursor = Cursors.Default
        End With
    End Sub


    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox1.SelectedIndexChanged
        Dim mat As String = ToolStripComboBox1.SelectedText
        tsmMaterial.HideDropDown()
        Dim message = MessageBox.Show("Would you like to edit " & ToolStripComboBox1.Text, "Edit Block", MessageBoxButtons.YesNo)
        If message = DialogResult.Yes Then
            tempDictionary.Clear()
            For Each dictPair In matterialDictionary
                If dictPair.Key = ToolStripComboBox1.SelectedItem Then
                    mat = InputBox("Enter new name for " & dictPair.Key, "Enter Material")
                    If mat = "" Then
                        mat = dictPair.Key
                    End If
                    ColorDialog1.ShowDialog()

                    For Each dictPair2 In blockDictionary
                        If dictPair2.Value = dictPair.Key Then
                            tempDictionary.Add(dictPair2.Key, mat)
                        End If
                    Next
                    For Each dictpair2 In tempDictionary
                        blockDictionary.Remove(dictpair2.Key)
                        blockDictionary.Add(dictpair2.Key, dictpair2.Value)
                    Next
                    matterialDictionary.Remove(dictPair.Key)
                    If ColorDialog1.Color = Nothing Then
                        matterialDictionary.Add(mat, dictPair.Value)
                    Else
                        matterialDictionary.Add(mat, ColorDialog1.Color)
                    End If
                    Exit For
                End If
            Next


            'updates dictionary points with old material
            tempDictionary.Clear()
            For Each dictPair In blockDictionary
                If dictPair.Value = mat Then
                    tempDictionary.Remove(dictPair.Key)
                    tempDictionary.Add(dictPair.Key, mat)
                End If
            Next
            For Each dictPair In tempDictionary
                blockDictionary.Remove(dictPair.Key)
                blockDictionary.Add(dictPair.Key, dictPair.Value)
            Next
        End If
        loadBlocks()
        loadGrid()
    End Sub

    Private Sub ToolStripMenuItemEditBlock_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEditBlock.MouseHover
        ToolStripComboBox1.Items.Clear()
        For Each dictPair In matterialDictionary
            ToolStripComboBox1.Items.Add(dictPair.Key)
        Next
    End Sub

    Private Sub LoadMaterialsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadMaterialsToolStripMenuItem.Click
        Dim delimiter As Char = ","
        Dim delimiter2 As Char = "{"
        Dim delimiter3 As Char = "}"
        With OpenFileDialog1
            .Filter = "Text file | *.txt"
            .InitialDirectory = "Desktop"
            .Title = "Select a File to Open"
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    Dim cfile As New StreamReader(.FileName)
                    Dim matString As String
                    Dim matName As String
                    Dim testcolor As New Color
                    Dim a As Int32
                    Dim r As Int32
                    Dim g As Int32
                    Dim b As Int32
                    Dim deleteTest = False
                    Do
                        matString = cfile.ReadLine
                        If Not matString = Nothing Then
                            ' add matterial Name from save file to matterialDictionary
                            matName = matString
                            matName = matString.Split(";")(0).Remove(0, 1)
                            ' add color from save file to matterialDictionary
                            matString = matString.Split(";")(1).Remove(matString.Split(";")(1).Length - 1, 1)
                            matString = matString.Remove(0, 8)
                            matString = matString.Remove(matString.Length - 2, 2).ToLower()
                            If matString.Contains("=") Then
                                a = matString.Split("=")(1).Split(",")(0)
                                r = matString.Split("=")(2).Split(",")(0)
                                g = matString.Split("=")(3).Split(",")(0)
                                b = matString.Split("=")(4)
                                testcolor = Color.FromArgb(a, r, g, b)
                                trueColor = testcolor
                            Else
                                testcolor = Color.FromName(matString)
                            End If
                            If deleteTest = False Then
                                matterialDictionary.Clear()
                                deleteTest = True
                            End If
                            matterialDictionary.Remove(matName)
                            matterialDictionary.Add(matName, testcolor)
                        End If
                    Loop Until matString = Nothing
                    saveFileMat = .FileName
                    cfile.Close()
                Catch ex As Exception

                    MsgBox("file is invalid")
                End Try

            End If
        End With
        cmbMaterials.Items.Clear()
        For Each dictpair In matterialDictionary
            cmbMaterials.Items.Add(dictpair.Key)
        Next
    End Sub

    Private Sub menuFileExport_Click(sender As Object, e As EventArgs) Handles menuFileExport.Click
        If setLocation = False Then
            MessageBox.Show("Click block to set in game anchor point", "Set Location")
            Threading.Thread.Sleep(300)
            setLocation = True
            Exit Sub
        Else
            setLocation = False
            tempDictionary.Clear()
            For Each dictPair In blockDictionary
                Dim changeX As Int32
                Dim changeY As Int32
                Dim changeZ As Int32
                If setLocationX > 0 Then
                    changeX = setLocationX
                ElseIf dictPair.Key.X < 0 Then
                    changeX = setLocationX * -1
                Else
                    changeX = 0
                End If

                If setLocationY > 0 Then
                    changeY = setLocationY * -1
                ElseIf dictPair.Key.Y < 0 Then
                    changeY = setLocationY
                Else
                    changeY = 0
                End If

                If setLocationZ > 0 Then
                    changeY = setLocationZ
                ElseIf dictPair.Key.Z < 0 Then
                    changeZ = setLocationZ * -1
                Else
                    changeZ = 0
                End If

                Dim tempVec As New Vector
                tempVec.X = dictPair.Key.X - changeX * 10
                tempVec.Y = dictPair.Key.Y - changeY * 10
                tempVec.Z = dictPair.Key.Z - changeZ
                tempDictionary.Remove(tempVec)
                tempDictionary.Add(tempVec, dictPair.Value)
            Next

            With SaveFileDialog1
                Dim fileName As System.IO.StreamWriter = Nothing
                .Filter = "Lua Files| *.lua"
                .InitialDirectory = "Desktop"
                .Title = "Export lua readable"
                .AddExtension = False
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Try
                        fileName = My.Computer.FileSystem.OpenTextFileWriter(.FileName, False)
                        Dim cfile As String = My.Resources.BlockList
                        fileName.WriteLine()
                        For Each dictPair In tempDictionary
                            fileName.WriteLine("{" & "{" & dictPair.Key.X / 10 & "," & dictPair.Key.Y / 10 & "," & dictPair.Key.Z & "}" & "," & dictPair.Value & "}" & ",")
                        Next
                    Finally
                        fileName.Close()
                    End Try
                End If
                Me.Cursor = Cursors.Default
            End With

        End If
        Threading.Thread.Sleep(150)
    End Sub

    ' control s saves project
    Private Sub main_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.ControlKey And e.KeyCode = Keys.S Then
            menuFileSave_Click(e, e)
        End If
    End Sub

    Private Sub FileToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem1.Click
        saveFile = Nothing
        ClearDictionary()
        ReFocus()
        MyBase.Text = "CAD"
    End Sub

    Private Sub ToolStripComboBox2_Click(sender As Object, e As EventArgs) Handles ToolStripComboBox2.SelectedIndexChanged
        ToolsToolStripMenuItem.HideDropDown()
    End Sub

    Private Sub tsmMaterial_Click(sender As Object, e As EventArgs) Handles tsmMaterial.Click
        cmbMaterials.Items.Clear()
        For Each dictpair In matterialDictionary
            cmbMaterials.Items.Add(dictpair.Key)
        Next
    End Sub

    Private Sub ImportDatabaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportDatabaseToolStripMenuItem.Click
        Dim connStr As String = "server=10.0.0.220,1466;User Id=sa;pwd=@a88word;database=Tool"
        Dim conn As New System.Data.SqlClient.SqlConnection(connStr)
        Dim comm As New System.Data.SqlClient.SqlCommand
        comm.CommandText = "SELECT * FROM material"
        comm.Connection = conn
        Try
            conn.Open()
        Catch ex As Exception
            connStr = "server=75.73.144.52,1466;User Id=sa;pwd=@a88word;database=Tool"
            conn = New System.Data.SqlClient.SqlConnection(connStr)
            comm.Connection = conn
            conn.Open()
        Finally
            Try
                Dim dr As SqlDataReader = comm.ExecuteReader()
                While dr.Read
                    Dim color As Color = Color.FromName(Convert.ToString(dr.Item("Color")))
                    Dim str As String = Convert.ToString(dr.Item("String"))
                    matterialDictionary.Remove(str)
                    matterialDictionary.Add(str, color)
                End While
            Catch ex As Exception
                matterialDictionary.Add("Stone", Color.Gray)
                matterialDictionary.Add("Brick", Color.Red)
            End Try
        End Try
    End Sub

End Class