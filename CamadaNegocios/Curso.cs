using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Bancos;
using System.Data;

namespace CamadaNegocios
{
    public class Curso
    {
        SqlServer _bd = new SqlServer();

        private int _codCurso;

        public int CodCurso
        {
            get { return _codCurso; }
            set { _codCurso = value; }
        }
        private string _descCurso;

        public string DescCurso
        {
            get { return _descCurso; }
            set { _descCurso = value; }
        }
        private List<Modulos> _modulos;

        public List<Modulos> Modulos
        {
            get { return _modulos; }
            set { _modulos = value; }
        }

        public Curso()
        {
            
        }

        public Curso(string descCurso)
        {
            _descCurso = descCurso;
        }

        public Curso(int codCurso, string descCurso)
        {
            _codCurso = codCurso;
            _descCurso = descCurso;
        }

        public bool GravarCurso()
        {
            _bd.Comando.CommandText = @"INSERT INTO curso(cur_desc) VALUES(@desc)";
            _bd.Comando.Parameters.Add("@desc", this._descCurso);
            
            if (_bd.ExecutarComandoNonQuery() > 0)
            {

                _bd.Comando.Parameters.Clear();
                _bd.Comando.CommandText = @"select MAX(cur_cod) as maxcod from curso";

                 DataTable dt = _bd.ExecutarComando();

                 if (dt.Rows.Count > 0)
                 {
                     _codCurso = Convert.ToInt32(dt.Rows[0]["maxcod"]);

                 }
                return true;
            }
            else return false;
        }

        

        public bool GravarCursoModulo(int codCur, int codMod)
        {
            _bd.Comando.CommandText = @"INSERT INTO modulos_curso(cur_cod,mod_cod) VALUES(@cur,@mod)";
            _bd.Comando.Parameters.Add("@cur", codCur);
            _bd.Comando.Parameters.Add("@mod", codMod);

            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }

        public List<Curso> PesqCurso()
        {
            List<Curso> ListaCurso = new List<Curso>();
            _bd.Comando.CommandText = @"select cur_cod, cur_desc from curso
                                        where cur_desc like @nome";
            _bd.Comando.Parameters.Add("@nome", "%" + this._descCurso + "%");
            DataTable dt = _bd.ExecutarComando();
            foreach (DataRow item in dt.Rows)
            {
                Curso cur = new Curso()
                {
                    _codCurso = Convert.ToInt32(item["cur_cod"]),
                    _descCurso = item["cur_desc"].ToString()
                };
                ListaCurso.Add(cur);
            }

            return ListaCurso;
        }

        public bool RecuperarCurso(int cod)
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"select cur_cod, cur_desc from curso where cur_cod = @cod";
            _bd.Comando.Parameters.Add("@cod", cod);
            DataTable dt = _bd.ExecutarComando();

            if (dt.Rows.Count > 0)
            {
                _descCurso = dt.Rows[0]["cur_desc"].ToString();

                return true;
            }
            else return false;
        }

        public bool AlterarCurso()
        {
            _bd.Comando.Parameters.Clear();
            _bd.Comando.CommandText = @"update curso set
                                        cur_desc = @desc
                                        where cur_cod = @cod";
            _bd.Comando.Parameters.Add("@desc",this._descCurso);
            _bd.Comando.Parameters.Add("@cod", this._codCurso);
            if (_bd.ExecutarComandoNonQuery() > 0)
            {
                return true;
            }
            else return false;
        }
         
    }
}
