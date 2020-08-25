using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServiceVeiculo : ServiceBase<Veiculo>, IServiceVeiculo
    {
        private readonly IRepositoryVeiculo _repositorioVeiculo;

        public ServiceVeiculo(IRepositoryVeiculo repositorioVeiculo)
            : base(repositorioVeiculo)
        {
            _repositorioVeiculo = repositorioVeiculo;
        }

        public void Excluir(int id)
        {
            _repositorioVeiculo.Deletar(_repositorioVeiculo.RetornarPorId(id));
        }

        public IEnumerable<VeiculoConsulta> Filtrar(VeiculoFiltro filtro, int id = 0)
        {
            var resultado = _repositorioVeiculo.RetornarConsulta();

            if (id > 0)
                resultado = resultado.Where(x => x.Id == id);
            else
            {
                if (!string.IsNullOrWhiteSpace(filtro.DescMarca))
                    resultado = resultado.Where(x => x.DescricaoMarca.Contains(filtro.DescMarca.ToUpper()));
                if (!string.IsNullOrWhiteSpace(filtro.Ano))
                    resultado = resultado.Where(x => x.Ano == filtro.Ano);
                if (!string.IsNullOrWhiteSpace(filtro.Modelo))
                    resultado = resultado.Where(x => x.Modelo.Contains(filtro.Modelo.ToUpper()));
                if (!string.IsNullOrWhiteSpace(filtro.Placa))
                    resultado = resultado.Where(x => x.Placa.Contains(filtro.Placa.ToUpper()));
                if (filtro.Id > 0)
                    resultado = resultado.Where(x => x.Id == filtro.Id);

                resultado = resultado.OrderBy(x => x.Id);
            }
            return resultado.ToList();
        }

        public Veiculo ObterPorPlaca(string placa)
        {
            return _repositorioVeiculo.RetornarTodos().FirstOrDefault(x => x.Placa == placa.ToUpper());
        }

        public void Salvar(Veiculo model)
        {
            if (string.IsNullOrWhiteSpace(model.Modelo))
                throw new Exception("Informe o Modelo!");

            if (string.IsNullOrWhiteSpace(model.Marca.Descricao))
                throw new Exception("Informe a Marca!");

            if (string.IsNullOrWhiteSpace(model.Ano))
                throw new Exception("Informe o Ano!");

            if (model.Id == 0)
                _repositorioVeiculo.Adicionar(ref model);
            else
                _repositorioVeiculo.Alterar(model);
        }
    }
}
