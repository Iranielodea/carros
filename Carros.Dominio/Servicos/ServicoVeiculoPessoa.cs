using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Carros.Dominio.Servicos
{
    public class ServicoVeiculoPessoa : ServicoBase<VeiculoPessoa>, IServicoVeiculoPessoa
    {
        private readonly IRepositorioVeiculoPessoa _repositorioVeiculoPessoa;

        public ServicoVeiculoPessoa(IRepositorioVeiculoPessoa repositorioVeiculoPessoa)
            :base(repositorioVeiculoPessoa)
        {
            _repositorioVeiculoPessoa = repositorioVeiculoPessoa;
        }

        public void Excluir(int id)
        {
            if (id > 0)
                _repositorioVeiculoPessoa.Deletar(_repositorioVeiculoPessoa.RetornarPorId(id));
        }

        public List<VeiculoPessoaConsulta> ListarPorPessoa(int idPessoa)
        {
            return _repositorioVeiculoPessoa.ListarPorPessoa(idPessoa).ToList();
        }

        public void Salvar(VeiculoPessoa model)
        {
            if (model.IdPessoa == 0)
                throw new Exception("Informe o Cliente!");
            if (model.IdVeiculo == 0)
                throw new Exception("Informe o Veículo!");

            if (model.Id == 0)
                _repositorioVeiculoPessoa.Adicionar(ref model);
            else
                _repositorioVeiculoPessoa.Alterar(model);
        }
    }
}
