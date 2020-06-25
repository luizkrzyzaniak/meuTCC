using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;

namespace Site
{
    public partial class MapaDeFaltas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    tbProf.Text = Request.QueryString["desc"];
                    hfProf.Value = Request.QueryString["id"];
                    Presenca p = new Presenca();
                    gvModulos.DataSource = p.RecuperarModulosProfessor(int.Parse(hfProf.Value));
                    gvModulos.DataBind();
                }
            }
        }

        protected void lbtnGerar_Command(object sender, CommandEventArgs e)
        {
            string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
            int codOcm = Convert.ToInt32(commandArgsAccept[0]);
            int ocCod = Convert.ToInt32(commandArgsAccept[1]);
            int codMod = Convert.ToInt32(commandArgsAccept[2]);
            Response.Redirect("ExibirMapaDeFaltas.aspx?id=" + codOcm + "&oc=" + ocCod + "&mod=" + codMod);
        }

        
        
    }
}