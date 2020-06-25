using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;

namespace Site
{
    public partial class CadModulo : System.Web.UI.Page
    {

        Utils u = new Utils();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    hfCod.Value =Request.QueryString["id"];
                    RecuperarModulos();
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int codMod = 0;
            Modulos mod = new Modulos(tbNomeModulo.Text, Convert.ToDouble(tbValor.Text));
            mod.GravarModulo();
            codMod = mod.CodModulo;
            Curso cur = new Curso();
            cur.GravarCursoModulo(Convert.ToInt32(hfCod.Value), codMod);
            tbNomeModulo.Text = "";
            tbValor.Text = "";
            RecuperarModulos();
        }

        protected void RecuperarModulos()
        {
            Modulos mod = new Modulos();
            gvModulos.DataSource = mod.PesqModCurso(Convert.ToInt32(hfCod.Value));
            gvModulos.DataBind();
        }

        protected void lbtnExcluir_Command(object sender, CommandEventArgs e)
        {
            Modulos mod = new Modulos();
            if (mod.ExcluirModuloCurso(Convert.ToInt32(e.CommandArgument)))
            {
                if (mod.ExcluirModulo(Convert.ToInt32(e.CommandArgument)))
                {
                    RecuperarModulos();
                }
            }
            else
            {
                u.MsgBox(this, "Não foi possivel excluir o modulo.");
            }
                
        }
    }
}