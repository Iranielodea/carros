using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositoryFiliacaoDapper : RepositoryBase<Filiacao>, IRepositoryFiliacao
    {
        private readonly IUnitOfWork _uow;

        public RepositoryFiliacaoDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Adicionar(ref Filiacao entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = Dados.Inserir(new Filiacao(), "FILIACAO", "ID");
            
            _uow.Connection.Execute(instrucaoSQL, entity, _uow.Transaction);
            entity.Id = _uow.Connection.Query<int>(base.SequencialFB("seq_filiacao"), null, _uow.Transaction).First();
        }
    }
}
