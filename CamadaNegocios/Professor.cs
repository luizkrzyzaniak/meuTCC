using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Bancos;
using System.Data;

namespace CamadaNegocios
{
    public class Professor
    {
        private int _codProfessor;

        public int CodProfessor
        {
            get { return _codProfessor; }
            set { _codProfessor = value; }
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
        private string _curriculo;

        public string Curriculo
        {
            get { return _curriculo; }
            set { _curriculo = value; }
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

        public Professor()
        {
            _nome = "";
            _cpf = "";
            _rg = "";
            _dtNasc = DateTime.Now;
            _curriculo = "";
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

        public Professor(string nome)
        {
            _nome = nome;
        }

        public Professor(string nome, string cpf, string rg, DateTime dtnasc, string curriculo, string endereco, int numero, string bairro, int dddFixo, int numFixo, int dddCel, int numCel, string uf, string cidade, int cod)
        {
            _nome = nome;
            _cpf = cpf;
            _rg = rg;
            _dtNasc = dtnasc;
            _curriculo = curriculo;
            _endereco = endereco;
            _numero = numero;
            _bairro = bairro;
            _dddFixo = dddFixo;
            _numFixo = numFixo;
            _dddCel = dddCel;
            _numCel = numCel;
            _uf = uf;
            _cidade = cidade;
            _codProfessor = cod;
        }

        public bool GravarProfessor()
        {
            _bd.Comando.CommandText = @"INSERT INTO professor(prof_nome, prof_cpf, prof_rg, prof_dtnasc,prof_curriculo, prof_endereco, prof_numero, prof_bairro, prof_dddfixo, prof_numfixo, prof_dddcel, prof_numcel, prof_uf, prof_cidade) 
                                        VALUES(@nome, @cpf, @rg, @dtnasc, @curriculo, @endereco, @numero, @bairro, @dddfixo, @numfixo, @dddcel, @numcel, @uf, @cidade)";
            _bd.Comando.Parameters.Add("@nome", this._nome);
            _bd.Comando.Parameters.Add("@cpf", this._cpf);
            _bd.Comando.Parameters.Add("@rg", this._rg);
            _bd.Comando.Parameters.Add("@dtnasc", this._dtNasc);
            _bd.Comando.Parameters.Add("@curriculo", this._curriculo);
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


        public bool AlterarProfessor()
        {
            _bd.Comando.CommandText = @"UPDATE professor set
                                        prof_nome = @nome,
                                        prof_cpf = @cpf,
                                        prof_rg = @rg,
                                        prof_dtnasc = @dtnasc,
                                        prof_curriculo = @curriculo,
                                        prof_endereco = @endereco,
                                        prof_numero = @numero,
                                        prof_bairro = @bairro,
                                        prof_dddfixo = @dddfixo,
                                        prof_numfixo = @numfixo,
                                        prof_dddcel = @dddcel,
                                        prof_numcel = @numcel,
                                        prof_uf = @uf,
                                        prof_cidade = @cidade
                                        where prof_cod = @cod";
            _bd.Comando.Parameters.Add("@cod", this._codProfessor);
            _bd.Comando.Parameters.Add("@nome", this._nome);
            _bd.Comando.Parameters.Add("@cpf", this._cpf);
            _bd.Comando.Parameters.Add("@rg", this._rg);
            _bd.Comando.Parameters.Add("@dtnasc", this._dtNasc);
            _bd.Comando.Parameters.Add("@curriculo", this._curriculo);
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

        public bool RecuperarProfessor(int id)
        {
            _bd.Comando.CommandText = @"select * from professor
                                        where prof_cod = @cod";
            _bd.Comando.Parameters.Add("@cod", id);
            DataTable dt = _bd.ExecutarComando();

            if (dt.Rows.Count > 0)
            {
                _codProfessor = Convert.ToInt32(dt.Rows[0]["prof_cod"]);
                _nome = dt.Rows[0]["prof_nome"].ToString();
                _cpf = dt.Rows[0]["prof_cpf"].ToString();
                _rg = dt.Rows[0]["prof_rg"].ToString();
                _dtNasc = Convert.ToDateTime(dt.Rows[0]["prof_dtnasc"]);
                _curriculo = dt.Rows[0]["prof_curriculo"].ToString();
                _endereco = dt.Rows[0]["prof_endereco"].ToString();
                _numero = Convert.ToInt32(dt.Rows[0]["prof_numero"]);
                _bairro = dt.Rows[0]["prof_bairro"].ToString();
                _dddFixo = Convert.ToInt32(dt.Rows[0]["prof_dddfixo"]);
                _numFixo = Convert.ToInt32(dt.Rows[0]["prof_numfixo"]);
                _dddCel = Convert.ToInt32(dt.Rows[0]["prof_dddcel"]);
                _numCel = Convert.ToInt32(dt.Rows[0]["prof_numcel"]);
                _uf = dt.Rows[0]["prof_uf"].ToString();
                _cidade = dt.Rows[0]["prof_cidade"].ToString();

                return true;
            }
            else return false;
        }

        public List<Professor> PesqProfessor()
        {
            List<Professor> ListaProfessores = new List<Professor>();
            _bd.Comando.CommandText = @"select prof_cod, prof_nome, prof_dtnasc from professor
                                        where prof_nome like @nome";
            _bd.Comando.Parameters.Add("@nome", "%" + this._nome + "%");
            DataTable dt = _bd.ExecutarComando();
            foreach (DataRow item in dt.Rows)
            {
                Professor prof = new Professor()
                {
                    _codProfessor = Convert.ToInt32(item["prof_cod"]),
                    _nome = item["prof_nome"].ToString(),
                    _dtNasc = Convert.ToDateTime(item["prof_dtnasc"])
                };
                ListaProfessores.Add(prof);
            }

            return ListaProfessores;
        }

        public bool ExcluirProfessor(int cod)
        {
            try
            {
                _bd.Comando.CommandText = @"delete professor where prof_cod = @cod";
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

        public bool ExcluirProfessor_ocm(int cod)
        {
            _bd.Comando.CommandText = @"delete professor_ofertacursomodulo where prof_cod = @codprof";
            _bd.Comando.Parameters.Add("@codprof", cod);
            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }

        public bool VerificaCpf(string cpf)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select prof_cpf from professor where prof_cpf = @cpf";
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
            _bd.Comando.CommandText = @"select prof_rg from professor where prof_rg = @rg";
            _bd.Comando.Parameters.Add("@rg", rg);
            DataTable dt = _bd.ExecutarComando();

            if (dt.Rows.Count > 0)
            {
                return false;
            }
            else return true;
        }

    }
}
