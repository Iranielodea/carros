using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using StructureMap;
using System.Windows.Forms;

namespace Carros.Cadastros
{
    public partial class frmFiliacao : Carros.Base.frmConsultaBase
    {
        int _idPessoa;
        private Filiacao _model;
        private IUnitOfWorkOld _unitOfWork;

        public frmFiliacao()
        {
            Iniciar();
        }

        public frmFiliacao(bool Pesquisar = false, int idPessoa = 0)
        {
            _idPessoa = idPessoa;
            btnPesquisar.Visible = false;
            Iniciar();
            groupBox1.Visible = false;
            if (btnPesquisar.Visible && dgvDados.RowCount > 0)
                dgvDados.Focus();
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);
            _unitOfWork = ObjectFactory.GetInstance<IUnitOfWorkOld>();

            Geral.Grade.Config(dgvDados);

            _model = new Filiacao();
            CarregarConsulta();
        }

        private void CarregarConsulta(int id = 0)
        {
            dgvDados.DataSource = _unitOfWork.ServicoFiliacao.ListarPorPessoa(_idPessoa);
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
            txtNome.DataBindings.Clear();
            txtId.DataBindings.Clear();
            txtDataNasc.DataBindings.Clear();

            txtId.DataBindings.Add("Text", _model, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNome.DataBindings.Add("Text", _model, "Nome", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDataNasc.DataBindings.Add("Text", _model, "DataNasc", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override void Editar()
        {
            if (dgvDados.RowCount == 0)
                return;

            _model.PessoaId = _idPessoa;
            _model = _unitOfWork.ServicoFiliacao.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
            base.Editar();

            VincularDados();
            txtNome.Focus();
        }

        public override void Salvar()
        {
            _unitOfWork.ServicoFiliacao.Salvar(_model);
            base.Salvar();
            CarregarConsulta(_model.Id);
            txtTexto.Focus();
        }

        public override void Novo()
        {
            base.Novo();
            _model = new Filiacao();
            _model.PessoaId = _idPessoa;
            VincularDados();
            txtNome.Focus();
        }

        public override void Excluir()
        {
            if (dgvDados.RowCount == 0)
                return;

            base.Excluir();

            if (Funcoes.Confirmar("Deseja Excluir?"))
            {
                _unitOfWork.ServicoFiliacao.Deletar(_unitOfWork.ServicoFiliacao.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString())));
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

        private void frmFiliacao_FormClosed(object sender, FormClosedEventArgs e)
        {
            _unitOfWork.Dispose();
        }
    }
}
