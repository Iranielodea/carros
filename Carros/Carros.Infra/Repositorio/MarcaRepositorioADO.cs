using Carros.Dominio.Entidades;
using Carros.Infra.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Infra.Repositorio
{
    public class MarcaRepositorioADO
    {
        private BancoFB _banco;

        public List<Marca> ListarPorNome(string nome, int Id = 0)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.AppendLine("SELECT ID, DESCRICAO FROM Marca");

                if (Id > 0)
                    sb.AppendLine(" WHERE ID = " + Id);
                else
                    sb.AppendLine(" where DESCRICAO containing('" + nome + "') ORDER BY DESCRICAO");

                _banco.RetornoReader(sb.ToString());
                List<Marca> lista = new List<Marca>();
                while (_banco.Read())
                {
                    var model = new Marca()
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

        public Marca ObterPorid(int id)
        {
            using (_banco = new BancoFB())
            {
                var model = new Marca();
                _banco.RetornoReader("SELECT ID, DESCRICAO FROM Marca where ID = " + id);
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
                _banco.ExecutaComando("DELETE FROM Marca where ID = " + id);
            }
        }

        public void Salvar(Marca model)
        {
            using (_banco = new BancoFB())
            {
                string Instrucao;
                if (model.Id == 0)
                {
                    model.Id = _banco.RetornarId("SEQ_MARCA");
                    Instrucao = string.Format("INSERT INTO MARCA(ID, DESCRICAO) VALUES ({0}, '{1}') returning id",
                       model.Id, model.Descricao);
                    model.Id = _banco.ExecutaScalar(Instrucao);

                }
                else
                {
                    Instrucao = string.Format("UPDATE MARCA SET DESCRICAO='{0}' WHERE ID = {1}",
                        model.Descricao, model.Id);
                    _banco.ExecutaComando(Instrucao);
                }
            }
        }
    }
}
