using Carros.Dominio.Entidades;
using System.Linq;

namespace Carros.Dominio.Interfaces
{
    public interface IRepositoryVeiculoPessoa : IRepositoryBase<VeiculoPessoa>
    {
        IQueryable<VeiculoPessoaConsulta> ListarPorPessoa(int idPessoa);
    }
}
