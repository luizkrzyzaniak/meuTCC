<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="CadMatricula.aspx.cs" Inherits="Site.CadMatricula" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="_scripts/fancyBox/lib/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="_scripts/fancyBox/source/jquery.fancybox.pack.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="_scripts/fancyBox/source/jquery.fancybox.css" />

 <script type="text/javascript">
     function btnPesqAluno_Click() {

         $.fancybox.open({
             href: 'PesqAlunos.aspx',
             type: 'iframe',
             padding: 5
         });


         return false;
     }


     function pesqAlunoRetorno(id, descr) {

         $.fancybox.close();
         document.getElementById("hfAluno").value = id;
         document.getElementById("tbAluno").value = descr;

     }

     function btnPesqOferta_Click() {

         $.fancybox.open({
             href: 'PesqOfertaCurso.aspx',
             type: 'iframe',
             padding: 5
         });


         return false;
     }


     function pesqOfertaRetorno(id, descr) {

         $.fancybox.close();
         document.getElementById("hfOferta").value = id;
         document.getElementById("tbOfertaCurso").value = descr;
     }


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
         document.location.href = "CadMatricula.aspx?id=" + id;

     }

     
        function btnAjuda() {

            $.fancybox.open({
                href: '/Ajuda/mat.pdf',
                type: 'iframe',
                padding: 5
            });


            return false;
        }

     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h3>Matrícula<asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return btnAjuda()">(?)Ajuda</asp:LinkButton><asp:HiddenField ID="hfAluno" runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hfMatricula" runat="server" />
    <asp:HiddenField ID="hfOferta" runat="server" ClientIDMode="Static" />
    </h3>
<ul id="listConteudo">
    <li>Aluno:<br />
        <asp:TextBox ID="tbAluno" runat="server"  ClientIDMode="Static" Width="400px"></asp:TextBox>
        <asp:Button ID="btnAluno" runat="server" Text="Selecionar Aluno" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="tbAluno" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
            SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator1_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator1">
        </asp:ValidatorCalloutExtender>
    </li>
    <li>Oferta Curso<br />
        <asp:TextBox ID="tbOfertaCurso" runat="server"  ClientIDMode="Static" 
            Width="400px" 
            AutoPostBack="True"></asp:TextBox>
        <asp:Button ID="btnOfertaCurso" runat="server" Text="Selecionar Oferta Curso" 
            Width="150px" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="tbOfertaCurso" Display="Dynamic" 
            ErrorMessage="Campo Obrigatorio" SetFocusOnError="True" 
            ValidationGroup="gravar">*</asp:RequiredFieldValidator>
        <asp:ValidatorCalloutExtender ID="RequiredFieldValidator2_ValidatorCalloutExtender" 
            runat="server" Enabled="True" TargetControlID="RequiredFieldValidator2">
        </asp:ValidatorCalloutExtender>
        <br />
        <br />
        <asp:Button ID="btnExbir" runat="server" onclick="btnExbir_Click" 
            Text="Mostrar Módulos" Width="300px" />
    </li>
    <li>
        <asp:Panel ID="pModulos" runat="server" Visible="False">
        
        <asp:GridView ID="gvModulos" runat="server" AutoGenerateColumns="False" 
            Width="600px" CellPadding="4" ForeColor="#333333" GridLines="None" 
            onrowdatabound="gvModulos_RowDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Literal ID="ltCk" runat="server"></asp:Literal>   
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Módulo" DataField="Mod.DesModulo" />
                <asp:BoundField HeaderText="Valor" DataField="Mod.Valor" />
                <asp:BoundField DataField="Professor.Nome" HeaderText="Professor" />
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
        &nbsp;<asp:Button ID="btnSelecionar" runat="server" Text="Selecionar Módulos" 
            onclick="btnSelecionar_Click" />
        <br />
        </asp:Panel>
    </li>
    <li>
        <asp:Panel ID="pValor" runat="server">
        <br />
            Valor:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Nº de Parcelas<br />
        <asp:TextBox ID="tbValor" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                ControlToValidate="tbValor" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
                ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator3_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator3">
            </asp:ValidatorCalloutExtender>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbNumParcelas" runat="server" Width="50px" AutoPostBack="True" 
                ontextchanged="tbNumParcelas_TextChanged"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                ControlToValidate="tbNumParcelas" Display="Dynamic" 
                ErrorMessage="Campo Obrigatorio" SetFocusOnError="True" 
                ValidationGroup="gravar">*</asp:RequiredFieldValidator>
            <asp:ValidatorCalloutExtender ID="RequiredFieldValidator4_ValidatorCalloutExtender" 
                runat="server" Enabled="True" TargetControlID="RequiredFieldValidator4">
            </asp:ValidatorCalloutExtender>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lDetalhes" runat="server" CssClass="valor"></asp:Label>
            <br />
            Data da Primeira Parcela:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Situação:<br />&nbsp;<asp:TextBox ID="tbDtParcela" 
                runat="server"></asp:TextBox>
            <asp:CalendarExtender ID="tbDtParcela_CalendarExtender" runat="server" 
                Enabled="True" Format="dd/MM/yyyy" TargetControlID="tbDtParcela" 
                TodaysDateFormat="d MMMM,  yyyy">
            </asp:CalendarExtender>
            <asp:MaskedEditExtender ID="tbDtParcela_MaskedEditExtender" runat="server" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="99/99/9999" MaskType="Date" TargetControlID="tbDtParcela" 
                UserDateFormat="DayMonthYear">
            </asp:MaskedEditExtender>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                ControlToValidate="tbDtParcela" Display="Dynamic" 
                ErrorMessage="Campo Obrigatorio" SetFocusOnError="True" 
                ValidationGroup="gravar">*</asp:RequiredFieldValidator>
&nbsp;
            <asp:DropDownList ID="ddlSit" runat="server">
                <asp:ListItem Value="N">Não Pago</asp:ListItem>
                <asp:ListItem Value="P">Pago</asp:ListItem>
            </asp:DropDownList>
        </asp:Panel>
    </li>
    <li>
        <br />
        <asp:Button ID="btnGravar" runat="server" Text="Gravar" 
            onclick="btnGravar_Click" ValidationGroup="gravar" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
            onclick="btnCancelar_Click" CausesValidation="False" />
        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" 
            onclick="btnExcluir_Click" 
            onclientclick="return confirm(&quot;Deseja realmente excluir?&quot;)" 
            Visible="False" CausesValidation="False" />
        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" 
            onclientclick="return btnPesquisar_Click()" CausesValidation="False" />
    </li>
</ul>
</asp:Content>
