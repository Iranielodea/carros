using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;

namespace Carros.Dominio.Servicos
{
    public class ServiceSQL : IServiceSQL
    {
        private readonly IRepositorySQL _repositorioSQL;

        public ServiceSQL(IRepositorySQL repositorioSQL)
        {
            _repositorioSQL = repositorioSQL;
        }

        public void ExecutarSQL(string instrucaoSQL)
        {
            _repositorioSQL.ExecutarSQL(instrucaoSQL);
        }
    }
}
