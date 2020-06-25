using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Site
{
    public class Utils
    {
        public string[] Estados()
        {
            string[] ufs = new string[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
            return ufs;
        }

        public void MsgBox(Page pagina, string msg)
        {
            ScriptManager.RegisterClientScriptBlock(pagina, pagina.GetType(), "msg", "alert('" + msg + "')", true);
        
        }
    }
}