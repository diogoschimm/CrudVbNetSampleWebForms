Public Interface IClienteRepository

    Function GetAll() As List(Of Cliente)
    Function GetById(idCliente As Integer) As Cliente

    Sub Add(cliente As Cliente)
    Sub Update(cliente As Cliente)
    Sub Delete(cliente As Cliente)

End Interface
