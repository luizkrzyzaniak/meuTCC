using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;

namespace Site
{
    public partial class PesqMatricula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesq_Click(object sender, EventArgs e)
        {
            Matricula m = new Matricula();
            gvMatricula.DataSource = m.PesqMatricula(tbNome.Text);
            gvMatricula.DataBind();
        }
    }
}