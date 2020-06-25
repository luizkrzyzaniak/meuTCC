using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Bancos;
using System.Data;

namespace CamadaNegocios
{
    public class Matricula
    {
        private int _codMatricula;

        public int CodMatricula
        {
            get { return _codMatricula; }
            set { _codMatricula = value; }
        }
        private DateTime _dtMatricula;

        public DateTime DtMatricula
        {
            get { return _dtMatricula; }
            set { _dtMatricula = value; }
        }

        private int _codOC;

        SqlServer _bd = new SqlServer();

        public int CodOC
        {
            get { return _codOC; }
            set { _codOC = value; }
        }

        private Alunos _aluno;

        public Alunos Aluno
        {
            get { return _aluno; }
            set { _aluno = value; }
        }
        private OfertaCurso _oferta;

        public OfertaCurso Oferta
        {
            get { return _oferta; }
            set { _oferta = value; }
        }

        public Matricula()
        {
            _codMatricula = 0;
            _dtMatricula = DateTime.Now;
            _codOC = 0;
        }

        public Matricula(int codMatricula, DateTime dtMatricula, int codOC)
        {
            _codMatricula = codMatricula;
            _dtMatricula = dtMatricula;
            _codOC = codOC;
        }

        public bool GravarMatricula()
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"insert into matricula(oc_cod,mat_data)
                                                       values(@ocCod, @data)";
            _bd.Comando.Parameters.Add("@ocCod", this._codOC);
            _bd.Comando.Parameters.Add("@data", this._dtMatricula);
            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                _bd.Comando.CommandText = @"select MAX(mat_cod) as maxcod from matricula";
                DataTable dt = _bd.ExecutarComando();

                if (dt.Rows.Count > 0)
                {
                    _codMatricula = Convert.ToInt32(dt.Rows[0]["maxcod"]);
                }
                    return true;
            }
            else return false;
        }


        public bool GravarAlunoOfertaCursoModulo(int alu, int ocm, int mat)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"insert into alunos_ofertacursomodulo(alu_ra,ocm_cod,mat_cod)
                                                       values(@alu, @ocm, @mat)";
            _bd.Comando.Parameters.Add("@alu", alu);
            _bd.Comando.Parameters.Add("@ocm", ocm);
            _bd.Comando.Parameters.Add("@mat", mat);
            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }

        public List<Matricula> PesqMatricula(string nome)
        {
            List<Matricula> listaMat = new List<Matricula>();
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select DISTINCT m.mat_cod, m.mat_data,a.alu_ra, a.alu_nome, oc.oc_desc from matricula m, alunos a, ofertacurso oc, ofertacursomodulo ocm, alunos_ofertacursomodulo aocm
                                        where
                                        oc.oc_cod = m.oc_cod and
                                        ocm.oc_cod = oc.oc_cod and
                                        aocm.ocm_cod = ocm.ocm_cod and
                                        a.alu_ra = aocm.alu_ra and
                                        m.mat_cod = aocm.mat_cod and
                                        a.alu_nome like @nome";
            _bd.Comando.Parameters.Add("@nome", "%" + nome + "%");
            DataTable dt = _bd.ExecutarComando();
            foreach (DataRow item in dt.Rows)
            {
                Matricula m = new Matricula();
                {
                    m.Aluno = new Alunos();
                    m.Oferta = new OfertaCurso();
                    m.Aluno.Ra = Convert.ToInt32(item["alu_ra"]);
                    m.Aluno.Nome = item["alu_nome"].ToString();
                    m.Oferta.Desc = item["oc_desc"].ToString();
                    m.CodMatricula = Convert.ToInt32(item["mat_cod"]);
                    m.DtMatricula = Convert.ToDateTime(item["mat_data"]);
                };
                listaMat.Add(m);
            }
            return listaMat;
        }

        public bool RecupararMatricula(int codmat)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select DISTINCT a.alu_ra, a.alu_nome, oc.oc_desc, oc.oc_cod from matricula m, alunos a, ofertacurso oc, ofertacursomodulo ocm, alunos_ofertacursomodulo aocm
                                        where
                                        oc.oc_cod = m.oc_cod and
                                        ocm.oc_cod = oc.oc_cod and
                                        aocm.ocm_cod = ocm.ocm_cod and
                                        a.alu_ra = aocm.alu_ra and
                                        m.mat_cod = aocm.mat_cod and
                                        m.mat_cod = @codmat";
            _bd.Comando.Parameters.Add("@codmat", codmat);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
               
                
                    this.Aluno = new Alunos();
                    this.Oferta = new OfertaCurso();
                    this.Aluno.Ra = Convert.ToInt32(dt.Rows[0]["alu_ra"]);
                    this.Aluno.Nome = dt.Rows[0]["alu_nome"].ToString();
                    this.Oferta.Desc = dt.Rows[0]["oc_desc"].ToString();
                    this.Oferta.CodOferta = Convert.ToInt32(dt.Rows[0]["oc_cod"]);
                
                return true;
            }
            else return false;
        }

        public bool ExcluirMatricula(int codmat)
        {
            try
            {
                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"delete matricula where mat_cod = @cod";
                _bd.Comando.Parameters.Add("@cod", codmat);
                _bd.ExecutarComandoNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool ExcluirAlunoOfertaCursoModulo(int codmat)
        {
            try
            {
                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"delete alunos_ofertacursomodulo where mat_cod = @cod";
                _bd.Comando.Parameters.Add("@cod", codmat);
                _bd.ExecutarComandoNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool AlterarMatricula()
        {
            _bd.Comando.CommandText = @"UPDATE matricula set
                                        oc_cod = @occod,
                                        mat_data = @dtmat
                                        where mat_cod = @matcod";
            _bd.Comando.Parameters.Add("@occod", this._codOC);
            _bd.Comando.Parameters.Add("@dtmat", this._dtMatricula);
            _bd.Comando.Parameters.Add("@matcod", this._codMatricula);
            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }


        public bool VerificarAlunoCadastrado(int codOc, int ra)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select DISTINCT m.mat_cod, m.mat_data,a.alu_ra, a.alu_nome, oc.oc_desc from matricula m, alunos a, ofertacurso oc, ofertacursomodulo ocm, alunos_ofertacursomodulo aocm
                                        where
                                        oc.oc_cod = m.oc_cod and
                                        ocm.oc_cod = oc.oc_cod and
                                        aocm.ocm_cod = ocm.ocm_cod and
                                        a.alu_ra = aocm.alu_ra and
                                        m.mat_cod = aocm.mat_cod and
                                        oc.oc_cod = @codOc and
                                        a.alu_ra like @ra";
            _bd.Comando.Parameters.Add("@codOc", codOc);
            _bd.Comando.Parameters.Add("@ra", ra);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
                return false;
            else return true;
        }
    }

}
