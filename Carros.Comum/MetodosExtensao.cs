using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Carros.Comum
{
    public static class MetodosExtensao
    {
        public static string SoNumeros(this String str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                Regex r = new Regex(@"\d+");
                string result = "";
                foreach (Match m in r.Matches(str))
                    result += m.Value;

                return result;
            }
            else
                return "";
        }
    }
}
