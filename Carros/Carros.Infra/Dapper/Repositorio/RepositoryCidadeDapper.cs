using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositoryCidadeDapper : RepositoryBase<Cidade>, IRepositoryCidade
    {
        private readonly IUnitOfWork _uow;

        public RepositoryCidadeDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Adicionar(ref Cidade entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            //string instrucaoSQL = Dados.Inserir(new Cidade(), "CIDADE", "ID");
            string instrucaoSQL = "INSERT INTO CIDADE(DESCRICAO, CEP, UF) values (@Nome, @CEP, @UF)";
            
            _uow.Connection.Execute(instrucaoSQL, entity, _uow.Transaction);
            entity.Id = _uow.Connection.Query<int>(base.SequencialFB("seq_cidade"), null, _uow.Transaction).First();
        }
    }
}
