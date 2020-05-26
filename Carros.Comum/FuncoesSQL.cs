using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Comum
{
    public static class FuncoesSQL
    {
        public static string CampoStr(string valor, bool virgula=true)
        {
            if (virgula)
                return "'" + valor + "',";
            else
                return "'" + valor + "'";
        }

        public static string CampoInt(int valor, bool virgula=true)
        {
            if (virgula)
                return valor.ToString() + ",";
            else
                return valor.ToString();
        }

        public static string CampoData(DateTime valor, bool virgula=true)
        {
            try
            {
                if (virgula)
                    return "'" + valor.ToString("yyyyMMdd") + "',";
                else
                    return "'" + valor.ToString("yyyyMMdd") + "'";
            }
            catch
            {
                return "null";
            }
        }

        public static string CampoIntNull(int? valor, bool virgula=true)
        {
            try
            {
                if (valor <= 0 || valor == null)
                    throw new Exception("");
                 
                if (virgula)
                {
                    int a = Convert.ToInt32(valor);
                    return a.ToString() + ",";
                }
                else
                {
                    int a = Convert.ToInt32(valor);
                    return a.ToString();
                }
            }
            catch
            {
                if (virgula)
                    return "null,";
                else
                    return "null";
            }
        }

        public static string CampoDataNull(DateTime? valor, bool virgula=true)
        {
            try
            {
                if (virgula)
                {
                    DateTime a = Convert.ToDateTime(valor);
                    return "'" + valor.Value.ToString("MM/dd/yyyy") + "',";
                }
                else
                {
                    DateTime a = Convert.ToDateTime(valor);
                    return "'" + valor.Value.ToString("MM/dd/yyyy") + "'";
                }
            }
            catch
            {
                if (virgula)
                    return "null,";
                else
                    return "null";
            }
        }
    }
}
