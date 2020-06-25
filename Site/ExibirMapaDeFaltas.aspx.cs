using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CamadaNegocios;

namespace Site
{
    public partial class ExibirMapaDeFaltas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    Modulos mod = new Modulos();

                    int cont = -1;
                    int contSit = -1;

                    mod.RetornaNomeModulo(int.Parse(Request.QueryString["mod"]));
                    lModNome.Text = mod.DesModulo;
                    
                    OfertaCursoModulo ocm = new OfertaCursoModulo();
                    DataTable dt = new DataTable();
                    

                    dt.Columns.Add("Nome");
                    List<string> datas = ocm.DiasFaltasLancada(int.Parse(Request.QueryString["id"])); //use aqui o método que retorna uma List de rels. do período.
                    foreach (string rel in datas)
                    {
                        dt.Columns.Add(rel);
                    }


                    List<string> listaAlunos = ocm.RecuperarAlunosOCM(int.Parse(Request.QueryString["oc"]), int.Parse(Request.QueryString["mod"]));

                    foreach (string aluno in listaAlunos)
                    {
                        DataRow row = dt.NewRow();
                        row["Nome"] = aluno;
                        dt.Rows.Add(row);
                    }

                    List<string> listaRa = ocm.RecuperarRaAluno(int.Parse(Request.QueryString["oc"]), int.Parse(Request.QueryString["mod"]));

                    foreach (DataRow row in dt.Rows)
                    {
                        cont++;
                        contSit = -1;
                        string raAlu = listaRa[cont];
                        List<string> sit = ocm.SituacaoAlunoPorData(raAlu, int.Parse(Request.QueryString["id"]));

                        foreach (DataColumn col in dt.Columns)
                        {
                            
                            if (col.ColumnName != "Nome")
                            {
                                contSit++;
                                        if (sit[contSit] == "F")
                                            row[col] = "X";
                                
                            }
                        }
                    }


                    gvMapa.DataSource = dt;
                    gvMapa.DataBind();
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("MapaDeFaltas.aspx");
        }
    }
}