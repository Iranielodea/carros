using Carros.Dominio.Entidades;
using Carros.Infra.Banco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Infra.Repositorio
{
    public class VeiculoPessoaRepositorioADO
    {
        private BancoFB _banco;

        public List<VeiculoPessoaConsulta> ListarPorPessoa(int idPessoa)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();

                sb.AppendLine(" SELECT VP.id, V.placa, V.modelo, V.ano, M.Descricao FROM VEICULO_PESSOA VP");
                sb.AppendLine(" INNER JOIN VEICULO V ON VP.id_veiculo = V.id");
                sb.AppendLine(" INNER JOIN MARCA M ON V.id_marca = M.id");
                sb.AppendLine(" WHERE VP.ID_PESSOA = " + idPessoa);
                _banco.RetornoReader(sb.ToString());
                var lista = new List<VeiculoPessoaConsulta>();
                while (_banco.Read())
                {
                    var model = new VeiculoPessoaConsulta()
                    {
                        Ano = _banco.CampoInt32("Ano"),
                        Id = _banco.CampoInt32("Id"),
                        Marca = _banco.CampoStr("Descricao"),
                        Modelo = _banco.CampoStr("Modelo"),
                        Placa = _banco.CampoStr("Placa")
                    };
                    lista.Add(model);
                }
                _banco.CloseReader();
                return lista;
            }
        }

        public VeiculoPessoa ObterPorId(int id)
        {
            using (_banco = new BancoFB())
            {
                var sb = new StringBuilder();
                sb.AppendLine(" SELECT VP.id, VP.ID_PESSOA, VP.ID_VEICULO, V.Placa, V.Id_Marca, M.Descricao, V.Modelo, V.Ano FROM VEICULO_PESSOA VP");
                sb.AppendLine(" INNER JOIN VEICULO V ON VP.id_veiculo = V.id");
                sb.AppendLine(" INNER JOIN MARCA M ON V.id_marca = M.id");
                sb.AppendLine(" WHERE VP.ID = " + id);
                _banco.RetornoReader(sb.ToString());

                var model = new VeiculoPessoa();
                if (_banco.Read())
                {
                    model.Id = _banco.CampoInt32("Id");
                    model.Pessoa.Id = _banco.CampoInt32("Id_pessoa");
                    model.Veiculo.Id = _banco.CampoInt32("id_veiculo");
                    model.Veiculo.Placa = _banco.CampoStr("Placa");
                    model.Veiculo.IdMarca = _banco.CampoInt32("Id_Marca");
                    model.Veiculo.Marca.Descricao = _banco.CampoStr("Descricao");
                    model.Veiculo.Modelo = _banco.CampoStr("Modelo");
                    model.Veiculo.Ano = _banco.CampoStr("Ano");
                }
                _banco.CloseReader();
                return model;
            }
        }

        public void Salvar(VeiculoPessoa model)
        {
            using (_banco = new BancoFB())
            {
                string Instrucao;
                if (model.Id == 0)
                {
                    model.Id = _banco.RetornarId("SEQ_VEICULO_PESSOA");
                    Instrucao = string.Format("INSERT INTO VEICULO_PESSOA(ID, ID_PESSOA, ID_VEICULO) VALUES ('{0}', {1}, {2})",
                        model.Id, model.Pessoa.Id, model.Veiculo.Id);
                }
                else
                {
                    Instrucao = string.Format("UPDATE VEICULO_PESSOA SET ID_PESSOA={0}, ID_VEICULO={1} WHERE ID = {2}",
                        model.Pessoa.Id, model.Veiculo.Id, model.Id);
                }

                _banco.ExecutaComando(Instrucao);
            }
        }

        public void Excluir(int id)
        {
            using (_banco = new BancoFB())
            {
                _banco.ExecutaComando("DELETE FROM VEICULO_PESSOA WHERE ID = " + id);
            }
        }
    }
}
