using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Bancos;
using System.Data;

namespace CamadaNegocios
{
    public class Presenca
    {
        private Alunos _aluno;

        public Alunos Aluno
        {
            get { return _aluno; }
            set { _aluno = value; }
        }
        private OfertaCursoModulo _ocm;

        public OfertaCursoModulo Ocm
        {
            get { return _ocm; }
            set { _ocm = value; }
        }
        private DateTime _data;

        public DateTime Data
        {
            get { return _data; }
            set { _data = value; }
        }
        private char _situacao;

        public char Situacao
        {
            get { return _situacao; }
            set { _situacao = value; }
        }

        private int _codAluno;

        public int CodAluno
        {
            get { return _codAluno; }
            set { _codAluno = value; }
        }
        private int _codOcm;

        public int CodOcm
        {
            get { return _codOcm; }
            set { _codOcm = value; }
        }

        private Modulos _modulo;

        public Modulos Modulo
        {
            get { return _modulo; }
            set { _modulo = value; }
        }

        SqlServer _bd = new SqlServer();

        public Presenca()
        {
            _data = DateTime.Now;
            _situacao = 'F';
            _codAluno = 0;
            _codOcm = 0;
        }

        public Presenca(DateTime data, char situacao, int codAluno, int codOcm)
        {
            _data = data;
            _situacao = situacao;
            _codAluno = codAluno;
            _codOcm = codOcm;
        }

        public List<Presenca> RecuperarModulosProfessor(int codProf)
        {
            List<Presenca> Lista = new List<Presenca>();
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select m.mod_desc, m.mod_cod, o.ocm_cod, o.oc_cod from professor p, ofertacursomodulo o, professor_ofertacursomodulo po, modulos m
                                        where
                                        p.prof_cod = po.prof_cod and
                                        o.ocm_cod = po.ocm_cod and
                                        m.mod_cod = o.mod_cod and
                                        @data between o.ocm_dtinicio and o.ocm_dtfinal and
                                        p.prof_cod = @codProf ";
            _bd.Comando.Parameters.Add("@codProf", codProf);
            _bd.Comando.Parameters.Add("@data", DateTime.Now);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Presenca p = new Presenca();
                    {
                        p.Ocm = new OfertaCursoModulo();
                        p.Modulo = new Modulos();
                        p.Ocm.Cod = Convert.ToInt32(item["ocm_cod"]);
                        p.Ocm.OcCod = Convert.ToInt32(item["oc_cod"]);
                        p.Modulo.DesModulo = item["mod_desc"].ToString();
                        p.Modulo.CodModulo = Convert.ToInt32(item["mod_cod"]);
                    }
                    Lista.Add(p);
                }
            }
            return Lista;
        }


        public List<Presenca> RecuperarAlunosOCM(int ocCod, int codMod)
        {
            List<Presenca> Lista = new List<Presenca>();
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
                    Presenca p = new Presenca();
                    {
                        p.Aluno = new Alunos();
                        p.Ocm = new OfertaCursoModulo();
                        p.Aluno.Ra = Convert.ToInt32(item["alu_ra"]);
                        p.Aluno.Nome = item["alu_nome"].ToString();
                        p.Ocm.Cod = Convert.ToInt32(item["ocm_cod"]);
                    }
                    Lista.Add(p);
                }
            }
            return Lista;
        }

        public bool LancarFaltas(string alunos, int codOC, int codMod)
        {
            List<Presenca> Lista = new List<Presenca>();
            Lista = RecuperarAlunosOCM(codOC, codMod);

            for (int i = 0; i < Lista.Count; i++)
            {
                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"insert into presenca(alu_ra,ocm_cod,pre_data,pre_situacao)
                                                         values(@ra, @ocm, @data, @situacao)";
                _bd.Comando.Parameters.Add("@ra", Lista[i].Aluno.Ra);
                _bd.Comando.Parameters.Add("@ocm", Lista[i].Ocm.Cod);
                _bd.Comando.Parameters.Add("@data", DateTime.Now);
                _bd.Comando.Parameters.Add("@situacao", 'P');
                _bd.ExecutarComandoNonQuery();
                
            }
            if (alunos != null)
            {
                string[] alu = alunos.Split(',');
                for (int i = 0; i < alu.Length; i++)
                {
                    _bd.Comando.Parameters.Clear();
                    _bd.Comando.CommandText = @"update presenca
                                            set pre_situacao = 'F'
                                            where alu_ra = @ra and
                                            convert(char,pre_data,102) = convert(char,@data,102) and
                                            ocm_cod = @ocm";
                    _bd.Comando.Parameters.Add("@ra", alu[i]);
                    _bd.Comando.Parameters.Add("@data", DateTime.Now);
                    _bd.Comando.Parameters.Add("@ocm", Lista[0].Ocm.Cod);
                    _bd.ExecutarComandoNonQuery();
                }
            }

            return true;
        }

        public string VerificaDia(int codOcm)
        {
            string ocm = "";
            _bd.Comando.CommandText = @"select distinct ocm_cod from presenca
                                        where CONVERT(CHAR,GETDATE(),102 ) = CONVERT (char,pre_data,102 )";
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Presenca p = new Presenca();
                    {
                        ocm = ocm + "," + item["ocm_cod"].ToString();
                    }
                }
                
            }
            return ocm;
        }

        public string RecuperarAlunosComFaltas(DateTime data, int ocmCod)
        {
            string alunos = "";
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select alu_ra from presenca
                                        where 
                                        pre_situacao = 'F' and
                                        CONVERT(char, pre_data, 102) = CONVERT(char, @data, 102) and
                                        ocm_cod = @ocm";
            _bd.Comando.Parameters.Add("@data", data);
            _bd.Comando.Parameters.Add("@ocm", ocmCod);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    alunos = alunos + "," + item["alu_ra"].ToString();
                }
            }
            return alunos;
        }

        public string RecuperarOcmLancadonoDia(DateTime data)
        {
            string ocm = "";
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select distinct ocm_cod from presenca
                                        where convert(char,pre_data,102) = convert(char,@data,102)";
            _bd.Comando.Parameters.Add("@data", data);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    ocm = ocm + "," + item["ocm_cod"].ToString();
                }
            }
            return ocm;
        }

        public bool ExcluirLancamento(DateTime data, int ocmCod)
        {
            try
            {
                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"delete presenca
                                            where ocm_cod = @ocm and
                                            convert(char,pre_data,102) = convert(char, @data, 102)";
                _bd.Comando.Parameters.Add("@ocm", ocmCod);
                _bd.Comando.Parameters.Add("@data", data);
                _bd.ExecutarComandoNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
                
            }
        }

        public DataTable RecuperarAlunosRel(int ocCod, int codMod)
        {
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
            return dt;
        }
       
    }
}
