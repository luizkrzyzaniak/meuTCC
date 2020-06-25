<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="PesqPresenca.aspx.cs" Inherits="Site.PesqPresenca" %>
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
            document.getElementById("hfProf").value = id;
            document.getElementById("tbProf").value = descr;

        }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h3>Pesquisar Presença do Modulo por Data<asp:HiddenField ID="hfProf" 
        runat="server" ClientIDMode="Static" />
    <asp:HiddenField ID="hfOcm" runat="server" />
    </h3>
<ul id="listConteudo">
    
<li>Nome do Professor:<br />
    <asp:TextBox ID="tbProf" runat="server" Width="400px" ClientIDMode="Static"></asp:TextBox>
    <asp:Button ID="btnPesq" runat="server" Text="Pesquisar Professor" 
        onclientclick="return btnPesq_Click()" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="tbProf" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
        ValidationGroup="gravar">*</asp:RequiredFieldValidator>
    </li>
<li>Data do Lançamento:<br />
    <asp:TextBox ID="tbData" runat="server" Width="150px"></asp:TextBox>
    <asp:CalendarExtender ID="tbData_CalendarExtender" runat="server" 
        Enabled="True" TargetControlID="tbData" Format="dd/MM/yyyy">
    </asp:CalendarExtender>
    <asp:MaskedEditExtender ID="tbData_MaskedEditExtender" runat="server" 
        CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
        CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
        CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
        Mask="99/99/9999" TargetControlID="tbData" ClearMaskOnLostFocus="False">
    </asp:MaskedEditExtender>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="tbData" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
        SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
    &nbsp;&nbsp;
    <asp:Button ID="btnMostrarModulos" runat="server" Text="Mostrar Modulos" 
        Width="200px" onclick="btnMostrarModulos_Click" ValidationGroup="gravar" />
    </li>
<li>
    <asp:Panel ID="pModulos" runat="server" Visible="False">
        Módulos:<asp:GridView ID="gvModulos" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="400px" 
            onrowdatabound="gvModulos_RowDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Modulo.DesModulo" HeaderText="Módulos" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnSelecionar" runat="server" 
                            CommandArgument='<%# Eval("Ocm.OcCod")+ "," + Eval("Modulo.CodModulo") + "," + Eval("Modulo.DesModulo") + "," +Eval("Ocm.Cod") %>' 
                            oncommand="lbtnSelecionar_Command" CausesValidation="False">Selecionar</asp:LinkButton>
                        <asp:Literal ID="ltTxt" runat="server"></asp:Literal>
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
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="pAlunos" runat="server" Visible="False">
        Alunos:<asp:GridView ID="gvAlunos" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" Width="600px" 
            onrowdatabound="gvAlunos_RowDataBound">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="Aluno.Nome" HeaderText="Nome do Aluno" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Literal ID="ltCk" runat="server"></asp:Literal>
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
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <br />
        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" Width="200px" 
            onclick="btnExcluir_Click" 
            onclientclick="return confirm(&quot;Deseja realmente excluir?&quot;)" />
        <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
            Text="Cancelar" Width="100px" />
    </asp:Panel>
    </li>
<li></li>
</ul>
</asp:Content>
