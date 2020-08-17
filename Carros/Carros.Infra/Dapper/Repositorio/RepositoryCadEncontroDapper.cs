using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositoryCadEncontroDapper : RepositoryBase<CadEncontro>, IRepositoryCadEncontro
    {
        private readonly IUnitOfWork _uow;

        public RepositoryCadEncontroDapper(IUnitOfWork uow) : base(uow)
        {
            _uow = uow;
        }

        public override void Adicionar(ref CadEncontro entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = "INSERT INTO CAD_ENCONTRO(NUM_ENCONTRO, DESCRICAO, EVENTO_ATUAL)"
                + " values (@NUMEROENCONTRO, @DESCRICAO, @EVENTOATUAL)";
            
            _uow.Connection.Execute(instrucaoSQL, entity, _uow.Transaction);
            entity.Id = _uow.Connection.Query<int>(base.SequencialFB("seq_cad_encontro"), null, _uow.Transaction).First();
        }
    }
}
