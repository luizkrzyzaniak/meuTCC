<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PesqUnidadeEnsino.aspx.cs" Inherits="Site.PesqUnidadeEnsino" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="_design/_css/telaFB.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function selecionar(id, descr) {

            window.parent.pesqUnidadeRetorno(id, descr);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="pag">
    <h3>Pesquisar Unidade de Ensino</h3>
    <ul>
        <li>
            Unidade de Ensino:<br />
            <asp:TextBox ID="tbPesq" runat="server" Width="400px"></asp:TextBox>
            <asp:Button ID="btnPesq" runat="server" onclick="btnPesq_Click" 
                Text="Pesquisar" />
        </li>
        <li>
            <asp:GridView ID="gvUE" runat="server" AutoGenerateColumns="False" 
                Width="485px" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    <asp:BoundField DataField="Cidade" HeaderText="Cidade" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <a href="javascript:;" onclick="selecionar(<%# Eval("CodUnidade")%>,'<%# Eval("Nome") %>')">Selecionar</a>
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
            <br />
            <br />
            <br />
        </li>
    </ul>
    </div>
    </form>
</body>
</html>
