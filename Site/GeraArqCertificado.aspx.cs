using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using CamadaNegocios;

namespace Site
{
    public partial class GeraArqCertificado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    tbPesq.Text = Request.QueryString["desc"];
                    hfOferta.Value = Request.QueryString["id"];
                    btnGerar.Visible = true;
                }
            }
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            if (File.Exists(Server.MapPath(@"~\_csv\") + @"exporta_SAAET.csv"))

                File.Delete(Server.MapPath(@"~\_csv\") + @"exporta_SAAET.csv");


            StreamWriter stream = new StreamWriter(Server.MapPath(@"~\_csv\") + @"exporta_SAAET.csv", false);

            OfertaCurso oc = new OfertaCurso();
            List<OfertaCurso> lista = oc.GerarCertificado(Convert.ToInt32(hfOferta.Value));

            string header = "RA;CPF;Nome;DtInicio;DtFinal";
            stream.WriteLine(header);

            for (int i = 0; i < lista.Count; i++)
            {
                string linha = lista[i].Aluno.Ra.ToString() + ";" + lista[i].Aluno.Cpf.ToString() + ";" + lista[i].Aluno.Nome.ToString() + ";" + lista[i].DtInicio.ToString("dd/MM/yyyy") + ";" + lista[i].DtFinal.ToString("dd/MM/yyyy");
                stream.WriteLine(linha);
            }
           

            stream.Close();
            Response.Clear();

    

            byte[] vet = File.ReadAllBytes(Server.MapPath(@"~\_csv\") + @"exporta_SAAET.csv");

            Response.AddHeader("content-disposition", "attachment; filename=exporta_SAAET.csv");
            Response.ContentType = "text/plain";
            Response.BinaryWrite(vet);

         
            Response.End();

        }
    }
}