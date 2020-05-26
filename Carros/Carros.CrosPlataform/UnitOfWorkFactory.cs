using Carros.Dominio.Interfaces;

namespace Carros.CrosPlataform
{
    public class UnitOfWorkFactory
    {
        public IUnitOfWork Retorno()
        {
            return new UnitOfWork();
        }
    }
}
