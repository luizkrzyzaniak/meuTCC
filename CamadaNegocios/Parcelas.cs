using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Bancos;
using System.Data;

namespace CamadaNegocios
{
    public class Parcelas
    {
        private int _codParcela;

        public int CodParcela
        {
            get { return _codParcela; }
            set { _codParcela = value; }
        }
        private int _matricula;

        public int Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }
        private decimal _valor;

        public decimal Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }
        private DateTime _dtVencimento;

        public DateTime DtVencimento
        {
            get { return _dtVencimento; }
            set { _dtVencimento = value; }
        }
        private char _sitParcela;

        public char SitParcela
        {
            get { return _sitParcela; }
            set { _sitParcela = value; }
        }

        private DateTime? _dtPagamento;

        public DateTime? DtPagamento
        {
            get { return _dtPagamento; }
            set { _dtPagamento = value; }
        }

        SqlServer _bd = new SqlServer();

        public Parcelas()
        {
            _codParcela = 0;
            _matricula = 0;
            _valor = 0;
            _dtVencimento = DateTime.Now;
            _sitParcela = ' ';
            _dtPagamento = DateTime.Now;
        }

        public Parcelas(int matricula, decimal valor, DateTime dtVencimento, char sitParcela, DateTime dtPagamento)
        {
            _matricula = matricula;
            _valor = valor;
            _dtVencimento = dtVencimento;
            _sitParcela = sitParcela;
            _dtPagamento = dtPagamento;
        }

        public bool GravarParcela(int matricula, decimal valor, DateTime dtVencimento, char sitParcela, DateTime dtPagamento)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"insert into parcelas(mat_cod, par_valor, par_dtvenc, par_situacao, par_dtpag)
                                                       values(@matCod, @parValor, @parDtVenc, @parSituacao";
            if (sitParcela == 'P')
            {
                _bd.Comando.CommandText = _bd.Comando.CommandText + ",@dtpag)";
                _bd.Comando.Parameters.Add("dtpag", dtPagamento);
            }
            else
            {
                _bd.Comando.CommandText = _bd.Comando.CommandText + ",null)";
            }
            _bd.Comando.Parameters.Add("@matCod", matricula);
            _bd.Comando.Parameters.Add("@parValor", valor);
            _bd.Comando.Parameters.Add("@parDtVenc", dtVencimento);
            _bd.Comando.Parameters.Add("@parSituacao", sitParcela);
            
            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }

        public List<Parcelas> PesqParcelas(int codmat)
        {
            List<Parcelas> ListaParc = new List<Parcelas>();
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select par_cod, par_valor, par_dtvenc, par_situacao, par_dtpag from parcelas
                                        where
                                        par_situacao != 'E' and
                                        mat_cod = @codmat";
            _bd.Comando.Parameters.Add("@codmat", codmat);
            DataTable dt = _bd.ExecutarComando();
            foreach (DataRow item in dt.Rows)
            {
                Parcelas p = new Parcelas();
                {
                    p.CodParcela = Convert.ToInt32(item["par_cod"]);
                    p.Valor = Convert.ToDecimal(item["par_valor"]);
                    p.DtVencimento = Convert.ToDateTime(item["par_dtvenc"]);
                    p.SitParcela = Convert.ToChar(item["par_situacao"]);
                    if (item["par_dtpag"].ToString() != "")
                        p.DtPagamento = Convert.ToDateTime(item["par_dtpag"]);
                    else
                        p.DtPagamento = null;

                };
                ListaParc.Add(p);
            }
            return ListaParc;
        }

        public decimal RecuperarValorParcela(int codParc)
        {

            decimal valor = 0;
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select par_valor from parcelas
                                        where par_cod = @codpar";
            _bd.Comando.Parameters.Add("@codpar", codParc);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                valor = Convert.ToDecimal(dt.Rows[0]["par_valor"]);
            }
            return valor;
        }

        public bool PagarParcela(int codPar, DateTime data)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"update parcelas
                                        set par_situacao = 'P',
                                        par_dtpag = @data
                                        where par_cod = @codpar";
            _bd.Comando.Parameters.Add("@codpar", codPar);
            _bd.Comando.Parameters.Add("@data", data);
            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }

        public string RecuperarOCMselecionados(int codMat)
        {
            string ocm = "";
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select ocm_cod from alunos_ofertacursomodulo
                                        where mat_cod = @codmat";
            _bd.Comando.Parameters.Add("codmat", codMat);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    ocm = ocm + "," + item["ocm_cod"].ToString();
                }
                return ocm;
            }
            else return ocm;
        }

        public bool ExcluirParcelas(int codMat)
        {
            try
            {
                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"update parcelas set
                                            par_situacao = 'E'
                                            where mat_cod = @cod";
                _bd.Comando.Parameters.Add("@cod", codMat);
                _bd.ExecutarComandoNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public DataTable AlunosDevedores(string cidade)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select distinct p.par_dtvenc, p.par_valor, a.alu_ra, a.alu_nome from parcelas p, matricula m, alunos_ofertacursomodulo ao, alunos a
                                        where
                                        m.mat_cod = p.mat_cod and
                                        ao.mat_cod = m.mat_cod and
                                        a.alu_ra = ao.alu_ra and 
                                        par_situacao = 'N' and
                                        CONVERT(char,par_dtvenc,102) < CONVERT(char,GETDATE(),102) and
                                        a.alu_cidade = @cid
                                        order by a.alu_nome";
            _bd.Comando.Parameters.Add("@cid", cidade);
            DataTable dt = _bd.ExecutarComando();
            return dt;
        }

        public DataTable RecuperarParcelasPaga(int matcod, DateTime data)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select  par_dtvenc, par_valor, par_dtpag from parcelas
                                        where
                                        mat_cod = @mat and
                                        par_dtpag = @data";
            _bd.Comando.Parameters.Add("@mat", matcod);
            _bd.Comando.Parameters.Add("@data", data);
            DataTable dt = _bd.ExecutarComando();
            return dt;
        }

        public double ValorParcelasPagaExcluidas(int codMat)
        {
            double valor = 0;
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select par_valor from parcelas
                                        where par_dtpag is not null and
                                        mat_cod = @cod";
            _bd.Comando.Parameters.Add("@cod", codMat);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    valor = valor + Convert.ToDouble(item["par_valor"]);
                }
                return valor;
            }
            else
            {
                return valor;
            }

        }



    }
}
