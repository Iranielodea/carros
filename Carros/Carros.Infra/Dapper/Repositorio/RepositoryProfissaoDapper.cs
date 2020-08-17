using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositoryProfissaoDapper : RepositoryBase<Profissao>, IRepositoryProfissao
    {
        private readonly IUnitOfWork _uow;

        public RepositoryProfissaoDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Adicionar(ref Profissao entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = Dados.Inserir(new Profissao(), "PROFISSAO", "ID");
            
            _uow.Connection.Execute(instrucaoSQL, entity, _uow.Transaction);
            entity.Id = _uow.Connection.Query<int>(base.SequencialFB("seq_Profissao"), null, _uow.Transaction).First();
        }
    }
}
