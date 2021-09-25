Public Class Mensagem

    Public Shared Sub Sucesso(page As Page, mensagem As String)
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "sucess", $"alert('{mensagem}')", True)
    End Sub

    Public Shared Sub [Error](page As Page, mensagem As String)
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "errorPage", $"alert('{mensagem}')", True)
    End Sub

End Class
