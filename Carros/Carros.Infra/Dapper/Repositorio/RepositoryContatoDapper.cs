using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Data;
using System.Linq;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositoryContatoDapper : RepositoryBase<Contato>, IRepositoryContato
    {
        private readonly IUnitOfWork _uow;
        public RepositoryContatoDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Adicionar(ref Contato entity)
        {
            string instrucaoSQL = "INSERT INTO CONTATO(PESSOA_ID, TELEFONE, CELULAR, EMAIL, OBS)" 
                + " values (@PessoaId, @Telefone, @Celular, @Email, @Observacao)";
            
            _uow.Connection.Execute(instrucaoSQL, entity, _uow.Transaction);
            entity.Id = _uow.Connection.Query<int>(base.SequencialFB("seq_Contato"), null, _uow.Transaction).First();
        }
    }
}
