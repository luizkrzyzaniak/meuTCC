using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;
using System.Data;

namespace Site
{
    public partial class CadAlunos : System.Web.UI.Page
    {
        Utils u = new Utils();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Utils u = new Utils();
                ddlUF.DataSource = u.Estados();
                ddlUF.DataBind();
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    CarregaAlteracao(int.Parse(Request.QueryString["id"]));

                }
            }
        }

        protected void CarregaAlteracao(int id)
        {
            Alunos alu = new Alunos();
            if (alu.RecuperarAluno(id))
            {
                hfCodAluno.Value = alu.Ra.ToString();
                tbNome.Text = alu.Nome.ToString();
                tbCPF.Text = alu.Cpf.ToString();
                tbRG.Text = alu.Rg.ToString();
                tbDtNasc.Text = alu.DtNasc.ToString();
                tbEndereco.Text = alu.Endereco.ToString();
                tbNumero.Text = alu.Numero.ToString();
                tbBairro.Text = alu.Bairro.ToString();
                tbDDDFixo.Text = alu.DddFixo.ToString();
                tbNumFixo.Text = alu.NumFixo.ToString();
                tbDDDCel.Text = alu.DddCel.ToString();
                tbNumCel.Text = alu.NumCel.ToString();
                ddlUF.SelectedItem.Text = alu.Uf.ToString();
                tbCidade.Text = alu.Cidade.ToString();
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (hfCodAluno.Value == "")
                {
                    Alunos a = new Alunos();
                    if (a.VerificaCpf(tbCPF.Text))
                    {
                        if (a.VerificaRG(tbRG.Text))
                        {
                            int ddd = 0, numcelular = 0;
                            int cod = 0;

                            if (tbDDDCel.Text != "" && tbNumCel.Text != "")
                            {
                                ddd = Convert.ToInt32(tbDDDCel.Text);
                                numcelular = Convert.ToInt32(tbNumCel.Text);
                            }

                            Alunos alu = new Alunos(tbNome.Text.ToUpper(), tbCPF.Text, tbRG.Text, Convert.ToDateTime(tbDtNasc.Text), tbEndereco.Text.ToUpper(), Convert.ToInt32(tbNumero.Text), tbBairro.Text.ToUpper(), Convert.ToInt32(tbDDDFixo.Text), Convert.ToInt32(tbNumFixo.Text), ddd, numcelular, ddlUF.SelectedItem.Text, tbCidade.Text.ToUpper(), cod);
                            alu.GravarAluno();
                            LimparTela();
                            
                        }
                        else
                        {
                            u.MsgBox(this, "RG já utilizado.");
                            tbRG.Focus();
                        }
                    }
                    else
                    {
                        u.MsgBox(this, "CPF já utilizado");
                        tbCPF.Focus();
                    }
                }
                else
                {
                    int ddd = 0, numcelular = 0;
                    int cod = 0;
                    cod = Convert.ToInt32(hfCodAluno.Value);

                    if (tbDDDCel.Text != "" && tbNumCel.Text != "")
                    {
                        ddd = Convert.ToInt32(tbDDDCel.Text);
                        numcelular = Convert.ToInt32(tbNumCel.Text);
                    }

                    Alunos alu = new Alunos(tbNome.Text.ToUpper(), tbCPF.Text, tbRG.Text, Convert.ToDateTime(tbDtNasc.Text), tbEndereco.Text.ToUpper(), Convert.ToInt32(tbNumero.Text), tbBairro.Text.ToUpper(), Convert.ToInt32(tbDDDFixo.Text), Convert.ToInt32(tbNumFixo.Text), ddd, numcelular, ddlUF.SelectedItem.Text, tbCidade.Text.ToUpper(), cod);
                    alu.AlterarAluno();
                    LimparTela();
                }
            }
            else
            {
                u.MsgBox(this, "Pagina não validada");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparTela();
        }


        protected void LimparTela()
        {
            Response.Redirect("CadAlunos.aspx");
        }

        protected void btnEcluir_Click(object sender, EventArgs e)
        {
            if (hfCodAluno.Value != "")
            {
                Alunos alu = new Alunos();
                if (alu.ExcluirAluno(Convert.ToInt32(hfCodAluno.Value)))
                {
                    LimparTela();
                }
                else
                {
                    u.MsgBox(this, "Não foi possivel excluir aluno.");
                }
            }
            else
            {
                u.MsgBox(this, "Não existe aluno selecionado.");
            }

        }
    }
}