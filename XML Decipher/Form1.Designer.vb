<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.butLoadXMLFile = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.butReadXML = New System.Windows.Forms.Button()
        Me.tbxProcess = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.butSaveXML = New System.Windows.Forms.Button()
        Me.nudSection = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenXMLFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SaveXMLFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProcessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.XMLFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckBox1_ExportImageInfo = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.c_DataGridView1_Catalog = New System.Windows.Forms.DataGridView()
        CType(Me.nudSection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.c_DataGridView1_Catalog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'butLoadXMLFile
        '
        Me.butLoadXMLFile.Location = New System.Drawing.Point(26, 62)
        Me.butLoadXMLFile.Name = "butLoadXMLFile"
        Me.butLoadXMLFile.Size = New System.Drawing.Size(97, 48)
        Me.butLoadXMLFile.TabIndex = 0
        Me.butLoadXMLFile.Text = "Load XML File"
        Me.butLoadXMLFile.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(61, 35)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 13)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "Label1"
        '
        'butReadXML
        '
        Me.butReadXML.Location = New System.Drawing.Point(162, 62)
        Me.butReadXML.Name = "butReadXML"
        Me.butReadXML.Size = New System.Drawing.Size(95, 48)
        Me.butReadXML.TabIndex = 2
        Me.butReadXML.Text = "Read XML"
        Me.butReadXML.UseVisualStyleBackColor = True
        '
        'tbxProcess
        '
        Me.tbxProcess.Location = New System.Drawing.Point(162, 292)
        Me.tbxProcess.Multiline = True
        Me.tbxProcess.Name = "tbxProcess"
        Me.tbxProcess.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbxProcess.Size = New System.Drawing.Size(508, 281)
        Me.tbxProcess.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'butSaveXML
        '
        Me.butSaveXML.Location = New System.Drawing.Point(629, 62)
        Me.butSaveXML.Name = "butSaveXML"
        Me.butSaveXML.Size = New System.Drawing.Size(95, 48)
        Me.butSaveXML.TabIndex = 5
        Me.butSaveXML.Text = "Save New XML File"
        Me.butSaveXML.UseVisualStyleBackColor = True
        '
        'nudSection
        '
        Me.nudSection.Location = New System.Drawing.Point(79, 116)
        Me.nudSection.Name = "nudSection"
        Me.nudSection.Size = New System.Drawing.Size(54, 20)
        Me.nudSection.TabIndex = 6
        Me.nudSection.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 123)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Section"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ProcessToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(817, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenXMLFileToolStripMenuItem, Me.ToolStripSeparator1, Me.SaveXMLFileToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenXMLFileToolStripMenuItem
        '
        Me.OpenXMLFileToolStripMenuItem.Name = "OpenXMLFileToolStripMenuItem"
        Me.OpenXMLFileToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.OpenXMLFileToolStripMenuItem.Text = "Open XML File"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(138, 6)
        '
        'SaveXMLFileToolStripMenuItem
        '
        Me.SaveXMLFileToolStripMenuItem.Name = "SaveXMLFileToolStripMenuItem"
        Me.SaveXMLFileToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.SaveXMLFileToolStripMenuItem.Text = "Save XML File"
        '
        'ProcessToolStripMenuItem
        '
        Me.ProcessToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.XMLFileToolStripMenuItem})
        Me.ProcessToolStripMenuItem.Name = "ProcessToolStripMenuItem"
        Me.ProcessToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.ProcessToolStripMenuItem.Text = "Process"
        '
        'XMLFileToolStripMenuItem
        '
        Me.XMLFileToolStripMenuItem.Name = "XMLFileToolStripMenuItem"
        Me.XMLFileToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.XMLFileToolStripMenuItem.Text = "XML File"
        '
        'CheckBox1_ExportImageInfo
        '
        Me.CheckBox1_ExportImageInfo.AutoSize = True
        Me.CheckBox1_ExportImageInfo.Location = New System.Drawing.Point(321, 259)
        Me.CheckBox1_ExportImageInfo.Name = "CheckBox1_ExportImageInfo"
        Me.CheckBox1_ExportImageInfo.Size = New System.Drawing.Size(143, 17)
        Me.CheckBox1_ExportImageInfo.TabIndex = 9
        Me.CheckBox1_ExportImageInfo.Text = "Export Image Information"
        Me.CheckBox1_ExportImageInfo.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(299, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 44)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Pictures"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(441, 67)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(134, 40)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Match"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'c_DataGridView1_Catalog
        '
        Me.c_DataGridView1_Catalog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.c_DataGridView1_Catalog.Location = New System.Drawing.Point(724, 546)
        Me.c_DataGridView1_Catalog.Name = "c_DataGridView1_Catalog"
        Me.c_DataGridView1_Catalog.Size = New System.Drawing.Size(62, 48)
        Me.c_DataGridView1_Catalog.TabIndex = 12
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(817, 658)
        Me.Controls.Add(Me.c_DataGridView1_Catalog)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CheckBox1_ExportImageInfo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudSection)
        Me.Controls.Add(Me.butSaveXML)
        Me.Controls.Add(Me.tbxProcess)
        Me.Controls.Add(Me.butReadXML)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.butLoadXMLFile)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Classic Auto Parts Media Manager (c) 2016-2017 MGB"
        CType(Me.nudSection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.c_DataGridView1_Catalog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents butLoadXMLFile As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents butReadXML As Button
    Friend WithEvents tbxProcess As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents butSaveXML As Button
    Friend WithEvents nudSection As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenXMLFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SaveXMLFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProcessToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XMLFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckBox1_ExportImageInfo As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents c_DataGridView1_Catalog As DataGridView
End Class
