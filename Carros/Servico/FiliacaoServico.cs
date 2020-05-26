using Carros.Dominio.Entidades;
using Carros.Infra.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carros.Servico
{
    public class FiliacaoServico
    {
        private readonly FiliacaoRepositorioADO _rep;

        public FiliacaoServico()
        {
            _rep = new FiliacaoRepositorioADO();
        }

        public List<Filiacao> ListarPorPessoa(int id)
        {
            return _rep.ListarPorPessoa(id);
        }

        public Filiacao ObterPorId(int id)
        {
            return _rep.ObterPorid(id);
        }

        public void Salvar(Filiacao model)
        {
            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new Exception("Informe o Descrição!");

            _rep.Salvar(model);
        }

        public void Excluir(int id)
        {
            _rep.Excluir(id);
        }
    }
}
