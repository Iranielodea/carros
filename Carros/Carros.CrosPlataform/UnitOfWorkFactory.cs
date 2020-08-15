using Carros.Dominio.Interfaces;

namespace Carros.CrosPlataform
{
    public class UnitOfWorkFactory
    {
        public IUnitOfWorkOld Retorno()
        {
            return new UnitOfWorkOld();
        }
    }
}
