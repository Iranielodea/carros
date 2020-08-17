using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServiceMarca : ServiceBase<Marca>, IServiceMarca
    {
        private readonly IRepositoryMarca _repositorioMarca;

        public ServiceMarca(IRepositoryMarca repositorioMarca)
            :base(repositorioMarca)
        {
            _repositorioMarca = repositorioMarca;
        }

        public List<Marca> ListarPorNome(string nome, int id = 0)
        {
            if (id > 0)
                return _repositorioMarca.RetornarTodos().Where(x => x.Id == id).ToList();
            else
                return _repositorioMarca.RetornarTodos()
                    .Where(x => x.Descricao.Contains(nome)).OrderBy(x => x.Descricao).ToList();
        }

        public void Salvar(Marca model)
        {
            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe o Descrição!");

            if (model.Id == 0)
                _repositorioMarca.Adicionar(ref model);
            else
                _repositorioMarca.Alterar(model);
        }
    }
}
