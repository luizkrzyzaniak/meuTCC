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
    public partial class RelAlunosDevedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Alunos a = new Alunos();
            gvCidades.DataSource = a.RecuperarCidades();
            gvCidades.DataBind();
        }

        protected void lbtnSelecionar_Command(object sender, CommandEventArgs e)
        {
            RelAlunosDevedoresCr cr = new RelAlunosDevedoresCr();

            RelAlunosDevedoresDs ds = new RelAlunosDevedoresDs();

            Parcelas p = new Parcelas();

            DataTable dt = p.AlunosDevedores(e.CommandArgument.ToString());

            ds.dtAlunosDevedores.Merge(dt);

            cr.SetDataSource(ds);

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

        protected void gvCidades_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbtnSelecionar = (LinkButton)e.Row.FindControl("lbtnSelecionar");

                string cidade = DataBinder.Eval(e.Row.DataItem, "Cidade").ToString();
                Parcelas p = new Parcelas();
                DataTable dt = p.AlunosDevedores(cidade);
                if (dt.Rows.Count == 0)
                {
                    lbtnSelecionar.Visible = false;
                }

            }
        }
    }
}