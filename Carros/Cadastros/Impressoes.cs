using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Cadastros
{
    public class Impressoes
    {
        //[DllImport("Impressao.dll")]
        //public static extern void Imprimir(string Letra, string Nome, string Modelo, int Ano, int NumFicha, bool Configurar);

        //[DllImport("Impressao.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        //public  static extern void ChamaErro([MarshalAs(UnmanagedType.AnsiBStr)]string Erro);

        [DllImport("Impressao.dll")]
        //public static extern void Imprimir([MarshalAs(UnmanagedType.LPStr)]string Texto);
        //public static extern void Imprimir([MarshalAs(UnmanagedType.BStr)]string Nome, [MarshalAs(UnmanagedType.BStr)]string Endereco);
        public static extern void Imprimir([MarshalAs(UnmanagedType.BStr)]string Texto);

        //[DllImport("Impressao.dll")]
        //public static extern void ImpressaoDLL(
        //    [MarshalAs(UnmanagedType.BStr)]string Nome, 
        //    [MarshalAs(UnmanagedType.BStr)]string Ano,
        //    [MarshalAs(UnmanagedType.BStr)]string Modelo,
        //    [MarshalAs(UnmanagedType.BStr)]string NumFicha,
        //    [MarshalAs(UnmanagedType.BStr)]string Letra);

        [DllImport("Impressao.dll")]
        public static extern void ImpressaoDLL(string Nome, string Ano, string Modelo,string NumFicha, string Letra, int Modo);

        //private static extern void Login(string id, string pass);
    }
}
