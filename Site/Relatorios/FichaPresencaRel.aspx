<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="FichaPresencaRel.aspx.cs" Inherits="Site.Relatorios.FichaPresencaRel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="../_scripts/fancyBox/lib/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="../_scripts/fancyBox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../_scripts/fancyBox/source/jquery.fancybox.css" />

    <script type="text/javascript">
        function btnPesq_Click() {

            $.fancybox.open({
                href: '../PesqProfessor.aspx',
                type: 'iframe',
                padding: 5
            });


            return false;
        }


        function pesqProfessorRetorno(id, descr) {

            $.fancybox.close();
            document.location.href = "Relatorios/FichaPresencaRel.aspx?id=" + id + "&desc=" + descr;

        }

        
        function btnAjuda() {

            $.fancybox.open({
                href: '../Ajuda/fichaPre.pdf',
                type: 'iframe',
                padding: 5
            });


            return false;
        }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h3>Ficha de Presença<asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return btnAjuda()">(?)Ajuda</asp:LinkButton></h3>
<ul id="listConteudo">
<li>
    <asp:TextBox ID="tbProf" runat="server" Width="300px"></asp:TextBox>
    <asp:Button ID="btnPesq" runat="server" Text="Pesquisar Professor" 
        onclientclick="return btnPesq_Click()" />
    </li>
<li>
    <asp:Panel ID="pModulos" runat="server">
        <asp:GridView ID="gvModulos" runat="server" 
    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
    GridLines="None" Width="300px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Modulo.DesModulo" HeaderText="Modulo" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnSelec" runat="server" 
                            CommandArgument='<%# Eval("Ocm.OcCod")+ "," + Eval("Modulo.CodModulo") + "," + Eval("Modulo.DesModulo") %>' 
                            oncommand="lbtnSelec_Command"> Gerar Ficha</asp:LinkButton>
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
    </asp:Panel>
    </li>
</ul>

</asp:Content>
