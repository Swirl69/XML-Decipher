<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Main
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
        Me.cLabel_WorkingDirectory = New System.Windows.Forms.Label()
        Me.cButton_ChangeWorkingDirectory = New System.Windows.Forms.Button()
        Me.cButton_GetStoryOrder = New System.Windows.Forms.Button()
        Me.cLabel_GetOrderInfo = New System.Windows.Forms.Label()
        Me.cTextBox_ProgramStatus = New System.Windows.Forms.TextBox()
        Me.cLabel_Status = New System.Windows.Forms.Label()
        Me.cButton_MatchID = New System.Windows.Forms.Button()
        Me.cLabel_MatchID = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cLabel_WorkingDirectory
        '
        Me.cLabel_WorkingDirectory.AutoSize = True
        Me.cLabel_WorkingDirectory.Location = New System.Drawing.Point(162, 31)
        Me.cLabel_WorkingDirectory.Name = "cLabel_WorkingDirectory"
        Me.cLabel_WorkingDirectory.Size = New System.Drawing.Size(104, 13)
        Me.cLabel_WorkingDirectory.TabIndex = 0
        Me.cLabel_WorkingDirectory.Text = "No working directory"
        '
        'cButton_ChangeWorkingDirectory
        '
        Me.cButton_ChangeWorkingDirectory.Location = New System.Drawing.Point(88, 19)
        Me.cButton_ChangeWorkingDirectory.Name = "cButton_ChangeWorkingDirectory"
        Me.cButton_ChangeWorkingDirectory.Size = New System.Drawing.Size(58, 36)
        Me.cButton_ChangeWorkingDirectory.TabIndex = 1
        Me.cButton_ChangeWorkingDirectory.Text = "New Directory"
        Me.cButton_ChangeWorkingDirectory.UseVisualStyleBackColor = True
        '
        'cButton_GetStoryOrder
        '
        Me.cButton_GetStoryOrder.Location = New System.Drawing.Point(88, 97)
        Me.cButton_GetStoryOrder.Name = "cButton_GetStoryOrder"
        Me.cButton_GetStoryOrder.Size = New System.Drawing.Size(58, 39)
        Me.cButton_GetStoryOrder.TabIndex = 2
        Me.cButton_GetStoryOrder.Text = "Get Order"
        Me.cButton_GetStoryOrder.UseVisualStyleBackColor = True
        '
        'cLabel_GetOrderInfo
        '
        Me.cLabel_GetOrderInfo.AutoSize = True
        Me.cLabel_GetOrderInfo.Location = New System.Drawing.Point(162, 123)
        Me.cLabel_GetOrderInfo.Name = "cLabel_GetOrderInfo"
        Me.cLabel_GetOrderInfo.Size = New System.Drawing.Size(38, 13)
        Me.cLabel_GetOrderInfo.TabIndex = 3
        Me.cLabel_GetOrderInfo.Text = "Setp 1"
        '
        'cTextBox_ProgramStatus
        '
        Me.cTextBox_ProgramStatus.Location = New System.Drawing.Point(88, 339)
        Me.cTextBox_ProgramStatus.Multiline = True
        Me.cTextBox_ProgramStatus.Name = "cTextBox_ProgramStatus"
        Me.cTextBox_ProgramStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.cTextBox_ProgramStatus.Size = New System.Drawing.Size(603, 151)
        Me.cTextBox_ProgramStatus.TabIndex = 4
        '
        'cLabel_Status
        '
        Me.cLabel_Status.AutoSize = True
        Me.cLabel_Status.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cLabel_Status.Location = New System.Drawing.Point(85, 306)
        Me.cLabel_Status.Name = "cLabel_Status"
        Me.cLabel_Status.Size = New System.Drawing.Size(126, 18)
        Me.cLabel_Status.TabIndex = 5
        Me.cLabel_Status.Text = "Program Status"
        '
        'cButton_MatchID
        '
        Me.cButton_MatchID.Location = New System.Drawing.Point(88, 151)
        Me.cButton_MatchID.Name = "cButton_MatchID"
        Me.cButton_MatchID.Size = New System.Drawing.Size(58, 39)
        Me.cButton_MatchID.TabIndex = 6
        Me.cButton_MatchID.Text = "Match ID"
        Me.cButton_MatchID.UseVisualStyleBackColor = True
        '
        'cLabel_MatchID
        '
        Me.cLabel_MatchID.AutoSize = True
        Me.cLabel_MatchID.Location = New System.Drawing.Point(162, 177)
        Me.cLabel_MatchID.Name = "cLabel_MatchID"
        Me.cLabel_MatchID.Size = New System.Drawing.Size(38, 13)
        Me.cLabel_MatchID.TabIndex = 7
        Me.cLabel_MatchID.Text = "Step 2"
        '
        'Form_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 502)
        Me.Controls.Add(Me.cLabel_MatchID)
        Me.Controls.Add(Me.cButton_MatchID)
        Me.Controls.Add(Me.cLabel_Status)
        Me.Controls.Add(Me.cTextBox_ProgramStatus)
        Me.Controls.Add(Me.cLabel_GetOrderInfo)
        Me.Controls.Add(Me.cButton_GetStoryOrder)
        Me.Controls.Add(Me.cButton_ChangeWorkingDirectory)
        Me.Controls.Add(Me.cLabel_WorkingDirectory)
        Me.Name = "Form_Main"
        Me.Text = "CAPG Catalog Data Manager (C) 2016-17 Mike G. Burch"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cLabel_WorkingDirectory As Label
    Friend WithEvents cButton_ChangeWorkingDirectory As Button
    Friend WithEvents cButton_GetStoryOrder As Button
    Friend WithEvents cLabel_GetOrderInfo As Label
    Friend WithEvents cTextBox_ProgramStatus As TextBox
    Friend WithEvents cLabel_Status As Label
    Friend WithEvents cButton_MatchID As Button
    Friend WithEvents cLabel_MatchID As Label
End Class
