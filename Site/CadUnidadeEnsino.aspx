<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="CadUnidadeEnsino.aspx.cs" Inherits="Site.CadUnidadeEnsino" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script src="_scripts/fancyBox/lib/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="_scripts/fancyBox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="_scripts/fancyBox/source/jquery.fancybox.css" />

    <script type="text/javascript">
        function btnPesq_Click() {

            $.fancybox.open({
                href: 'PesqUnidadeEnsino.aspx',
                type: 'iframe',
                padding: 5
            });


            return false;
        }


        function pesqUnidadeRetorno(id) {

            $.fancybox.close();
            document.location.href = "CadUnidadeEnsino.aspx?id=" + id;

        }

        function btnAjuda() {

            $.fancybox.open({
                href: '/Ajuda/cadUe.pdf',
                type: 'iframe',
                padding: 5
            });


            return false;
        }

        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h3>Cadastro de Unidade de Ensino<asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return btnAjuda()">(?)Ajuda</asp:LinkButton><asp:HiddenField ID="hfCodUE" runat="server" />
    </h3>
<ul id="listConteudo">
    <li>Unidade de Ensino:<br />
        <asp:TextBox ID="tbNome" runat="server" Width="400px" MaxLength="40"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="tbNome" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
            SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
        </asp:ValidatorCalloutExtender>
    </li>
    <li>Responsavel:<br />
        <asp:TextBox ID="tbResponsavel" runat="server" Width="400px" MaxLength="40"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="tbResponsavel" Display="Dynamic" 
            ErrorMessage="Campo Obrigatorio" SetFocusOnError="True" 
            ValidationGroup="gravar">*</asp:RequiredFieldValidator>
        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
        </asp:ValidatorCalloutExtender>
    </li>
    <li>Endereço:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nº:<br />
        <asp:TextBox ID="tbEndereco" runat="server" Width="340px" MaxLength="30"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="tbEndereco" Display="Dynamic" 
            ErrorMessage="Campo Obrigatorio" SetFocusOnError="True" 
            ValidationGroup="gravar">*</asp:RequiredFieldValidator>
        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
        </asp:ValidatorCalloutExtender>
        &nbsp;&nbsp;
        <asp:TextBox ID="tbNumero" runat="server" Width="50px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="tbNumero" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
            SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
        </asp:ValidatorCalloutExtender>
    </li>
    <li>Bairro:<br />
        <asp:TextBox ID="tbBairro" runat="server" Width="300px"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="tbBairro" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
            SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
        </asp:ValidatorCalloutExtender>
        &nbsp;&nbsp;
        </li>
    <li>Cidade:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        U.F.:<br />
        <asp:TextBox ID="tbCidade" runat="server" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ControlToValidate="tbCidade" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
            SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator6_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
        </asp:ValidatorCalloutExtender>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlUf" runat="server">
        </asp:DropDownList>
    </li>
    <li>Telefone:<br />
        <asp:TextBox ID="tbDDDFixo" runat="server" Width="50px"></asp:TextBox>
        <asp:MaskedEditExtender ID="tbDDDFixo_MaskedEditExtender" runat="server" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
            Mask="(99)" TargetControlID="tbDDDFixo">
        </asp:MaskedEditExtender>
        <asp:TextBox ID="tbNumFixo" runat="server"></asp:TextBox>
        <asp:MaskedEditExtender ID="tbNumFixo_MaskedEditExtender" runat="server" 
            CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
            CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
            Mask="9999-9999" TargetControlID="tbNumFixo">
        </asp:MaskedEditExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
            ControlToValidate="tbDDDFixo" Display="Dynamic" 
            ErrorMessage="Campo Obrigatorio" SetFocusOnError="True" 
            ValidationGroup="gravar">*</asp:RequiredFieldValidator>
        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
        </asp:ValidatorCalloutExtender>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
            ControlToValidate="tbNumFixo" Display="Dynamic" 
            ErrorMessage="Campo Obrigatorio" SetFocusOnError="True" 
            ValidationGroup="gravar">*</asp:RequiredFieldValidator>
    </li>
    <li>
        <asp:Button ID="btnGravar" runat="server" onclick="btnGravar_Click" 
            Text="Gravar" ValidationGroup="gravar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
            onclick="btnCancelar_Click" CausesValidation="False" />
        <asp:Button ID="btnExcluir" runat="server" onclick="btnExcluir_Click" 
            Text="Excluir" CausesValidation="False" 
            onclientclick="return confirm(&quot;Deseja realmente excluir?&quot;)" />
        <asp:Button ID="btnPesq" runat="server" Text="Pesquisar" 
            OnClientClick="return btnPesq_Click()" CausesValidation="False" />
    </li>
</ul>
</asp:Content>
