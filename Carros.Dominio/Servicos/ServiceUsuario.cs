using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServiceUsuario : ServiceBase<Usuario>, IServiceUsuario
    {
        private readonly IRepositoryUsuario _repositorioUsuario;

        public ServiceUsuario(IRepositoryUsuario repositorioUsuario)
            : base(repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public void Excluir(int id)
        {
            _repositorioUsuario.Deletar(_repositorioUsuario.RetornarPorId(id));
        }

        public List<Usuario> ListarPorNome(string nome, int id = 0)
        {
            if (id > 0)
                return _repositorioUsuario.RetornarTodos().Where(x => x.Id == id).ToList();
            else
                return _repositorioUsuario.RetornarTodos()
                    .Where(x => x.Nome.Contains(nome)).OrderBy(x => x.Nome).ToList();
        }

        public void ObterPorUsuario(string usuario, string senha)
        {
            var model = _repositorioUsuario.RetornarTodos().FirstOrDefault(x => x.Nome == usuario);
            if (model == null || model.Id == 0)
                throw new Exception("Usuário não Cadastrado!");

            if (model.Senha != senha)
                throw new Exception("Senha Inválida!");
        }

        public void Salvar(Usuario model)
        {
            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Nome!");

            if (model.Id == 0)
                _repositorioUsuario.Adicionar(ref model);
            else
                _repositorioUsuario.Alterar(model);
        }

        public void UsuarioJaCadastrado(Usuario model)
        {
            if (_repositorioUsuario.RetornarTodos().Where(x => x.Nome == model.Nome && x.Id != model.Id).Any())
                throw new Exception("Usuário já Cadastrado!");
        }
    }
}
