using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;

namespace Site
{
    public partial class PesqCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPesq_Click(object sender, EventArgs e)
        {
            Curso cur = new Curso(tbDesc.Text);
            gvCurso.DataSource = cur.PesqCurso();
            gvCurso.DataBind();
        }
    }
}