using Carros.Dominio.Entidades;
using Carros.Infra.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Infra.Repositorio
{
    public class VeiculoRepositorioADO
    {
        private BancoFB _banco;

        public List<VeiculoConsulta> FiltrarDados(VeiculoFiltro filtro, int id = 0)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.AppendLine("SELECT V.ID, V.PLACA, V.MODELO, V.ANO, M.DESCRICAO FROM Veiculo V");
                sb.AppendLine(" INNER JOIN MARCA M ON V.ID_MARCA = M.ID");
                sb.AppendLine(" WHERE V.ID IS NOT NULL");

                if (filtro.Id > 0)
                    sb.AppendLine(" AND V.ID = " + filtro.Id);

                if (! string.IsNullOrWhiteSpace(filtro.DescMarca))
                    sb.AppendLine(" AND M.DESCRICAO containing('" + filtro.DescMarca + "')");

                if (!string.IsNullOrWhiteSpace(filtro.Ano))
                    sb.AppendLine(" AND V.ANO = '" + filtro.Ano + "'");

                if (!string.IsNullOrWhiteSpace(filtro.Modelo))
                    sb.AppendLine(" AND V.MODELO containing('" + filtro.Modelo + "')");

                if (!string.IsNullOrWhiteSpace(filtro.Placa))
                    sb.AppendLine(" AND V.PLACA containing('" + filtro.Placa + "')");

                if (id > 0)
                    sb.AppendLine(" AND V.ID = " + id);

                sb.AppendLine(" ORDER BY V.ID");
                _banco.RetornoReader(sb.ToString());

                List<VeiculoConsulta> lista = new List<VeiculoConsulta>();
                while (_banco.Read())
                {
                    var model = new VeiculoConsulta()
                    {
                        Id = _banco.CampoInt32("Id"),
                        Ano = _banco.CampoStr("Ano"),
                        Modelo = _banco.CampoStr("Modelo"),
                        Placa = _banco.CampoStr("Placa"),
                        DescricaoMarca = _banco.CampoStr("Descricao")
                    };
                    lista.Add(model);
                };
                _banco.CloseReader();

                return lista;
            }
        }

        public Veiculo ObterPorid(int id)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.AppendLine("SELECT V.ID, V.PLACA, V.MODELO, V.ANO, V.ID_MARCA, M.DESCRICAO FROM Veiculo V");
                sb.AppendLine(" INNER JOIN MARCA M ON V.ID_MARCA = M.ID");
                sb.AppendLine(" WHERE V.ID = " + id);
                _banco.RetornoReader(sb.ToString());

                var model = new Veiculo();

                _banco.RetornoReader(sb.ToString());
                if (_banco.Read())
                {
                    model.Id = _banco.CampoInt32("Id");
                    model.Ano = _banco.CampoStr("Ano");
                    model.Marca.Descricao = _banco.CampoStr("Descricao");
                    model.Modelo = _banco.CampoStr("Modelo");
                    model.Placa = _banco.CampoStr("Placa");
                    model.IdMarca = _banco.CampoInt32("Id_Marca");
                }
                _banco.CloseReader();
                return model;
            }
        }

        public Veiculo ObterPorPlaca(string placa)
        {
            int id = 0;
            using (_banco = new BancoFB())
            {
                
                var sb = new StringBuilder();
                sb.AppendLine("SELECT ID FROM Veiculo WHERE Placa= '" + placa + "'");
                _banco.RetornoReader(sb.ToString());
                if (_banco.Read())
                {
                    id = _banco.CampoInt32("ID");
                }
                _banco.CloseReader();
            }
            return ObterPorid(id);
        }

        public void Excluir(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("DELETE FROM Veiculo where ID = " + id);
            }
        }

        public void Salvar(Veiculo model)
        {
            using (_banco = new BancoFB())
            {
                string Instrucao;
                if (model.Id == 0)
                {
                    model.Id = _banco.RetornarId("SEQ_VEICULO");
                    Instrucao = string.Format("INSERT INTO VEICULO(ID, PLACA, MODELO, ID_MARCA, ANO) VALUES ({0}, '{1}', '{2}', {3}, '{4}')",
                        model.Id, model.Placa, model.Modelo, model.Marca.Id, model.Ano);
                }
                else
                {
                    Instrucao = string.Format("UPDATE VEICULO SET  PLACA='{0}', MODELO='{1}', ID_MARCA='{2}', ANO='{3}' WHERE ID = {4}",
                        model.Placa, model.Modelo, model.Marca.Id, model.Ano, model.Id);
                }

                _banco.ExecutaComando(Instrucao);
            }
        }
    }
}
