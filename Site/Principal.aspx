<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Site.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="_scripts/fancyBox/lib/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="_scripts/fancyBox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="_scripts/fancyBox/source/jquery.fancybox.css" />

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
    <asp:LinkButton ID="lbtnAjuda" runat="server" onclientclick="return btnAjuda()">(?)Ajuda</asp:LinkButton><br />
    <div id="imgLogoPagPrinc">
    <asp:Image ID="Image1" runat="server" ImageUrl="~/_design/imgs/Logo.png" />
    </div>
</asp:Content>
