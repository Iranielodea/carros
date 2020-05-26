using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Carros.Comum
{
    public class ArquivoTexto : IDisposable
    {
        private string _nomeArquivo;
        StreamWriter _writer;
        public ArquivoTexto(string nomeArquivo)
        {
            _nomeArquivo = nomeArquivo;
            _writer = new StreamWriter(nomeArquivo);
        }

        public void Dispose()
        {
            _writer.Close();
        }

        public void Escrever(string texto, int tamanho)
        {
            texto = texto + "                                             ";
            _writer.Write(texto.Substring(0, tamanho));
        }

        public void Escrever(string texto)
        {
            _writer.Write(texto);
        }

        public void NovaLinha()
        {
            _writer.WriteLine("");
        }
    }
}
