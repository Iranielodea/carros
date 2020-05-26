using Carros.Dominio.Entidades;
using Carros.Infra.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Infra.Repositorio
{
    public class ProfissaoRepositorioADO 
    {
        private BancoFB _banco;

        public List<Profissao> ListarPorNome(string nome, int id)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.AppendLine("SELECT ID, DESCRICAO FROM Profissao");
                if (id > 0)
                    sb.AppendLine(" WHERE ID = " + id);
                else
                    sb.AppendLine(" where DESCRICAO containing('" + nome + "') ORDER BY DESCRICAO");
                _banco.RetornoReader(sb.ToString());
                List<Profissao> lista = new List<Profissao>();
                while (_banco.Read())
                {
                    var model = new Profissao()
                    {
                        Id = _banco.CampoInt32("Id"),
                        Descricao = _banco.CampoStr("Descricao"),
                    };
                    lista.Add(model);
                };
                _banco.CloseReader();

                return lista;
            }
        }

        public Profissao ObterPorid(int id)
        {
            using (_banco = new BancoFB())
            {
                var model = new Profissao();
                _banco.RetornoReader("SELECT ID, DESCRICAO FROM Profissao where ID = " + id);
                if (_banco.Read())
                {
                    model.Id = _banco.CampoInt32("Id");
                    model.Descricao = _banco.CampoStr("Descricao");
                }
                _banco.CloseReader();
                return model;
            }
        }

        public void Excluir(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("DELETE FROM Profissao where ID = " + id);
            }
        }

        public void Salvar(Profissao model)
        {
            using (_banco = new BancoFB())
            {
                string Instrucao;
                if (model.Id == 0)
                {
                    model.Id = _banco.RetornarId("SEQ_PROFISSAO");
                    Instrucao = string.Format("INSERT INTO PROFISSAO(DESCRICAO, ID) VALUES ('{0}', {1}) returning id",
                        model.Descricao, model.Id);
                    model.Id = _banco.ExecutaScalar(Instrucao);
                }
                else
                {
                    Instrucao = string.Format("UPDATE PROFISSAO SET DESCRICAO='{0}' WHERE ID = {1}",
                        model.Descricao, model.Id);
                    _banco.ExecutaComando(Instrucao);
                }
            }
        }
    }
}
