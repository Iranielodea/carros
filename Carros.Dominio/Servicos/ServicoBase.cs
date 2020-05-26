using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServicoBase<T> : IDisposable, IServicoBase<T> where T : class
    {
        private readonly IRepositorioBase<T> _repositorio;

        public ServicoBase(IRepositorioBase<T> repositorioBase)
        {
            _repositorio = repositorioBase;
        }

        public void Adicionar(ref T entidade)
        {
            _repositorio.Adicionar(ref entidade);
        }

        public void Alterar(T entidade)
        {
            _repositorio.Alterar(entidade);
        }

        public void Deletar(T entidade)
        {
            _repositorio.Deletar(entidade);
        }

        public void Dispose()
        {
            _repositorio.Dispose();
        }

        public T RetornarPorId(int id)
        {
            return _repositorio.RetornarPorId(id);
        }

        public IQueryable<T> RetornarTodos()
        {
            return _repositorio.RetornarTodos();
        }
    }
}
