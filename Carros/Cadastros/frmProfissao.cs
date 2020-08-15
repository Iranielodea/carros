using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using StructureMap;
using System;
using System.Windows.Forms;

namespace Carros.Cadastros
{
    public partial class frmProfissao : Carros.Base.frmConsultaBase
    {
        private Profissao _model;
        private IUnitOfWorkOld _unitOfWork;

        public frmProfissao()
        {
            Iniciar();
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            _unitOfWork = ObjectFactory.GetInstance<IUnitOfWorkOld>();

            Geral.Grade.Config(dgvDados);

            _model = new Profissao();
            CarregarConsulta();
        }

        public frmProfissao(bool Pesquisar = false, string texto = "")
        {
            btnPesquisar.Visible = Pesquisar;
            txtTexto.Text = texto;
            Iniciar();
        }

        private void CarregarConsulta(int id = 0)
        {
            dgvDados.DataSource = _unitOfWork.ServicoProfissao.ListarPorNome(txtTexto.Text, id);
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

            txtCodigo.DataBindings.Add("Text", _model, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDescricao.DataBindings.Add("Text", _model, "Descricao", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override void Editar()
        {
            if (dgvDados.RowCount == 0)
                return;

            _model = _unitOfWork.ServicoProfissao.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));

            base.Editar();

            VincularDados();
            txtDescricao.Focus();
        }

        public override void Salvar()
        {
            _unitOfWork.ServicoProfissao.Salvar(_model);

            base.Salvar();
            CarregarConsulta(_model.Id);
            txtTexto.Focus();
        }

        public override void Novo()
        {
            base.Novo();
            _model = new Profissao();
            VincularDados();
            txtDescricao.Focus();
        }

        public override void Excluir()
        {
            if (dgvDados.RowCount == 0)
                return;

            base.Excluir();

            if (Funcoes.Confirmar("Deseja Excluir?"))
            {
                _unitOfWork.ServicoProfissao.Excluir(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));

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

        public override void Pesquisar()
        {
            base.Pesquisar();

            if (dgvDados.RowCount > 0)
            {
                Funcoes.IdRetorno = int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString());
                Close();
                DialogResult = DialogResult.OK;
            }
        }

        private void frmProfissao_Shown(object sender, EventArgs e)
        {
            if (btnPesquisar.Visible && dgvDados.RowCount > 0 && txtTexto.Text != "")
                dgvDados.Focus();
        }

        private void dgvDados_KeyDown(object sender, KeyEventArgs e)
        {
            if (btnPesquisar.Visible)
            {
                if (e.KeyCode == Keys.Return)
                    Pesquisar();
            }
        }

        private void dgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (btnPesquisar.Visible)
                Pesquisar();
        }

        private void frmProfissao_FormClosed(object sender, FormClosedEventArgs e)
        {
            _unitOfWork.Dispose();
        }
    }
}
