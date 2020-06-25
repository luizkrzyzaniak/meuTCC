<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="RelAlunosDevedores.aspx.cs" Inherits="Site.Relatorios.RelAlunosDevedores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../_scripts/fancyBox/lib/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../_scripts/fancyBox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../_scripts/fancyBox/source/jquery.fancybox.css" />
<script type="text/javascript">
        function btnAjuda() {

            $.fancybox.open({
                href: '/Ajuda/principal.pdf',
                type: 'iframe',
                padding: 5
            });


            return false;
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h3>Relatorio de Alunos Devedores por Cidade<asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return btnAjuda()">(?)Ajuda</asp:LinkButton></h3>
<ul id="listConteudo">
<li>Cidades:<asp:GridView ID="gvCidades" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="300px" 
        onrowdatabound="gvCidades_RowDataBound">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="Cidade" HeaderText="Nome da Cidade" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lbtnSelecionar" runat="server" 
                    CommandArgument='<%# Eval("Cidade") %>' oncommand="lbtnSelecionar_Command">Selecionar</asp:LinkButton>
                <asp:Literal ID="txt" runat="server"></asp:Literal>
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
    </li>
</ul>
</asp:Content>
