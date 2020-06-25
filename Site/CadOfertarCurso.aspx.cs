using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;

namespace Site
{
    public partial class CadOfertarCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnPesqCurso.OnClientClick = "return btnPesqCurso_Click()";
            tbNome.Attributes.Add("readonly", "readonly");
            btnPesqUE.OnClientClick = "return btnPesqUE_Click()";
            tbNomeUE.Attributes.Add("readonly", "readonly");
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    CarregaAlteracao(int.Parse(Request.QueryString["id"]));

                }
            }
        }

        protected void CarregaAlteracao(int cod)
        {
            OfertaCurso oc = new OfertaCurso();
            if (oc.RecuperarOfertaCurso(cod))
            {
                tbDescOC.Text = oc.Desc;
                tbDtInicio.Text = oc.DtInicio.ToString();
                tbDtFinal.Text = oc.DtFinal.ToString();
                hfCodCurso.Value = oc.Curso.ToString();
                hfCodOferta.Value = oc.CodOferta.ToString();
                hfCodUe.Value = oc.UnidadeEnsino.ToString();
                Curso cur = new Curso();
                if (cur.RecuperarCurso(Convert.ToInt32(oc.Curso)))
                {
                    tbNome.Text = cur.DescCurso;
                }
                UnidadeEnsino ue = new UnidadeEnsino();
                if (ue.RecuperarUnidadeEnsino(Convert.ToInt32(oc.UnidadeEnsino)))
                {
                    tbNomeUE.Text = ue.Nome;
                }
                btnPesqCurso.Enabled = false;
                btnPesqUE.Enabled = false;
                btnExcluir.Enabled = true;
                btnAdd.Enabled = true;
            }
        }

        protected void LimpaTela()
        {
            Response.Redirect("CadOfertarCurso.aspx");
        }
       
        protected void btnGravar_Click(object sender, EventArgs e)
        {
            DateTime dti = Convert.ToDateTime(tbDtInicio.Text), dtf = Convert.ToDateTime(tbDtFinal.Text);
            Session.Add("dti", dti);
            Session.Add("dtf", dtf);
            if (dti < dtf)
            {
                int codigo = 0;
                if (hfCodOferta.Value != "")
                    codigo = Convert.ToInt32(hfCodOferta.Value);

                OfertaCurso oc = new OfertaCurso(codigo, Convert.ToDateTime(tbDtInicio.Text), Convert.ToDateTime(tbDtFinal.Text), Convert.ToInt32(hfCodUe.Value), Convert.ToInt32(hfCodCurso.Value), tbDescOC.Text);
                if (codigo == 0)
                {
                    oc.GravarOfertaCurso();
                    hfCodOferta.Value = oc.CodOferta.ToString();
                    Response.Redirect("CadOfertaCursoModulo.aspx?oferta=" + hfCodOferta.Value + "&cur=" + hfCodCurso.Value);
                }
                else
                {
                    oc.AlterarOC();
                    LimpaTela();
                }
            }
            else
            {
                Utils u = new Utils();
                u.MsgBox(this, "Data Inicial tem que ser menor que a Data Final");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            DateTime dti = Convert.ToDateTime(tbDtInicio.Text), dtf = Convert.ToDateTime(tbDtFinal.Text);
            Session.Add("dti", dti);
            Session.Add("dtf", dtf);
            Response.Redirect("CadOfertaCursoModulo.aspx?oferta=" + hfCodOferta.Value + "&cur=" + hfCodCurso.Value);
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            OfertaCurso oc = new OfertaCurso();
            if (oc.ExcluirOfertaCurso(Convert.ToInt32(hfCodOferta.Value)))
            {
                LimpaTela();
            }
            else
            {
                Utils u = new Utils();
                u.MsgBox(this, "Não foi possivel excluir, Oferta Curso sendo utilizada.");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaTela();
        }
    }
}