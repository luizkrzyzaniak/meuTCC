<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PesqOfertaCurso.aspx.cs" Inherits="Site.PesqOfertaCurso" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="_design/_css/telaFB.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function selecionar(id, descr) {

            window.parent.pesqOfertaRetorno(id, descr);
        }

        function add() {

            window.parent.add(oferta, curso);

        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="pag">
    <h3>Pesquisar Oferta Curso</h3>
        <ul>
            <asp:Panel ID="pUE" runat="server">
            
        <li>Selecione uma unidade de ensino:</li>
            <li>
                <asp:GridView ID="gvUE" runat="server" CellPadding="4" ForeColor="#333333" 
                    GridLines="None" Width="500px" AutoGenerateColumns="False">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Nome" HeaderText="Unidade de Ensino" />
                        <asp:BoundField DataField="Cidade" HeaderText="Cidade" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnSelecionar" runat="server" 
                                    CommandArgument='<%# Eval("CodUnidade") %>' oncommand="lbtnSelecionar_Command">Selecionar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
                <br />
            </li>
            </asp:Panel>
            <asp:Panel ID="pOferta" runat="server" Visible="False">
            
        <li>
            Selecione uma oferta de curso:</li>
            <li>
            <asp:GridView ID="gvOfertaCurso" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" ForeColor="#333333" GridLines="None" Width="500px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="CodOferta" HeaderText="Codigo" />
                    <asp:BoundField DataField="Desc" HeaderText="Descrição" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="javascript:;" onclick="selecionar(<%# Eval("CodOferta") %>, '<%# Eval("Desc") %>')">Selecionar</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
                <br />
                <asp:LinkButton ID="lbtnVoltar" runat="server" onclick="lbtnVoltar_Click">&lt;&lt; Voltar</asp:LinkButton>
            </li>
            </asp:Panel>
        </ul>
    </div>
    </form>
</body>
</html>
