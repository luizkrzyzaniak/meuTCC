using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;

namespace Site
{
    public partial class CadPresenca : System.Web.UI.Page
    {
        string ckSelecionar;
        Utils u = new Utils();

        protected void Page_Load(object sender, EventArgs e)
        {
            tbProf.Attributes.Add("readonly", "readonly");
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    hfProf.Value = Request.QueryString["id"].ToString();
                    tbProf.Text = Request.QueryString["desc"].ToString();
                    Presenca p = new Presenca();

                    gvModulos.DataSource = p.RecuperarModulosProfessor(Convert.ToInt32(Request.QueryString["id"]));
                    gvModulos.DataBind();
                    pModulo.Visible = true;
                }
            }
        }

        protected void lbtnSelec_Command(object sender, CommandEventArgs e)
        {
            string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
            int ocCod = Convert.ToInt32(commandArgsAccept[0]);
            int modCod = Convert.ToInt32(commandArgsAccept[1]);
            string descMod = commandArgsAccept[2].ToString();
            ViewState.Add("occod", ocCod);
            ViewState.Add("modcod", modCod);
            Presenca p = new Presenca();
            gvAlunos.DataSource = p.RecuperarAlunosOCM(ocCod, modCod);
            gvAlunos.DataBind();
            lInfo.Text = "Módulo: " + descMod + " - Data: " + DateTime.Now.ToString("dd/MM/yyyy");
            pAlunos.Visible = true;
            pModulo.Visible = false;
        }

        protected void gvAlunos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltCk = (Literal)e.Row.FindControl("ltCk");

                string cod = DataBinder.Eval(e.Row.DataItem, "Aluno.Ra").ToString();
                string ck = "";
                Parcelas p = new Parcelas();
                
                ck = "";

                ltCk.Text = "<input id=\"ckSelecionar\" name=\"ckSelecionar\" type=\"checkbox\" value=\"" + cod + "\" " + ck + "/>";
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
               ckSelecionar = Request.Form["ckSelecionar"];
                
                if (ckSelecionar != "")
                {
                    Presenca p = new Presenca();
                    p.LancarFaltas(ckSelecionar, Convert.ToInt32(ViewState["occod"]), Convert.ToInt32(ViewState["modcod"]));
                    u.MsgBox(this, "Lançamento de faltas realizado com sucesso.");
                    Response.Redirect("CadPresenca.aspx");
                }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pAlunos.Visible = false;
            pModulo.Visible = true;
        }

        protected void gvModulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal lTxt = (Literal)e.Row.FindControl("lTxt");
                LinkButton lbtnSelec = (LinkButton)e.Row.FindControl("lbtnSelec");

                string cod = DataBinder.Eval(e.Row.DataItem, "Ocm.Cod").ToString();

                Presenca pre = new Presenca();
                string[] str = pre.VerificaDia(Convert.ToInt32(cod)).Split(',');

                for (int i = 0; i < str.Length; i++)
                {
                    if (cod == str[i])
                    {
                        lTxt.Text = "Lançamento do dia realizado com sucesso." ;
                        lbtnSelec.Visible = false;
                    }
                }

                
            }
        }

        protected void btmPesqLanc_Click(object sender, EventArgs e)
        {
            Response.Redirect("PesqPresenca.aspx");
        }
    }
}