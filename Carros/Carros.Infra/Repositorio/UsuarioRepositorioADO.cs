using Carros.Dominio.Entidades;
using Carros.Infra.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Infra.Repositorio
{
    public class UsuarioRepositorioADO
    {
        private BancoFB _banco;

        public List<Usuario> ListarPorNome(string nome, int id = 0)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.AppendLine("SELECT ID, NOME FROM Usuario");
                if (id > 0)
                    sb.AppendLine(" WHERE ID = " + id);
                else
                    sb.AppendLine(" WHERE NOME containing('" + nome + "') ORDER BY NOME");

                _banco.RetornoReader(sb.ToString());
                List<Usuario> lista = new List<Usuario>();
                while (_banco.Read())
                {
                    var model = new Usuario()
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

        public Usuario ObterPorid(int id)
        {
            using (_banco = new BancoFB())
            {
                var model = new Usuario();
                _banco.RetornoReader("SELECT ID, NOME, SENHA FROM Usuario where ID = " + id);
                if (_banco.Read())
                {
                    model.Id = _banco.CampoInt32("Id");
                    model.Nome = _banco.CampoStr("Nome");
                    model.Senha = _banco.CampoStr("Senha");
                }
                _banco.CloseReader();
                return model;
            }
        }

        public bool UsuarioJaCadastrado(Usuario model)
        {
            using (_banco = new BancoFB())
            {
                int id = 0;
                _banco.RetornoReader("SELECT ID FROM Usuario where NOME = '" + model.Nome + "' AND ID <> " + model.Id);
                if (_banco.Read())
                    id = _banco.CampoInt32("Id");
                _banco.CloseReader();
                return (id > 0);
            }
        }

        public Usuario ObterPorUsuario(string usuario, string senha)
        {
            using (_banco = new BancoFB())
            {
                int id = 0;
                _banco.RetornoReader("SELECT ID FROM Usuario where NOME = '" + usuario + "'");
                if (_banco.Read())
                    id = _banco.CampoInt32("Id");
                _banco.CloseReader();

                return ObterPorid(id);
            }
        }

        public void Excluir(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("DELETE FROM Usuario where ID = " + id);
            }
        }

        public void Salvar(Usuario model)
        {
            using (_banco = new BancoFB())
            {
                string Instrucao;
                if (model.Id == 0)
                {
                    model.Id = _banco.RetornarId("SEQ_USUARIO");
                    Instrucao = string.Format("INSERT INTO USUARIO(NOME, SENHA, ID) VALUES ('{0}', '{1}', {2}) returning ID",
                        model.Nome, model.Senha, model.Id);
                    model.Id = _banco.ExecutaScalar(Instrucao);
                }
                else
                {
                    Instrucao = string.Format("UPDATE USUARIO SET NOME='{0}', SENHA='{1}' WHERE ID = {2}",
                        model.Nome, model.Senha, model.Id);
                    _banco.ExecutaComando(Instrucao);
                }
            }
        }
    }
}
