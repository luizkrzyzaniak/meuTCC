using System;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Bancos
{
    /// <summary>
    /// Classe para manipulação de acesso a dados do banco de dados SQL SERVER.
    /// </summary>
    public class SqlServer
    {

        SqlConnection _conexao;
        SqlCommand _comando;
        SqlTransaction _transacao;
        bool _gerenciarConexaoAutomatica = true;

        /// <summary>
        /// Objeto SqlCommand para execução de instruções SQL.
        /// </summary>
        public SqlCommand Comando
        {
            get { return _comando; }
            set { _comando = value; }
        }

        /// <summary>
        /// Retorna o objeto de conexão tipo SqlConnection.
        /// </summary>
        public SqlConnection Conexao
        {
            get { return _conexao; }
        }

        /// <summary>
        /// Retorna o objeto de transação tipo SqlTransaction.
        /// </summary>
        public SqlTransaction Transacao
        {
            get { return _transacao; }
        }


        /// <summary>
        /// Inicia uma transação com o banco de dados. A conexão será aberta caso esteja fechada e o objeto Comando ligado a transação.
        /// </summary>
        public bool GerenciarConexaoAutomatica
        {
            get { return _gerenciarConexaoAutomatica; }
            set { _gerenciarConexaoAutomatica = value; }
        }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public SqlServer()
        { 
            _conexao = new SqlConnection();
            _conexao.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=SAAET;Persist Security Info=True;User ID=sa;Password=a12345z";
            _comando = _conexao.CreateCommand();
        }


        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="gerenciaConexaoAutomatica">Indica se o a conexão do banco de será automaticamente gerenciada.</param>
        public SqlServer(bool gerenciaConexaoAutomatica)
        {
            _conexao = new SqlConnection();
            _conexao.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Persist Security Info=True;User ID=sa;Password=a12345z";
            _comando = _conexao.CreateCommand();
            _gerenciarConexaoAutomatica = gerenciaConexaoAutomatica;
        }


        /// <summary>
        /// Abre a conexão com o banco de dados.
        /// </summary>
        public void AbrirConexao()
        {
            if (_conexao.State == ConnectionState.Closed)
                _conexao.Open();
        }

        /// <summary>
        /// Fecha a conexão com o banco de dados.
        /// </summary>
        public void FecharConexao()
        {
            if (_conexao.State == ConnectionState.Open)
                _conexao.Close();                    
        }

        /// <summary>
        /// Inicia uma transação com o banco de dados. A conexão será aberta caso esteja fechada.
        /// </summary>
        public void IniciarTransacao()
        {
            if (_conexao.State == ConnectionState.Closed)
                _conexao.Open();

            _transacao = _conexao.BeginTransaction();
            _comando.Transaction = _transacao;
        }

        /// <summary>
        /// Executa o objeto Comando (SqlCommand) com uma instrução Select.
        /// </summary>
        /// <returns>Retorna um objeto DataTable com o resultado da consulta.</returns>
        public DataTable ExecutarComando()
        {
            if (_comando.CommandText == string.Empty)
                throw new Exception("Comando sem instrução SQL.");

            DataTable dt = new DataTable();

            try
            {
                if (_conexao.State == ConnectionState.Closed)
                    _conexao.Open();

                SqlDataReader dr = _comando.ExecuteReader();

                dt.Load(dr);
            }
            catch (Exception ex)
            {

                if (_transacao != null)
                {
                    _transacao.Rollback();
                    _transacao = null;
                }

                if (_conexao.State == ConnectionState.Open)
                    _conexao.Close();

                throw new Exception("Erro em Bancos.SqlServer.ExecutarComando.", ex);
            }
            finally
            {
                if (_gerenciarConexaoAutomatica)
                    _conexao.Close();
            }

            return (dt);
        }

        /// <summary>
        /// Executa o objeto Comando (SqlCommand) com uma instrução Select.
        /// </summary>
        /// <param name="sql">Instrução SELECT</param>
        /// <returns></returns>
        public DataTable ExecutarComando(string sql)
        {
            _comando.CommandText = sql;
            return (ExecutarComando());
        }

        /// <summary>
        /// Executa o objeto Comando (SqlCommand) com uma instrução SQL Scalar.
        /// </summary>
        /// <returns>Retorna um objeto do tipo Object, sendo possível ser convertido para qualquer tipo de dado.</returns>
        public object ExecutarComandoScalar()
        {
            if (_comando.CommandText == string.Empty)
                throw new Exception("Comando sem instrução SQL.");

            object retorno = 0;

            try
            {
                if (_conexao.State == ConnectionState.Closed)
                    _conexao.Open();

                retorno = _comando.ExecuteScalar();

            }
            catch (Exception ex)
            {

                if (_transacao != null)
                {
                    _transacao.Rollback();
                    _transacao = null;
                }

                if (_conexao.State == ConnectionState.Open)
                    _conexao.Close();

                throw new Exception("Erro em Bancos.SqlServer.ExecutarComandoScalar.", ex);
            }
            finally
            {
                if (_gerenciarConexaoAutomatica)
                    _conexao.Close();
            }

            return (retorno);
        }

        /// <summary>
        /// Executa o objeto Comando (SqlCommand) com uma instrução SQL Scalar.
        /// </summary>
        /// <param name="sql">Instrução SELECT</param>
        /// <returns>Retorna um objeto do tipo Object, sendo possível ser convertido para qualquer tipo de dado.</returns>
        public object ExecutarComandoScalar(string sql)
        {
            _comando.CommandText = sql;
            return (ExecutarComandoScalar());
        }

        /// <summary>
        /// Executa o objeto Comando (SqlCommand) com uma instrução Insert, Update ou Delete, ou ainda execução de StoredProcedure.
        /// </summary>
        /// <returns>Retorna o número de linhas afetadas durante a execução.</returns>
        public int ExecutarComandoNonQuery()
        {
            if (_comando.CommandText == string.Empty)
                throw new Exception("Comando sem instrução SQL.");

            int linhasAfetadas = 0;

            try
            {
                if (_conexao.State == ConnectionState.Closed)
                    _conexao.Open();

                linhasAfetadas = _comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                if (_transacao != null)
                {
                    _transacao.Rollback();
                    _transacao = null;
                }


                if (_conexao.State == ConnectionState.Open)
                    _conexao.Close();

                throw new Exception("Erro em Bancos.SqlServer.ExecutaComandoNonQuery.", ex);
            }
            finally
            {
                if (_gerenciarConexaoAutomatica)
                    _conexao.Close();
            }

            return (linhasAfetadas);
        }

        /// <summary>
        ///  Executa o objeto Comando (SqlCommand) com uma instrução Insert, Update ou Delete, ou ainda execução de StoredProcedure.
        /// </summary>
        /// <param name="sql">Instrução Insert, Update ou Delete</param>
        /// <returns>Retorna o número de linhas afetadas durante a execução.</returns>
        public int ExecutarComandoNonQuery(string sql)
        {
            _comando.CommandText = sql;
            return (ExecutarComandoNonQuery());
        }

    }



}
