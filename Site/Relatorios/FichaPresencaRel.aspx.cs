using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;
using System.Data;
using System.IO;

namespace Site.Relatorios
{
    public partial class FichaPresencaRel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbProf.Attributes.Add("readonly", "readonly");
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    tbProf.Text = Request.QueryString["desc"].ToString();
                    Presenca p = new Presenca();

                    gvModulos.DataSource = p.RecuperarModulosProfessor(Convert.ToInt32(Request.QueryString["id"]));
                    gvModulos.DataBind();
                    pModulos.Visible = true;
                }
            }
        }

        protected void lbtnSelec_Command(object sender, CommandEventArgs e)
        {
            string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
            int ocCod = Convert.ToInt32(commandArgsAccept[0]);
            int modCod = Convert.ToInt32(commandArgsAccept[1]);
            string descMod = commandArgsAccept[2].ToString();

            FichaPresencaCr cr = new FichaPresencaCr();

            FichaPresencaDs ds = new FichaPresencaDs();

            Presenca p = new Presenca();

            DataTable dt = p.RecuperarAlunosRel(ocCod, modCod);

            ds.dtFichaPresenca.Merge(dt);

            cr.SetDataSource(ds);
            cr.SetParameterValue("pProf", tbProf.Text);
            cr.SetParameterValue("pModulo", descMod);

            Stream relStream = cr.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            BinaryReader stream = new BinaryReader(relStream);
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=relatorio.pdf");
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Close();
        }
    }
}