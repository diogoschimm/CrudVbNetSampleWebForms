Imports System.Web.Configuration
Imports CrudVbNetWeb.Data

Public Class Options
    Implements IOptions

    Public Function GetStrConexao() As String Implements IOptions.GetStrConexao
        Return WebConfigurationManager.ConnectionStrings("ConnectionStringBase").ConnectionString
    End Function

    Public Shared Function Create() As IOptions
        Return New Options()
    End Function

End Class
