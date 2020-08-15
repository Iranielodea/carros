using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServiceBase<T> : IDisposable, IServiceBase<T> where T : class
    {
        private readonly IRepositoryBase<T> _repositorio;

        public ServiceBase(IRepositoryBase<T> repositorioBase)
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
