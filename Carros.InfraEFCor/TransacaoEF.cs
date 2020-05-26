using Carros.InfraEFCor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carros.InfraEFCor
{
    public class TransacaoEF : ITransacao
    {
        private readonly Contexto _contexto;

        public TransacaoEF(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void BeginTransaction()
        {
            _contexto.Database.BeginTransaction();
        }

        public void Commit()
        {
            _contexto.Database.CommitTransaction();
        }

        public void Rollback()
        {
            _contexto.Database.RollbackTransaction();
        }
    }
}
