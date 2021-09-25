Imports CrudVbNetWeb.Core

Public Class formClientes
    Inherits System.Web.UI.Page

#Region "Eventos da Página"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CarregarGrid()
            ColocarTelaEmListagem()
        End If
    End Sub

    Protected Sub btnAdicionar_Click(sender As Object, e As EventArgs) Handles btnAdicionar.Click
        ColocarTelaEmCadastro()
    End Sub

    Private Sub gvListagem_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvListagem.RowCommand
        Try
            If e.CommandName = "Editar" Then
                Dim cliente = ClienteRepositoryFactory.Create().GetById(e.CommandArgument.ToString())
                If cliente IsNot Nothing Then

                    Me.litIdCliente.Text = cliente.IdCliente.ToString()
                    Me.txtNomeCliente.Text = cliente.Nome
                    Me.txtDocumentoCliente.Text = cliente.Documento

                    ColocarTelaEmEdicao()
                End If

            ElseIf e.CommandName = "Excluir" Then
                Dim clienteRepository = ClienteRepositoryFactory.Create()
                Dim cliente = clienteRepository.GetById(e.CommandArgument.ToString())
                If cliente IsNot Nothing Then

                    clienteRepository.Delete(cliente)
                    Mensagem.Sucesso(Me.Page, "Registro excluído com sucesso")

                    CarregarGrid()

                End If
            End If
        Catch ex As Exception
            Me.lit_mensagem.Text = ex.Message
        End Try
    End Sub

    Private Sub gvListagem_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvListagem.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim idCliente = DataBinder.Eval(e.Row.DataItem, "idCliente").ToString

            Dim linkBtnEditar As LinkButton = e.Row.FindControl("linkBtnEditar")
            linkBtnEditar.CommandArgument = idCliente

            Dim linkBtnExcluir As LinkButton = e.Row.FindControl("linkBtnExcluir")
            linkBtnExcluir.CommandArgument = idCliente
        End If
    End Sub

    Private Sub btnSalvar_Click(sender As Object, e As EventArgs) Handles btnSalvar.Click
        Try
            Dim cliente = ObterCliente()
            Dim clienteRepository = ClienteRepositoryFactory.Create

            If IsEdicao Then
                clienteRepository.Update(cliente)
                Mensagem.Sucesso(Me.Page, "Registro atualizado com sucesso")

            Else
                clienteRepository.Add(cliente)
                Mensagem.Sucesso(Me.Page, "Registro cadastrado com sucesso")
            End If

            Me.CarregarGrid()
            Me.ColocarTelaEmListagem()

        Catch ex As Exception
            Me.lit_mensagem.Text = ex.Message
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        ColocarTelaEmListagem()
    End Sub


#End Region

#Region "Métodos"
    Private ReadOnly Property IsEdicao As Boolean
        Get
            Return Me.litOperacao.Text = "Edição"
        End Get
    End Property

    Private Sub ColocarTelaEmListagem()
        litOperacao.Text = "Listagem"
        AbrirFormulario(False)
    End Sub

    Private Sub ColocarTelaEmCadastro()
        litOperacao.Text = "Cadastro"
        AbrirFormulario(True)
        LimparCampos()
    End Sub

    Private Sub ColocarTelaEmEdicao()
        litOperacao.Text = "Edição"
        AbrirFormulario(True)
    End Sub

    Private Sub AbrirFormulario(isCadastro As Boolean)
        Me.lit_mensagem.Text = ""

        pnlListagem.Visible = Not isCadastro
        pnlCadastro.Visible = isCadastro

        btnAdicionar.Enabled = Not isCadastro
        btnSalvar.Enabled = isCadastro
        btnCancelar.Enabled = isCadastro
    End Sub

    Private Sub CarregarGrid()
        Dim clientes = ClienteRepositoryFactory.Create().GetAll()

        gvListagem.DataSource = clientes
        gvListagem.DataBind()
        gvListagem.Caption = $"Total de Registros: {clientes.Count}"
    End Sub

    Private Function ObterCliente() As Cliente
        Dim nome = Me.txtNomeCliente.Text
        Dim documento = Me.txtDocumentoCliente.Text

        If Me.IsEdicao Then
            Return New Cliente(Me.litIdCliente.Text, nome, documento)
        Else
            Return New Cliente(nome, documento)
        End If
    End Function

    Private Sub LimparCampos()
        Me.litIdCliente.Text = "Automático"
        Me.txtNomeCliente.Text = ""
        Me.txtDocumentoCliente.Text = ""
    End Sub

#End Region

End Class