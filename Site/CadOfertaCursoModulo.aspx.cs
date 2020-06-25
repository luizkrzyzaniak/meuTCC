using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;

namespace Site
{
    public partial class CadOfertaCursoModulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            btnPesqProf.OnClientClick = "return btnPesq_Click()";
            tbProf.Attributes.Add("readonly", "readonly");
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["oferta"]))
                {
                    lInfo.Text = "Informação da Oferta de Curso: Data Incial " + Session["dti"] + " Data Final " + Session["dtf"];
                    Modulos mod = new Modulos();
                    hfOferta.Value = Request.QueryString["oferta"];
                    gvModulos.DataSource = mod.PesqModCurso(int.Parse(Request.QueryString["cur"]));
                    gvModulos.DataBind();
                    Novo();
                }
            }

        }

        protected void Novo()
        {
            hfCod.Value = "";
            hfprof.Value = "";
            hfCodMod.Value = "";
            tbProf.Text = "";
            pModulos.Visible = true;
            OfertaCursoModulo ocm = new OfertaCursoModulo();
            gvModSelecionados.DataSource = ocm.RecuperarModulosSelecionados(Convert.ToInt32(hfOferta.Value));
            gvModSelecionados.DataBind();
            
        }

        protected void lbtnAddMod_Command(object sender, CommandEventArgs e)
        {
            hfCodMod.Value = e.CommandArgument.ToString();
            pModulos.Visible = false;
            btnGravar.Visible = true;
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            DateTime dti = Convert.ToDateTime(tbDtinicial.Text), dtf = Convert.ToDateTime(tbDtFinal.Text);
            DateTime dtiOc = Convert.ToDateTime(Session["dti"]), dtfOc = Convert.ToDateTime(Session["dtf"]);

            if (dti < dtf && dti >= dtiOc && dtf <= dtfOc)
            {
                int codigo = 0;
                if (hfCod.Value != "")
                    codigo = Convert.ToInt32(hfCod.Value);

                OfertaCursoModulo ocm = new OfertaCursoModulo(codigo, Convert.ToDateTime(tbDtinicial.Text), Convert.ToDateTime(tbDtFinal.Text), Convert.ToInt32(hfCodMod.Value), Convert.ToInt32(hfOferta.Value));
                if (ocm.GravarOCM())
                {
                    ocm.GravarProfOCM(ocm.Cod, Convert.ToInt32(hfprof.Value));
                    Novo();
                    Modulos mod = new Modulos();
                    gvModulos.DataSource = mod.PesqModCurso(int.Parse(Request.QueryString["cur"]));
                    gvModulos.DataBind();
                    btnFinal.Visible = true;
                    btnGravar.Visible = false;
                }
            }
            else
            {
                Utils u = new Utils();
                u.MsgBox(this, "Verifique a Data inicial e a Data Final");
            }
        }

        protected void lbtnExcluir_Command(object sender, CommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            OfertaCursoModulo ocm = new OfertaCursoModulo();
            if (ocm.ExcluirPROF_OCM(codigo))
            {
                if (ocm.ExcluirOCM(codigo))
                {
                    Novo();
                    Modulos mod = new Modulos();
                    gvModulos.DataSource = mod.PesqModCurso(int.Parse(Request.QueryString["cur"]));
                    gvModulos.DataBind();
                }
                
            }
            else
            {
                Utils u = new Utils();
                u.MsgBox(this, "Não foi possivel excluir.");
            }
            
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Novo();
        }

        protected void gvModulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
                if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbtnAddMod = (LinkButton)e.Row.FindControl("lbtnAddMod");

                string cod = DataBinder.Eval(e.Row.DataItem, "CodModulo").ToString();
                OfertaCursoModulo o = new OfertaCursoModulo();
                string[] vet = o.VerificarModulosSel(Convert.ToInt32(hfOferta.Value)).Split(',');
                for (int i = 0; i < vet.Length; i++)
                {
                    if (vet.Contains(cod))
                    {
                        lbtnAddMod.Visible = false;
                    }
                    
                }

            }
        }

        protected void btnFinal_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadOfertarCurso.aspx");
        }


    }
}