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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtStudentAmount = New System.Windows.Forms.TextBox()
        Me.lblStudentsPrompt = New System.Windows.Forms.Label()
        Me.lblDisplay = New System.Windows.Forms.Label()
        Me.btnRead = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblButtonPrompt = New System.Windows.Forms.Label()
        Me.lblMainTitle = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(35, 115)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(109, 42)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add Students/Grades"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtStudentAmount
        '
        Me.txtStudentAmount.Font = New System.Drawing.Font("Rockwell", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStudentAmount.Location = New System.Drawing.Point(265, 78)
        Me.txtStudentAmount.Name = "txtStudentAmount"
        Me.txtStudentAmount.Size = New System.Drawing.Size(109, 20)
        Me.txtStudentAmount.TabIndex = 1
        '
        'lblStudentsPrompt
        '
        Me.lblStudentsPrompt.AutoSize = True
        Me.lblStudentsPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStudentsPrompt.Location = New System.Drawing.Point(36, 78)
        Me.lblStudentsPrompt.Name = "lblStudentsPrompt"
        Me.lblStudentsPrompt.Size = New System.Drawing.Size(223, 16)
        Me.lblStudentsPrompt.TabIndex = 2
        Me.lblStudentsPrompt.Text = "How many students are in the class?"
        '
        'lblDisplay
        '
        Me.lblDisplay.AutoSize = True
        Me.lblDisplay.Location = New System.Drawing.Point(416, 43)
        Me.lblDisplay.Name = "lblDisplay"
        Me.lblDisplay.Size = New System.Drawing.Size(0, 13)
        Me.lblDisplay.TabIndex = 3
        '
        'btnRead
        '
        Me.btnRead.Location = New System.Drawing.Point(150, 115)
        Me.btnRead.Name = "btnRead"
        Me.btnRead.Size = New System.Drawing.Size(109, 42)
        Me.btnRead.TabIndex = 4
        Me.btnRead.Text = "Read CSV"
        Me.btnRead.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(265, 114)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(109, 43)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear CSV"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(435, 245)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(109, 40)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search CSV for Student"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblButtonPrompt
        '
        Me.lblButtonPrompt.AutoSize = True
        Me.lblButtonPrompt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblButtonPrompt.Location = New System.Drawing.Point(23, 254)
        Me.lblButtonPrompt.Name = "lblButtonPrompt"
        Me.lblButtonPrompt.Size = New System.Drawing.Size(406, 20)
        Me.lblButtonPrompt.TabIndex = 8
        Me.lblButtonPrompt.Text = "Click the button to search for a student and their grades:"
        '
        'lblMainTitle
        '
        Me.lblMainTitle.AutoSize = True
        Me.lblMainTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMainTitle.Location = New System.Drawing.Point(60, 19)
        Me.lblMainTitle.Name = "lblMainTitle"
        Me.lblMainTitle.Size = New System.Drawing.Size(280, 37)
        Me.lblMainTitle.TabIndex = 9
        Me.lblMainTitle.Text = "Grading Program"
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtitle.Location = New System.Drawing.Point(21, 191)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(578, 31)
        Me.lblSubtitle.TabIndex = 10
        Me.lblSubtitle.Text = "Parent Teacher Interviews Search Function"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblSubtitle)
        Me.Controls.Add(Me.lblMainTitle)
        Me.Controls.Add(Me.lblButtonPrompt)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnRead)
        Me.Controls.Add(Me.lblDisplay)
        Me.Controls.Add(Me.lblStudentsPrompt)
        Me.Controls.Add(Me.txtStudentAmount)
        Me.Controls.Add(Me.btnAdd)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAdd As Button
    Friend WithEvents txtStudentAmount As TextBox
    Friend WithEvents lblStudentsPrompt As Label
    Friend WithEvents lblDisplay As Label
    Friend WithEvents btnRead As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblButtonPrompt As Label
    Friend WithEvents lblMainTitle As Label
    Friend WithEvents lblSubtitle As Label
End Class
