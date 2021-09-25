<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="formClientes.aspx.vb" Inherits="CrudVbNetWeb.formClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scm" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="updPnlGeral" runat="server" UpdateMode="Conditional">
            <ContentTemplate>

                <div>
                    <h2>Clientes -
                        <asp:Literal ID="litOperacao" runat="server"></asp:Literal></h2>
                    <div class="operacoes">
                        <asp:Button ID="btnAdicionar" runat="server" Text="Novo" CausesValidation="false" />
                        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CausesValidation="false" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CausesValidation="false" />
                    </div>
                    <asp:Panel ID="pnlListagem" runat="server" CssClass="listagem">
                        <asp:GridView ID="gvListagem" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Editar">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkBtnEditar" runat="server" Text="Editar" CommandName="Editar"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Excluir">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="linkBtnExcluir" runat="server" Text="Excluir" CommandName="Excluir"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="idCliente" HeaderText="ID" />
                                <asp:BoundField DataField="nome" HeaderText="Nome" />
                                <asp:BoundField DataField="documento" HeaderText="Documento" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <asp:Panel ID="pnlCadastro" runat="server" CssClass="cadastro">
                        <div class="row">
                            <div class="col">
                                <label>ID Cliente</label>
                                <div class="data">
                                    <asp:Literal ID="litIdCliente" runat="server"></asp:Literal>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Nome Cliente</label>
                                <div class="data">
                                    <asp:TextBox ID="txtNomeCliente" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Documento Cliente</label>
                                <div class="data">
                                    <asp:TextBox ID="txtDocumentoCliente" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>                        
                    </asp:Panel>
                </div>
                <div class="mensagem">
                    <asp:Literal ID="lit_mensagem" runat="server"></asp:Literal>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
