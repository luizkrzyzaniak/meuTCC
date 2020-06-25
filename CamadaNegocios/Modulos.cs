using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Bancos;
using System.Data;

namespace CamadaNegocios
{
    public class Modulos
    {
        private int _codModulo;

        public int CodModulo
        {
            get { return _codModulo; }
            set { _codModulo = value; }
        }
        private string _desModulo;

        public string DesModulo
        {
            get { return _desModulo; }
            set { _desModulo = value; }
        }

        private double _valor;

        public double Valor
        {
            get { return _valor; }
            set { _valor = value; }
        }

        public Modulos()
        {
            _codModulo = 0;
            _desModulo = "";
            _valor = 0;
        }

        public Modulos(string descModulos, double valor)
        {
            _desModulo = descModulos;
            _valor = valor;
        }

        public Modulos(int codMod, string descModulos, double valor)
        {
            _codModulo = codMod;
            _desModulo = descModulos;
            _valor = valor;
        }

        SqlServer _bd = new SqlServer();

        public bool GravarModulo()
        {
            _bd.Comando.CommandText = @"insert into modulos(mod_desc, mod_valor)
                                        values(@desc, @valor)";
            _bd.Comando.Parameters.Add("@desc", this._desModulo);
            _bd.Comando.Parameters.Add("@valor", this._valor);

            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                _bd.Comando.CommandText = @"select MAX(mod_cod) as maxcod from modulos";
                DataTable dt = _bd.ExecutarComando();
                _codModulo = Convert.ToInt32(dt.Rows[0]["maxcod"]);

                return true;
            }
            else return false;
        }

        public DataTable RecuperarModulos()
        {
            DataTable dt = new DataTable();
            _bd.Comando.CommandText = @"select mod_cod, mod_desc, mod_valor from modulos";
            dt = _bd.ExecutarComando();
            return dt;
        }


        public List<Modulos> PesqModCurso(int codCurso)
        {
            List<Modulos> ListaModulosCurso = new List<Modulos>();
            _bd.Comando.CommandText = @"select m.mod_cod, m.mod_desc, m.mod_valor from modulos m, curso c, modulos_curso mc
                                      where mc.mod_cod = m.mod_cod and
	                                  mc.cur_cod = c.cur_cod and
	                                  mc.cur_cod = @codcurso";
            _bd.Comando.Parameters.Add("@codcurso", codCurso);
            DataTable dt = _bd.ExecutarComando();
            foreach (DataRow item in dt.Rows)
            {
                Modulos mod = new Modulos()
                {
                    _codModulo = Convert.ToInt32(item["mod_cod"]),
                    _desModulo = item["mod_desc"].ToString(),
                    _valor = Convert.ToDouble(item["mod_valor"])
                };
                ListaModulosCurso.Add(mod);
            }

            return ListaModulosCurso;
        }

        public bool ExcluirModulo(int cod)
        {
            try
            {
                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"delete modulos where mod_cod = @cod";
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

        public bool ExcluirModuloCurso(int cod2)
        {
            try
            {
                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"delete modulos_curso where mod_cod = @cod";
                _bd.Comando.Parameters.Add("@cod", cod2);
                _bd.ExecutarComandoNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public bool RetornaNomeModulo(int mod)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select mod_desc from modulos where mod_cod = @mod";
            _bd.Comando.Parameters.Add("@mod", mod);
            DataTable dt = _bd.ExecutarComando();
            if (dt.Rows.Count > 0)
            {
                _desModulo = dt.Rows[0]["mod_desc"].ToString();
                return true;
            }
            else return false;
        }
    }
}
