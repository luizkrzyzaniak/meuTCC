<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WucMenuPrincipal.ascx.cs"
    Inherits="Site._design.WucMenuPrincipal" %>
<link href="/_design/_css/menu.css" rel="stylesheet" type="text/css" />
<div class="menu">
    <ul>
        <li><a href="../Principal.aspx">Início</a></li>
        <li><a href="#" id="current">Cadastro</a>
            <ul>
                <li><a href="../CadAlunos.aspx">Alunos</a></li>
                <li><a href="../CadProfessor.aspx">Professores</a></li>
                <li><a href="../CadUnidadeEnsino.aspx">Unidade de Ensino</a></li>
                <li><a href="../CadCurso.aspx">Cursos</a></li>
            </ul>
        </li>
        <li><a href="../CadOfertarCurso.aspx">Ofertar Curso</a></li>
        <li><a href="../CadMatricula.aspx">Matrícula</a></li>
        
        <li><a href="#">Frequência</a>
            <ul>
                <li><a href="../CadPresenca.aspx">Lançamento de Falta</a></li>
                <li><a href="../MapaDeFaltas.aspx" >Gerar Mapas de Faltas</a></li>
            </ul>
        </li>
        <li><a href="#">Pagamento</a>
            <ul>
                <li><a href="../PagParcelas.aspx">Parcelas</a></li>
            </ul>
        </li>
        <li><a href="#">Relatorios</a>
            <ul>
                <li><a href="../Relatorios/RelAlunosDevedores.aspx" >Alunos Devedores</a></li>
                <li><a href="../Relatorios/FichaPresencaRel.aspx" >Ficha de Presença</a></li>
                <li><a href="../GeraArqCertificado.aspx" >Gerar .CSV para Certificado</a></li>
                <li><a href="../Relatorios/HorarioAlunoRel.aspx" >Horário do Aluno</a></li>
            </ul>
        </li>
    </ul>
</div>
