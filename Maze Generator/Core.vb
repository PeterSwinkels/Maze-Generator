'This module's imports and settings.
Option Compare Binary
Option Explicit On
Option Infer Off
Option Strict On

Imports System
Imports System.Environment
Imports System.Windows.Forms

'This module contains this program's core procedures.
Public Module CoreModule
   'This procedure displays any errors that occur.
   Public Sub DisplayError(ExceptionO As Exception)
      Try
         MessageBox.Show(ExceptionO.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
      Catch
         [Exit](0)
      End Try
   End Sub

   'This procedure returns information about this program.
   Public Function ProgramInformation() As String
      Try
         Dim Information As String = Nothing

         With My.Application.Info
            Information = $"{ .Title} v{ .Version} - by: { .CompanyName}"
         End With

         Return Information
      Catch ExceptionO As Exception
         DisplayError(ExceptionO)
      End Try

      Return Nothing
   End Function
End Module
