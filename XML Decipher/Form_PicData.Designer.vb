<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_PicData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cButton_OpenFolderLocation = New System.Windows.Forms.Button()
        Me.cButton_StartExtract = New System.Windows.Forms.Button()
        Me.cTextBox_Status = New System.Windows.Forms.TextBox()
        Me.cLabel_Directory = New System.Windows.Forms.Label()
        Me.cButton_MatchPartNumbers = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cButton_OpenFolderLocation
        '
        Me.cButton_OpenFolderLocation.Location = New System.Drawing.Point(36, 48)
        Me.cButton_OpenFolderLocation.Name = "cButton_OpenFolderLocation"
        Me.cButton_OpenFolderLocation.Size = New System.Drawing.Size(60, 48)
        Me.cButton_OpenFolderLocation.TabIndex = 0
        Me.cButton_OpenFolderLocation.Text = "Pick Folder"
        Me.cButton_OpenFolderLocation.UseVisualStyleBackColor = True
        '
        'cButton_StartExtract
        '
        Me.cButton_StartExtract.Location = New System.Drawing.Point(38, 106)
        Me.cButton_StartExtract.Name = "cButton_StartExtract"
        Me.cButton_StartExtract.Size = New System.Drawing.Size(58, 45)
        Me.cButton_StartExtract.TabIndex = 1
        Me.cButton_StartExtract.Text = "Start Extract"
        Me.cButton_StartExtract.UseVisualStyleBackColor = True
        '
        'cTextBox_Status
        '
        Me.cTextBox_Status.Location = New System.Drawing.Point(36, 222)
        Me.cTextBox_Status.Multiline = True
        Me.cTextBox_Status.Name = "cTextBox_Status"
        Me.cTextBox_Status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.cTextBox_Status.Size = New System.Drawing.Size(726, 115)
        Me.cTextBox_Status.TabIndex = 2
        '
        'cLabel_Directory
        '
        Me.cLabel_Directory.AutoSize = True
        Me.cLabel_Directory.Location = New System.Drawing.Point(35, 19)
        Me.cLabel_Directory.Name = "cLabel_Directory"
        Me.cLabel_Directory.Size = New System.Drawing.Size(89, 13)
        Me.cLabel_Directory.TabIndex = 3
        Me.cLabel_Directory.Text = "Current Directory:"
        '
        'cButton_MatchPartNumbers
        '
        Me.cButton_MatchPartNumbers.Location = New System.Drawing.Point(38, 159)
        Me.cButton_MatchPartNumbers.Name = "cButton_MatchPartNumbers"
        Me.cButton_MatchPartNumbers.Size = New System.Drawing.Size(58, 48)
        Me.cButton_MatchPartNumbers.TabIndex = 4
        Me.cButton_MatchPartNumbers.Text = "Done"
        Me.cButton_MatchPartNumbers.UseVisualStyleBackColor = True
        '
        'Form_PicData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 368)
        Me.Controls.Add(Me.cButton_MatchPartNumbers)
        Me.Controls.Add(Me.cLabel_Directory)
        Me.Controls.Add(Me.cTextBox_Status)
        Me.Controls.Add(Me.cButton_StartExtract)
        Me.Controls.Add(Me.cButton_OpenFolderLocation)
        Me.Name = "Form_PicData"
        Me.Text = "Extract Image Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cButton_OpenFolderLocation As Button
    Friend WithEvents cButton_StartExtract As Button
    Friend WithEvents cTextBox_Status As TextBox
    Friend WithEvents cLabel_Directory As Label
    Friend WithEvents cButton_MatchPartNumbers As Button
End Class
