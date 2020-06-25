<%@ Page Title="" Language="C#" MasterPageFile="~/_design/MpPrincipal.Master" AutoEventWireup="true" CodeBehind="CadPresenca.aspx.cs" Inherits="Site.CadPresenca" %>
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
            document.location.href = "CadPresenca.aspx?id=" + id + "&desc=" + descr;

        }

        
        function btnAjuda() {

            $.fancybox.open({
                href: '/Ajuda/cadPre.pdf',
                type: 'iframe',
                padding: 5
            });


            return false;
        }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphConteudo" runat="server">
<h3>Cadastro de Presença<asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return btnAjuda()">(?)Ajuda</asp:LinkButton><asp:HiddenField ID="hfProf" runat="server" />
    </h3>
<ul id="listConteudo">
<li>Professor<br />
    <asp:TextBox ID="tbProf" runat="server" Width="400px"></asp:TextBox>
    <asp:Button ID="btnPesq" runat="server" Text="Pesquisar" 
        onclientclick="return btnPesq_Click()" />
    </li>
    <asp:Panel ID="pModulo" runat="server" Visible="False">
    
<li>Módulo:<br />
    <asp:GridView ID="gvModulos" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="400px" 
        onrowdatabound="gvModulos_RowDataBound">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Modulo.DesModulo" HeaderText="Módulo" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnSelec" runat="server" 
                        CommandArgument='<%# Eval("Ocm.OcCod")+ "," + Eval("Modulo.CodModulo") + "," + Eval("Modulo.DesModulo") %>' 
                        oncommand="lbtnSelec_Command">Selecionar</asp:LinkButton>
                    <asp:Literal ID="lTxt" runat="server"></asp:Literal>
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
    </asp:Panel>
    <asp:Panel ID="pAlunos" runat="server" Visible="False">
    
<li>
    <br />
    <asp:Label ID="lInfo" runat="server" CssClass="info"></asp:Label>
    <br />
    <br />
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
    </asp:GridView>
    <br />
    <asp:Button ID="btnConfirm" runat="server" Text="Lançar Faltas" Width="200px" 
        onclick="btnConfirm_Click" />
    <asp:Button ID="btnCancelar" runat="server" onclick="btnCancelar_Click" 
        Text="Cancelar" />
    </li>
    </asp:Panel>
    <li>
        <asp:Button ID="btmPesqLanc" runat="server" onclick="btmPesqLanc_Click" 
            Text="Pesquisar Lançamento de Faltas" />
    </li>
</ul>
</asp:Content>
