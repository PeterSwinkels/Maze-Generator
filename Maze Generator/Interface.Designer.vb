Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InterfaceWindow
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
        Me.MazeBox = New System.Windows.Forms.PictureBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.MazeBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MazeBox
        '
        Me.MazeBox.Location = New System.Drawing.Point(0, 0)
        Me.MazeBox.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.MazeBox.Name = "MazeBox"
        Me.MazeBox.Size = New System.Drawing.Size(100, 50)
        Me.MazeBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.MazeBox.TabIndex = 0
        Me.MazeBox.TabStop = False
        '
        'InterfaceWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(829, 475)
        Me.Controls.Add(Me.MazeBox)
        Me.KeyPreview = True
        Me.Name = "InterfaceWindow"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.MazeBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MazeBox As PictureBox
    Friend WithEvents ToolTip As ToolTip
End Class
