using Carros.Cadastros;
using Carros.Comum;
using Carros.CrosPlataform;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Dominio.Interfaces.Servico;
using System.Linq;
using System.Windows.Forms;
using static Carros.Geral.Enumercador;

namespace Carros.Consultas
{
    public class CidadeConsulta
    {
        private readonly IUnitOfWorkOld _unitOfWork;

        public CidadeConsulta(IUnitOfWorkOld unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Cidade Pesquisar(int id, string descricao, TipoConsulta tipo)
        {
            Cidade model = new Cidade();

            if (tipo == TipoConsulta.Id)
                model = _unitOfWork.ServicoCidade.RetornarPorId(id);
            if (tipo == TipoConsulta.Descricao)
            {
                if (!string.IsNullOrWhiteSpace(descricao))
                {
                    var lista = _unitOfWork.ServicoCidade.ListarPorNome(descricao);

                    if (lista.Count() == 1)
                        model = lista.Single();
                    else
                    {
                        //var frm = CompositionRoot.ResolveWithArgument<frmCidade>(new Ninject.Parameters.ConstructorArgument("pesquisa", true));
                        var frm = new frmCidade(true, descricao);
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                            model = _unitOfWork.ServicoCidade.RetornarPorId(Funcoes.IdRetorno);
                    }
                }
            }

            if (tipo == TipoConsulta.Tela)
            {
                var frm = new frmCidade(true, "");
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    model = _unitOfWork.ServicoCidade.RetornarPorId(Funcoes.IdRetorno);
            }
            return model;
        }
    }
}
