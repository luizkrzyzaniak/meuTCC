<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadModulo.aspx.cs" Inherits="Site.CadModulo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="_design/_css/telaFB.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="pag">
    <ul>
            <li>
                Descrição Módulo:<br />
                <asp:TextBox ID="tbNomeModulo" runat="server" Width="350px" MaxLength="30"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="tbNomeModulo" Display="Dynamic" 
                    ErrorMessage="Campo Obrigatorio" SetFocusOnError="True" 
                    ValidationGroup="gravar">*</asp:RequiredFieldValidator>
                <br />
                Valor do Módulo:<br />
                <asp:TextBox ID="tbValor" runat="server"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="tbValor" Display="Dynamic" ErrorMessage="Campo Obrigatorio" 
                    SetFocusOnError="True" ValidationGroup="gravar">*</asp:RequiredFieldValidator>
                &nbsp;&nbsp;
                <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="Inserir" 
                    ValidationGroup="gravar" />
            </li>
            <li>
                <asp:GridView ID="gvModulos" runat="server" AutoGenerateColumns="False" 
                    Width="400px" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="DesModulo" HeaderText="Nome" />
                        <asp:BoundField DataField="Valor" HeaderText="Valor" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnExcluir" runat="server" 
                                    CommandArgument='<%# Eval("CodModulo") %>' oncommand="lbtnExcluir_Command" 
                                    CausesValidation="False" 
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
                <asp:HiddenField ID="hfCod" runat="server" />
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
