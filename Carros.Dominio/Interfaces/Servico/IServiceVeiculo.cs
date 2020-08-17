using Carros.Dominio.Entidades;
using System.Collections.Generic;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServiceVeiculo : IServiceBase<Veiculo>
    {
        void Salvar(Veiculo profissao);
        IEnumerable<VeiculoConsulta> Filtrar(VeiculoFiltro filtro, int id = 0);
        Veiculo ObterPorPlaca(string placa);
        void Excluir(int id);
    }
}
