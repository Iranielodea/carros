using Carros.Dominio.Entidades;
using System.Collections.Generic;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServicoCidade : IServicoBase<Cidade>
    {
        void Salvar(Cidade profissao);
        List<Cidade> ListarPorNome(string nome, int id = 0);
    }
}
