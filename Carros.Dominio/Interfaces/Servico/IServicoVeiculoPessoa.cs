using Carros.Dominio.Entidades;
using System.Collections.Generic;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServicoVeiculoPessoa : IServicoBase<VeiculoPessoa>
    {
        void Salvar(VeiculoPessoa veiculoPessoa);
        List<VeiculoPessoaConsulta> ListarPorPessoa(int idPessoa);
        void Excluir(int id);
    }
}
