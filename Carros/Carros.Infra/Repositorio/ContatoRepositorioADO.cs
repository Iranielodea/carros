using Carros.Dominio.Entidades;
using Carros.Infra.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Infra.Repositorio
{
    public class ContatoRepositorioADO
    {
        private BancoFB _banco;

        public Contato ObterPorId(int id)
        {
            using (_banco = new BancoFB())
            {
                var contato = new Contato();
                _banco.RetornoReader("SELECT id, pessoa_id,telefone,celular,email,obs FROM Contato where ID = " + id);
                if (_banco.Read())
                {
                    contato.Id = _banco.CampoInt32("Id");
                    contato.Telefone = _banco.CampoStr("Telefone");
                    contato.Celular = _banco.CampoStr("celular");
                    contato.Email = _banco.CampoStr("Email");
                    contato.Observacao = _banco.CampoStr("Obs");
                    contato.Pessoa.Id = _banco.CampoInt32("pessoa_id");
                }
                _banco.CloseReader();
                return contato;
            }
        }

        public List<Contato> ObterPorPessoa(int idPessoa)
        {
            var lista = new List<Contato>();
            using (_banco = new BancoFB())
            {
                _banco.RetornoReader("SELECT id, telefone,celular,email FROM Contato where pessoa_id = " + idPessoa);
                while (_banco.Read())
                {
                    var contato = new Contato();
                    contato.Id = _banco.CampoInt32("Id");
                    contato.Telefone = _banco.CampoStr("Telefone");
                    contato.Email = _banco.CampoStr("Email");
                    contato.Celular = _banco.CampoStr("Celular");
                    lista.Add(contato);
                }
                return lista;
            }
        }

        public void Excluir(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("DELETE FROM Contato where ID = " + id);
            }
        }

        public void Salvar(Contato contato)
        {
            using (_banco = new BancoFB())
            {
                string Instrucao;
                if (contato.Id == 0)
                {
                    contato.Id = _banco.RetornarId("SEQ_CONTATO");
                    Instrucao = string.Format("INSERT INTO CONTATO(ID, pessoa_id, telefone,celular,email,obs) VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}') returning id",
                       contato.Id, contato.Pessoa.Id, contato.Telefone, contato.Celular, contato.Email, contato.Observacao);
                    contato.Id = _banco.ExecutaScalar(Instrucao);

                }
                else
                {
                    Instrucao = string.Format("UPDATE CONTATO SET pessoa_id={0}, telefone = '{1}', celular = '{2}', email = '{3}', obs = '{4}' WHERE ID = " + contato.Id,
                        contato.Pessoa.Id, contato.Telefone, contato.Celular, contato.Email, contato.Observacao);
                    _banco.ExecutaComando(Instrucao);
                }
            }

        }
    }
}
