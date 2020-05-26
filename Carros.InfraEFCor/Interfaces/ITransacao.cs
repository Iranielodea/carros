using System;
using System.Collections.Generic;
using System.Text;

namespace Carros.InfraEFCor.Interfaces
{
    public interface ITransacao
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
