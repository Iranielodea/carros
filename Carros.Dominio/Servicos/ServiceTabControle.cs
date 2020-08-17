using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Carros.Dominio.Servicos
{
    public class ServiceTabControle : ServiceBase<TabControle>, IServiceTabControle
    {
        private readonly IRepositoryTabControle _repositorioTabControle;

        public ServiceTabControle(IRepositoryTabControle repositorioTabControle)
            :base(repositorioTabControle)
        {
            _repositorioTabControle = repositorioTabControle;
        }

        public void ExecutarComando(string instrucaoSQL)
        {
            if (!string.IsNullOrEmpty(instrucaoSQL))
                _repositorioTabControle.ExecutarComando(instrucaoSQL);
        }

        public List<TabControle> ListarTudo(int id = 0)
        {
            if (id == 0)
                return _repositorioTabControle.RetornarTodos().OrderBy(x => x.Id).ToList();
            else
                return _repositorioTabControle.RetornarTodos().Where(x => x.Id == id).ToList();
        }

        public TabControle ObterPorSigla(string sigla)
        {
            return _repositorioTabControle.RetornarTodos().FirstOrDefault(x => x.Sigla == sigla);
        }

        public void Salvar(TabControle model)
        {
            if (string.IsNullOrWhiteSpace(model.Descricao))
                throw new Exception("Informe a Descrição!");

            if (string.IsNullOrWhiteSpace(model.Sigla))
                throw new Exception("Informe a Sigla!");

            if (model.Id == 0)
                _repositorioTabControle.Adicionar(ref model);
            else
                _repositorioTabControle.Alterar(model);
        }

        public string AtualizarVersao()
        {
            int versaoSistema = 0;
            var model = ObterPorSigla("VERSAO");

            if (model != null)
                versaoSistema = model.ValorInt.Value;

            string linha;
            string versao = "";
            string slinha = "";

            StreamReader arq = new StreamReader(@"Versao.sql");
            try
            {
                var sb = new StringBuilder();
                while ((linha = arq.ReadLine()) != null)
                {
                    if (linha.Trim() == "")
                        continue;

                    if (linha.Contains("VERSAO"))
                    {
                        slinha = linha.Substring(0, 8);
                        if (slinha == "--VERSAO")
                        {
                            versao = linha.Substring(10, 5);
                            continue;
                        }
                    }

                    if (linha.Trim() == "GO")
                    {
                        if (int.Parse(versao) > versaoSistema)
                            ExecutarComando(sb.ToString());
                        sb.Clear();
                    }
                    else
                        sb.AppendLine(linha);
                }

                if (versao != "")
                {
                    if (Convert.ToInt32(versao) > 1 && int.Parse(versao) > versaoSistema)
                    {
                        model = ObterPorSigla("VERSAO");
                        if (model != null)
                        {
                            model.ValorInt = Convert.ToInt32(versao);
                            _repositorioTabControle.Alterar(model);
                        }
                        versao = "." + versao;
                    }
                }

                return versao;
            }
            finally
            {
                arq.Close();
            }
        }
    }
}
