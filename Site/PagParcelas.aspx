<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="PagParcelas.aspx.cs" Inherits="Site.PagParcelas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="_scripts/fancyBox/lib/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="_scripts/fancyBox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="_scripts/fancyBox/source/jquery.fancybox.css" />

 <script type="text/javascript">

function btnPesquisar_Click() {

         $.fancybox.open({
             href: 'PesqMatricula.aspx',
             type: 'iframe',
             padding: 5
         });


         return false;
     }


     function pesqMatriculaRetorno(id, descr) {

         $.fancybox.close();
         document.location.href = "PagParcelas.aspx?id=" + id + "&alu="+ descr;


     }

     
        function btnAjuda() {

            $.fancybox.open({
                href: '/Ajuda/Pag.pdf',
                type: 'iframe',
                padding: 5
            });


            return false;
        }

     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h3>Pagamento de Parcelas<asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return btnAjuda()">(?)Ajuda</asp:LinkButton></h3>
<ul id="listConteudo">
<li>Nome do aluno:<br />
    <asp:TextBox ID="tbAluno" runat="server" Width="300px"></asp:TextBox>
    <asp:Button ID="btnPesquisar" runat="server" 
        Text="Pesquisar Matricula por Aluno" 
        onclientclick="return btnPesquisar_Click()" />
    </li>
    <asp:GridView ID="gvParcelas" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="400px" 
        onrowdatabound="gvParcelas_RowDataBound">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField />
            <asp:BoundField DataField="DtVencimento" DataFormatString="{0:dd/MM/yyyy}" 
                HeaderText="Data de Vencimento" />
            <asp:BoundField DataField="DtPagamento" HeaderText="Data de Pagamento" 
                DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Valor" HeaderText="Valor" 
                DataFormatString="{0:N2}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Literal ID="ltCk" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <EmptyDataTemplate>
            das
        </EmptyDataTemplate>
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
<li>
    <asp:Button ID="btnSelec" runat="server" onclick="btnSelec_Click" 
        Text="Selecionar Parcelas" Visible="False" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lValor" runat="server" CssClass="valor" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnConf" runat="server" Text="Confirmar" Visible="False" 
        onclick="btnConf_Click" />
    <asp:LinkButton ID="lbtnImprimir" runat="server" onclick="lbtnImprimir_Click" 
        Visible="False">Imprimir Recibo</asp:LinkButton>
    </li>
</ul>
</asp:Content>
