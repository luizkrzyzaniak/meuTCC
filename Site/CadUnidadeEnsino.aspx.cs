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
    public partial class CadUnidadeEnsino : System.Web.UI.Page
    {
        Utils u = new Utils();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Utils u = new Utils();
                ddlUf.DataSource = u.Estados();
                ddlUf.DataBind();
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    CarregaAlteracao(int.Parse(Request.QueryString["id"]));

                }
            }
        }

        protected void CarregaAlteracao(int id)
        {
            UnidadeEnsino ue = new UnidadeEnsino();
            if (ue.RecuperarUnidadeEnsino(id))
            {
                hfCodUE.Value = ue.CodUnidade.ToString();
                tbNome.Text = ue.Nome.ToString();
                tbResponsavel.Text = ue.Responsavel.ToString();
                tbEndereco.Text = ue.Endereco.ToString();
                tbNumero.Text = ue.Numero.ToString();
                tbBairro.Text = ue.Bairro.ToString();
                tbDDDFixo.Text = ue.DddFixo.ToString();
                tbNumFixo.Text = ue.NumFixo.ToString();
                ddlUf.SelectedItem.Text = ue.Uf.ToString();
                tbCidade.Text = ue.Cidade.ToString();
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            int cod = 0;
            if (hfCodUE.Value != "")
                cod = Convert.ToInt32(hfCodUE.Value);

            UnidadeEnsino ue = new UnidadeEnsino(tbNome.Text, tbResponsavel.Text, tbEndereco.Text, Convert.ToInt32(tbNumero.Text), tbBairro.Text, Convert.ToInt32(tbDDDFixo.Text), Convert.ToInt32(tbNumFixo.Text), ddlUf.SelectedItem.Text,tbCidade.Text,cod);
            if (hfCodUE.Value == "")
            {
                if (ue.GravarUnidadeEnsino())
                {
                    LimparTela();
                }
            }
            else
            {
                if (ue.AlterarUnidadeEnsino())
                {
                    LimparTela();
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        protected void LimparTela()
        {
            Response.Redirect("CadUnidadeEnsino.aspx");
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            UnidadeEnsino ue = new UnidadeEnsino();
            if (ue.ExcluirUnidade(Convert.ToInt32(hfCodUE.Value)))
            {
                LimparTela();
            }
            else
            {
                u.MsgBox(this, "Não foi possivel excluir a unidade de ensino.");
            }
        }
    }
}