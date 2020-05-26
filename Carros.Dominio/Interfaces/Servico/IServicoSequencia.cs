using Carros.Dominio.Entidades;
using System.Collections.Generic;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServicoSequencia : IServicoBase<Sequencia>
    {
        List<Sequencia> ListarTudo(int id = 0);
        void Salvar(Sequencia sequencia);
        int IncrementarProximoNumero(string sigla, string descricao);
        int ProximaFichaSocioExpositor();
        int ProximaFichaExpositorVisitante();
        int ProximoSocioMaisUm();
        int ProximaVisitanteMaisUm();
    }
}
