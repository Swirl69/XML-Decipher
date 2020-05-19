<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Start
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
        Me.cButton_Step1 = New System.Windows.Forms.Button()
        Me.cButton_Step2 = New System.Windows.Forms.Button()
        Me.cButton_Step3 = New System.Windows.Forms.Button()
        Me.cLabel_Step1 = New System.Windows.Forms.Label()
        Me.cLabel_Step2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cButton_Step1
        '
        Me.cButton_Step1.Location = New System.Drawing.Point(40, 26)
        Me.cButton_Step1.Name = "cButton_Step1"
        Me.cButton_Step1.Size = New System.Drawing.Size(68, 53)
        Me.cButton_Step1.TabIndex = 0
        Me.cButton_Step1.Text = "Parse XML"
        Me.cButton_Step1.UseVisualStyleBackColor = True
        '
        'cButton_Step2
        '
        Me.cButton_Step2.Location = New System.Drawing.Point(40, 124)
        Me.cButton_Step2.Name = "cButton_Step2"
        Me.cButton_Step2.Size = New System.Drawing.Size(68, 53)
        Me.cButton_Step2.TabIndex = 1
        Me.cButton_Step2.Text = "Listing Order"
        Me.cButton_Step2.UseVisualStyleBackColor = True
        '
        'cButton_Step3
        '
        Me.cButton_Step3.Location = New System.Drawing.Point(40, 225)
        Me.cButton_Step3.Name = "cButton_Step3"
        Me.cButton_Step3.Size = New System.Drawing.Size(68, 53)
        Me.cButton_Step3.TabIndex = 2
        Me.cButton_Step3.Text = "Picture Data"
        Me.cButton_Step3.UseVisualStyleBackColor = True
        '
        'cLabel_Step1
        '
        Me.cLabel_Step1.AutoSize = True
        Me.cLabel_Step1.Location = New System.Drawing.Point(126, 66)
        Me.cLabel_Step1.Name = "cLabel_Step1"
        Me.cLabel_Step1.Size = New System.Drawing.Size(318, 13)
        Me.cLabel_Step1.TabIndex = 3
        Me.cLabel_Step1.Text = "Step 1:  Click here to process the exported XML file from Indesign."
        '
        'cLabel_Step2
        '
        Me.cLabel_Step2.Location = New System.Drawing.Point(126, 151)
        Me.cLabel_Step2.Name = "cLabel_Step2"
        Me.cLabel_Step2.Size = New System.Drawing.Size(336, 26)
        Me.cLabel_Step2.TabIndex = 4
        Me.cLabel_Step2.Text = "Step 2:  Click here to process the IDML files to find the story order of the layo" &
    "ut."
        '
        'Form_Start
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 403)
        Me.Controls.Add(Me.cLabel_Step2)
        Me.Controls.Add(Me.cLabel_Step1)
        Me.Controls.Add(Me.cButton_Step3)
        Me.Controls.Add(Me.cButton_Step2)
        Me.Controls.Add(Me.cButton_Step1)
        Me.Name = "Form_Start"
        Me.Text = "Catalog Data Parser (C) 2016-17 Mike G. Burch For CAPG, Inc."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cButton_Step1 As Button
    Friend WithEvents cButton_Step2 As Button
    Friend WithEvents cButton_Step3 As Button
    Friend WithEvents cLabel_Step1 As Label
    Friend WithEvents cLabel_Step2 As Label
End Class
