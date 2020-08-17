using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using Carros.Dominio.Servicos;
using Carros.Infra.Dapper.Repositorio;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;

namespace Carros.CrosPlataform
{
    public sealed class DalSession : IDalSession, IDisposable
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

        private IServiceProfissao _serviceProfissao;
        public IServiceProfissao ServiceProfissao => _serviceProfissao = _serviceProfissao ?? new ServiceProfissao(new RepositoryProfissaoDapper(_unitOfWork));

        private IServiceUsuario _serviceUsuario;
        public IServiceUsuario ServiceUsuario => _serviceUsuario = _serviceUsuario ?? new ServiceUsuario(new RepositoryUsuarioDapper(_unitOfWork));

        private IServiceTabControle _serviceTabControle;
        public IServiceTabControle ServiceTabControle => _serviceTabControle = _serviceTabControle ?? new ServiceTabControle(new RepositoryTabControleDapper(_unitOfWork));

        private IServiceSequencia _serviceSequencia;
        public IServiceSequencia ServiceSequencia => _serviceSequencia = _serviceSequencia ?? new ServiceSequencia(new RepositorySequenciaDapper(_unitOfWork));

        private IServiceMarca _serviceMarca;
        public IServiceMarca ServiceMarca => _serviceMarca = _serviceMarca ?? new ServiceMarca(new RepositoryMarcaDapper(_unitOfWork));

        private IServiceCadEncontro _serviceCadEncontro;
        public IServiceCadEncontro ServiceCadEncontro => _serviceCadEncontro = _serviceCadEncontro ?? new ServiceCadEncontro(new RepositoryCadEncontroDapper(_unitOfWork));

        private IServiceContato _serviceContato;
        public IServiceContato ServiceContato => _serviceContato = _serviceContato ?? new ServiceContato(new RepositoryContatoDapper(_unitOfWork));

        private IServiceVeiculo _serviceVeiculo;
        public IServiceVeiculo ServiceVeiculo => _serviceVeiculo = _serviceVeiculo ?? new ServiceVeiculo(new RepositoryVeiculoDapper(_unitOfWork));

        IUnitOfWork IDalSession.UnitOfWork => new UnitOfWork(_connection);

        private IServiceEncontro _serviceEncontro;
        public IServiceEncontro ServiceEncontro => _serviceEncontro = _serviceEncontro ?? new ServiceEncontro(new RepositoryEncontroDapper(_unitOfWork), this);

        private IServicePessoa _servicePessoa;
        public IServicePessoa ServicePessoa => _servicePessoa = _servicePessoa ?? new ServicePessoa(new RepositoryPessoaDapper(_unitOfWork), this);

        private IServiceVeiculoPessoa _serviceVeiculoPessoa;
        public IServiceVeiculoPessoa ServiceVeiculoPessoa => _serviceVeiculoPessoa = _serviceVeiculoPessoa ?? new ServiceVeiculoPessoa(new RepositoryVeiculoPessoaDapper(_unitOfWork));
    }
}
