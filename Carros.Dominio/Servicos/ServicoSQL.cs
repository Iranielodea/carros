using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.IO;
using System.Text;

namespace Carros.Dominio.Servicos
{
    public class ServicoSQL : IServicoSQL
    {
        private readonly IRepositorioSQL _repositorioSQL;

        public ServicoSQL(IRepositorioSQL repositorioSQL)
        {
            _repositorioSQL = repositorioSQL;
        }

        public void ExecutarSQL(string instrucaoSQL)
        {
            _repositorioSQL.ExecutarSQL(instrucaoSQL);
        }
    }
}
