using Carros.Dominio.Entidades;
using System.Collections.Generic;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServicoTabControle : IServicoBase<TabControle>
    {
        void Salvar(TabControle tabControle);
        List<TabControle> ListarTudo(int id = 0);
        TabControle ObterPorSigla(string sigla);
        string AtualizarVersao();
    }
}
