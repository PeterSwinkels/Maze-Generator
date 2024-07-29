'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Drawing

'This module contains this program's main interface.
Public Class InterfaceWindow
   'This procedure initializes this program's main window.
   Public Sub New()
      Try
         InitializeComponent()

         With My.Application.Info
            Me.Text = ProgramInformation()
         End With

         With My.Computer.Screen.WorkingArea
            Me.ClientSize = New Size(CInt(.Width / 1.5), CInt(.Height / 1.5))
         End With

         ToolTip.SetToolTip(Me, "Double click here to generate mazes.")
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub

   'This procedure gives the command to generate a maze when the user double clicks.
   Private Sub Maze_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick, MazeBox.DoubleClick
      Try
         MazeBox.Image = GenerateMaze(MazeSize:=New Size(100, 100), CellSize:=New Size(10, 10))
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try
   End Sub
End Class
