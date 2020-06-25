using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Bancos;
using System.Data;

namespace CamadaNegocios
{
    public class OfertaCursoModulo
    {
        private int _cod;

        public int Cod
        {
            get { return _cod; }
            set { _cod = value; }
        }
        private DateTime _dtInicioModulo;

        public DateTime DtInicioModulo
        {
            get { return _dtInicioModulo; }
            set { _dtInicioModulo = value; }
        }
        private DateTime _dtFinalModulo;

        public DateTime DtFinalModulo
        {
            get { return _dtFinalModulo; }
            set { _dtFinalModulo = value; }
        }
        private int _modulo;

        public int Modulo
        {
            get { return _modulo; }
            set { _modulo = value; }
        }

        private int _ocCod;

        public int OcCod
        {
            get { return _ocCod; }
            set { _ocCod = value; }
        }

        Professor _professor;

        public Professor Professor
        {
            get { return _professor; }
            set { _professor = value; }
        }

        Modulos _mod;

        public Modulos Mod
        {
            get { return _mod; }
            set { _mod = value; }
        }


        SqlServer _bd = new SqlServer();

        public OfertaCursoModulo()
        {
            _cod = 0;
            _dtInicioModulo = DateTime.Now;
            _dtFinalModulo = DateTime.Now;
            _modulo = 0;
            _ocCod = 0;
        }

        public OfertaCursoModulo(int cod, DateTime dtInicio, DateTime dtFinal, int modulo, int ocCod)
        {
            _cod = cod;
            _dtInicioModulo = dtInicio;
            _dtFinalModulo = dtFinal;
            _modulo = modulo;
            _ocCod = ocCod;
        }

        public bool GravarOCM()
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"insert into ofertacursomodulo(oc_cod, ocm_dtinicio, ocm_dtfinal, mod_cod)
                                                               values(@ocCod, @dtInicio, @dtFinal, @mod)";
            _bd.Comando.Parameters.Add("@ocCod", this._ocCod);
            _bd.Comando.Parameters.Add("@dtInicio", this._dtInicioModulo);
            _bd.Comando.Parameters.Add("@dtFinal", this._dtFinalModulo);
            _bd.Comando.Parameters.Add("@mod", this._modulo);
            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"select MAX(ocm_cod) as maxcod from ofertacursomodulo";
                DataTable dt = _bd.ExecutarComando();

                if (dt.Rows.Count > 0)
                {
                    _cod = Convert.ToInt32(dt.Rows[0]["maxcod"]);
                }
                return true;
            }
            else return false;
        }

        public bool GravarProfOCM(int ocm, int prof)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"insert into professor_ofertacursomodulo(ocm_cod, prof_cod)
                                                                         values(@ocm, @prof)";
            _bd.Comando.Parameters.Add("@ocm", ocm);
            _bd.Comando.Parameters.Add("@prof", prof);
            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }


        public List<OfertaCursoModulo> RecuperarModulosSelecionados(int cod)
        {
            List<OfertaCursoModulo> ListaOCM = new List<OfertaCursoModulo>();
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select ocm.ocm_cod, m.mod_desc, m.mod_valor, p.prof_nome, ocm.ocm_dtinicio, ocm.ocm_dtfinal from ofertacurso oc, ofertacursomodulo ocm, modulos m, professor_ofertacursomodulo pocm, professor p
                                        where ocm.mod_cod = m.mod_cod and
                                        ocm.ocm_cod = pocm.ocm_cod and
                                        pocm.prof_cod = p.prof_cod and
                                        oc.oc_cod = ocm.oc_cod and
                                        oc.oc_cod = @cod";
            _bd.Comando.Parameters.Add("@cod", cod);
            DataTable dt = _bd.ExecutarComando(); 

            foreach (DataRow item in dt.Rows)
            {
                OfertaCursoModulo m = new OfertaCursoModulo();
                {
                     m.Professor = new Professor();
                     m.Mod = new Modulos();
                     m.Professor.Nome = item["prof_nome"].ToString();
                     m.Mod.DesModulo = item["mod_desc"].ToString();
                     m.Mod.Valor = Convert.ToDouble(item["mod_valor"]);
                     m.Cod = Convert.ToInt32(item["ocm_cod"]);
                     m.DtInicioModulo = Convert.ToDateTime(item["ocm_dtinicio"]);
                     m.DtFinalModulo = Convert.ToDateTime(item["ocm_dtfinal"]);
                };
                ListaOCM.Add(m);
            }

            return ListaOCM;
        }


        public bool ExcluirOCM(int cod)
        {
            try
            {
                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"delete ofertacursomodulo where ocm_cod = @cod";
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

        public bool ExcluirPROF_OCM(int cod)
        {
            try
            {
                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"delete professor_ofertacursomodulo where ocm_cod = @codocm";
                _bd.Comando.Parameters.Add("@codocm", cod);
                _bd.ExecutarComandoNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }


        public double RecuperarValorModulos(int cod)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select m.mod_valor from ofertacurso oc, ofertacursomodulo ocm, modulos m
                                        where ocm.mod_cod = m.mod_cod and
                                        oc.oc_cod = ocm.oc_cod and
                                        ocm.ocm_cod = @codOC";
            _bd.Comando.Parameters.Add("@codOC", cod);
            DataTable dt = _bd.ExecutarComando();

            if (dt.Rows.Count > 0)
            {
                return Convert.ToDouble(dt.Rows[0]["mod_valor"]);
            }
            else return 0;
        }

        public string VerificarModulosSel(int codOc)
        {
            string modulos = "";
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select m.mod_cod from ofertacurso oc, ofertacursomodulo ocm, modulos m, professor_ofertacursomodulo pocm, professor p
                                        where ocm.mod_cod = m.mod_cod and
                                        ocm.ocm_cod = pocm.ocm_cod and
                                        pocm.prof_cod = p.prof_cod and
                                        oc.oc_cod = ocm.oc_cod and
                                        oc.oc_cod = @cod";
            _bd.Comando.Parameters.Add("@cod", codOc);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    OfertaCursoModulo o = new OfertaCursoModulo();
                    {
                        o.Mod = new Modulos();
                        modulos = modulos + "," + item["mod_cod"].ToString();
                    }
                }
            }
            return modulos;
        }

        public List<string> DiasFaltasLancada(int codOcm)
        {
            List<string> lista = new List<string>();
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select distinct CONVERT(char,pre_data,102) as data from presenca
                                        where ocm_cod = @cod";
            _bd.Comando.Parameters.Add("@cod", codOcm);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(item["data"].ToString());
                }
            }
            return lista;
        }

        public List<string> RecuperarAlunosOCM(int ocCod, int codMod)
        {
            List<string> Lista = new List<string>();
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select a.alu_ra, a.alu_nome, o.ocm_cod from alunos a, ofertacursomodulo o, alunos_ofertacursomodulo ao
                                        where 
                                        a.alu_ra = ao.alu_ra and
                                        o.ocm_cod = ao.ocm_cod and
                                        o.mod_cod = @codMod and
                                        o.oc_cod = @ocCod
                                        order by alu_nome";
            _bd.Comando.Parameters.Add("@codMod", codMod);
            _bd.Comando.Parameters.Add("@ocCod", ocCod);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Lista.Add(item["alu_nome"].ToString());
                }
            }
            return Lista;
        }

       
        public List<string> SituacaoAlunoPorData(string ra, int ocm)
        {
            List<string> lista = new List<string>();
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select pre_data, pre_situacao from presenca
                                        where alu_ra = @ra and
                                        ocm_cod = @ocm
                                        order by pre_data";
            _bd.Comando.Parameters.Add("@ocm", ocm);
            _bd.Comando.Parameters.Add("@ra", ra);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    lista.Add(item["pre_situacao"].ToString());
                }
            }
            return lista;
        }


        public List<string> RecuperarRaAluno(int ocCod, int codMod)
        {
            List<string> Lista = new List<string>();
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select a.alu_ra, a.alu_nome, o.ocm_cod from alunos a, ofertacursomodulo o, alunos_ofertacursomodulo ao
                                        where 
                                        a.alu_ra = ao.alu_ra and
                                        o.ocm_cod = ao.ocm_cod and
                                        o.mod_cod = @codMod and
                                        o.oc_cod = @ocCod
                                        order by alu_nome";
            _bd.Comando.Parameters.Add("@codMod", codMod);
            _bd.Comando.Parameters.Add("@ocCod", ocCod);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Lista.Add(item["alu_ra"].ToString());
                }
            }
            return Lista;
        }

        public DataTable RecuperarHrAluno(int ra, int codOc)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select distinct m.mod_desc, ocm.ocm_dtinicio, ocm.ocm_dtfinal from ofertacurso o, ofertacursomodulo ocm, alunos_ofertacursomodulo ao, alunos a, modulos m
                                        where 
                                        ocm.oc_cod = o.oc_cod and
                                        ao.ocm_cod = ocm.ocm_cod and
                                        a.alu_ra = ao.alu_ra and
                                        m.mod_cod = ocm.mod_cod and
                                        o.oc_cod = @cod and
                                        a.alu_ra = @ra";
            _bd.Comando.Parameters.Add("@cod", codOc);
            _bd.Comando.Parameters.Add("@ra", ra);
            DataTable dt = _bd.ExecutarComando();
            return dt;
        }
    }
}
