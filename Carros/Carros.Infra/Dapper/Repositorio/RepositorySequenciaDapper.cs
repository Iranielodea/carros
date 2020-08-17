using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorySequenciaDapper : RepositoryBase<Sequencia>, IRepositorySequencia
    {
        private readonly IUnitOfWork _uow;

        public RepositorySequenciaDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Adicionar(ref Sequencia entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = Dados.Inserir(new Sequencia(), "SEQUENCIA", "ID");
            
            _uow.Connection.Execute(instrucaoSQL, entity, _uow.Transaction);
            entity.Id = _uow.Connection.Query<int>(base.SequencialFB("seq_sequencia"), null, _uow.Transaction).First();
        }
    }
}
