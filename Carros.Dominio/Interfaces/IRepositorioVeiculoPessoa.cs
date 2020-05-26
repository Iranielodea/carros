using Carros.Dominio.Entidades;
using System.Linq;

namespace Carros.Dominio.Interfaces
{
    public interface IRepositorioVeiculoPessoa : IRepositorioBase<VeiculoPessoa>
    {
        IQueryable<VeiculoPessoaConsulta> ListarPorPessoa(int idPessoa);
    }
}
