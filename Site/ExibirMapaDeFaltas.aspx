<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExibirMapaDeFaltas.aspx.cs" Inherits="Site.ExibirMapaDeFaltas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mapa de Faltas</title>
    <link href="_design/_css/telaFB.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ul>
            <h3>Mapa de Faltas 
                <asp:Literal ID="lModNome" runat="server"></asp:Literal></h3>
            <li>
                <asp:GridView ID="gvMapa" runat="server" CellPadding="3" Font-Size="Small" 
                    ForeColor="Black" GridLines="Vertical" BackColor="White" 
                    BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" 
                        Font-Size="8px"/>
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle HorizontalAlign="Center"/>
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">&lt;&lt; Voltar</asp:LinkButton>
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
