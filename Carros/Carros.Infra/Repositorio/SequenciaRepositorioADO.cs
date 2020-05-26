using Carros.Dominio.Entidades;
using Carros.Infra.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Infra.Repositorio
{
    public class SequenciaRepositorioADO
    {
        private BancoFB _banco;

        public List<Sequencia> ListarPorTudo(int id = 0)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.Append("SELECT ID, SIGLA, DESCRICAO, VALOR FROM SEQUENCIA");
                if (id > 0)
                    sb.Append(" WHERE ID = " + id);
                else
                    sb.Append(" ORDER BY SIGLA");

                _banco.RetornoReader(sb.ToString());

                List<Sequencia> lista = new List<Sequencia>();
                while (_banco.Read())
                {
                    var model = new Sequencia()
                    {
                        Id = _banco.CampoInt32("Id"),
                        Descricao = _banco.CampoStr("Descricao"),
                        Sigla = _banco.CampoStr("Sigla"),
                        Valor = _banco.CampoIntNull("Valor")
                    };
                    lista.Add(model);
                };
                _banco.CloseReader();

                return lista;
            }
        }

        public Sequencia ObterPorid(int id)
        {
            using (_banco = new BancoFB())
            {
                var model = new Sequencia();
                _banco.RetornoReader("SELECT ID, SIGLA, DESCRICAO, VALOR FROM SEQUENCIA WHERE ID = " + id);
                if (_banco.Read())
                {
                    model.Id = _banco.CampoInt32("Id");
                    model.Descricao = _banco.CampoStr("Descricao");
                    model.Sigla = _banco.CampoStr("Sigla");
                    model.Valor = _banco.CampoIntNull("Valor");
                }
                _banco.CloseReader();
                return model;
            }
        }

        public void Excluir(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("DELETE FROM Sequencia where ID = " + id);
            }
        }

        public void Salvar(Sequencia model)
        {
            using (_banco = new BancoFB())
            {
                string Instrucao;
                if (model.Id == 0)
                {
                    model.Id = _banco.RetornarId("SEQ_SEQUENCIA");
                    Instrucao = string.Format("INSERT INTO SEQUENCIA(DESCRICAO, ID, SIGLA, VALOR) VALUES ('{0}', {1}, '{2}', {3}) returning ID",
                        model.Descricao, model.Id, model.Sigla, model.Valor);
                    model.Id = _banco.ExecutaScalar(Instrucao);
                }
                else
                {
                    Instrucao = string.Format("UPDATE SEQUENCIA SET DESCRICAO='{0}', SIGLA='{1}', VALOR='{2}' WHERE ID = {3}",
                        model.Descricao, model.Sigla, model.Valor, model.Id);
                    _banco.ExecutaComando(Instrucao);
                }
                
            }
        }

        public int IncrementarProximoNumero(string sigla, string descricao)
        {
            using (_banco = new BancoFB())
            {
                int valor = 0;
                _banco.RetornoReader("SELECT VALOR FROM SEQUENCIA WHERE SIGLA = '" + sigla + "'");
                if (_banco.Read())
                    valor = _banco.CampoInt32("VALOR");
                _banco.CloseReader();

                if (valor > 0)
                    _banco.ExecutaComando("UPDATE SEQUENCIA SET VALOR = VALOR + 1 WHERE SIGLA = '" + sigla + "'");
                else
                {
                    var model = new Sequencia();
                    model.Descricao = descricao;
                    model.Sigla = sigla;
                    Salvar(model);
                    valor = 1;
                }
                return valor;
            }
        }

        public int BuscarProximoCodigo(string sigla)
        {
            using (_banco = new BancoFB())
            {
                int valor = 0;
                _banco.RetornoReader("SELECT VALOR FROM SEQUENCIA WHERE SIGLA = '" + sigla + "'");
                if (_banco.Read())
                    valor = _banco.CampoInt32("VALOR") + 1;
                _banco.CloseReader();

                return valor;
            }
        }
    }
}
