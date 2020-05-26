using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carros.InfraEFCor.Repositorio
{
    public class RepositorioBancoDados : IDisposable
    {
        private Contexto _contexto;
        public RepositorioBancoDados()
        {
            _contexto = new Contexto();
        }

        public void ExecutarComandos(string comandoSQL)
        {
            _contexto.Database.ExecuteSqlCommand(comandoSQL);
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
