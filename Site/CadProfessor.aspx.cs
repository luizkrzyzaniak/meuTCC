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
    public partial class CadProfessor : System.Web.UI.Page
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
            Professor prof = new Professor();
            if (prof.RecuperarProfessor(id))
            {
                hfCodProf.Value = Request.QueryString["id"];
                tbNome.Text = prof.Nome.ToString();
                tbCPF.Text = prof.Cpf.ToString();
                tbRG.Text = prof.Rg.ToString();
                tbDtNasc.Text = prof.DtNasc.ToString();
                tbEndereco.Text = prof.Endereco.ToString();
                tbNumero.Text = prof.Numero.ToString();
                tbBairro.Text = prof.Bairro.ToString();
                tbDDDFixo.Text = prof.DddFixo.ToString();
                tbNumFixo.Text = prof.NumFixo.ToString();
                tbDDDCel.Text = prof.DddCel.ToString();
                tbNumCel.Text = prof.NumCel.ToString();
                ddlUF.SelectedItem.Text = prof.Uf.ToString();
                tbCidade.Text = prof.Cidade.ToString();
                ckeCurriculo.Text = prof.Curriculo.ToString();
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Professor p = new Professor();
                if (hfCodProf.Value == "")
                {
                    if (p.VerificaCpf(tbCPF.Text))
                    {
                        if (p.VerificaRG(tbRG.Text))
                        {
                            int ddd = 0, numcelular = 0;
                            int cod = 0;


                            if (tbDDDCel.Text != "" && tbNumCel.Text != "")
                            {
                                ddd = Convert.ToInt32(tbDDDCel.Text);
                                numcelular = Convert.ToInt32(tbNumCel.Text);
                            }

                            Professor prof = new Professor(tbNome.Text.ToUpper(), tbCPF.Text, tbRG.Text, Convert.ToDateTime(tbDtNasc.Text), ckeCurriculo.Text, tbEndereco.Text.ToUpper(), Convert.ToInt32(tbNumero.Text), tbBairro.Text.ToUpper(), Convert.ToInt32(tbDDDFixo.Text), Convert.ToInt32(tbNumFixo.Text), ddd, numcelular, ddlUF.SelectedItem.Text, tbCidade.Text.ToUpper(), cod);
                            prof.GravarProfessor();
                            LimparTela();

                        }
                        else
                        {
                            u.MsgBox(this, "RG já utilizado");
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
                    cod = Convert.ToInt32(hfCodProf.Value);

                    if (tbDDDCel.Text != "" && tbNumCel.Text != "")
                    {
                        ddd = Convert.ToInt32(tbDDDCel.Text);
                        numcelular = Convert.ToInt32(tbNumCel.Text);
                    }

                    Professor prof = new Professor(tbNome.Text.ToUpper(), tbCPF.Text, tbRG.Text, Convert.ToDateTime(tbDtNasc.Text), ckeCurriculo.Text, tbEndereco.Text.ToUpper(), Convert.ToInt32(tbNumero.Text), tbBairro.Text.ToUpper(), Convert.ToInt32(tbDDDFixo.Text), Convert.ToInt32(tbNumFixo.Text), ddd, numcelular, ddlUF.SelectedItem.Text, tbCidade.Text.ToUpper(), cod);
                    prof.AlterarProfessor();
                    LimparTela();

                }
            }
            else
            {
                u.MsgBox(this, "Pagina não validada.");
            }
        }

        protected void LimparTela()
        {
            Response.Redirect("CadProfessor.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            if (hfCodProf.Value != "")
            {
                Professor prof = new Professor();
                if (prof.ExcluirProfessor(Convert.ToInt32(hfCodProf.Value)))
                {
                    LimparTela();
                }
                else
                {
                    u.MsgBox(this, "Não foi possivel excluir professor.");
                }
            }
            else
            {
                u.MsgBox(this, "Não existe professor selecionado.");
            }
        }
    }
}