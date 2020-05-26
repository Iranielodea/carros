using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Carros.Geral.Enumercador;
using System.Windows.Forms;
using Carros.Cadastros;
using Carros.Dominio.Interfaces;

namespace Carros.Consultas
{
    public class PessoaConsulta
    {
        private readonly IUnitOfWork _unitOfWork;
        public PessoaConsulta(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Pessoa Pesquisar(int id, string descricao, TipoConsulta tipo, EnTipoExpositor tipoExpositor)
        {
            Pessoa model = new Pessoa();

            if (tipo == TipoConsulta.Id)
            {
                model = _unitOfWork.ServicoPessoa.RetornarPorId(id);
            }
            if (tipo == TipoConsulta.Descricao)
            {
                if (!string.IsNullOrWhiteSpace(descricao))
                {
                    var lista = _unitOfWork.ServicoPessoa.ListarPorNome(descricao);

                    if (lista.Count == 1)
                        model = _unitOfWork.ServicoPessoa.RetornarPorId(lista.Single().Id);
                    else
                    {
                        var frm = new frmVisitante(tipoExpositor, true, descricao);
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                            model = _unitOfWork.ServicoPessoa.RetornarPorId(Funcoes.IdRetorno);
                    }
                }
            }

            if (tipo == TipoConsulta.Tela)
            {
                var frm = new frmVisitante(tipoExpositor, true, "");
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    model = _unitOfWork.ServicoPessoa.RetornarPorId(Funcoes.IdRetorno);
            }
            return model;
        }
    }
}
