<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PesqMatricula.aspx.cs" Inherits="Site.PesqMatricula" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="_design/_css/telaFB.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function selecionar(id, descr) {

            window.parent.pesqMatriculaRetorno(id, descr);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="pag">
    <h3>Pesquisar Matrícula</h3>
    <ul>
     <li>Nome do aluno:<br />
         <asp:TextBox ID="tbNome" runat="server" Width="350px"></asp:TextBox>
         <asp:Button ID="btnPesq" runat="server" onclick="btnPesq_Click" 
             Text="Pesquisar" />
        </li>
     <li>
         <asp:GridView ID="gvMatricula" runat="server" AutoGenerateColumns="False" 
             CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px">
             <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
             <Columns>
                 <asp:BoundField DataField="Aluno.Nome" HeaderText="Aluno" />
                 <asp:BoundField DataField="DtMatricula" DataFormatString="{0:dd/MM/yyyy}" 
                     HeaderText="Data da Matrícula" />
                 <asp:BoundField DataField="Oferta.Desc" HeaderText="Descrição da OfertaCurso" />
                 <asp:TemplateField>
                     <ItemTemplate>
                         <a href="javascript:;" onclick="selecionar(<%# Eval("CodMatricula") %>, '<%# Eval("Aluno.Nome") %>')">Selecionar</a>
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
    </div>
    </form>
</body>
</html>
