using Carros.Dominio.Entidades;
using Carros.Infra.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Infra.Repositorio
{
    public class EncontroRepositorioADO
    {
        private BancoFB _banco;

        public List<EncontroConsulta> ListarPorNome(string nome, int numEncontro, int id)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();

                sb.AppendLine(" SELECT E.id, E.num_ficha, E.id_pessoa, P.nome, P.CODIGO_SOCIO, P.CODIGO_FICHA, P.CODIGO_VISITA,");
                sb.AppendLine(" IIF(E.tipo_expositor = 1, P.codigo_ficha, P.codigo_visita) as CODPESSOA,");
                sb.AppendLine(" case e.tipo_expositor");
                sb.AppendLine(" when 1 then 'SOCIO'");
                sb.AppendLine(" when 2 then 'VISITANTE'");
                sb.AppendLine(" else");
                sb.AppendLine(" 'CAD_SOCIO'");
                sb.AppendLine(" end AS TIPO_EXPOSITOR");
                sb.AppendLine(" from ENCONTRO E");
                sb.AppendLine(" inner JOIN PESSOA P ON E.id_pessoa = P.id");
                if (id > 0)
                    sb.AppendLine(" WHERE E.ID = " + id);
                else
                    sb.AppendLine(" WHERE P.NOME containing('" + nome + "')");
                sb.AppendLine(" AND E.NUM_ENCONTRO = " + numEncontro);

                sb.AppendLine(" ORDER BY E.ID desc");

                List<EncontroConsulta> lista = new List<EncontroConsulta>();

                _banco.RetornoReader(sb.ToString());
                while (_banco.Read())
                {
                    var model = new EncontroConsulta()
                    {
                        Codigo = _banco.CampoInt32("CodPessoa"),
                        Id = _banco.CampoInt32("id"),
                        Nome = _banco.CampoStr("Nome"),
                        NumeroFicha = _banco.CampoInt32("num_ficha"),
                        TipoExpositor = _banco.CampoStr("Tipo_expositor"),
                        IdPessoa = _banco.CampoInt32("ID_PESSOA")
                    };
                    lista.Add(model);
                }
                _banco.CloseReader();
                return lista;
            }
        }

        public Encontro ObterPorId(int id)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.AppendLine("select E.DATA, E.ID, E.ID_PESSOA, E.NUM_ENCONTRO, E.NUM_FICHA, E.TIPO_EXPOSITOR, P.NOME, P.CODIGO_SOCIO, P.CODIGO_FICHA, P.CODIGO_VISITA ");
                sb.AppendLine(" FROM ENCONTRO E");
                sb.AppendLine(" INNER JOIN Pessoa P On E.Id_Pessoa = P.Id");
                sb.AppendLine(" WHERE E.ID = " + id);

                var model = new Encontro();

                _banco.RetornoReader(sb.ToString());
                if (_banco.Read())
                {
                    model.Id = _banco.CampoInt32("id");
                    model.Data = _banco.CampoData("Data");
                    model.NumeroFicha = _banco.CampoInt32("Num_Ficha");
                    model.TipoExpositor = _banco.CampoInt32("Tipo_Expositor");
                    model.Pessoa.Id = _banco.CampoInt32("Id_Pessoa");
                    model.Pessoa.Nome = _banco.CampoStr("Nome");
                    model.Encontros.NumeroEncontro = _banco.CampoInt32("NUM_ENCONTRO");
                    model.Pessoa.CodigoFicha = _banco.CampoInt32("CODIGO_FICHA");
                    model.Pessoa.CodigoSocio = _banco.CampoInt32("CODIGO_SOCIO");
                    model.Pessoa.CodigoVisita = _banco.CampoInt32("CODIGO_VISITA");

                    if (_banco.CampoInt32("CODIGO_SOCIO") != 0)
                        model.Pessoa.Codigo = _banco.CampoInt32("CODIGO_SOCIO");
                    else if (_banco.CampoInt32("CODIGO_VISITA") != 0)
                        model.Pessoa.Codigo = _banco.CampoInt32("CODIGO_VISITA");
                    else if (_banco.CampoInt32("CODIGO_FICHA") != 0)
                        model.Pessoa.Codigo = _banco.CampoInt32("CODIGO_FICHA");
                }
                _banco.CloseReader();
                return model;
            }
        }

        public Encontro ObterNumeroFicha(int idCliente, int numeroEncontro)
        {
            int id = 0;
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.AppendLine(" SELECT E.ID");
                sb.AppendLine(" FROM ENCONTRO E");
                sb.AppendLine(" WHERE E.ID_PESSOA = " + idCliente);
                sb.AppendLine(" AND E.NUM_ENCONTRO = " + numeroEncontro);

                _banco.RetornoReader(sb.ToString());
                if (_banco.Read())
                {
                    id = _banco.CampoInt32("id");
                }
                _banco.CloseReader();
            }
            return ObterPorId(id);
        }

        public void Excluir(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("DELETE FROM ENCONTRO WHERE ID = " + id);
            }
        }

        public void Salvar(Encontro model)
        {
            using (_banco = new BancoFB())
            {
                string Instrucao;
                if (model.Id == 0)
                {
                    model.Id = _banco.RetornarId("SEQ_ENCONTRO");
                    Instrucao = string.Format("INSERT INTO ENCONTRO(ID, DATA, ID_PESSOA, NUM_FICHA, TIPO_EXPOSITOR, NUM_ENCONTRO) VALUES ({0}, '{1}', {2}, {3}, {4}, {5}) returning id",
                       model.Id, model.Data, model.Pessoa.Id, model.NumeroFicha, model.TipoExpositor, model.Encontros.NumeroEncontro);
                    model.Id = _banco.ExecutaScalar(Instrucao);

                }
                else
                {
                    Instrucao = string.Format("UPDATE ENCONTRO SET DATA='{0}', ID_PESSOA = {1}, NUM_FICHA = {2}, TIPO_EXPOSITOR = {3}, NUM_ENCONTRO = {4}  WHERE ID = {5}",
                        model.Data, model.Pessoa.Id, model.NumeroFicha, model.TipoExpositor, model.Encontros.NumeroEncontro, model.Id);
                    _banco.ExecutaComando(Instrucao);
                }
            }
        }
    }
}
