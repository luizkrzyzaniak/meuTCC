using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;

namespace Site
{
    public partial class PesqProfessor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Pesquisar()
        {
            Professor prof = new Professor(tbPesq.Text);
            gvProf.DataSource = prof.PesqProfessor();
            gvProf.DataBind();
        }

        protected void btnPesq_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }

        
    }
}