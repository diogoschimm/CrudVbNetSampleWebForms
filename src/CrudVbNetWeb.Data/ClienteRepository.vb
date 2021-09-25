Imports System.Data.SqlClient
Imports CrudVbNetWeb.Core

Public Class ClienteRepository
    Inherits RepositoryBase
    Implements IClienteRepository

    Public Sub New(options As IOptions)
        MyBase.New(options)
    End Sub

    Public Function GetAll() As List(Of Cliente) Implements IClienteRepository.GetAll
        Using conexao As New SqlConnection(Options.GetStrConexao())
            conexao.Open()
            Using adp As New SqlDataAdapter("SELECT * FROM Clientes", conexao)
                Dim dt As New DataTable
                adp.Fill(dt)

                Dim clientes As New List(Of Cliente)

                For Each dr As DataRow In dt.Rows
                    Dim idCliente = dr.Item("idCliente").ToString()
                    Dim nome = dr.Item("nomeCliente").ToString()
                    Dim documento = dr.Item("documentoCliente").ToString()

                    clientes.Add(New Cliente(idCliente, nome, documento))
                Next

                Return clientes
            End Using
        End Using
    End Function

    Public Function GetById(idCliente As Integer) As Cliente Implements IClienteRepository.GetById
        Using conexao As New SqlConnection(Options.GetStrConexao())
            conexao.Open()
            Using cmd As New SqlCommand("SELECT * FROM Clientes WHERE idCliente = @idCliente", conexao)

                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente
                Dim dr = cmd.ExecuteReader()

                If dr.Read Then

                    Dim nome = dr.Item("nomeCliente").ToString()
                    Dim documento = dr.Item("documentoCliente").ToString()

                    Return New Cliente(idCliente, nome, documento)

                End If
            End Using
        End Using

        Return Nothing
    End Function

    Public Sub Add(cliente As Cliente) Implements IClienteRepository.Add
        Using conexao As New SqlConnection(Options.GetStrConexao())
            conexao.Open()
            Using cmd As New SqlCommand("INSERT INTO Clientes (nomeCliente, documentoCliente) VALUES (@nomeCliente, @documentoCliente); SET @idCliente = @@IDENTITY", conexao)

                cmd.Parameters.Add("@nomeCliente", SqlDbType.VarChar, 100).Value = cliente.Nome
                cmd.Parameters.Add("@documentoCliente", SqlDbType.VarChar, 14).Value = cliente.Documento
                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Direction = ParameterDirection.Output
                cmd.ExecuteNonQuery()

                cliente.IdCliente = cmd.Parameters("@idCliente").Value

            End Using
        End Using
    End Sub

    Public Sub Update(cliente As Cliente) Implements IClienteRepository.Update
        Using conexao As New SqlConnection(Options.GetStrConexao())
            conexao.Open()
            Using cmd As New SqlCommand("UPDATE Clientes SET nomeCliente = @nomeCliente, documentoCliente = @documentoCliente WHERE idCliente = @idCliente", conexao)

                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = cliente.IdCliente
                cmd.Parameters.Add("@nomeCliente", SqlDbType.VarChar, 100).Value = cliente.Nome
                cmd.Parameters.Add("@documentoCliente", SqlDbType.VarChar, 14).Value = cliente.Documento

                cmd.ExecuteNonQuery()

            End Using
        End Using
    End Sub

    Public Sub Delete(cliente As Cliente) Implements IClienteRepository.Delete
        Using conexao As New SqlConnection(Options.GetStrConexao())
            conexao.Open()
            Using cmd As New SqlCommand("DELETE FROM Clientes WHERE idCliente = @idCliente", conexao)

                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = cliente.IdCliente
                cmd.ExecuteNonQuery()

            End Using
        End Using
    End Sub

End Class
