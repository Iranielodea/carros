using Carros.Cadastros;
using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using System.Windows.Forms;
using static Carros.Geral.Enumercador;

namespace Carros.Consultas
{
    public class VeiculoConsulta
    {
        private readonly IUnitOfWork _unitOfWork;

        public VeiculoConsulta(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Veiculo Pesquisar(string placa, TipoConsulta tipo)
        {
            Veiculo model = new Veiculo();

            if (tipo == TipoConsulta.Tela)
            {
                var frm = new frmVeiculo(true, "");
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    model = _unitOfWork.ServicoVeiculo.RetornarPorId(Funcoes.IdRetorno);
            }
            else
                model = _unitOfWork.ServicoVeiculo.ObterPorPlaca(placa);

            if (model != null)
                model.Marca = _unitOfWork.ServicoMarca.RetornarPorId(model.IdMarca);
            return model;
        }
    }
}
