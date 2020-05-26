using Carros.Comum;
using Carros.Consultas;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using StructureMap;
using System;
using System.Windows.Forms;
using static Carros.Geral.Enumercador;

namespace Carros.Cadastros
{
    public partial class frmVeiculo : Carros.Base.frmConsultaBase
    {
        private Veiculo _model;
        private bool _filtrar = false;
        private IUnitOfWork _unitOfWork;

        public frmVeiculo()
        {
            Iniciar();
        }

        public frmVeiculo(bool Pesquisar = false, string texto = "")
        {
            btnPesquisar.Visible = Pesquisar;
            txtTexto.Text = texto;
            _filtrar = true;
            Iniciar();
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            _unitOfWork = ObjectFactory.GetInstance<IUnitOfWork>();

            Geral.Grade.Config(dgvDados);

            _model = new Veiculo();
            PopularCampos();

            if (_filtrar == false)
                txtTexto.Text = "ABCDE";

            CarregarConsulta();

            if (_filtrar == false)
                txtTexto.Text = "";
        }

        private void PopularCampos()
        {
            cbCampos.Items.Add("Código");
            cbCampos.Items.Add("Placa");
            cbCampos.Items.Add("Marca");
            cbCampos.Items.Add("Modelo");
            cbCampos.Items.Add("Ano");
            cbCampos.SelectedIndex = 1;
        }

        private void CarregarConsulta(int id = 0)
        {
            var filtro = new VeiculoFiltro();

            if (cbCampos.SelectedIndex == 0 && (!string.IsNullOrWhiteSpace(txtTexto.Text)))
                filtro.Id = Funcoes.StrToIntDef(txtTexto.Text, 0);

            if (cbCampos.SelectedIndex == 1)
                filtro.Placa = txtTexto.Text;

            if (cbCampos.SelectedIndex == 2)
                filtro.DescMarca = txtTexto.Text;

            if (cbCampos.SelectedIndex == 3)
                filtro.Modelo = txtTexto.Text;

            if (cbCampos.SelectedIndex == 4)
                filtro.Ano = txtTexto.Text;

            dgvDados.DataSource = _unitOfWork.ServicoVeiculo.Filtrar(filtro, id);
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
            txtPlaca.DataBindings.Clear();
            txtAno.DataBindings.Clear();
            txtIdMarca.Clear();
            txtModelo.DataBindings.Clear();
            txtDescMarca.Clear();

            txtCodigo.DataBindings.Add("Text", _model, "Id", true, DataSourceUpdateMode.OnPropertyChanged);
            txtAno.DataBindings.Add("Text", _model, "Ano", true, DataSourceUpdateMode.OnPropertyChanged);
            txtModelo.DataBindings.Add("Text", _model, "Modelo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPlaca.DataBindings.Add("Text", _model, "Placa", true, DataSourceUpdateMode.OnPropertyChanged);
            txtIdMarca.Text = _model.IdMarca.ToString();
            txtDescMarca.Text = _model.Marca.Descricao;
        }

        public override void Editar()
        {
            if (dgvDados.RowCount == 0)
                return;

            _model = _unitOfWork.ServicoVeiculo.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
            _model.Marca = _unitOfWork.ServicoMarca.RetornarPorId(_model.IdMarca);

            base.Editar();

            VincularDados();
            txtPlaca.Focus();
        }

        public override void Salvar()
        {
            _model.IdMarca = Funcoes.StrToIntNull(txtIdMarca.Text).Value;
            _unitOfWork.ServicoVeiculo.Salvar(_model);
            base.Salvar();
            CarregarConsulta(_model.Id);
            txtTexto.Focus();
        }

        public override void Novo()
        {
            base.Novo();
            _model = new Veiculo();
            VincularDados();
            txtPlaca.Focus();
        }

        public override void Excluir()
        {
            if (dgvDados.RowCount == 0)
                return;

            base.Excluir();

            if (Funcoes.Confirmar("Deseja Excluir?"))
            {
                _unitOfWork.ServicoVeiculo.Excluir(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
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

        private void btnMarca_Click(object sender, EventArgs e)
        {
            PesquisarMarcas(Funcoes.StrToIntDef(txtIdMarca.Text, 0), txtDescMarca.Text, TipoConsulta.Tela);
            txtModelo.Focus();
        }

        private void PesquisarMarcas(int id, string descricao, TipoConsulta tipo)
        {
            if (id == 0 && tipo == TipoConsulta.Id)
            {
                txtIdMarca.Clear();
                txtDescMarca.Clear();
                return;
            }

            var marca = new MarcaConsulta(_unitOfWork);
            var model = new Marca();

            model = marca.Pesquisar(id, descricao, tipo);

            if (model.Id == 0 && tipo == TipoConsulta.Id)
            {
                MessageBox.Show("Registro não Encontrado!");
            }

            if (tipo == TipoConsulta.Tela && model.Id == 0)
                return;

            txtIdMarca.Text = Funcoes.IntToStr(model.Id);
            txtDescMarca.Text = model.Descricao;
            txtIdMarca.Modified = false;
            txtDescMarca.Modified = false;
            txtDescMarca.Focus();
        }

        private void txtIdMarca_Leave(object sender, EventArgs e)
        {
            if (txtIdMarca.Modified)
            {
                PesquisarMarcas(Funcoes.StrToIntDef(txtIdMarca.Text, 0), txtDescMarca.Text, TipoConsulta.Id);
            }
        }

        private void txtDescMarca_Leave(object sender, EventArgs e)
        {
            if (txtDescMarca.Modified)
            {
                if (txtDescMarca.Text.Trim() == "")
                    txtIdMarca.Clear();
                else
                {
                    PesquisarMarcas(Funcoes.StrToIntDef(txtIdMarca.Text, 0), txtDescMarca.Text, TipoConsulta.Descricao);
                }
            }
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

        private void frmVeiculo_Shown(object sender, EventArgs e)
        {
            if (btnPesquisar.Visible && dgvDados.RowCount > 0 && txtTexto.Text != "")
                dgvDados.Focus();
        }

        private void txtIdMarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
            {
                PesquisarMarcas(Funcoes.StrToIntDef(txtIdMarca.Text, 0), txtDescMarca.Text, TipoConsulta.Tela);
            }
        }

        private void frmVeiculo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _unitOfWork.Dispose();
        }
    }
}
