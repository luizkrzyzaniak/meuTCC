<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="CadAlunos.aspx.cs" Inherits="Site.CadAlunos" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="_scripts/fancyBox/lib/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="_scripts/fancyBox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="_scripts/fancyBox/source/jquery.fancybox.css" />

    <script type="text/javascript">
        function btnPesq_Click() {

            $.fancybox.open({
                href: 'PesqAlunos.aspx',
                type: 'iframe',
                padding: 5
            });


            return false;
        }


        function pesqAlunoRetorno(id) {

            $.fancybox.close();
            document.location.href = "CadAlunos.aspx?id=" + id;

        }

        function btnAjuda() {

            $.fancybox.open({
                href: '/Ajuda/CadAluno.pdf',
                type: 'iframe',
                padding: 5
            });


            return false;
        }

        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
    <h3>Cadastro de Aluno<asp:LinkButton ID="LinkButton1" runat="server" 
            onclientclick="return btnAjuda()">(?)Ajuda</asp:LinkButton><asp:HiddenField ID="hfCodAluno" runat="server" />
    </h3>
    <ul id="listConteudo">
        <li>Nome:<br />
&nbsp;<asp:TextBox ID="tbNome" runat="server" Width="450px" MaxLength="40"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="tbNome" ErrorMessage="Campo Obrigatorio" 
                SetFocusOnError="True" ValidationGroup="gravar"> * </asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
            </asp:ValidatorCalloutExtender>
        </li>
        
        <li>CPF:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        RG:<br />
&nbsp;<asp:TextBox ID="tbCPF" runat="server" Width="200px"></asp:TextBox>
            <asp:MaskedEditExtender ID="tbCPF_MaskedEditExtender" runat="server" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="999.999.999-99" TargetControlID="tbCPF">
            </asp:MaskedEditExtender>
        &nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="tbCPF" Display="Dynamic" ErrorMessage="CPF Obtigatorio" 
                SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2" 
                PopupPosition="Left">
            </asp:ValidatorCalloutExtender>
            &nbsp;&nbsp; <asp:TextBox ID="tbRG" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="tbRG" Display="Dynamic" ErrorMessage="RG Obrigatorio" 
                SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
            </asp:ValidatorCalloutExtender>
        </li>
        
        <li>Data de Nascimento: 
            <br />
            <asp:TextBox ID="tbDtNasc" runat="server" Width="100px"></asp:TextBox>
            <asp:MaskedEditExtender ID="tbDtNasc_MaskedEditExtender" runat="server" 
                ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="99/99/9999" TargetControlID="tbDtNasc">
            </asp:MaskedEditExtender>
            <asp:RangeValidator ID="RangeValidator1" runat="server" 
                ControlToValidate="tbDtNasc" Display="Dynamic" ErrorMessage="Data Invalida" 
                MaximumValue="01/01/2050" MinimumValue="01/01/1900" Type="Date" 
                ValidationGroup="gravar">*</asp:RangeValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="tbDtNasc" Display="Dynamic" 
                ErrorMessage="Data de Nascimento Obrigatoria" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
            </asp:ValidatorCalloutExtender>
        </li>
        
        <li>Endereço:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Nº 
            <br />
            <asp:TextBox ID="tbEndereco" runat="server" Width="300px" MaxLength="30"></asp:TextBox>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="tbEndereco" Display="Dynamic" 
                ErrorMessage="Campo Obrigatorio" SetFocusOnError="True" 
                ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
            </asp:ValidatorCalloutExtender>
            &nbsp;&nbsp; <asp:TextBox ID="tbNumero" runat="server" Width="50px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="tbNumero" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
                SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator6_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
            </asp:ValidatorCalloutExtender>
            <asp:RangeValidator ID="RangeValidator2" runat="server" 
                ControlToValidate="tbNumero" Display="Dynamic" ErrorMessage="Somente numero" 
                MaximumValue="99999" MinimumValue="0" SetFocusOnError="True" Type="Integer" 
                ValidationGroup="gravar">*</asp:RangeValidator>
            <asp:ValidatorCalloutExtender ID="RangeValidator2_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RangeValidator2">
            </asp:ValidatorCalloutExtender>
        </li>
        
        <li>Bairro:<br />
            <asp:TextBox ID="tbBairro" runat="server" Width="350px" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                ControlToValidate="tbBairro" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
                SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator7_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator7">
            </asp:ValidatorCalloutExtender>
            &nbsp;&nbsp;&nbsp;&nbsp; 
        </li>
        <li>Cidade:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            U.F.:<br />
            <asp:TextBox ID="tbCidade" runat="server" Width="250px" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ControlToValidate="tbCidade" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
                SetFocusOnError="True">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator8_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator8">
            </asp:ValidatorCalloutExtender>
&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlUF" runat="server">
            </asp:DropDownList>
        </li>
        
        <li>Telefone: 
            <br />
            <asp:TextBox ID="tbDDDFixo" runat="server" Width="50px"></asp:TextBox>
            <asp:MaskedEditExtender ID="tbDDDFixo_MaskedEditExtender" runat="server" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="(99)" TargetControlID="tbDDDFixo">
            </asp:MaskedEditExtender>
        <asp:TextBox ID="tbNumFixo" runat="server" Width="200px"></asp:TextBox>
            <asp:MaskedEditExtender ID="tbNumFixo_MaskedEditExtender" runat="server" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="9999-9999" TargetControlID="tbNumFixo">
            </asp:MaskedEditExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                ControlToValidate="tbDDDFixo" Display="Dynamic" ErrorMessage="DDD Obrigatorio" 
                ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator9_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator9">
            </asp:ValidatorCalloutExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                ControlToValidate="tbNumFixo" Display="Dynamic" 
                ErrorMessage="Campo Obrigatorio" SetFocusOnError="True" 
                ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator10_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator10">
            </asp:ValidatorCalloutExtender>
        </li>
        
        <li>Celular:<br />
&nbsp;<asp:TextBox ID="tbDDDCel" runat="server" Width="50px"></asp:TextBox>
            <asp:MaskedEditExtender ID="tbDDDCel_MaskedEditExtender" runat="server" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="(99)" TargetControlID="tbDDDCel">
            </asp:MaskedEditExtender>
        <asp:TextBox ID="tbNumCel" runat="server" Width="200px"></asp:TextBox>
            <asp:MaskedEditExtender ID="tbNumCel_MaskedEditExtender" runat="server" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="9999-9999" TargetControlID="tbNumCel">
            </asp:MaskedEditExtender>
        </li>
        
        <li>
            <asp:Button ID="btnGravar" runat="server" Text="Gravar" 
                onclick="btnGravar_Click" ValidationGroup="gravar" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                onclick="btnCancelar_Click" CausesValidation="False" />
            <asp:Button ID="btnEcluir" runat="server" CausesValidation="False" 
                onclick="btnEcluir_Click" Text="Excluir" 
                onclientclick="return confirm(&quot;Deseja realmente excluir?&quot;)" />
            <asp:Button ID="btnPesq" runat="server" Text="Pesquisar" 
                OnClientClick="return btnPesq_Click()" CausesValidation="False" /></li>    
    </ul>
</asp:Content>
