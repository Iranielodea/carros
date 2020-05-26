using Carros.Comum;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using StructureMap;
using System.Windows.Forms;

namespace Carros.Cadastros
{
    public partial class frmContato : Carros.Base.frmConsultaBase
    {
        int _idPessoa;
        private Contato _model;
        private IUnitOfWork _unitOfWork;

        public frmContato()
        {
            Iniciar();
        }

        public frmContato(bool Pesquisar = false, int idPessoa = 0)
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
            _unitOfWork = ObjectFactory.GetInstance<IUnitOfWork>();

            Geral.Grade.Config(dgvDados);

            _model = new Contato();
            CarregarConsulta();
        }

        private void CarregarConsulta(int id = 0)
        {
            dgvDados.DataSource = _unitOfWork.ServicoContato.ObterPorPessoa(_idPessoa);
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
            txtTelefone.DataBindings.Clear();
            txtCelular.DataBindings.Clear();
            txtId.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtObs.DataBindings.Clear();

            txtId.DataBindings.Add("Text", _model, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCelular.DataBindings.Add("Text", _model, "Celular", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTelefone.DataBindings.Add("Text", _model, "Telefone", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("Text", _model, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            txtObs.DataBindings.Add("Text", _model, "Observacao", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override void Editar()
        {
            if (dgvDados.RowCount == 0)
                return;

            _model.PessoaId = _idPessoa;
            _model = _unitOfWork.ServicoContato.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
            base.Editar();

            VincularDados();
            txtTelefone.Focus();
        }

        public override void Salvar()
        {
            _unitOfWork.ServicoContato.Salvar(_model);
            base.Salvar();
            CarregarConsulta(_model.Id);
            txtTexto.Focus();
        }

        public override void Novo()
        {
            base.Novo();
            _model = new Contato();
            _model.PessoaId = _idPessoa;
            VincularDados();
            txtTelefone.Focus();
        }

        public override void Excluir()
        {
            if (dgvDados.RowCount == 0)
                return;

            base.Excluir();

            if (Funcoes.Confirmar("Deseja Excluir?"))
            {
                _unitOfWork.ServicoContato.Deletar(_unitOfWork.ServicoContato.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString())));
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

        private void frmContato_FormClosed(object sender, FormClosedEventArgs e)
        {
            _unitOfWork.Dispose();
        }
    }
}
