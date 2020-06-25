using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Bancos;
using System.Data;

namespace CamadaNegocios
{
    public class OfertaCurso
    {
        private int _codOferta;

        public int CodOferta
        {
            get { return _codOferta; }
            set { _codOferta = value; }
        }
        private DateTime _dtInicio;

        public DateTime DtInicio
        {
            get { return _dtInicio; }
            set { _dtInicio = value; }
        }
        private DateTime _dtFinal;

        public DateTime DtFinal
        {
            get { return _dtFinal; }
            set { _dtFinal = value; }
        }
        private int _unidadeEnsino;

        public int UnidadeEnsino
        {
            get { return _unidadeEnsino; }
            set { _unidadeEnsino = value; }
        }
        private int _curso;

        public int Curso
        {
            get { return _curso; }
            set { _curso = value; }
        }

        private string _desc;

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }

        private Alunos _aluno;

        public Alunos Aluno
        {
            get { return _aluno; }
            set { _aluno = value; }
        }

        SqlServer _bd = new SqlServer();

        public OfertaCurso()
        {
            _codOferta = 0;
            _dtInicio = DateTime.Now;
            _dtFinal = DateTime.Now;
            _unidadeEnsino = 0;
            _curso = 0;
            _desc = "";

        }

        public OfertaCurso(int codOferta, DateTime dtInicio, DateTime dtFinal, int unidadeEnsino, int curso, string desc)
        {
            _codOferta = codOferta;
            _dtInicio = dtInicio;
            _dtFinal = dtFinal;
            _unidadeEnsino = unidadeEnsino;
            _curso = curso;
            _desc = desc;
        }

        public OfertaCurso(string desc)
        {
            _desc = desc;
        }

        public bool GravarOfertaCurso()
        {
            _bd.Comando.CommandText = @"insert into ofertacurso(cur_cod,ue_cod,oc_dtinicio,oc_dtfinal, oc_desc)
			                                            values(@cur, @ue, @dtinicio, @dtfinal, @desc)";
            _bd.Comando.Parameters.Add("@cur", this._curso);
            _bd.Comando.Parameters.Add("@ue", this._unidadeEnsino);
            _bd.Comando.Parameters.Add("@dtinicio", this._dtInicio);
            _bd.Comando.Parameters.Add("@dtfinal", this._dtFinal);
            _bd.Comando.Parameters.Add("@desc", this._desc);

            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                _bd.Comando.CommandText = @"select MAX(oc_cod) as maxcod from ofertacurso";
                DataTable dt = _bd.ExecutarComando();
                if (dt.Rows.Count > 0)
                {
                    _codOferta = Convert.ToInt32(dt.Rows[0]["maxcod"]);
                }
                return true;
            }
            else return false;
        }

        



        public List<OfertaCurso> PesqOfertaCurso(int codue)
        {
            List<OfertaCurso> ListaOC = new List<OfertaCurso>();
            _bd.Comando.CommandText = @"select oc_cod, oc_desc, cur_cod from ofertacurso
                                        where ue_cod = @ue";
            _bd.Comando.Parameters.Add("@ue", codue);
            DataTable dt = _bd.ExecutarComando();
            foreach (DataRow item in dt.Rows)
            {
                OfertaCurso oc = new OfertaCurso()
                {
                    _codOferta = Convert.ToInt32(item["oc_cod"]),
                    _desc = item["oc_desc"].ToString(),
                    _curso = Convert.ToInt32(item["cur_cod"])
                };
                ListaOC.Add(oc);
            }

            return ListaOC;
        }

        public bool RecuperarOfertaCurso(int cod)
        {
            _bd.Comando.CommandText = @"select * from ofertacurso where oc_cod = @cod";
            _bd.Comando.Parameters.Add("@cod", cod);
            DataTable dt = _bd.ExecutarComando();

            if (dt.Rows.Count > 0)
            {
                _codOferta = Convert.ToInt32(dt.Rows[0]["oc_cod"]);
                _curso = Convert.ToInt32(dt.Rows[0]["cur_cod"]);
                _unidadeEnsino = Convert.ToInt32(dt.Rows[0]["ue_cod"]);
                _dtInicio = Convert.ToDateTime(dt.Rows[0]["oc_dtinicio"]);
                _dtFinal = Convert.ToDateTime(dt.Rows[0]["oc_dtfinal"]);
                _desc = dt.Rows[0]["oc_desc"].ToString();

                return true;
            }
            else return false;
        }

        public bool ExcluirOfertaCurso(int cod)
        {
            
            try
            {
                _bd.Comando.CommandText = @"delete ofertacurso where oc_cod = @cod";
                _bd.Comando.Parameters.Add("@cod", cod);
                _bd.ExecutarComandoNonQuery();        
                    return true;
	        }
	        catch (Exception)
	        {
                return false;
                throw;
	        }
            
        }

        public bool AlterarOC()
        {
            _bd.Comando.CommandText = @"UPDATE ofertacurso set
                                        oc_desc = @nome,
                                        oc_dtinicio = @dtinicio,
                                        oc_dtfinal = @dtfinal
                                        where oc_cod = @cod";
            _bd.Comando.Parameters.Add("@cod", this._codOferta);
            _bd.Comando.Parameters.Add("@nome", this._desc);
            _bd.Comando.Parameters.Add("@dtinicio", this._dtInicio);
            _bd.Comando.Parameters.Add("@dtfinal", this._dtFinal);
            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }


        public List<OfertaCurso> GerarCertificado(int codOc)
        {
            List<OfertaCurso> Lista = new List<OfertaCurso>();
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select distinct a.alu_ra, a.alu_cpf, alu_nome, oc_dtinicio, oc_dtfinal from ofertacurso oc, ofertacursomodulo ocm, alunos_ofertacursomodulo aocm, alunos a
                                        where
                                        oc.oc_cod = @oc and
                                        ocm.oc_cod = oc.oc_cod and
                                        aocm.ocm_cod = ocm.ocm_cod and
                                        a.alu_ra = aocm.alu_ra";
            _bd.Comando.Parameters.Add("@oc", codOc);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    OfertaCurso oc = new OfertaCurso();
                    {
                        oc.Aluno = new Alunos();
                        oc.Aluno.Ra = Convert.ToInt32(item["alu_ra"]);
                        oc.Aluno.Cpf = item["alu_cpf"].ToString();
                        oc.Aluno.Nome = item["alu_nome"].ToString();
                        oc.DtInicio = Convert.ToDateTime(item["oc_dtinicio"]);
                        oc.DtFinal = Convert.ToDateTime(item["oc_dtfinal"]);
                    }
                    Lista.Add(oc);
                }
            }
            return Lista;
        }


        
        
    }
}
