using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositoryMarcaDapper : RepositoryBase<Marca>, IRepositoryMarca
    {
        private readonly IUnitOfWork _uow;
        public RepositoryMarcaDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Adicionar(ref Marca entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = Dados.Inserir(new Marca(), "MARCA", "ID");
            
            _uow.Connection.Execute(instrucaoSQL, entity, _uow.Transaction);
            entity.Id = _uow.Connection.Query<int>(base.SequencialFB("seq_marca"), null, _uow.Transaction).First();
        }
    }
}
