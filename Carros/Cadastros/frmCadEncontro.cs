using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using StructureMap;
using System;
using System.Windows.Forms;

namespace Carros.Cadastros
{
    public partial class frmCadEncontro : Carros.Base.frmConsultaBase
    {
        private CadEncontro _model;
        private IUnitOfWork _unitOfWork;

        public frmCadEncontro()
        {
            Iniciar();
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            _unitOfWork = ObjectFactory.GetInstance<IUnitOfWork>();

            Geral.Grade.Config(dgvDados);

            _model = new CadEncontro();
            CarregarConsulta();
        }

        private void CarregarConsulta(int id = 0)
        {
            dgvDados.DataSource = _unitOfWork.ServicoCadEncontro.ListarPorNome(txtTexto.Text, id);
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CarregarConsulta(0);
                dgvDados.Focus();
            }
        }

        private void VincularDados()
        {
            txtCodigo.DataBindings.Clear();
            txtDescricao.DataBindings.Clear();
            txtNumEncontro.DataBindings.Clear();
            txtEventoAtual.DataBindings.Clear();

            txtCodigo.DataBindings.Add("Text", _model, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDescricao.DataBindings.Add("Text", _model, "Descricao", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNumEncontro.DataBindings.Add("Text", _model, "NumeroEncontro", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEventoAtual.DataBindings.Add("Text", _model, "EventoAtual", true, DataSourceUpdateMode.OnPropertyChanged);
            chkEventoAtual.Checked = (_model.EventoAtual == "S");
        }

        public override void Editar()
        {
            if (dgvDados.RowCount == 0)
                return;

            _model = _unitOfWork.ServicoCadEncontro.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
            base.Editar();

            VincularDados();
            txtDescricao.Focus();
        }

        public override void Salvar()
        {
            _model.EventoAtual = chkEventoAtual.Checked ? "S" : "N";
            try
            {
                _unitOfWork.ServicoCadEncontro.Salvar(_model);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            base.Salvar();
            CarregarConsulta(_model.Id);
            txtTexto.Focus();
        }

        public override void Novo()
        {
            base.Novo();
            _model = new CadEncontro();
            VincularDados();
            chkEventoAtual.Checked = false;
            txtDescricao.Focus();
        }

        public override void Excluir()
        {
            if (dgvDados.RowCount == 0)
                return;

            base.Excluir();

            if (Funcoes.Confirmar("Deseja Excluir?"))
            {
                _unitOfWork.ServicoCadEncontro.Deletar(_unitOfWork.ServicoCadEncontro.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString())));
                CarregarConsulta(0);
                txtTexto.Focus();
            }
        }

        public override void Filtrar()
        {
            base.Filtrar();
            CarregarConsulta(0);
            txtTexto.Focus();
        }

        private void frmCadEncontro_FormClosed(object sender, FormClosedEventArgs e)
        {
            _unitOfWork.Dispose();
        }
    }
}
