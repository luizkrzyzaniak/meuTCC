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
    public partial class CadCurso : System.Web.UI.Page
    {
        Utils u = new Utils();
               
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    CarregaAlteracao(int.Parse(Request.QueryString["id"]));

                }
            }
        }

        protected void CarregaAlteracao(int id)
        {
            Curso cur = new Curso();
            if (cur.RecuperarCurso(id))
            {
                hfCodCurso.Value = id.ToString();
                tbDescCurso.Text = cur.DescCurso;
                btnAddModulos.Enabled = true;
                btnAddModulos.OnClientClick = "return btnMod_Click(" + hfCodCurso.Value + ")";
                btnFinal.Visible = true;
            }
        }
        
     

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            if (tbDescCurso.Text.Trim() != "")
            {
                if (hfCodCurso.Value == "")
                {
                    Curso cur = new Curso(tbDescCurso.Text.ToUpper());
                    cur.GravarCurso();

                    Response.Redirect("CadCurso.aspx?id=" + cur.CodCurso);
                }
                else
                {
                    Curso cur = new Curso(Convert.ToInt32(hfCodCurso.Value), tbDescCurso.Text.ToUpper());
                    cur.AlterarCurso();
                    Response.Redirect("CadCurso.aspx?id=" + cur.CodCurso);
                }
            }
            else
            {
                u.MsgBox(this, "Digite o nome do curso.");
            }
        }

        protected void LimparTela()
        {
            Response.Redirect("CadCurso.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimparTela();
        }

        protected void btnFinal_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadCurso.aspx");
        }
      
    }
}