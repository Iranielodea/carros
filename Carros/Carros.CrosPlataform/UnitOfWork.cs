using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using Carros.Dominio.Servicos;
using Carros.Infra.Dapper.Repositorio;
using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace Carros.CrosPlataform
{
    public class UnitOfWork : IUnitOfWork
    {
        private string connection =
        "User=SYSDBA;" +
        "Password=rota11;" +
        "Database=C:\\Projetos\\DotNet\\Carros\\Banco\\Veiculo.fdb;" +
        "DataSource=localhost;" +
        "Port=3050;" +
        "Dialect=3;" +
        "Charset=NONE;" +
        "Role=;" +
        "Connection lifetime=15;" +
        "Pooling=true;" +
        "Packet Size=8192;" +
        "ServerType=0";

        IDbConnection _conexao;
        IDbTransaction _transacao;
        private bool _inTransacao;
        //string connection = ConfigurationManager.ConnectionStrings["FireBirdConnectionString"].ToString();
        

        public UnitOfWork()
        {
            //connection = DadosStaticos.StringConexao;
            //ConnectionString = connection;
            _conexao = new FbConnection(connection);
            _inTransacao = false;
        }

        public void BeginTransaction()
        {
            _conexao.Open();
            _transacao = _conexao.BeginTransaction();
            _inTransacao = true;
        }

        public void Commit()
        {
            _transacao.Commit();
            _inTransacao = true;
        }

        public void Dispose()
        {
            _conexao.Dispose();
            if (_inTransacao)
                _transacao.Dispose();
        }

        public void RollBack()
        {
            _transacao.Rollback();
            _inTransacao = true;
        }

        private IServicoProfissao _servicoProfissao;
        private IServicoCidade _servicoCidade;
        private IServicoUsuario _servicoUsuario;
        private IServicoTabControle _servicoTabControle;
        private IServicoCadEncontro _servicoCadEncontro;
        private IServicoContato _servicoContato;
        private IServicoMarca _servicoMarca;
        private IServicoSequencia _servicoSequencia;
        private IServicoVeiculo _servicoVeiculo;
        private IServicoPessoa _servicoPessoa;
        private IServicoEncontro _servicoEncontro;
        private IServicoVeiculoPessoa _servicoVeiculoPessoa;
        private IServicoFiliacao _servicoFiliacao;
        private IServicoSQL _servicoSQL;

        public IServicoProfissao ServicoProfissao => _servicoProfissao  = _servicoProfissao ?? new ServicoProfissao(new RepositorioProfissaoDapper(_conexao, _transacao));
        public IServicoCidade ServicoCidade => _servicoCidade = _servicoCidade ?? new ServicoCidade(new RepositorioCidadeDapper(_conexao, _transacao));
        public IServicoUsuario ServicoUsuario => _servicoUsuario = _servicoUsuario ?? new ServicoUsuario(new RepositorioUsuarioDapper(_conexao, _transacao));
        public IServicoTabControle ServicoTabControle => _servicoTabControle = _servicoTabControle ?? new ServicoTabControle(new RepositorioTabControleDapper(_conexao, _transacao));
        public IServicoCadEncontro ServicoCadEncontro => _servicoCadEncontro = _servicoCadEncontro ?? new ServicoCadEncontro(new RepositorioCadEncontroDapper(_conexao, _transacao));
        public IServicoContato ServicoContato => _servicoContato = _servicoContato ?? new ServicoContato(new RepositorioContatoDapper(_conexao, _transacao));
        public IServicoMarca ServicoMarca => _servicoMarca = _servicoMarca ?? new ServicoMarca(new RepositorioMarcaDapper(_conexao, _transacao));
        public IServicoSequencia ServicoSequencia => _servicoSequencia = _servicoSequencia ?? new ServicoSequencia(new RepositorioSequenciaDapper(_conexao, _transacao));
        public IServicoVeiculo ServicoVeiculo => _servicoVeiculo = _servicoVeiculo ?? new ServicoVeiculo(new RepositorioVeiculoDapper(_conexao, _transacao));
        public IServicoVeiculoPessoa ServicoVeiculoPessoa => _servicoVeiculoPessoa = _servicoVeiculoPessoa ?? new ServicoVeiculoPessoa(new RepositorioVeiculoPessoaDapper(_conexao, _transacao));
        public IServicoFiliacao ServicoFiliacao => _servicoFiliacao = _servicoFiliacao ?? new ServicoFiliacao(new RepositorioFiliacaoDapper(_conexao, _transacao));
        public IServicoSQL ServicoSQL => _servicoSQL = _servicoSQL ?? new ServicoSQL(new RepositorioSQLDapper(_conexao));

        public IServicoPessoa ServicoPessoa => _servicoPessoa = _servicoPessoa ?? new ServicoPessoa(
            new RepositorioPessoaDapper(_conexao, _transacao), ServicoEncontro, ServicoCadEncontro, ServicoSequencia);

        public IServicoEncontro ServicoEncontro => _servicoEncontro = _servicoEncontro ?? new ServicoEncontro(
            new RepositorioEncontroDapper(_conexao, _transacao), ServicoSequencia, ServicoCadEncontro);
    }
}
