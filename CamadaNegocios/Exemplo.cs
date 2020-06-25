using System;
using System.Collections.Generic;
using System.Text;
//*Importando a camada de dados
using CamadaDados.Bancos;
using System.Data; //Para usar o DataTable


namespace CamadaNegocios
{
    public class Exemplo
    {
      

        int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        string _descricao;

        public string Descricao
        {
            get { return _descricao; }
            set { _descricao = value; }
        }

        public Exemplo(int id, string descricao)
        {
            this._id = id;
            this._descricao = descricao;
        }

        public bool Gravar()
        { 
            SqlServer sqlBd = new SqlServer();
            sqlBd.Comando.CommandText = @"INSERT INTO REGION (REGIONID, REGIONDESCRIPTION)
                                          VALUES(@REGIONID, @REGIONDESCRIPTION)";   
            sqlBd.Comando.Parameters.AddWithValue("@REGIONID",this._id);
            sqlBd.Comando.Parameters.AddWithValue("@REGIONDESCRIPTION",this._descricao);
            
            if (sqlBd.ExecutarComandoNonQuery() > 0)
                return true;
            else return false;
        }


    }
}
