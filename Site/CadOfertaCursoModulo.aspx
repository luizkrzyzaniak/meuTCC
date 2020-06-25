<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="CadOfertaCursoModulo.aspx.cs" Inherits="Site.CadOfertaCursoModulo" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
         document.getElementById("hfprof").value = id;
         document.getElementById("tbProf").value = descr;

     }

     
        function btnAjuda() {

            $.fancybox.open({
                href: '/Ajuda/cadOcm.pdf',
                type: 'iframe',
                padding: 5
            });


            return false;
        }

        </script>
        

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h3>Cadastro de Módulos da Oferta Curso<asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return btnAjuda()">(?)Ajuda</asp:LinkButton></h3>
<ul id="listConteudo">
    <asp:HiddenField ID="hfprof" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hfOferta" runat="server" />
    <asp:HiddenField ID="hfCod" runat="server" />
    <asp:HiddenField ID="hfCodMod" runat="server" />
    <li>
        <asp:Label ID="lInfo" runat="server" CssClass="info"></asp:Label>
    </li>
    <li>Nome do Professor:<br />
        <asp:TextBox ID="tbProf" runat="server"  ClientIDMode="Static" Width="400px"></asp:TextBox>
        <asp:Button ID="btnPesqProf" runat="server" Text="Pesquisar Professor" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="tbProf" Display="Dynamic" ErrorMessage="Campo Obigatorio" 
            ValidationGroup="gravar">*</asp:RequiredFieldValidator>
        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
        </asp:ValidatorCalloutExtender>
    </li>
    <li>Data Inicial:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Data Final:<br />
        <asp:TextBox ID="tbDtinicial" runat="server"></asp:TextBox>
        <asp:MaskedEditExtender ID="tbDtinicial_MaskedEditExtender" runat="server" 
            ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
            Mask="99/99/9999" TargetControlID="tbDtinicial">
        </asp:MaskedEditExtender>
&nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" 
            ControlToValidate="tbDtinicial" Display="Dynamic" ErrorMessage="Data Invalida" 
            MaximumValue="01/01/2050" MinimumValue="01/01/1900" Type="Date" 
            ValidationGroup="gravar">*</asp:RangeValidator>
        <asp:ValidatorCalloutExtender ID="RangeValidator1_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RangeValidator1">
        </asp:ValidatorCalloutExtender>
        &nbsp;&nbsp;
        <asp:TextBox ID="tbDtFinal" runat="server"></asp:TextBox>
        <asp:MaskedEditExtender ID="tbDtFinal_MaskedEditExtender" runat="server" 
            ClearMaskOnLostFocus="False" CultureAMPMPlaceholder="" 
            CultureCurrencySymbolPlaceholder="" CultureDateFormat="" 
            CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
            CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
            Mask="99/99/9999" TargetControlID="tbDtFinal">
        </asp:MaskedEditExtender>
        <asp:RangeValidator ID="RangeValidator2" runat="server" 
            ControlToValidate="tbDtFinal" Display="Dynamic" ErrorMessage=" Data Invalida" 
            MaximumValue="01/01/2050" MinimumValue="01/01/1900" Type="Date" 
            ValidationGroup="gravar">*</asp:RangeValidator>
        <asp:ValidatorCalloutExtender ID="RangeValidator2_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RangeValidator2">
        </asp:ValidatorCalloutExtender>
    </li>
    <li>
        <asp:Panel ID="pModulos" runat="server">
            Módulos:<asp:GridView ID="gvModulos" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="500px" 
                onrowdatabound="gvModulos_RowDataBound">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="DesModulo" HeaderText="Módulo" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnAddMod" runat="server" 
                        CommandArgument='<%# Eval("CodModulo") %>' oncommand="lbtnAddMod_Command">Selecionar</asp:LinkButton>
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
        <br />
        </asp:Panel>
    </li>
    <li>
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" 
            onclick="btnGravar_Click" ValidationGroup="gravar" Visible="False" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
            onclick="btnCancelar_Click" />
        <asp:Button ID="btnFinal" runat="server" onclick="btnFinal_Click" 
            Text="Finalizar" Visible="False" />
    </li>
    <li>
        <br />
        Módulos Selecionados:<asp:GridView ID="gvModSelecionados" runat="server" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" Width="600px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField HeaderText="Módulo" DataField="Mod.DesModulo" />
            <asp:BoundField HeaderText="Professor" DataField="Professor.Nome" />
            <asp:BoundField HeaderText="Dt Inicial" DataField="DtInicioModulo" 
                DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField HeaderText="Dt Final" DataField="DtFinalModulo" 
                DataFormatString="{0:dd/MM/yyyy}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnExcluir" runat="server" 
                        CommandArgument='<%# Eval("Cod") %>' oncommand="lbtnExcluir_Command" 
                        onclientclick="return confirm(&quot;Deseja realmente excluir?&quot;)">Excluir</asp:LinkButton>
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
