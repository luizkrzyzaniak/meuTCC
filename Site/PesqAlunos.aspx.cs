using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;

namespace Site
{
    public partial class PesqAlunos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Pesquisar()
        {
            Alunos alu = new Alunos(tbNome.Text);
            gvAlunos.DataSource = alu.PesqAlunos();
            gvAlunos.DataBind();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            Pesquisar();
        }
        
                
    }
}