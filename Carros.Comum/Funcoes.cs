using System;
using System.Windows.Forms;

namespace Carros.Comum
{
    public class Funcoes
    {
        const string DATAEMBRANCO = "/  /";

        public static int IdRetorno;
        public static int IdUsuario;
        public static int IdEmpresa;

        public static bool Confirmar(string mensagem)
        {
            return
                (MessageBox.Show(mensagem, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes);
        }

        public static void LimparTela(Control controles)
        {
            foreach (Control ctl in controles.Controls)
            {
                if (ctl is TextBox) ctl.Text = "";
                if (ctl is MaskedTextBox) ctl.Text = "";
            }
        }

        public static int StrToIntDef(string valor, int def)
        {
            try
            {
                return Convert.ToInt32(valor);
            }
            catch
            {
                return def;
            }
        }

        public static DateTime StrToDate(string valor)
        {
            try
            {
                return Convert.ToDateTime(valor);
            }
            catch
            {
                return Convert.ToDateTime("01/01/1900");
            }
        }

        public static string IntToStr(int? valor)
        {
            try
            {
                if (valor > 0)
                    return valor.ToString();
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

        public static int? StrToIntNull(string valor)
        {
            try
            {
                return Convert.ToInt32(valor);
            }
            catch
            {
                return null;
            }
        }

        public static string IfStr(bool valor, string valor1, string valor2)
        {
            if (valor)
                return valor1;
            else
                return valor2;
        }

        public static bool DataEmBranco(string data)
        {
            return (data.Trim() == DATAEMBRANCO);
        }

        public static string Valor(string valor, int casas)
        {
            try
            {
                decimal val = Convert.ToDecimal(valor);
                return val.ToString("N" + casas);
            }
            catch
            {
                decimal val = Convert.ToDecimal("0");
                return val.ToString("N" + casas);
            }
        }
    }
}
