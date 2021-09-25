Imports CrudVbNetWeb.Core
Imports CrudVbNetWeb.Data

Public Class ClienteRepositoryFactory

    Public Shared Function Create() As IClienteRepository
        Return New ClienteRepository(Options.Create)
    End Function
End Class
