using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocios;

namespace Site
{
    public partial class CadMatricula : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tbAluno.Attributes.Add("readonly", "readonly");
            tbOfertaCurso.Attributes.Add("readonly", "readonly");
            tbValor.Attributes.Add("readonly", "readonly");
            btnAluno.OnClientClick = "return btnPesqAluno_Click()";
            btnOfertaCurso.OnClientClick = "return btnPesqOferta_Click()";
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                {
                    CarregaAlteracao(int.Parse(Request.QueryString["id"]));

                }
            }
        }

        string ckSelecionar;
        decimal valorParc;

        Utils u = new Utils();

        protected void CarregaAlteracao(int id)
        {
            Matricula m = new Matricula();
            if (m.RecupararMatricula(id))
            {
                hfAluno.Value = m.Aluno.Ra.ToString();
                hfOferta.Value = m.Oferta.CodOferta.ToString();
                tbAluno.Text = m.Aluno.Nome.ToString();
                tbOfertaCurso.Text = m.Oferta.Desc.ToString();
                hfMatricula.Value = id.ToString();
                CarregaGvModulos(id);
                pModulos.Visible = true;
                CarregaGvModulos(Convert.ToInt32(hfOferta.Value));
                tbDtParcela.Text = DateTime.Now.ToString();
                btnExcluir.Visible = true;
                //SelecionarModulos();
            }
        }

        protected void LimpaTela()
        {
            Response.Redirect("CadMatricula.aspx");
        }

        protected void CarregaGvModulos(int codOC)
        {
            OfertaCursoModulo ocm = new OfertaCursoModulo();

            gvModulos.DataSource = ocm.RecuperarModulosSelecionados(codOC);
            gvModulos.DataBind();
        }

        protected void btnExbir_Click(object sender, EventArgs e)
        {
            if (hfOferta.Value != "")
            {
                pModulos.Visible = true;
                CarregaGvModulos(Convert.ToInt32(hfOferta.Value));
            }
            else
            {
                u.MsgBox(this, "Escolha uma Oferta de Curso");
            }
        }

        protected void btnSelecionar_Click(object sender, EventArgs e)
        {
            SelecionarModulos();
            gvModulos.Visible = false;
            btnSelecionar.Visible = false;
        }

        private void SelecionarModulos()
        {
            if (Request.Form["ckSelecionar"] != null)
            {
                if (hfMatricula.Value == "")
                {
                    ckSelecionar = Request.Form["ckSelecionar"];
                    ViewState.Add("ocmSel", ckSelecionar);

                    if (ckSelecionar != "")
                    {
                        string[] vet = ckSelecionar.Split(',');
                        OfertaCursoModulo ocm = new OfertaCursoModulo();
                        double valor = 0;
                        for (int i = 0; i < vet.Length; i++)
                        {
                            int cod = int.Parse(vet[i]);


                            valor = valor + ocm.RecuperarValorModulos(cod);

                        }
                        tbValor.Text = valor.ToString();
                    }
                }
                else
                {
                    ckSelecionar = Request.Form["ckSelecionar"];
                    ViewState.Add("ocmSel", ckSelecionar);

                    if (ckSelecionar != "")
                    {
                        string[] vet = ckSelecionar.Split(',');
                        OfertaCursoModulo ocm = new OfertaCursoModulo();
                        double valor = 0;
                        for (int i = 0; i < vet.Length; i++)
                        {
                            int cod = int.Parse(vet[i]);


                            valor = valor + ocm.RecuperarValorModulos(cod);

                        }
                        Parcelas p = new Parcelas();
                        double vlrParExcl = p.ValorParcelasPagaExcluidas(Convert.ToInt32(hfMatricula.Value));
                        valor = valor - vlrParExcl;
                        tbValor.Text = valor.ToString();
                    }
                    else
                    {
                        u.MsgBox(this, "Selecione pelo menos um modulo.");
                    }
                }
            }
        }

        protected void tbNumParcelas_TextChanged(object sender, EventArgs e)
        {
            tbValor.Text = tbValor.Text.Trim();
            if (tbValor.Text.Length > 0)
            {
                decimal valor = Convert.ToDecimal(tbValor.Text);
                decimal parcelas = Convert.ToDecimal(tbNumParcelas.Text);
                valorParc = valor / parcelas;
                lDetalhes.Text = parcelas.ToString() + "x de R$ " + valorParc.ToString("N2");
                ViewState.Add("vlParc", valorParc);
            }
        }

        protected void gvModulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            { 
                Literal ltCk = (Literal)e.Row.FindControl("ltCk");

                string cod = DataBinder.Eval(e.Row.DataItem, "Cod").ToString();
                string ck = "";
                Parcelas p = new Parcelas();
                if (hfMatricula.Value != "")
                {
                    string[] cods = p.RecuperarOCMselecionados(Convert.ToInt32(hfMatricula.Value)).ToString().Split(',');
                    ck = "checked=\"checked\"";

                    for (int i = 0; i < cods.Length; i++)
                    {
                        if (!cods.Contains(cod))
                            ck = "";
                    }
                }
                else
                {
                    ck = "";
                }

                ltCk.Text =  "<input id=\"ckSelecionar\" name=\"ckSelecionar\" type=\"checkbox\" value=\"" + cod + "\" " + ck + "/>";
            
            }
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (hfMatricula.Value == "")
                {
                    Matricula mat = new Matricula();
                    if (mat.VerificarAlunoCadastrado(Convert.ToInt32(hfOferta.Value), Convert.ToInt32(hfAluno.Value)))
                    {
                        if (ViewState["vlParc"] != null)
                        {
                            valorParc = Convert.ToDecimal(ViewState["vlParc"]);
                        }
                        int codigo = 0;
                        int matricula = 0;
                        DateTime data = Convert.ToDateTime(tbDtParcela.Text);
                        int qtdParc = Convert.ToInt32(tbNumParcelas.Text);

                        if (hfMatricula.Value != "")
                            codigo = Convert.ToInt32(hfMatricula.Value);

                        Matricula m = new Matricula(codigo, DateTime.Now, Convert.ToInt32(hfOferta.Value));
                        m.GravarMatricula();
                        matricula = m.CodMatricula;

                        string[] vet = ViewState["ocmSel"].ToString().Split(',');
                        for (int i = 0; i < vet.Length; i++)
                        {
                            int cod = int.Parse(vet[i]);
                            m.GravarAlunoOfertaCursoModulo(Convert.ToInt32(hfAluno.Value), cod, matricula);

                        }


                        Parcelas p = new Parcelas();
                        p.GravarParcela(matricula, valorParc, data, Convert.ToChar(ddlSit.SelectedItem.Value), DateTime.Now);

                        for (int i = 0; i < qtdParc - 1; i++)
                        {
                            data = data.AddDays(30);
                            p.GravarParcela(matricula, valorParc, data, 'N', DateTime.Now);
                        }
                        LimpaTela();
                        u.MsgBox(this, "Matricula gravada com sucesso.");
                    }
                    else
                    {
                        u.MsgBox(this, "Aluno já gravado na oferta curso selecionada.");
                    }
                }
                else
                {
                    if (ViewState["vlParc"] != null)
                    {
                        valorParc = Convert.ToInt32(ViewState["vlParc"]);
                    }
                    int codigo = 0;
                    DateTime data = Convert.ToDateTime(tbDtParcela.Text);
                    int qtdParc = Convert.ToInt32(tbNumParcelas.Text);

                    if (hfMatricula.Value != "")
                        codigo = Convert.ToInt32(hfMatricula.Value);

                    Matricula m = new Matricula(codigo, DateTime.Now, Convert.ToInt32(hfOferta.Value));
                    m.AlterarMatricula();

                    m.ExcluirAlunoOfertaCursoModulo(codigo);

                    string[] vet = ViewState["ocmSel"].ToString().Split(',');
                    for (int i = 0; i < vet.Length; i++)
                    {
                        int cod = int.Parse(vet[i]);
                        m.GravarAlunoOfertaCursoModulo(Convert.ToInt32(hfAluno.Value), cod, codigo);

                    }
                               
                    Parcelas p = new Parcelas();
                    p.ExcluirParcelas(codigo);

                    p.GravarParcela(codigo, valorParc, data, Convert.ToChar(ddlSit.SelectedItem.Value), DateTime.Now);

                    for (int i = 0; i < qtdParc - 1; i++)
                    {
                        data = data.AddDays(30);
                        p.GravarParcela(codigo, valorParc, data, 'N', DateTime.Now);
                    }
                    LimpaTela();
                    u.MsgBox(this, "Matricula alterada com sucesso.");
                }
            }
            else
            {
                u.MsgBox(this, "Pagina não validada.");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpaTela();
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            int mat = Convert.ToInt32(hfMatricula.Value);
            Matricula m = new Matricula();
            Parcelas p = new Parcelas();

            p.ExcluirParcelas(mat);
            m.ExcluirAlunoOfertaCursoModulo(mat);
            m.ExcluirMatricula(mat);

        }
    }
}