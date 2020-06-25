<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="CadCurso.aspx.cs" Inherits="Site.CadCurso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="_scripts/fancyBox/lib/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="_scripts/fancyBox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="_scripts/fancyBox/source/jquery.fancybox.css" />

    <script type="text/javascript">
        function btnPesq_Click() {

            $.fancybox.open({
                href: 'PesqCurso.aspx',
                type: 'iframe',
                padding: 5
            });


            return false;
        }


        function pesqCursoRetorno(id) {

            $.fancybox.close();
            document.location.href = 'CadCurso.aspx?id=' + id;

        }

        function btnMod_Click(id) {

            $.fancybox.open({
                href: "CadModulo.aspx?id=" + id,
                type: 'iframe',
                padding: 5
            });


            return false;
        }

        
        function btnAjuda() {

            $.fancybox.open({
                href: '/Ajuda/CadCurso.pdf',
                type: 'iframe',
                padding: 5
            });


            return false;
        }

        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h3>Cadastro de Curso<asp:LinkButton ID="LinkButton1" runat="server" 
        onclientclick="return btnAjuda()">(?)Ajuda</asp:LinkButton><asp:HiddenField ID="hfCodCurso" runat="server" />
    </h3>
<ul id="listConteudo">
    <li>Descrição do Curso:<br />
        <asp:TextBox ID="tbDescCurso" runat="server" Width="500px" MaxLength="30"></asp:TextBox>
    </li>
    <li>
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" 
            onclick="btnGravar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
            onclick="btnCancelar_Click" />
        <asp:Button ID="btnPesq" runat="server" Text="Pesquisar" OnClientClick="return btnPesq_Click()"/>
        <asp:Button ID="btnAddModulos" runat="server" Text="Adicionar Modulos" 
            Enabled="False" OnClientClick="return btnMod_Click(<%# Convert.toInt32(hfCodCurso.value) %>)" />
        <asp:Button ID="btnFinal" runat="server" onclick="btnFinal_Click" 
            Text="Finalizar" Visible="False" />
        <br />
    </li>
    <li></li>
</ul>
</asp:Content>
