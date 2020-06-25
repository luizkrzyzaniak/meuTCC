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
    public partial class HorarioAlunoRel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbOc.Attributes.Add("readonly", "readonly");
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    hfCodOc.Value = Request.QueryString["id"];
                    tbOc.Text = Request.QueryString["desc"];
                    pAluno.Visible = true;
                    Alunos a = new Alunos();
                    gvAlunos.DataSource = a.RecuperarAlunosOC(Convert.ToInt32(Request.QueryString["id"]));
                    gvAlunos.DataBind();
                }
            }
        }

        protected void lbtnSelec_Command(object sender, CommandEventArgs e)
        {
            string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
            int ra = Convert.ToInt32(commandArgsAccept[0]);
            string nome = commandArgsAccept[1].ToString();

            HorarioAlunoCr cr = new HorarioAlunoCr();

            HorarioAlunoDs ds = new HorarioAlunoDs();

            OfertaCursoModulo ocm = new OfertaCursoModulo();

            DataTable dt = ocm.RecuperarHrAluno(ra, Convert.ToInt32(hfCodOc.Value));

            ds.dtHorario.Merge(dt);

            cr.SetDataSource(ds);
            cr.SetParameterValue("pNome", nome);
            cr.SetParameterValue("pRa", ra);

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