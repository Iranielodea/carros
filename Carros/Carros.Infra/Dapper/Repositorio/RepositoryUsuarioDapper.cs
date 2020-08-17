using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Dapper;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositoryUsuarioDapper : RepositoryBase<Usuario>, IRepositoryUsuario
    {
        private readonly IUnitOfWork _uow;

        public RepositoryUsuarioDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Adicionar(ref Usuario entity)
        {
            string instrucaoSQL = "INSERT INTO USUARIO(NOME, SENHA) values (@Nome, @Senha)";
            
            _uow.Connection.Execute(instrucaoSQL, entity, _uow.Transaction);
            entity.Id = _uow.Connection.Query<int>(base.SequencialFB("seq_usuario"), null, _uow.Transaction).First();
        }
    }
}
