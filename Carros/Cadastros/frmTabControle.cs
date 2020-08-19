using Carros.CrosPlataform;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using StructureMap;
using System.Windows.Forms;

namespace Carros.Cadastros
{
    public partial class frmTabControle : Carros.Base.frmConsultaBase
    {
        private TabControle _model;
        private IDalSession _session;

        public frmTabControle()
        {
            Iniciar();
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            _session = SessionFactory.Criar();

            Geral.Grade.Config(dgvDados);

            _model = new TabControle();
            CarregarConsulta();
        }

        private void CarregarConsulta(int id = 0)
        {
            dgvDados.DataSource = _session.ServiceTabControle.ListarTudo(id);
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
            txtSigla.DataBindings.Clear();
            txtParametroStr.DataBindings.Clear();
            txtParametroInt.DataBindings.Clear();

            txtCodigo.DataBindings.Add("Text", _model, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDescricao.DataBindings.Add("Text", _model, "Descricao", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSigla.DataBindings.Add("Text", _model, "Sigla", true, DataSourceUpdateMode.OnPropertyChanged);
            txtParametroStr.DataBindings.Add("Text", _model, "ValorString", true, DataSourceUpdateMode.OnPropertyChanged);
            txtParametroInt.DataBindings.Add("Text", _model, "ValorInt", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public override void Editar()
        {
            if (dgvDados.RowCount == 0)
                return;

            _model = _session.ServiceTabControle.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
            txtSigla.Enabled = false;
            base.Editar();

            VincularDados();
            txtDescricao.Focus();
        }

        public override void Salvar()
        {
            _session.ServiceTabControle.Salvar(_model);

            base.Salvar();
            CarregarConsulta(_model.Id);
            txtTexto.Focus();
        }

        public override void Novo()
        {
            //base.Novo();
            //_servico = new TabControleServico();
            //_model = _servico.ObterPorId(0);
            //VincularDados();
            //txtDescricao.Focus();
            txtSigla.Enabled = true;
        }

        public override void Excluir()
        {
            //base.Excluir();

            //if (Funcoes.Confirmar("Deseja Excluir?"))
            //{
            //    _servico = new TabControleServico();
            //    _servico.Excluir(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
            //    CarregarConsulta(0);
            //    txtTexto.Focus();
            //}
        }

        public override void Filtrar()
        {
            base.Filtrar();
            CarregarConsulta(0);
            txtTexto.Focus();
        }

        private void frmTabControle_FormClosed(object sender, FormClosedEventArgs e)
        {
            _session.Dispose();
        }
    }
}
