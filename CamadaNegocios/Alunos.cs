using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Bancos;
using System.Data;

namespace CamadaNegocios
{
    public class Alunos
    {
        private int _ra;

        public int Ra
        {
            get { return _ra; }
            set { _ra = value; }
        }
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private string _cpf;

        public string Cpf
        {
            get { return _cpf; }
            set { _cpf = value; }
        }
        private string _rg;

        public string Rg
        {
            get { return _rg; }
            set { _rg = value; }
        }
        private DateTime _dtNasc;

        public DateTime DtNasc
        {
            get { return _dtNasc; }
            set { _dtNasc = value; }
        }
        private string _endereco;

        public string Endereco
        {
            get { return _endereco; }
            set { _endereco = value; }
        }
        private int _numero;

        public int Numero
        {
            get { return _numero; }
            set { _numero = value; }
        }
        private string _bairro;

        public string Bairro
        {
            get { return _bairro; }
            set { _bairro = value; }
        }
        private int _dddFixo;

        public int DddFixo
        {
            get { return _dddFixo; }
            set { _dddFixo = value; }
        }
        private int _numFixo;

        public int NumFixo
        {
            get { return _numFixo; }
            set { _numFixo = value; }
        }
        private int _dddCel;

        public int DddCel
        {
            get { return _dddCel; }
            set { _dddCel = value; }
        }
        private int _numCel;

        public int NumCel
        {
            get { return _numCel; }
            set { _numCel = value; }
        }
        private string _uf;

        public string Uf
        {
            get { return _uf; }
            set { _uf = value; }
        }

        private string _cidade;

        public string Cidade
        {
            get { return _cidade; }
            set { _cidade = value; }
        }

        SqlServer _bd = new SqlServer();

        public Alunos()
        {
            _nome = "";
            _cpf = "";
            _rg = "";
            _dtNasc = DateTime.Now;
            _endereco = "";
            _numero = 0;
            _bairro = "";
            _dddFixo = 0;
            _numFixo = 0;
            _dddCel = 0;
            _numCel = 0;
            _uf = "";
            _cidade = "";
        }

        public Alunos(string nome, string cpf, string rg, DateTime dtNasc, string endereco, int numero, string bairro, int dddFixo, int numFixo, int dddCel, int numCel, string uf, string cidade, int ra)
        {
            _nome = nome;
            _cpf = cpf;
            _rg = rg;
            _dtNasc = dtNasc;
            _endereco = endereco;
            _numero = numero;
            _bairro = bairro;
            _dddFixo = dddFixo;
            _numFixo = numFixo;
            _dddCel = dddCel;
            _numCel = numCel;
            _uf = uf;
            _cidade = cidade;
            _ra = ra;
        }

        public Alunos(string nome)
        {
            _nome = nome;
        }

        public bool GravarAluno()
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"INSERT INTO alunos(alu_nome, alu_cpf, alu_rg, alu_dtnasc, alu_endereco, alu_numero, alu_bairro, alu_dddfixo, alu_numfixo, alu_dddcel, alu_numcel, alu_uf, alu_cidade) 
                                        VALUES(@nome, @cpf, @rg, @dtnasc, @endereco, @numero, @bairro, @dddfixo, @numfixo, @dddcel, @numcel, @uf, @cidade)";
            _bd.Comando.Parameters.Add("@nome", this._nome);
            _bd.Comando.Parameters.Add("@cpf", this._cpf);
            _bd.Comando.Parameters.Add("@rg", this._rg);
            _bd.Comando.Parameters.Add("@dtnasc", this._dtNasc);
            _bd.Comando.Parameters.Add("@endereco", this._endereco);
            _bd.Comando.Parameters.Add("@numero", this._numero);
            _bd.Comando.Parameters.Add("@bairro", this._bairro);
            _bd.Comando.Parameters.Add("@dddfixo", this._dddFixo);
            _bd.Comando.Parameters.Add("@numfixo", this._numFixo);
            _bd.Comando.Parameters.Add("@dddcel", this._dddCel);
            _bd.Comando.Parameters.Add("@numcel", this._numCel);
            _bd.Comando.Parameters.Add("@uf", this._uf);
            _bd.Comando.Parameters.Add("@cidade", this._cidade);

            if(_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }

        public List<Alunos> PesqAlunos()
        {
            List<Alunos> ListaAlunos = new List<Alunos>();
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select alu_ra, alu_nome, alu_dtnasc from alunos
                                        where alu_nome like @nome";
            _bd.Comando.Parameters.Add("@nome", "%" + this._nome + "%");
            DataTable dt = _bd.ExecutarComando();
            foreach (DataRow item in dt.Rows)
            {
                Alunos alu = new Alunos()
                {
                    _ra = Convert.ToInt32(item["alu_ra"]),
                    _nome = item["alu_nome"].ToString(),
                    _dtNasc = Convert.ToDateTime(item["alu_dtnasc"])                    
                };
                ListaAlunos.Add(alu);
            }

            return ListaAlunos;
        }

        public bool RecuperarAluno(int id)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select * from alunos
                                        where alu_ra = @ra";
            _bd.Comando.Parameters.Add("@ra", id);
            DataTable dt = _bd.ExecutarComando();

            if (dt.Rows.Count > 0)
            {
                _ra = Convert.ToInt32(dt.Rows[0]["alu_ra"]);
                _nome = dt.Rows[0]["alu_nome"].ToString();
                _cpf = dt.Rows[0]["alu_cpf"].ToString();
                _rg = dt.Rows[0]["alu_rg"].ToString();
                _dtNasc = Convert.ToDateTime(dt.Rows[0]["alu_dtnasc"]);
                _endereco = dt.Rows[0]["alu_endereco"].ToString();
                _numero = Convert.ToInt32(dt.Rows[0]["alu_numero"]);
                _bairro = dt.Rows[0]["alu_bairro"].ToString();
                _dddFixo = Convert.ToInt32(dt.Rows[0]["alu_dddfixo"]);
                _numFixo = Convert.ToInt32(dt.Rows[0]["alu_numfixo"]);
                _dddCel = Convert.ToInt32(dt.Rows[0]["alu_dddcel"]);
                _numCel = Convert.ToInt32(dt.Rows[0]["alu_numcel"]);
                _uf = dt.Rows[0]["alu_uf"].ToString();
                _cidade = dt.Rows[0]["alu_cidade"].ToString();

                return true;
            }
            else return false;
        }

        public bool AlterarAluno()
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"UPDATE alunos set
                                        alu_nome = @nome,
                                        alu_cpf = @cpf,
                                        alu_rg = @rg,
                                        alu_dtnasc = @dtnasc,
                                        alu_endereco =@endereco,
                                        alu_numero = @numero,
                                        alu_bairro = @bairro,
                                        alu_dddfixo = @dddfixo,
                                        alu_numfixo = @numfixo,
                                        alu_dddcel = @dddcel,
                                        alu_numcel = @numcel,
                                        alu_uf = @uf,
                                        alu_cidade = @cidade
                                        where alu_ra = @ra";
            _bd.Comando.Parameters.Add("@ra", this._ra);
            _bd.Comando.Parameters.Add("@nome", this._nome);
            _bd.Comando.Parameters.Add("@cpf", this._cpf);
            _bd.Comando.Parameters.Add("@rg", this._rg);
            _bd.Comando.Parameters.Add("@dtnasc", this._dtNasc);
            _bd.Comando.Parameters.Add("@endereco", this._endereco);
            _bd.Comando.Parameters.Add("@numero", this._numero);
            _bd.Comando.Parameters.Add("@bairro", this._bairro);
            _bd.Comando.Parameters.Add("@dddfixo", this._dddFixo);
            _bd.Comando.Parameters.Add("@numfixo", this._numFixo);
            _bd.Comando.Parameters.Add("@dddcel", this._dddCel);
            _bd.Comando.Parameters.Add("@numcel", this._numCel);
            _bd.Comando.Parameters.Add("@uf", this._uf);
            _bd.Comando.Parameters.Add("@cidade", this._cidade);
            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }

        public bool ExcluirAluno(int ra)
        {
            try
            {
                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"delete alunos where alu_ra = @cod";
                _bd.Comando.Parameters.Add("@cod", ra);
                _bd.ExecutarComandoNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public bool ExcluirAluno_ocm(int ra)
        {

            try
            {
                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"delete alunos_ofertacursomodulo where alu_ra = @ra";
                _bd.Comando.Parameters.Add("@ra", ra);
                _bd.ExecutarComandoNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<Alunos> RecuperarCidades()
        {
            List<Alunos> Lista = new List<Alunos>();
            _bd.Comando.CommandText = @"select distinct alu_cidade from alunos";
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Alunos a = new Alunos();
                    {
                        a.Cidade = item["alu_cidade"].ToString();
                    }
                    Lista.Add(a);
                }

            }
            return Lista;
        }

        public bool VerificaCpf(string cpf)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select alu_cpf from alunos where alu_cpf = @cpf";
            _bd.Comando.Parameters.Add("@cpf", cpf);
            DataTable dt = _bd.ExecutarComando();

            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else return true;
        }

        public bool VerificaRG(string rg)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select alu_rg from alunos where alu_rg = @rg";
            _bd.Comando.Parameters.Add("@rg", rg);
            DataTable dt = _bd.ExecutarComando();

            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else return true;
        }

        public List<Alunos> RecuperarAlunosOC(int codOc)
        {
            List<Alunos> lista = new List<Alunos>();
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select distinct a.alu_nome, a.alu_ra from ofertacurso o, ofertacursomodulo ocm, alunos_ofertacursomodulo ao, alunos a
                                        where 
                                        ocm.oc_cod = o.oc_cod and
                                        ao.ocm_cod = ocm.ocm_cod and
                                        a.alu_ra = ao.alu_ra and
                                        o.oc_cod = @cod";
            _bd.Comando.Parameters.Add("@cod", codOc);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    Alunos alu = new Alunos()
                    {
                        _nome = item["alu_nome"].ToString(),
                        _ra = Convert.ToInt32(item["alu_ra"]),
                    };
                    lista.Add(alu);
                }
            }
            return lista;
        }
    }
}
