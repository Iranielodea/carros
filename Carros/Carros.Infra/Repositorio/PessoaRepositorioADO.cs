using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Infra.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Infra.Repositorio
{
    public class PessoaRepositorioADO
    {
        private BancoFB _banco;

        public List<Pessoa> ListarEmails(int numeroEncontro, EnTipoExpositor tipo)
        {
            var sb = new StringBuilder();
            sb.Append(" select");
            sb.Append("    PES.EMAIL");
            sb.Append(" from ENCONTRO ENC");
            sb.Append("   inner join PESSOA PES on (ENC.ID_PESSOA = PES.ID)");
            sb.Append(" where ENC.NUM_ENCONTRO = " + numeroEncontro);

            if (tipo == EnTipoExpositor.expSocio)
                sb.Append(" and PES.CODIGO_FICHA > 0");

            if (tipo == EnTipoExpositor.expVisitante)
                sb.Append(" and PES.CODIGO_VISITA > 0");

            if (tipo == EnTipoExpositor.expCadSocio)
                sb.Append(" and PES.CODIGO_SOCIO > 0");

            sb.Append(" order by PES.EMAIL");

            var lista = new List<Pessoa>();
            using (_banco = new BancoFB())
            {
                _banco.RetornoReader(sb.ToString());
                while (_banco.Read())
                {
                    var model = new Pessoa();
                    model.Email = _banco.CampoStr("EMAIL");

                    if (model.Email.Trim() != "")
                        lista.Add(model);
                }
            }
            return lista;
        }

        public List<Pessoa> ListarPorNome(string nome, int? idCidade = null)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.AppendLine("SELECT P.ID, P.NOME, P.CODIGO_SOCIO, P.CODIGO_FICHA, P.CODIGO_VISITA FROM Pessoa P");
                sb.AppendLine(" WHERE P.NOME containing('" + nome + "')");

                if (idCidade != null)
                    sb.AppendLine(" AND P.id_Cidade = " + idCidade.Value);
                sb.AppendLine(" ORDER BY P.NOME");

                _banco.RetornoReader(sb.ToString());

                List<Pessoa> lista = new List<Pessoa>();
                while (_banco.Read())
                {
                    var model = new Pessoa()
                    {
                        Id = _banco.CampoInt32("Id"),
                        Nome = _banco.CampoStr("Nome"),
                        CodigoFicha = _banco.CampoIntNull("CODIGO_FICHA"),
                        CodigoSocio = _banco.CampoIntNull("CODIGO_SOCIO"),
                        CodigoVisita = _banco.CampoIntNull("CODIGO_VISITA")
                    };
                    lista.Add(model);
                };
                _banco.CloseReader();

                return lista;
            }
        }

        public List<Pessoa> FiltrarSocios(PessoaFiltro filtro, int id = 0)
        {
            return Filtrar(filtro, EnTipoExpositor.expSocio, id);
        }

        public List<Pessoa> FiltrarCadastroSocios(PessoaFiltro filtro, int id = 0)
        {
            return Filtrar(filtro, EnTipoExpositor.expCadSocio, id);
        }

        public List<Pessoa> FiltrarVisitantes(PessoaFiltro filtro, int id = 0)
        {
            return Filtrar(filtro, EnTipoExpositor.expVisitante, id);
        }

        public List<Pessoa> FiltrarTodos(PessoaFiltro filtro, int id = 0)
        {
            return Filtrar(filtro, EnTipoExpositor.expTodos, id);
        }

        public List<Pessoa> FiltrarExpositores(PessoaFiltro filtro, int id = 0)
        {
            return Filtrar(filtro, EnTipoExpositor.expExpositores, id);
        }

        private List<Pessoa> Filtrar(PessoaFiltro filtro, EnTipoExpositor tipo, int id = 0)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.AppendLine("SELECT P.ID, P.NOME, P.CPF, P.TELEFONE, P.CODIGO_SOCIO, P.CODIGO_FICHA, P.CODIGO_VISITA FROM Pessoa P");
                sb.AppendLine(" LEFT JOIN Cidade C ON P.ID_CIDADE = C.ID ");
                sb.AppendLine(" WHERE P.ID IS NOT NULL ");

                if (!string.IsNullOrWhiteSpace(filtro.CPF))
                    sb.AppendLine(" AND P.CPF containing('" + filtro.CPF + "')");

                if (!string.IsNullOrWhiteSpace(filtro.Nome))
                    sb.AppendLine(" AND P.NOME containing('" + filtro.Nome + "')");

                if (!string.IsNullOrWhiteSpace(filtro.NomeCidade))
                    sb.AppendLine(" AND C.DESCRICAO containing('" + filtro.NomeCidade + "')");

                if (!string.IsNullOrWhiteSpace(filtro.RG))
                    sb.AppendLine(" AND P.RG containing('" + filtro.RG + "')");

                if (!string.IsNullOrWhiteSpace(filtro.Telefone))
                    sb.AppendLine(" AND P.TELEFONE containing('" + filtro.Telefone + "')");

                if (!string.IsNullOrWhiteSpace(filtro.UF))
                    sb.AppendLine(" AND C.UF containing('" + filtro.UF + "')");

                if (tipo == EnTipoExpositor.expSocio)
                    sb.AppendLine(" AND P.CODIGO_FICHA IS NOT NULL");

                if (tipo == EnTipoExpositor.expCadSocio)
                    sb.AppendLine(" AND P.CODIGO_SOCIO IS NOT NULL");

                if (tipo == EnTipoExpositor.expVisitante)
                    sb.AppendLine(" AND P.CODIGO_VISITA IS NOT NULL");

                if (tipo == EnTipoExpositor.expExpositores)
                    sb.AppendLine(" AND ((P.CODIGO_VISITA IS NOT NULL) OR (P.CODIGO_FICHA IS NOT NULL))");

                if (id > 0)
                    sb.AppendLine(" AND P.ID = " + id);

                sb.AppendLine(" ORDER BY P.NOME");

                _banco.RetornoReader(sb.ToString());

                List<Pessoa> lista = new List<Pessoa>();
                while (_banco.Read())
                {
                    var model = new Pessoa();
                    model.Id = _banco.CampoInt32("Id");
                    model.Codigo = model.Id;
                    model.Nome = _banco.CampoStr("Nome");
                    model.CPF = _banco.CampoStr("CPF");
                    model.Telefone = _banco.CampoStr("Telefone");

                    lista.Add(model);
                };
                _banco.CloseReader();

                return lista;
            }
        }

        public Pessoa ObterPorid(int id)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.AppendLine("SELECT P.FATOR_RH, P.NOME, P.ENDERECO, P.EMPRESA, P.EMAIL, P.DATA_NASC, P.DATA_CADASTRO,");
                sb.AppendLine(" P.CPF, P.CONJUGE, P.CODIGO_VISITA, P.CODIGO_SOCIO, P.CODIGO_FICHA, P.CEP, P.CELULAR, P.BAIRRO,");
                sb.AppendLine(" P.TIPO_SANGUE, P.TELEFONE, P.RG, P.PAI, P.MAE, P.OBSERVACAO, P.ID_PROFISSAO, P.ID_CIDADE,");
                sb.AppendLine(" C.DESCRICAO, C.UF, F.DESCRICAO AS DESCPROFISSAO, P.Id");
                sb.AppendLine(" FROM PESSOA P");
                sb.AppendLine(" LEFT JOIN CIDADE C ON P.ID_CIDADE = C.ID");
                sb.AppendLine(" LEFT JOIN Profissao F ON P.Id_Profissao = F.Id");
                sb.AppendLine(" WHERE P.ID = " + id);
                _banco.RetornoReader(sb.ToString());

                var model = new Pessoa();

                _banco.RetornoReader(sb.ToString());
                if (_banco.Read())
                {
                    model.Id = _banco.CampoInt32("Id");
                    model.Bairro = _banco.CampoStr("Bairro");
                    model.CEP = _banco.CampoStr("CEP");
                    model.CidadeId = _banco.CampoIntNull("Id_Cidade");
                    model.Cidade.Nome = _banco.CampoStr("Descricao");
                    model.CPF = _banco.CampoStr("CPF");
                    model.DataCadastro = _banco.CampoDataNull("DATA_CADASTRO");
                    model.DataNascimento = _banco.CampoDataNull("Data_Nasc");
                    model.Email = _banco.CampoStr("Email");
                    model.Endereco = _banco.CampoStr("Endereco");
                    model.FatorRH = _banco.CampoStr("Fator_RH");
                    model.Id = _banco.CampoInt32("Id");
                    model.Nome = _banco.CampoStr("Nome");
                    model.NomeConjuge = _banco.CampoStr("Conjuge");
                    model.NomeEmpresa = _banco.CampoStr("Empresa");
                    model.NomeMae = _banco.CampoStr("Mae");
                    model.NomePai = _banco.CampoStr("Pai");
                    model.Observacao = _banco.CampoStr("Observacao");
                    model.ProfissaoId = _banco.CampoIntNull("Id_Profissao");
                    model.Profissao.Descricao = _banco.CampoStr("DescProfissao");
                    model.RG = _banco.CampoStr("RG");
                    model.Telefone = _banco.CampoStr("Telefone");
                    model.TipoSangue = _banco.CampoStr("Tipo_Sangue");
                    model.CodigoFicha = _banco.CampoIntNull("Codigo_Ficha");
                    model.CodigoSocio = _banco.CampoIntNull("Codigo_Socio");
                    model.CodigoVisita = _banco.CampoIntNull("Codigo_Visita");

                    if (model.CodigoFicha != null)
                        model.Codigo = model.CodigoFicha.Value;

                    if (model.CodigoSocio != null)
                        model.Codigo = model.CodigoSocio.Value;

                    if (model.CodigoVisita != null)
                        model.Codigo = model.CodigoVisita.Value;
                }
                _banco.CloseReader();
                return model;
            }
        }

        public Pessoa ObterPorCPF(string cpf, EnTipoExpositor enTipoExpositor)
        {
            using (_banco = new BancoFB())
            {
                int id = 0;
                var sb = new StringBuilder();
                sb.AppendLine("SELECT ID FROM Pessoa where CPF = '" + cpf + "'");

                if (enTipoExpositor == EnTipoExpositor.expCadSocio)
                    sb.AppendLine(" AND CODIGO_SOCIO IS NOT NULL");
                if (enTipoExpositor == EnTipoExpositor.expSocio)
                    sb.AppendLine(" AND CODIGO_FICHA IS NOT NULL");
                if (enTipoExpositor == EnTipoExpositor.expVisitante)
                    sb.AppendLine(" AND CODIGO_VISITA IS NOT NULL");

                _banco.RetornoReader(sb.ToString());
                if (_banco.Read())
                    id = _banco.CampoInt32("Id");
                _banco.CloseReader();

                if (id > 0)
                    return ObterPorid(id);
                else
                    return null;
            }
        }

        public Pessoa ObterPorSocio(int codigo)
        {
            using (_banco = new BancoFB())
            {
                int id = 0;
                _banco.RetornoReader("SELECT ID FROM Pessoa where Codigo_Ficha = " + codigo);
                if (_banco.Read())
                    id = _banco.CampoInt32("Id");
                _banco.CloseReader();

                if (id > 0)
                    return ObterPorid(id);
                else
                    return null;
            }
        }

        public Pessoa ObterPorSocioVisitante(int codigo)
        {
            using (_banco = new BancoFB())
            {
                int id = 0;
                _banco.RetornoReader("SELECT ID FROM Pessoa where Codigo_Socio = " + codigo);
                if (_banco.Read())
                    id = _banco.CampoInt32("Id");
                _banco.CloseReader();

                if (id > 0)
                    return ObterPorid(id);
                else
                    return null;
            }
        }

        public Pessoa ObterPorVisitante(int codigo)
        {
            using (_banco = new BancoFB())
            {
                int id = 0;
                _banco.RetornoReader("SELECT ID FROM Pessoa where Codigo_Visita = " + codigo);
                if (_banco.Read())
                    id = _banco.CampoInt32("Id");
                _banco.CloseReader();

                if (id > 0)
                    return ObterPorid(id);
                else
                    return null;
            }
        }

        public void Excluir(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("DELETE FROM Pessoa where ID = " + id);
            }
        }

        public void Salvar(Pessoa model)
        {
            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");

            if (model.Id == 0)
                Incluir(model);
            else
                Update(model);
        }

        private void Incluir(Pessoa model)
        {
            using (var _banco = new BancoFB())
            {
                model.Id = _banco.RetornarId("SEQ_PESSOA");

            }
            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO PESSOA(");
            sb.AppendLine("id,");
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
            sb.AppendLine(" observacao");
            sb.AppendLine(") VALUES (");
            sb.AppendLine(FuncoesSQL.CampoInt(model.Id));
            sb.AppendLine(FuncoesSQL.CampoStr(model.Nome));
            sb.AppendLine(FuncoesSQL.CampoStr(model.RG));
            sb.AppendLine(FuncoesSQL.CampoStr(model.CPF));
            sb.AppendLine(FuncoesSQL.CampoStr(model.Endereco));
            sb.AppendLine(FuncoesSQL.CampoStr(model.Bairro));
            sb.AppendLine(FuncoesSQL.CampoIntNull(model.CidadeId));
            sb.AppendLine(FuncoesSQL.CampoStr(model.CEP));
            sb.AppendLine(FuncoesSQL.CampoStr(model.Telefone));
            sb.AppendLine(FuncoesSQL.CampoStr(model.Celular));
            sb.AppendLine(FuncoesSQL.CampoStr(model.Email));
            sb.AppendLine(FuncoesSQL.CampoStr(model.NomePai));
            sb.AppendLine(FuncoesSQL.CampoStr(model.NomeMae));
            sb.AppendLine(FuncoesSQL.CampoStr(model.TipoSangue));
            sb.AppendLine(FuncoesSQL.CampoStr(model.FatorRH));
            sb.AppendLine(FuncoesSQL.CampoIntNull(model.ProfissaoId));
            sb.AppendLine(FuncoesSQL.CampoStr(model.NomeEmpresa));
            sb.AppendLine(FuncoesSQL.CampoIntNull(model.CodigoSocio));
            sb.AppendLine(FuncoesSQL.CampoIntNull(model.CodigoFicha));
            sb.AppendLine(FuncoesSQL.CampoDataNull(model.DataCadastro));
            sb.AppendLine(FuncoesSQL.CampoDataNull(model.DataNascimento));
            sb.AppendLine(FuncoesSQL.CampoStr(model.NomeConjuge));
            sb.AppendLine(FuncoesSQL.CampoIntNull(model.CodigoVisita));
            sb.AppendLine(FuncoesSQL.CampoStr(model.Observacao, false));
            sb.AppendLine(")");

            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando(sb.ToString());
            }
        }

        private void Update(Pessoa model)
        {
            var sb = new StringBuilder();
            sb.AppendLine(" UPDATE PESSOA SET ");
            sb.AppendLine(" nome = " + FuncoesSQL.CampoStr(model.Nome));
            sb.AppendLine(" rg = " + FuncoesSQL.CampoStr(model.RG));
            sb.AppendLine(" cpf = " + FuncoesSQL.CampoStr(model.CPF));
            sb.AppendLine(" endereco = " + FuncoesSQL.CampoStr(model.Endereco));
            sb.AppendLine(" bairro = " + FuncoesSQL.CampoStr(model.Bairro));
            sb.AppendLine(" id_cidade = " + FuncoesSQL.CampoIntNull(model.CidadeId));
            sb.AppendLine(" cep= " + FuncoesSQL.CampoStr(model.CEP));
            sb.AppendLine(" telefone= " + FuncoesSQL.CampoStr(model.Telefone));
            sb.AppendLine(" celular= " + FuncoesSQL.CampoStr(model.Celular));
            sb.AppendLine(" email = " + FuncoesSQL.CampoStr(model.Email));
            sb.AppendLine(" pai= " + FuncoesSQL.CampoStr(model.NomePai));
            sb.AppendLine(" mae= " + FuncoesSQL.CampoStr(model.NomeMae));
            sb.AppendLine(" tipo_sangue= " + FuncoesSQL.CampoStr(model.TipoSangue));
            sb.AppendLine(" fator_rh= " + FuncoesSQL.CampoStr(model.FatorRH));
            sb.AppendLine(" id_profissao= " + FuncoesSQL.CampoIntNull(model.ProfissaoId));
            sb.AppendLine(" empresa= " + FuncoesSQL.CampoStr(model.NomeEmpresa));
            sb.AppendLine(" codigo_socio= " + FuncoesSQL.CampoIntNull(model.CodigoSocio));
            sb.AppendLine(" codigo_ficha= " + FuncoesSQL.CampoIntNull(model.CodigoFicha));
            sb.AppendLine(" data_cadastro= " + FuncoesSQL.CampoDataNull(model.DataCadastro));
            sb.AppendLine(" data_nasc= " + FuncoesSQL.CampoDataNull(model.DataNascimento));
            sb.AppendLine(" conjuge= " + FuncoesSQL.CampoStr(model.NomeConjuge));
            sb.AppendLine(" codigo_visita= " + FuncoesSQL.CampoIntNull(model.CodigoVisita));
            sb.AppendLine(" observacao= " + FuncoesSQL.CampoStr(model.Observacao, false));
            sb.AppendLine(" WHERE Id = " + model.Id);

            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando(sb.ToString());
            }
        }
    }
}
