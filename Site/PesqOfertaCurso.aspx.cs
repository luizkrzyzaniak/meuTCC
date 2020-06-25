using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;

namespace Site
{
    public partial class PesqOfertaCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnidadeEnsino ue = new UnidadeEnsino();
            gvUE.DataSource = ue.PesqUnidadeEnsino();
            gvUE.DataBind();
        }

        protected void lbtnSelecionar_Command(object sender, CommandEventArgs e)
        {
            OfertaCurso oc = new OfertaCurso();
            gvOfertaCurso.DataSource = oc.PesqOfertaCurso(Convert.ToInt32(e.CommandArgument));
            gvOfertaCurso.DataBind();
            pOferta.Visible = true;
            pUE.Visible = false;
        }

        protected void lbtnVoltar_Click(object sender, EventArgs e)
        {
            pUE.Visible = true;
            pOferta.Visible = false;
        }

        

        
    }
}