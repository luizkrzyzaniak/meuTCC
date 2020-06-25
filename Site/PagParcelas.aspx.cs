using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;
using System.Data;
using System.IO;

namespace Site
{
    public partial class PagParcelas : System.Web.UI.Page
    {

        int numParc = 1;

        DateTime data;

        protected void Page_Load(object sender, EventArgs e)
        {
            tbAluno.Attributes.Add("readonly", "readonly");
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    tbAluno.Text = Request.QueryString["alu"];
                    CarregaAlteracao(int.Parse(Request.QueryString["id"]));
                    btnSelec.Visible = true;
                }
            }
        }
        Utils u = new Utils();

        string ckSelecionar;

        protected void CarregaAlteracao(int id)
        {
            Parcelas p = new Parcelas();
            gvParcelas.DataSource = p.PesqParcelas(id);
            gvParcelas.DataBind();
        }

        protected void gvParcelas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
                numParc = 1;

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Text = numParc.ToString();
                numParc++;
                Literal ltCk = (Literal)e.Row.FindControl("ltCk");

                string cod = DataBinder.Eval(e.Row.DataItem, "CodParcela").ToString();
                char sit = Convert.ToChar(DataBinder.Eval(e.Row.DataItem, "SitParcela"));

                if (sit == 'N')
                    ltCk.Text = "<input id=\"ckSelecionar\" name=\"ckSelecionar\" type=\"checkbox\" value=\"" + cod + "\" " + "/>";

                
            
            }
        }

        protected void btnSelec_Click(object sender, EventArgs e)
        {
            if (Request.Form["ckSelecionar"] != null)
            {
                ckSelecionar = Request.Form["ckSelecionar"];
                ViewState.Add("ParCodSel", ckSelecionar);

                if (ckSelecionar != "")
                {
                    string[] vet = ckSelecionar.Split(',');
                    Parcelas p = new Parcelas();
                    decimal valor = 0;
                    for (int i = 0; i < vet.Length; i++)
                    {
                        int cod = int.Parse(vet[i]);


                        valor = valor + p.RecuperarValorParcela(cod);

                    }
                    lValor.Text = "R$ " + valor.ToString("N2");
                }

                lValor.Visible = true;
                btnConf.Visible = true;
                lbtnImprimir.Visible = false;
            }
            else
            {
                u.MsgBox(this, "Selecione uma parcela.");
            }
        }

        protected void btnConf_Click(object sender, EventArgs e)
        {
            data = DateTime.Now;
            ckSelecionar = ViewState["ParCodSel"].ToString();
            if (ckSelecionar != "")
            {
                string[] vet = ckSelecionar.Split(',');
                Parcelas p = new Parcelas();
                for (int i = 0; i < vet.Length; i++)
                {
                    int cod = int.Parse(vet[i]);
                    p.PagarParcela(cod, data);
                }

                ViewState.Add("data", data);
                lValor.Visible = false;
                btnConf.Visible = false;
                lbtnImprimir.Visible = true;
                CarregaAlteracao(int.Parse(Request.QueryString["id"]));
                u.MsgBox(this, "Pagamento realizado com sucesso.");

                
            }
        }

        protected void lbtnImprimir_Click(object sender, EventArgs e)
        {
            Parcelas p = new Parcelas();
            Relatorios.ReciboCr cr = new Relatorios.ReciboCr();

            Relatorios.ReciboDs ds = new Relatorios.ReciboDs();
            data = Convert.ToDateTime(ViewState["data"]);
            DataTable dt = p.RecuperarParcelasPaga(Convert.ToInt32(Request.QueryString["id"]), data);

            ds.dtRecibo.Merge(dt);

            cr.SetDataSource(ds);
            cr.SetParameterValue("pNome", Request.QueryString["alu"]);

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