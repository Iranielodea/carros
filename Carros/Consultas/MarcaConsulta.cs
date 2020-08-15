using Carros.Cadastros;
using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using System.Linq;
using System.Windows.Forms;
using static Carros.Geral.Enumercador;

namespace Carros.Consultas
{
    public class MarcaConsulta
    {
        private readonly IUnitOfWorkOld _unitOfWork;

        public MarcaConsulta(IUnitOfWorkOld unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Marca Pesquisar(int id, string descricao, TipoConsulta tipo)
        {
            Marca model = new Marca();

            if (tipo == TipoConsulta.Id)
            {
                model = _unitOfWork.ServicoMarca.RetornarPorId(id);
            }

            if (tipo == TipoConsulta.Descricao)
            {
                if (!string.IsNullOrWhiteSpace(descricao))
                {
                    var lista = _unitOfWork.ServicoMarca.ListarPorNome(descricao);

                    if (lista.Count == 1)
                        model = lista.Single();
                    else
                    {
                        var frm = new frmMarca(true, descricao);
                        frm.ShowDialog();
                        if (frm.DialogResult == DialogResult.OK)
                            model = _unitOfWork.ServicoMarca.RetornarPorId(Funcoes.IdRetorno);
                    }
                }
            }

            if (tipo == TipoConsulta.Tela)
            {
                var frm = new frmMarca(true, "");
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    model = _unitOfWork.ServicoMarca.RetornarPorId(Funcoes.IdRetorno);
            }
            return model;
        }
    }
}
