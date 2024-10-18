Imports System.Runtime.Serialization

''' <summary>A todo item represented by a text and a boolean status.</summary>
<DataContract>
Public Class TodoItem

    ''' <summary>Private property that represents the text of the todo item.</summary>
    <DataMember>
    Private _text As String

    ''' <summary>Private property that represents the status of the todo item.</summary>
    <DataMember>
    Private _done As Boolean

    ''' <summary>The text that represents the todo item.</summary>
    Public ReadOnly Property Text As String
        Get
            Return _text
        End Get
    End Property

    ''' <summary>A boolean that represents the status of the todo item.</summary>
    Public ReadOnly Property Done As Boolean
        Get
            Return _done
        End Get
    End Property

    ''' <summary>Create a new todo item with the given text and optional status.</summary>
    ''' <param name="text">The text that will represents the todo item.</param>
    ''' <param name="done">The status of the item, defaults to False.</param>
    Public Sub New(text As String, Optional done As Boolean = False)
        Me._text = text
        Me._done = done
    End Sub

    ''' <summary>Toggles the state of the task between done and not done.</summary>
    Public Sub ToggleDoneState()
        _done = Not _done
    End Sub
End Class
