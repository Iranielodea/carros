using Carros.Dominio.Entidades;
using Carros.Infra.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Infra.Repositorio
{
    public class FiliacaoRepositorioADO
    {
        private BancoFB _banco;

        public List<Filiacao> ListarPorPessoa(int idPessoa)
        {
            using (_banco = new BancoFB())
            {
                _banco.RetornoReader("SELECT ID, DATANASC, NOME FROM Filiacao where ID_PESSOA = " + idPessoa);
                List<Filiacao> lista = new List<Filiacao>();
                while (_banco.Read())
                {
                    var model = new Filiacao()
                    {
                        Id = _banco.CampoInt32("Id"),
                        Nome = _banco.CampoStr("Nome"),
                    };
                    lista.Add(model);
                };
                _banco.CloseReader();

                return lista;
            }
        }

        public Filiacao ObterPorid(int id)
        {
            using (_banco = new BancoFB())
            {
                var model = new Filiacao();
                _banco.RetornoReader("SELECT ID, NOME, DATANASC, ID_PESSOA FROM Filiacao where ID = " + id);
                if (_banco.Read())
                {
                    model.Id = _banco.CampoInt32("Id");
                    model.DataNascimento = _banco.CampoDataNull("DATANASC");
                    model.Nome = _banco.CampoStr("NOME");
                    model.Id = _banco.CampoInt32("Id_Pessoa");
                }
                _banco.CloseReader();
                return model;
            }
        }

        public void Excluir(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("DELETE FROM Filiacao where ID = " + id);
            }
        }

        public void Salvar(Filiacao model)
        {
            using (_banco = new BancoFB())
            {
                string Instrucao;
                if (model.Id == 0)
                {
                    model.Id = _banco.RetornarId("SEQ_FILIACAO");
                    Instrucao = string.Format("INSERT INTO FILIACAO(NOME, ID, DATANASC, ID_PESSOA) VALUES ('{0}', {1}, {2}, {3})",
                        model.Nome, model.Id, model.DataNascimento, model.Pessoa.Id);
                }
                else
                {
                    Instrucao = string.Format("UPDATE FILIACAO SET NOME='{0}', DATANASC='{1}', ID_PESSOA = {2}  WHERE ID = {3}",
                        model.Nome, model.DataNascimento, model.PessoaId, model.Id);
                }

                _banco.ExecutaComando(Instrucao);
            }
        }
    }
}
