using Carros.Dominio.Entidades;
using System.Collections.Generic;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServiceVeiculoPessoa : IServiceBase<VeiculoPessoa>
    {
        void Salvar(VeiculoPessoa veiculoPessoa);
        List<VeiculoPessoaConsulta> ListarPorPessoa(int idPessoa);
        void Excluir(int id);
    }
}
