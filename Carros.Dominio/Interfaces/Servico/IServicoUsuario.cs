using Carros.Dominio.Entidades;
using System.Collections.Generic;

namespace Carros.Dominio.Interfaces.Servico
{
    public interface IServicoUsuario : IServicoBase<Usuario>
    {
        void Salvar(Usuario profissao);
        List<Usuario> ListarPorNome(string nome, int id = 0);
        void ObterPorUsuario(string usuario, string senha);
        void UsuarioJaCadastrado(Usuario model);
        void Excluir(int id);

    }
}
