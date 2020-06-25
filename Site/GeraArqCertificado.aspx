<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="GeraArqCertificado.aspx.cs" Inherits="Site.GeraArqCertificado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script src="_scripts/fancyBox/lib/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="_scripts/fancyBox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="_scripts/fancyBox/source/jquery.fancybox.css" />

 <script type="text/javascript">
     

     function btnPesq_Click() {

         $.fancybox.open({
             href: 'PesqOfertaCurso.aspx',
             type: 'iframe',
             padding: 5
         });


         return false;
     }


     function pesqOfertaRetorno(id, descr) {

         $.fancybox.close();
         document.location.href = "GeraArqCertificado.aspx?id=" + id + "&desc=" + descr;

     }

     function add(oferta, curso) {

         $.fancybox.close();
         document.location.href = "GeraArqCertificado.aspx?oferta=" + oferta + "&cur=" + cur;

     }

    
        function btnAjuda() {

            $.fancybox.open({
                href: '/Ajuda/gerarCSV.pdf',
                type: 'iframe',
                padding: 5
            });


            return false;
        }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h3>Gerar Arquivo .CSV para Certificado<asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return btnAjuda()">(?)Ajuda</asp:LinkButton></h3>
<ul id="listConteudo">
<li>Oferta de Curso:<asp:HiddenField ID="hfOferta" runat="server" />
    <br />
    <asp:TextBox ID="tbPesq" runat="server" Width="300px"></asp:TextBox>
    <asp:Button ID="btnPesq" runat="server" Text="Pesquisar Oferta De Curso" 
        onclientclick="return btnPesq_Click()" />
    </li>
<li>
    <asp:Button ID="btnGerar" runat="server" onclick="btnGerar_Click" 
        Text="Gerar Arquivo .CSV" Visible="False" Width="200px" />
    </li>
</ul>
</asp:Content>
