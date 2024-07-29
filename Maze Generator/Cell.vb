'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Collections.Generic
Imports System.Drawing

'This module contains the cell class.
Public Class CellClass
   Private Const EAST As Integer = &B1%       'Defines the east direction flag.
   Private Const NORTH As Integer = &B10%     'Defines the north direction flag.
   Private Const SOUTH As Integer = &B100%    'Defines the south direction flag.
   Private Const WEST As Integer = &B1000%    'Defines the west direction flag.

   'This structure defines this cell neighbouring ids.
   Private Structure NeighbourIdsStr
      Public East As String     'Defines the eastern neighbor cell's id.
      Public North As String    'Defines the northern neighbor cell's id.
      Public South As String    'Defines the southern neighbor cell's id.
      Public West As String     'Defines the western neighbor cell's id.
   End Structure

   Public Id As String = Nothing         'Contains this cell's id.
   Public Visited As Boolean = False     'Indicates whether one of the cell's walls have been removed.
   Public Walls As Integer = Nothing     'Indicates which of the cell's walls are present.
   Private Bounds As New Rectangle       'Contains this cell's boundaries.
   Private Ids As New NeighbourIdsStr    'Contains this cell's neighour ids.

   'This procedure draws the specified walls on the specified canvas.
   Public Sub Draw(Canvas As Graphics, Walls As Integer)
      Try
         If (Walls And EAST) = EAST Then Canvas.DrawLine(Pens.Black, New Point(Bounds.Right, Bounds.Top), New Point(Bounds.Right, Bounds.Bottom))
         If (Walls And NORTH) = NORTH Then Canvas.DrawLine(Pens.Black, New Point(Bounds.Left, Bounds.Top), New Point(Bounds.Right, Bounds.Top))
         If (Walls And SOUTH) = SOUTH Then Canvas.DrawLine(Pens.Black, New Point(Bounds.Left, Bounds.Bottom), New Point(Bounds.Right, Bounds.Bottom))
         If (Walls And WEST) = WEST Then Canvas.DrawLine(Pens.Black, New Point(Bounds.Left, Bounds.Top), New Point(Bounds.Left, Bounds.Bottom))
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure returns a random neighbour for this cell.
   Private Function GetRandomNeighbor(Cells As Dictionary(Of String, CellClass), RandomO As Random) As CellClass
      Try
         Dim Neighbours As New List(Of CellClass)

         With Ids
            If .East IsNot Nothing AndAlso Not Cells(.East).Visited Then Neighbours.Add(Cells(.East))
            If .North IsNot Nothing AndAlso Not Cells(.North).Visited Then Neighbours.Add(Cells(.North))
            If .South IsNot Nothing AndAlso Not Cells(.South).Visited Then Neighbours.Add(Cells(.South))
            If .West IsNot Nothing AndAlso Not Cells(.West).Visited Then Neighbours.Add(Cells(.West))
         End With

         Return If(Neighbours.Count > 0, Neighbours(RandomO.Next(0, Neighbours.Count)), Nothing)
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure initializes this cell using the specified parameters and returns its unique id.
   Public Function Initialize(Position As Point, CellSize As Size, Row As Integer, Column As Integer, Rows As Integer, Columns As Integer) As String
      Try
         Me.Bounds = New Rectangle(Position, CellSize)
         Me.Id = String.Format("c{0}r{1}", Column, Row)

         With Ids
            .East = If(Column + 1 > Columns, Nothing, String.Format("c{0}r{1}", Column + 1, Row))
            .North = If(Row - 1 < 0, Nothing, String.Format("c{0}r{1}", Column, Row - 1))
            .South = If(Row + 1 > Rows, Nothing, String.Format("c{0}r{1}", Column, Row + 1))
            .West = If(Column - 1 < 0, Nothing, String.Format("c{0}r{1}", Column - 1, Row))
         End With

         Walls = (EAST Or NORTH Or SOUTH Or WEST)

         Return Me.Id
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try

      Return Nothing
   End Function

   'This procedure removes a random wall from this cell and returns the result..
   Public Function RemoveRandomWall(Cells As Dictionary(Of String, CellClass), CellStack As Stack(Of CellClass), RandomO As Random) As CellClass
      Try
         Dim NextCell As CellClass = GetRandomNeighbor(Cells, RandomO)

         With NextCell
            If NextCell IsNot Nothing Then
               CellStack.Push(NextCell)
               Select Case .Id
                  Case Me.Ids.North
                     Me.Walls = Me.Walls Xor NORTH
                     .Walls = .Walls Xor SOUTH
                  Case Me.Ids.South
                     Me.Walls = Me.Walls Xor SOUTH
                     .Walls = .Walls Xor NORTH
                  Case Me.Ids.East
                     Me.Walls = Me.Walls Xor EAST
                     .Walls = .Walls Xor WEST
                  Case Me.Ids.West
                     Me.Walls = Me.Walls Xor WEST
                     NextCell.Walls = NextCell.Walls Xor EAST
               End Select
            ElseIf CellStack.Count > 0 Then
               NextCell = CellStack.Pop
            Else
               Return Nothing
            End If
         End With

         Return NextCell
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try

      Return Nothing
   End Function
End Class
