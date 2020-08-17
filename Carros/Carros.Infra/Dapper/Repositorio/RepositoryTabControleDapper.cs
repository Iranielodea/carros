using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositoryTabControleDapper : RepositoryBase<TabControle>, IRepositoryTabControle
    {
        private readonly IUnitOfWork _uow;

        public RepositoryTabControleDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Adicionar(ref TabControle entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = Dados.Inserir(new TabControle(), "TABCONTROLE", "ID");
            
            _uow.Connection.Execute(instrucaoSQL, entity, _uow.Transaction);
            entity.Id = _uow.Connection.Query<int>(base.SequencialFB("seq_tabControle"), null, _uow.Transaction).First();
        }

        public void ExecutarComando(string instrucaoSQL)
        {
            _uow.Connection.Execute(instrucaoSQL);
        }
    }
}
