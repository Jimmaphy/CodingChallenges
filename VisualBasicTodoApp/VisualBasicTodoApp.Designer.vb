<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VisualBasicTodoApp
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
        ImportList = New Button()
        ExportList = New Button()
        TodoList = New CheckedListBox()
        ItemInput = New TextBox()
        AddItem = New Button()
        OpenXMLTodoList = New OpenFileDialog()
        SaveXMLTodoList = New SaveFileDialog()
        SuspendLayout()
        ' 
        ' ImportList
        ' 
        ImportList.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        ImportList.Location = New Point(12, 455)
        ImportList.Name = "ImportList"
        ImportList.Size = New Size(225, 34)
        ImportList.TabIndex = 0
        ImportList.Text = "Import todo list"
        ImportList.UseVisualStyleBackColor = True
        ' 
        ' ExportList
        ' 
        ExportList.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        ExportList.Location = New Point(241, 455)
        ExportList.Name = "ExportList"
        ExportList.Size = New Size(225, 34)
        ExportList.TabIndex = 1
        ExportList.Text = "Export todo list"
        ExportList.UseVisualStyleBackColor = True
        ' 
        ' TodoList
        ' 
        TodoList.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TodoList.FormattingEnabled = True
        TodoList.Location = New Point(12, 53)
        TodoList.Name = "TodoList"
        TodoList.Size = New Size(454, 396)
        TodoList.TabIndex = 2
        ' 
        ' ItemInput
        ' 
        ItemInput.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        ItemInput.Location = New Point(12, 12)
        ItemInput.Name = "ItemInput"
        ItemInput.PlaceholderText = "Add a new todo item"
        ItemInput.Size = New Size(336, 31)
        ItemInput.TabIndex = 3
        ' 
        ' AddItem
        ' 
        AddItem.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        AddItem.Enabled = False
        AddItem.Location = New Point(354, 10)
        AddItem.Name = "AddItem"
        AddItem.Size = New Size(112, 34)
        AddItem.TabIndex = 4
        AddItem.Text = "Add item"
        AddItem.UseVisualStyleBackColor = True
        ' 
        ' OpenXMLTodoList
        ' 
        OpenXMLTodoList.FileName = "OpenFileDialog1"
        OpenXMLTodoList.Filter = "XML files (*.xml)|*.xml"
        OpenXMLTodoList.Title = "Select a Todo List XML file to import"
        ' 
        ' SaveXMLTodoList
        ' 
        SaveXMLTodoList.Filter = "XML files (*.xml)|*.xml"
        SaveXMLTodoList.Title = "Select a location to save the todo list XML file"
        ' 
        ' VisualBasicTodoApp
        ' 
        AutoScaleDimensions = New SizeF(144F, 144F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(478, 501)
        Controls.Add(AddItem)
        Controls.Add(ItemInput)
        Controls.Add(ExportList)
        Controls.Add(TodoList)
        Controls.Add(ImportList)
        Name = "VisualBasicTodoApp"
        Text = "VisualBasic Todo"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ImportList As Button
    Friend WithEvents ExportList As Button
    Friend WithEvents TodoList As CheckedListBox
    Friend WithEvents ItemInput As TextBox
    Friend WithEvents AddItem As Button
    Friend WithEvents OpenXMLTodoList As OpenFileDialog
    Friend WithEvents SaveXMLTodoList As SaveFileDialog

End Class
