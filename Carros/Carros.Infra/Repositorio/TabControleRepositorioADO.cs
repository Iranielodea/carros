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
    public class TabControleRepositorioADO
    {
        private BancoFB _banco;

        public List<TabControle> ListarTudo(int id = 0)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.Append("SELECT ID, DESCRICAO, SIGLA, VALORINT, VALORSTRING, VALORDATA FROM TabControle");
                if (id > 0)
                    sb.Append(" WHERE ID = " + id);
                else
                    sb.Append(" ORDER BY DESCRICAO");
                _banco.RetornoReader(sb.ToString());
                List<TabControle> lista = new List<TabControle>();
                while (_banco.Read())
                {
                    var model = new TabControle()
                    {
                        Id = _banco.CampoInt32("Id"),
                        Descricao = _banco.CampoStr("Descricao"),
                        Sigla = _banco.CampoStr("Sigla"),
                        ValorData = _banco.CampoDataNull("VALORDATA"),
                        ValorInt = _banco.CampoIntNull("VALORINT"),
                        ValorString = _banco.CampoStr("VALORSTRING")
                    };
                    lista.Add(model);
                };
                _banco.CloseReader();

                return lista;
            }
        }

        public TabControle ObterPorid(int id)
        {
            using (_banco = new BancoFB())
            {
                var model = new TabControle();
                _banco.RetornoReader("SELECT ID, DESCRICAO, SIGLA, VALORINT, VALORSTRING, VALORDATA FROM TabControle where ID = " + id);
                if (_banco.Read())
                {
                    model.Id = _banco.CampoInt32("Id");
                    model.Descricao = _banco.CampoStr("Descricao");
                    model.Sigla = _banco.CampoStr("Sigla");
                    model.ValorData = _banco.CampoDataNull("VALORDATA");
                    model.ValorInt = _banco.CampoIntNull("VALORINT");
                    model.ValorString = _banco.CampoStr("VALORSTRING");
                }
                _banco.CloseReader();
                return model;
            }
        }

        public void Excluir(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("DELETE FROM TabControle where ID = " + id);
            }
        }

        public void Salvar(TabControle model)
        {
            using (_banco = new BancoFB())
            {
                string Instrucao;
                if (model.Id == 0)
                {
                    model.Id = _banco.RetornarId("SEQ_TABCONTROLE");
                    Instrucao = string.Format("INSERT INTO TABCONTROLE(DESCRICAO, ID, SIGLA, VALORINT, VALORSTRING) VALUES ('{0}', {1}, '{2}', {3}, {4}) returning ID",
                        model.Descricao, model.Id, model.Sigla, model.ValorInt.Value, model.ValorString);
                    model.Id = _banco.ExecutaScalar(Instrucao);
                }
                else
                {
                    Instrucao = string.Format("UPDATE TABCONTROLE SET DESCRICAO='{0}', SIGLA='{1}', VALORINT={2}, VALORSTRING='{3}' WHERE ID = {4}",
                        model.Descricao, model.Sigla, model.ValorInt.Value, model.ValorString, model.Id);
                    _banco.ExecutaComando(Instrucao);
                }
            }
        }
    }
}
