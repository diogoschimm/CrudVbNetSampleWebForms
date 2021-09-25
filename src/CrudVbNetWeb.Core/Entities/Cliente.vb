Imports CrudSampleNet.CrossCutting.All

Public Class Cliente

    Public Sub New(nome As String, documento As String)
        Me.Nome = nome
        Me.Documento = documento
        Validar()
    End Sub

    Public Sub New(idCliente As Integer, nome As String, documento As String)
        Me.IdCliente = idCliente
        Me.Nome = nome
        Me.Documento = documento
        Validar()
    End Sub

    Public Property IdCliente As Integer
    Public ReadOnly Property Nome As String
    Public ReadOnly Property Documento As String

    Private Sub Validar()
        If String.IsNullOrEmpty(Nome) Then
            Throw New DomainException("Nome é obrigatório")
        End If
        If String.IsNullOrEmpty(Documento) Then
            Throw New DomainException("Documento é obrigatório")
        End If
    End Sub

End Class
