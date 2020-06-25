using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Bancos;
using System.Data;

namespace CamadaNegocios
{
    public class UnidadeEnsino
    {
        private int _codUnidade;

        public int CodUnidade
        {
            get { return _codUnidade; }
            set { _codUnidade = value; }
        }
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }
        private string _responsavel;

        public string Responsavel
        {
            get { return _responsavel; }
            set { _responsavel = value; }
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

        public UnidadeEnsino(string nome, string responsavel, string endereco, int numero, string bairro,int dddFixo, int numFixo, string uf, string cidade, int cod)
        {
            _nome = nome;
            _responsavel = responsavel;
            _endereco = endereco;
            _numero = numero;
            _bairro = bairro;
            _dddFixo = dddFixo;
            _numFixo = numFixo;
            _uf = uf;
            _cidade = cidade;
            _codUnidade = cod;
        }

        public UnidadeEnsino()
        {
            _nome = "";
            _responsavel = "";
            _endereco = "";
            _numero = 0;
            _bairro = "";
            _dddFixo = 0;
            _numFixo = 0;
            _uf = "";
            _cidade = "";
            _codUnidade = 0;
        }

        public UnidadeEnsino(string nome)
        {
            _nome = nome;
        }

        public bool GravarUnidadeEnsino()
        {
            _bd.Comando.CommandText = @"INSERT INTO unidadeensino(ue_nome,ue_responsavel , ue_endereco, ue_numero, ue_bairro, ue_dddfixo, ue_numfixo, ue_uf, ue_cidade) 
                                        VALUES(@nome, @responsavel, @endereco, @numero, @bairro, @dddfixo, @numfixo, @uf, @cidade)";
            _bd.Comando.Parameters.Add("@nome", this._nome);
            _bd.Comando.Parameters.Add("@responsavel",this._responsavel);
            _bd.Comando.Parameters.Add("@endereco", this._endereco);
            _bd.Comando.Parameters.Add("@numero", this._numero);
            _bd.Comando.Parameters.Add("@bairro", this._bairro);
            _bd.Comando.Parameters.Add("@dddfixo", this._dddFixo);
            _bd.Comando.Parameters.Add("@numfixo", this._numFixo);
            _bd.Comando.Parameters.Add("@uf", this._uf);
            _bd.Comando.Parameters.Add("@cidade", this._cidade);

            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }


        public bool AlterarUnidadeEnsino()
        {
            _bd.Comando.CommandText = @"UPDATE unidadeensino set
                                        ue_nome = @nome,
                                        ue_responsavel = @responsavel,
                                        ue_endereco = @endereco,
                                        ue_numero = @numero,
                                        ue_bairro = @bairro,
                                        ue_dddfixo = @dddfixo,
                                        ue_numfixo = @numfixo,
                                        ue_uf = @uf,
                                        ue_cidade = @cidade
                                        where ue_cod = @cod";
            _bd.Comando.Parameters.Add("@cod", this._codUnidade);
            _bd.Comando.Parameters.Add("@nome", this._nome);
            _bd.Comando.Parameters.Add("@responsavel", this._responsavel);
            _bd.Comando.Parameters.Add("@endereco", this._endereco);
            _bd.Comando.Parameters.Add("@numero", this._numero);
            _bd.Comando.Parameters.Add("@bairro", this._bairro);
            _bd.Comando.Parameters.Add("@dddfixo", this._dddFixo);
            _bd.Comando.Parameters.Add("@numfixo", this._numFixo);
            _bd.Comando.Parameters.Add("@uf", this._uf);
            _bd.Comando.Parameters.Add("@cidade", this._cidade);
            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }

        public bool RecuperarUnidadeEnsino(int id)
        {
            _bd.Comando.CommandText = @"select * from unidadeensino
                                        where ue_cod = @cod";
            _bd.Comando.Parameters.Add("@cod", id);
            DataTable dt = _bd.ExecutarComando();

            if (dt.Rows.Count > 0)
            {
                _codUnidade = Convert.ToInt32(dt.Rows[0]["ue_cod"]);
                _nome = dt.Rows[0]["ue_nome"].ToString();
                _responsavel = dt.Rows[0]["ue_responsavel"].ToString();
                _endereco = dt.Rows[0]["ue_endereco"].ToString();
                _numero = Convert.ToInt32(dt.Rows[0]["ue_numero"]);
                _bairro = dt.Rows[0]["ue_bairro"].ToString();
                _dddFixo = Convert.ToInt32(dt.Rows[0]["ue_dddfixo"]);
                _numFixo = Convert.ToInt32(dt.Rows[0]["ue_numfixo"]);
                _uf = dt.Rows[0]["ue_uf"].ToString();
                _cidade = dt.Rows[0]["ue_cidade"].ToString();
                return true;
            }
            else return false;
            
        }

        public List<UnidadeEnsino> PesqUnidadeEnsino()
        {
            List<UnidadeEnsino> listaUE = new List<UnidadeEnsino>();
            _bd.Comando.CommandText = @"select ue_cod, ue_nome, ue_cidade from unidadeensino
                                        where ue_nome like @nome";
            _bd.Comando.Parameters.Add("@nome", "%" + this._nome + "%");
            DataTable dt = _bd.ExecutarComando();

            foreach (DataRow item in dt.Rows)
            {
                UnidadeEnsino ue = new UnidadeEnsino()
                {
                    _codUnidade = Convert.ToInt32(item["ue_cod"]),
                    _nome = item["ue_nome"].ToString(),
                    _cidade = item["ue_cidade"].ToString()
                };
                listaUE.Add(ue);
            }

            return listaUE;
           
        }

        public bool ExcluirUnidade(int cod)
        {
            try
            {
                _bd.Comando.CommandText = @"delete unidadeensino where ue_cod = @cod";
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
    }
}
