using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Infra.Banco;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Carros.Infra.Dapper.Repositorio
{
    public class RepositorioPessoaDapper : RepositorioBase<Pessoa>, IRepositorioPessoa
    {
        private IDbConnection _conexao;
        private IDbTransaction _transaction;

        public RepositorioPessoaDapper(IDbConnection conexao, IDbTransaction transaction) : base(conexao, transaction)
        {
            _conexao = conexao;
            _transaction = transaction;
        }

        public override void Adicionar(ref Pessoa entity)
        {
            var sb = new StringBuilder();

            sb.AppendLine(" insert into pessoa(");
            sb.AppendLine(" id,");
            sb.AppendLine(" nome,");
            sb.AppendLine(" rg,");
            sb.AppendLine(" cpf,");
            sb.AppendLine(" endereco,");
            sb.AppendLine(" bairro,");
            sb.AppendLine(" id_cidade,");
            sb.AppendLine(" cep,");
            sb.AppendLine(" telefone,");
            sb.AppendLine(" celular,");
            sb.AppendLine(" email,");
            sb.AppendLine(" pai,");
            sb.AppendLine(" mae,");
            sb.AppendLine(" tipo_sangue,");
            sb.AppendLine(" fator_rh,");
            sb.AppendLine(" id_profissao,");
            sb.AppendLine(" empresa,");
            sb.AppendLine(" codigo_socio,");
            sb.AppendLine(" codigo_ficha,");
            sb.AppendLine(" data_cadastro,");
            sb.AppendLine(" data_nasc,");
            sb.AppendLine(" conjuge,");
            sb.AppendLine(" codigo_visita,");
            sb.AppendLine(" observacao)");
            sb.AppendLine(" values(");
            sb.AppendLine(" @id,");
            sb.AppendLine(" @nome,");
            sb.AppendLine(" @rg,");
            sb.AppendLine(" @cpf,");
            sb.AppendLine(" @endereco,");
            sb.AppendLine(" @bairro,");
            sb.AppendLine(" @CidadeId,");
            sb.AppendLine(" @cep,");
            sb.AppendLine(" @telefone,");
            sb.AppendLine(" @celular,");
            sb.AppendLine(" @email,");
            sb.AppendLine(" @NomePai,");
            sb.AppendLine(" @NomeMae,");
            sb.AppendLine(" @TipoSangue,");
            sb.AppendLine(" @FatorRh,");
            sb.AppendLine(" @ProfissaoId,");
            sb.AppendLine(" @NomeEmpresa,");
            sb.AppendLine(" @codigosocio,");
            sb.AppendLine(" @codigoficha,");
            sb.AppendLine(" @datacadastro,");
            sb.AppendLine(" @datanascimento,");
            sb.AppendLine(" @NomeConjuge,");
            sb.AppendLine(" @codigovisita,");
            sb.AppendLine(" @observacao)");

            _conexao.Execute(sb.ToString(), entity, _transaction);
            entity.Id = _conexao.Query<int>(base.SequencialFB("seq_pessoa"), null, _transaction).First();
        }

        public IQueryable<PessoaPesquisa> ListarCadastroSocios()
        {
            return RetornarPesquisa(EnTipoExpositor.expCadSocio);
        }

        public IEnumerable<string> ListarEmails(int numeroEncontro, EnTipoExpositor tipo)
        {
            var sb = new StringBuilder();
            sb.Append(" select");
            sb.Append("    PES.EMAIL");
            sb.Append(" from ENCONTRO ENC");
            sb.Append("   inner join PESSOA PES on (ENC.ID_PESSOA = PES.ID)");
            sb.Append(" where ENC.NUM_ENCONTRO = " + numeroEncontro);

            if (tipo == EnTipoExpositor.expSocio)
                sb.Append(" and PES.CODIGO_FICHA IS NOT NULL");

            if (tipo == EnTipoExpositor.expVisitante)
                sb.Append(" and PES.CODIGO_VISITA IS NOT NULL");

            if (tipo == EnTipoExpositor.expCadSocio)
                sb.Append(" and PES.CODIGO_SOCIO IS NOT NULL");

            sb.Append(" order by PES.EMAIL");

            return _conexao.Query<string>(sb.ToString(), null).ToList();
        }

        public IQueryable<PessoaPesquisa> ListarExpositoresVisitantes()
        {
            return RetornarPesquisa(EnTipoExpositor.expVisitante);
        }

        public IQueryable<PessoaPesquisa> ListarSociosExpositores()
        {
            return RetornarPesquisa(EnTipoExpositor.expSocio);
        }

        public IQueryable<PessoaPesquisa> ListarTodosExpositores()
        {
            return RetornarPesquisa(EnTipoExpositor.expTodos);
        }

        private IQueryable<PessoaPesquisa> RetornarPesquisa(EnTipoExpositor enTipoExpositor)
        {
            var sb = new StringBuilder();
            sb.AppendLine("SELECT ID, NOME, CPF, RG, TELEFONE, CODIGO_FICHA, CODIGO_VISITA, CODIGO_SOCIO FROM PESSOA");

            if (enTipoExpositor == EnTipoExpositor.expSocio)
                sb.AppendLine(" WHERE CODIGO_FICHA IS NOT NULL");

            if (enTipoExpositor == EnTipoExpositor.expCadSocio)
                sb.AppendLine(" WHERE CODIGO_SOCIO IS NOT NULL");

            if (enTipoExpositor == EnTipoExpositor.expVisitante)
                sb.AppendLine(" WHERE CODIGO_VISITA IS NOT NULL");

            return _conexao.Query<PessoaPesquisa>(sb.ToString(), null).AsQueryable();
        }
    }
}
