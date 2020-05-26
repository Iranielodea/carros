using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carros.Dominio.Entidades;
using Carros.Infra.Banco;

namespace Carros.Infra.Repositorio
{
    public class CadEncontroRepositorioADO
    {
        private BancoFB _banco;

        public CadEncontro ObterPorId(int id)
        {
            using(_banco = new BancoFB())
            {
                var model = new CadEncontro();
                _banco.RetornoReader("SELECT ID, NUM_ENCONTRO, DESCRICAO, EVENTO_ATUAL FROM Cad_Encontro where ID = " + id);
                if (_banco.Read())
                {
                    model.Id = _banco.CampoInt32("Id");
                    model.NumeroEncontro = _banco.CampoInt32("NUM_ENCONTRO");
                    model.EventoAtual = _banco.CampoStr("EVENTO_ATUAL");
                    model.Descricao = _banco.CampoStr("DESCRICAO");
                }
                _banco.CloseReader();
                return model;
            }
        }

        public CadEncontro ObterNumeroEncontroAtual()
        {
            int id = 0;
            using (_banco = new BancoFB())
            {
                var model = new CadEncontro();
                _banco.RetornoReader("select ID from CAD_ENCONTRO where EVENTO_ATUAL = 'S'");
                if (_banco.Read())
                {
                    id = _banco.CampoInt32("ID");
                }
                _banco.CloseReader();
            }

            return ObterPorId(id);
        }

        public List<CadEncontro> ListarPorNome(string nome, int id)
        {
            using(_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.Append("SELECT ID, NUM_ENCONTRO, DESCRICAO FROM Cad_Encontro");

                if (id > 0)
                    sb.Append(" WHERE ID = " + id);
                else
                    sb.Append(" where DESCRICAO containing('" + nome + "') ORDER BY Id");
                
                _banco.RetornoReader(sb.ToString());
                List<CadEncontro> lista = new List<CadEncontro>();
                while (_banco.Read())
                {
                    var model = new CadEncontro()
                    {
                        Id = _banco.CampoInt32("Id"),
                        NumeroEncontro = _banco.CampoInt32("Num_Encontro"),
                        Descricao = _banco.CampoStr("Descricao"),
                    };
                    lista.Add(model);
                };
                _banco.CloseReader();

                return lista;
            }
        }

        private void EventoAtual(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("UPDATE Cad_Encontro SET EVENTO_ATUAL = 'N' WHERE ID <> " + id +" AND EVENTO_ATUAL = 'S'");
            }
        }

        public void Salvar(CadEncontro model)
        {
            using (_banco = new BancoFB())
            {
                string Instrucao;
                if (model.Id == 0)
                {
                    model.Id = _banco.RetornarId("SEQ_CAD_ENCONTRO");
                    Instrucao = string.Format("INSERT INTO Cad_Encontro(ID, NUM_ENCONTRO, DESCRICAO, EVENTO_ATUAL) VALUES ({0}, {1}, '{2}', '{3}' ) returning ID",
                        model.Id, model.NumeroEncontro, model.Descricao, model.EventoAtual);
                    model.Id = _banco.ExecutaScalar(Instrucao);
                }
                else
                {
                    Instrucao = string.Format("UPDATE Cad_Encontro SET NUM_ENCONTRO={0}, DESCRICAO='{1}', EVENTO_ATUAL='{2}' WHERE ID = {3}",
                        model.NumeroEncontro, model.Descricao, model.EventoAtual, model.Id);
                    _banco.ExecutaComando(Instrucao);
                }

                if (model.EventoAtual == "S")
                    EventoAtual(model.Id);
            }
        }

        public void Excluir(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("DELETE FROM Cad_Encontro where ID = " + id);
            }
        }
    }
}
