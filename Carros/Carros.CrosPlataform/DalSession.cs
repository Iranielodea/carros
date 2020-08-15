using Carros.Infra.Banco;
using System;
using System.Data;
using System.Data.OleDb;
using FirebirdSql.Data.FirebirdClient;
using Carros.Dominio.Interfaces.Servico;
using Carros.Infra.Dapper.Repositorio;
using Carros.Dominio.Servicos;

namespace Carros.CrosPlataform
{
    public sealed class DalSession : IDisposable
    {
        IDbConnection _connection = null;
        UnitOfWork _unitOfWork = null;
        private readonly string connection =
        "User=SYSDBA;" +
        "Password=masterkey;" +
        "Database=C:\\Projetos\\Carros\\Banco\\Veiculo.fdb;" +
        "DataSource=localhost;" +
        "Port=3050;" +
        "Dialect=3;" +
        "Charset=NONE;" +
        "Role=;" +
        "Connection lifetime=15;" +
        "Pooling=true;" +
        "Packet Size=8192;" +
        "ServerType=0";

        public DalSession()
        {
            //string conexaoSql = "Data Source=" + servidor + ";Initial Catalog=" + nomeBanco
            //    + ";User ID=" + usuario
            //    + ";Password=" + password;

            _connection = new FbConnection(connection);
            _connection.Open();
            _unitOfWork = new UnitOfWork(_connection);
        }

        public UnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
            _connection.Dispose();
        }

        private IServiceCidade _serviceCidade;
        public IServiceCidade ServiceCidade => _serviceCidade = _serviceCidade ?? new ServiceCidade(new RepositoryCidadeDapper(_unitOfWork));
    }
}
