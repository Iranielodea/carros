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
    public class RepositorioCadEncontroDapper : RepositorioBase<CadEncontro>, IRepositorioCadEncontro
    {
        private IDbConnection _conexao;
        private IDbTransaction _transaction;

        public RepositorioCadEncontroDapper(IDbConnection conexao, IDbTransaction transaction) : base(conexao, transaction)
        {
            _conexao = conexao;
            _transaction = transaction;
        }

        public override void Adicionar(ref CadEncontro entity)
        {
            var Dados = new PersistenciaFactory().Instanciar();
            string instrucaoSQL = "INSERT INTO CAD_ENCONTRO(NUM_ENCONTRO, DESCRICAO, EVENTO_ATUAL)"
                + " values (@NUMEROENCONTRO, @DESCRICAO, @EVENTOATUAL)";
            
            _conexao.Execute(instrucaoSQL, entity, _transaction);
            entity.Id = _conexao.Query<int>(base.SequencialFB("seq_cad_encontro"), null, _transaction).First();
        }
    }
}
