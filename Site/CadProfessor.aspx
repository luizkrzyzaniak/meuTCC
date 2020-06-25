<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="CadProfessor.aspx.cs" Inherits="Site.CadProfessor" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

    <script src="_scripts/fancyBox/lib/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="_scripts/fancyBox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="_scripts/fancyBox/source/jquery.fancybox.css" />

    <script type="text/javascript">
        function btnPesq_Click() {

            $.fancybox.open({
                href: 'PesqProfessor.aspx',
                type: 'iframe',
                padding: 5
            });


            return false;
        }


        function pesqProfessorRetorno(id, descr) {

            $.fancybox.close();
            document.location.href = "CadProfessor.aspx?id=" + id;

        }

        
        function btnAjuda() {

            $.fancybox.open({
                href: '/Ajuda/cadProf.pdf',
                type: 'iframe',
                padding: 5
            });


            return false;
        }

        </script>
        

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h3>Cadastro de Professor<asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return btnAjuda()">(?)Ajuda</asp:LinkButton><asp:HiddenField ID="hfCodProf" runat="server" />
    </h3>
    <ul id="listConteudo">
        <li>Nome:<br />
&nbsp;<asp:TextBox ID="tbNome" runat="server" Width="450px" MaxLength="40"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="tbNome" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
                SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
            </asp:ValidatorCalloutExtender>
        </li>
        
        <li>CPF:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        RG:<br />
&nbsp;<asp:TextBox ID="tbCPF" runat="server" Width="200px"></asp:TextBox>
            <asp:MaskedEditExtender ID="tbCPF_MaskedEditExtender" runat="server" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="999.999.999-99" TargetControlID="tbCPF">
            </asp:MaskedEditExtender>
        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="tbCPF" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
                SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
            </asp:ValidatorCalloutExtender>
            &nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbRG" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="tbRG" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
                SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
            </asp:ValidatorCalloutExtender>
        </li>
        
        <li>Data Nascimento: 
            <br />
            <asp:TextBox ID="tbDtNasc" runat="server" Width="100px"></asp:TextBox>
            <asp:MaskedEditExtender ID="tbDtNasc_MaskedEditExtender" runat="server" 
                ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="99/99/9999" TargetControlID="tbDtNasc">
            </asp:MaskedEditExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="tbDtNasc" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
                ValidationGroup="gravar">*</asp:RequiredFieldValidator>
        </li>
        
        <li>Endereço:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Nº 
            <br />
            <asp:TextBox ID="tbEndereco" runat="server" Width="300px" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="tbEndereco" Display="Dynamic" 
                ErrorMessage="Campo Obrigatorio" SetFocusOnError="True" 
                ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator5_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator5">
            </asp:ValidatorCalloutExtender>
        &nbsp;&nbsp;&nbsp; <asp:TextBox ID="tbNumero" runat="server" Width="50px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="tbNumero" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
                SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator6_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator6">
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
        <li>Cidade:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            U.F.:<br />
            <asp:TextBox ID="tbCidade" runat="server" Width="250px" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ControlToValidate="tbCidade" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
                SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
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
                ControlToValidate="tbDDDFixo" Display="Dynamic" 
                ErrorMessage="Campo Obrigatorio" SetFocusOnError="True" 
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
            <br />
            Currículo:<asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                runat="server" ControlToValidate="ckeCurriculo" Display="Dynamic" 
                ErrorMessage="Campo Obrigatorio" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator11_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator11">
            </asp:ValidatorCalloutExtender>
            <br />
            <CKEditor:CKEditorControl ID="ckeCurriculo" runat="server"></CKEditor:CKEditorControl>
        </li>
        
        <li>
            <asp:Button ID="btnGravar" runat="server" Text="Gravar" 
                onclick="btnGravar_Click" ValidationGroup="gravar" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                onclick="btnCancelar_Click" CausesValidation="False" />
            <asp:Button ID="btnExcluir" runat="server" onclick="btnExcluir_Click" 
                Text="Excluir" CausesValidation="False" 
                onclientclick="return confirm(&quot;Deseja realmente excluir?&quot;)" />
            <asp:Button ID="btnPesq" runat="server" Text="Pesquisar" 
                OnClientClick="return btnPesq_Click()" CausesValidation="False"/></li>    
    </ul>
</asp:Content>
