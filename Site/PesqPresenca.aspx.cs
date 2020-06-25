using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;

namespace Site
{
    public partial class PesqPresenca : System.Web.UI.Page
    {
        Utils u = new Utils();
        int codOcm = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            tbProf.Attributes.Add("readonly", "readonly");
        }

        protected void btnMostrarModulos_Click(object sender, EventArgs e)
        {
            Presenca p = new Presenca();

            gvModulos.DataSource = p.RecuperarModulosProfessor(Convert.ToInt32(hfProf.Value));
            gvModulos.DataBind();
            pModulos.Visible = true;
            pAlunos.Visible = false;
        }

        protected void lbtnSelecionar_Command(object sender, CommandEventArgs e)
        {
            string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
            int ocCod = Convert.ToInt32(commandArgsAccept[0]);
            int modCod = Convert.ToInt32(commandArgsAccept[1]);
            codOcm = Convert.ToInt32(commandArgsAccept[3]);
            ViewState.Add("ocmCod", codOcm);
            ViewState.Add("occod", ocCod);
            ViewState.Add("modcod", modCod);
            Presenca p = new Presenca();
            gvAlunos.DataSource = p.RecuperarAlunosOCM(ocCod, modCod);
            gvAlunos.DataBind();
            pAlunos.Visible = true;
            pModulos.Visible = false;
        }

        protected void gvAlunos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltCk = (Literal)e.Row.FindControl("ltCk");

                string cod = DataBinder.Eval(e.Row.DataItem, "Aluno.Ra").ToString();
                string ck = "<img src=\"_design\\imgs\\apply.png\" alt=\"presente\" \\> Presente";
                Presenca p = new Presenca();
                string[] vet = p.RecuperarAlunosComFaltas(Convert.ToDateTime(tbData.Text), codOcm).Split(',');
                for (int i = 0; i < vet.Length; i++)
                {
                    if (cod == vet[i])
                    {
                        ck = "<img src=\"_design\\imgs\\cancel.png\" alt=\"falta\" \\> Falta";
                    }
                }

                ltCk.Text = ck;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PesqPresenca.aspx");
        }

        protected void gvModulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Literal ltTxt = (Literal)e.Row.FindControl("ltTxt");
                LinkButton lbtnSelecionar = (LinkButton)e.Row.FindControl("lbtnSelecionar");

                string cod = DataBinder.Eval(e.Row.DataItem, "Ocm.Cod").ToString();

                Presenca p = new Presenca();
                string[] vet = p.RecuperarOcmLancadonoDia(Convert.ToDateTime(tbData.Text)).Split(',');
                if (!vet.Contains(cod))
                {
                    lbtnSelecionar.Visible = false;
                    ltTxt.Text = "Não há lançamento nessa data";
                }

            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            Presenca p = new Presenca();
            if (p.ExcluirLancamento(Convert.ToDateTime(tbData.Text), Convert.ToInt32(ViewState["ocmCod"])))
            {
                Response.Redirect("PesqPresenca.aspx");
            }
            else
            {
                u.MsgBox(this, "Não foi possivel excluir o Lançamento de falta.");
            }
        }
    }
}