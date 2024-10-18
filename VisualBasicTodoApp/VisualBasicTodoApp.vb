Imports System.IO
Imports System.Runtime.Serialization
Imports System.Xml

''' <summary>The main form of the todo application.</summary>
Public Class VisualBasicTodoApp

    ''' <summary>The list of todo items currently active in the application.</summary>
    Private Property TodoItems As List(Of TodoItem)

    ''' <summary>The serializer used to read and write the todo items to an XML file.</summary>
    Private Property Serializer As DataContractSerializer

    ''' <summary>Update the list of todo items in the form.</summary>
    Private Sub UpdateTodoList()
        TodoList.Items.Clear()
        For Each item As TodoItem In TodoItems
            TodoList.Items.Add(item.Text)
            TodoList.SetItemChecked(TodoList.Items.Count - 1, item.Done)
        Next
    End Sub

    ''' <summary>Initialize the list of todo items and serializer on loading.</summary>
    ''' <param name="sender">The object that triggered the handler</param>
    ''' <param name="e">The event</param>
    Private Sub OnStartup(sender As Object, e As EventArgs) Handles MyBase.Load
        TodoItems = New List(Of TodoItem)
        Serializer = New DataContractSerializer(GetType(List(Of TodoItem)))
        UpdateTodoList()
    End Sub

    ''' <summary>Add a new item to the list when the Add button is clicked.</summary>
    ''' <param name="sender">The object that triggered the handler</param>
    ''' <param name="e">The event</param>
    Private Sub AddTodoItem(sender As Object, e As EventArgs) Handles AddItem.Click
        TodoItems.Add(New TodoItem(ItemInput.Text))
        ItemInput.Text = ""
        UpdateTodoList()
    End Sub

    ''' <summary>Enable the Add button when the input is not empty, disable otherwise</summary>
    ''' <param name="sender">The object that triggered the handler</param>
    ''' <param name="e">The event</param>
    Private Sub ToggleAddButton(sender As Object, e As EventArgs) Handles ItemInput.TextChanged
        AddItem.Enabled = ItemInput.Text.Length > 0
    End Sub

    ''' <summary>Add a new item to the list when the Enter key is pressed.</summary>
    ''' <param name="sender">The object that triggered the handler</param>
    ''' <param name="e">The event</param>
    Private Sub AddItemOnEnter(sender As Object, e As KeyPressEventArgs) Handles ItemInput.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            AddTodoItem(sender, e)
            e.Handled = True
        End If
    End Sub

    ''' <summary>Toggle the done state of the selected item when checked.</summary>
    ''' <param name="sender">The object that triggered the handler</param>
    ''' <param name="e">The event</param>
    Private Sub ItemChecked(sender As Object, e As ItemCheckEventArgs) Handles TodoList.ItemCheck
        If TodoList.SelectedIndex >= 0 Then
            TodoItems(TodoList.SelectedIndex).ToggleDoneState()
        End If
    End Sub

    ''' <summary>Remove the selected item from the list when backspace is pressed.</summary>
    ''' <param name="sender">The object that triggered the handler</param>
    ''' <param name="e">The event</param>
    Private Sub RemoveItem(sender As Object, e As KeyPressEventArgs) Handles TodoList.KeyPress
        If e.KeyChar = ChrW(Keys.Back) Then
            ' Display a confirmation dialog before deleting the item.
            Dim question As String = "Are you sure you want to delete this item?"
            Dim title As String = "Delete item"
            Dim result As DialogResult = MessageBox.Show(question, title, MessageBoxButtons.YesNo)

            ' If the user confirms the deletion, remove the item from the list.
            If result = DialogResult.Yes Then
                TodoItems.RemoveAt(TodoList.SelectedIndex)
                UpdateTodoList()
            End If

            ' Prevent the key press of the dialog from being handled by the list.
            e.Handled = True
        End If
    End Sub

    ''' <summary>Import a list of todo items from an XML file.</summary>
    ''' <param name="sender">The object that triggered the handler</param>
    ''' <param name="e">The event</param>
    Private Sub ImportTodoList(sender As Object, e As EventArgs) Handles ImportList.Click
        If OpenXMLTodoList.ShowDialog() = DialogResult.OK Then
            ' Deserialize the XML file into a list of TodoItems.
            Using fileStream As New FileStream(OpenXMLTodoList.FileName, FileMode.Open)
                Using reader As XmlReader = XmlReader.Create(fileStream)
                    TodoItems = DirectCast(Serializer.ReadObject(reader), List(Of TodoItem))
                End Using
            End Using

            ' Update the list in the form.
            UpdateTodoList()
        End If
    End Sub

    ''' <summary>Export the list of todo items to an XML file.</summary>
    ''' <param name="sender">The object that triggered the handler</param>
    ''' <param name="e">The event</param>
    Private Sub ExportTodoList(sender As Object, e As EventArgs) Handles ExportList.Click
        If SaveXMLTodoList.ShowDialog() = DialogResult.OK Then
            ' Serialize the list of TodoItems into an XML file.
            Using fileStream As New FileStream(SaveXMLTodoList.FileName, FileMode.Create)
                Using writer As XmlWriter = XmlWriter.Create(fileStream)
                    Serializer.WriteObject(writer, TodoItems)
                End Using
            End Using
        End If
    End Sub
End Class
