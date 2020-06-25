<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="CadOfertarCurso.aspx.cs" Inherits="Site.CadOfertarCurso" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

        <script src="_scripts/fancyBox/lib/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="_scripts/fancyBox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="_scripts/fancyBox/source/jquery.fancybox.css" />

 <script type="text/javascript">
     function btnPesqCurso_Click() {

         $.fancybox.open({
             href: 'PesqCurso.aspx',
             type: 'iframe',
             padding: 5
         });


         return false;
     }


     function pesqCursoRetorno(id, descr) {

         $.fancybox.close();
         document.getElementById("hfCodCurso").value = id;
         document.getElementById("tbNome").value = descr;

     }

     
        function btnAjuda() {

            $.fancybox.open({
                href: '/Ajuda/cadOc.pdf',
                type: 'iframe',
                padding: 5
            });


            return false;
        }


     function btnPesqUE_Click() {

         $.fancybox.open({
             href: 'PesqUnidadeEnsino.aspx',
             type: 'iframe',
             padding: 5
         });


         return false;
     }


     function pesqUnidadeRetorno(id, descr) {

         $.fancybox.close();
         document.getElementById("hfCodUe").value = id;
         document.getElementById("tbNomeUE").value = descr;

     }

     function btnPesq_Click() {

         $.fancybox.open({
             href: 'PesqOfertaCurso.aspx',
             type: 'iframe',
             padding: 5
         });


         return false;
     }


     function pesqOfertaRetorno(id) {

         $.fancybox.close();
         document.location.href = "CadOfertarCurso.aspx?id=" + id;

     }

     function add(oferta, curso) {

         $.fancybox.close();
         document.location.href = "CadOfertaCursoModulo.aspx?oferta=" + oferta + "&cur=" + cur;

     }

        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h3>Cadastro de Ofertar Curso<asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return btnAjuda()">(?)Ajuda</asp:LinkButton></h3>
<ul id="listConteudo">
    <asp:HiddenField ID="hfCodOferta" runat="server" />
    <asp:HiddenField ID="hfCodCurso" runat="server" ClientIDMode="Static"/>
    <asp:HiddenField ID="hfCodUe" runat="server" ClientIDMode="Static"/>
        <li>Descrição:<br />
            <asp:TextBox ID="tbDescOC" runat="server" Width="400px" MaxLength="40"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="tbDescOC" ErrorMessage="Campo Obrigatorio" 
                SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
            </asp:ValidatorCalloutExtender>
    </li>
        <li>Curso:<br />
        <asp:TextBox ID="tbNome" runat="server" ClientIDMode="Static" Width="400px"></asp:TextBox>
        <asp:Button ID="btnPesqCurso" runat="server" 
            Text="Pesquisa Curso" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="tbNome" ErrorMessage="Campo Obrigatorio" 
                ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
            </asp:ValidatorCalloutExtender>
    </li>
    <li>
    
        <asp:TextBox ID="tbNomeUE" runat="server" ClientIDMode="Static" Width="400px"></asp:TextBox>
        <asp:Button ID="btnPesqUE" runat="server" 
            Text="Pesquisa Unidade de Ensino" />
    
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="tbNomeUE" ErrorMessage="Campo Obigatorio" 
            ValidationGroup="gravar">*</asp:RequiredFieldValidator>
        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
        </asp:ValidatorCalloutExtender>
    
    </li>
    <li>Dt. Inicio:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dt. Final:<br />
        <asp:TextBox ID="tbDtInicio" runat="server"></asp:TextBox>
        <asp:MaskedEditExtender ID="tbDtInicio_MaskedEditExtender" runat="server" 
            ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
            Mask="99/99/9999" TargetControlID="tbDtInicio">
        </asp:MaskedEditExtender>
&nbsp;&nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" 
            ControlToValidate="tbDtInicio" Display="Dynamic" ErrorMessage="Data Invalida" 
            MaximumValue="01/01/2050" MinimumValue="01/01/1900" Type="Date" 
            ValidationGroup="gravar">*</asp:RangeValidator>
        <asp:ValidatorCalloutExtender ID="RangeValidator1_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RangeValidator1">
        </asp:ValidatorCalloutExtender>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbDtFinal" runat="server"></asp:TextBox>
        <asp:MaskedEditExtender ID="tbDtFinal_MaskedEditExtender" runat="server" 
            ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
            Mask="99/99/9999" TargetControlID="tbDtFinal">
        </asp:MaskedEditExtender>
        <asp:RangeValidator ID="RangeValidator2" runat="server" 
            ControlToValidate="tbDtFinal" Display="Dynamic" ErrorMessage="Data Invalida" 
            MaximumValue="01/01/2050" MinimumValue="01/01/1900" Type="Date" 
            ValidationGroup="gravar">*</asp:RangeValidator>
        <asp:ValidatorCalloutExtender ID="RangeValidator2_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RangeValidator2">
        </asp:ValidatorCalloutExtender>
    </li>


    
    <li>
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" 
            onclick="btnGravar_Click" ValidationGroup="gravar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
            onclick="btnCancelar_Click" />
        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" 
            onclick="btnExcluir_Click" 
            onclientclick="return confirm(&quot;Deseja realmente excluir?&quot;)" 
            Enabled="False" />
        <asp:Button ID="btnPesq" runat="server" Text="Pesquisar" 
            onclientclick="return btnPesq_Click()" />
        <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" 
            Text="Adicionar" Enabled="False" />
        </li>
</ul>
</asp:Content>
