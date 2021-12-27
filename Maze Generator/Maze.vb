'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Linq

'This module contains the maze generating procedures.
Public Module MazeModule

   'This procedure generates is maze using the specified parameters and returns the graphical representation.
   Public Function GenerateMaze(MazeSize As Size, CellSize As Size) As Bitmap
      Dim Cell As CellClass = Nothing
      Dim Cells As New Dictionary(Of String, CellClass)
      Dim CellStack As New Stack(Of CellClass)
      Dim Column As Integer = 0
      Dim MazeImage As New Bitmap((MazeSize.Width * CellSize.Width) + 1, (MazeSize.Height * CellSize.Height) + 1)
      Dim RandomO As New Random
      Dim Row As Integer = 0
      Dim StartCell As CellClass = Nothing

      For y As Integer = 0 To (MazeSize.Height * CellSize.Height) + 1 Step CellSize.Height
         For x As Integer = 0 To (MazeSize.Width * CellSize.Width) + 1 Step CellSize.Width
            Cell = New CellClass
            Cells.Add(Cell.Initialize(New Point(x, y), New Size(CellSize.Width, CellSize.Height), Row, Column, (MazeSize.Height - 1), (MazeSize.Width - 1)), Cell)
            Column += 1
         Next x
         Column = 0
         Row += 1
      Next y

      CellStack.Clear()
      StartCell = Cells(Cells.Keys.First)
      StartCell.Visited = True
      Do Until StartCell Is Nothing
         StartCell = StartCell.RemoveRandomWall(Cells, CellStack, RandomO)
         If StartCell Is Nothing Then Exit Do
         StartCell.Visited = True
      Loop

      CellStack.Clear()
      Using Canvas As Graphics = Graphics.FromImage(MazeImage)
         Canvas.Clear(Color.White)
         If Cells.Any Then
            For y As Integer = 0 To MazeSize.Height - 1
               For x As Integer = 0 To MazeSize.Width - 1
                  With Cells(String.Format("c{0}r{1}", x, y))
                     .Draw(Canvas, .Walls)
                  End With
               Next x
            Next y
         End If
      End Using

      Return MazeImage
   End Function
End Module
