using Carros.Comum;
using Carros.CrosPlataform;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using System;
using System.Windows.Forms;

namespace Carros.Cadastros
{
    public partial class frmPessoaVeiculo : Carros.Base.frmConsultaBase
    {
        int _idPessoa;
        int _ID;
        private VeiculoPessoa _model;
        private IDalSession _session;

        public frmPessoaVeiculo()
        {
            Iniciar();
        }

        public frmPessoaVeiculo(bool Pesquisar = false, int idPessoa = 0)
        {
            _idPessoa = idPessoa;
            btnPesquisar.Visible = false;
            Iniciar();

            BuscarPessoa();
            //if (btnPesquisar.Visible && dgvDados.RowCount > 0)
            dgvDados.Focus();
        }

        private void BuscarPessoa()
        {
            var Pessoa = new Pessoa();
            Pessoa = _session.ServicePessoa.RetornarPorId(_idPessoa);
            txtIdPessoa.Text = Pessoa.Id.ToString();
            txtNomePessoa.Text = Pessoa.Nome;
        }

        private void Iniciar()
        {
            InitializeComponent();

            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);

            _session = SessionFactory.Criar();

            Geral.Grade.Config(dgvDados);

            _model = new VeiculoPessoa();
            CarregarConsulta();
        }

        private void CarregarConsulta(int id = 0)
        {
            dgvDados.DataSource = _session.ServiceVeiculoPessoa.ListarPorPessoa(_idPessoa);
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CarregarConsulta(0);
                dgvDados.Focus();
            }
        }

        private void Limpar()
        {
            txtPlaca.Clear();
            txtIdMarca.Clear();
            txtId.Clear();
            txtIdVeiculo.Clear();
            txtDescMarca.Clear();
            txtModelo.Clear();
            txtAno.Clear();
        }

        private void VincularDados()
        {
            txtPlaca.Text = _model.Veiculo.Placa;
            if (_model.Veiculo.Id > 0)
            {
                txtIdMarca.Text = _model.Veiculo.IdMarca.ToString();
                txtIdVeiculo.Text = _model.IdVeiculo.ToString();
                txtDescMarca.Text = _model.Veiculo.Marca.Descricao;
                txtModelo.Text = _model.Veiculo.Modelo;
                txtAno.Text = _model.Veiculo.Ano;
            }
        }

        public override void Editar()
        {
            if (dgvDados.RowCount == 0)
                return;

            _model.IdPessoa = _idPessoa;
            _model = _session.ServiceVeiculoPessoa.RetornarPorId(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
            _model.Veiculo = _session.ServiceVeiculo.RetornarPorId(_model.IdVeiculo);
            _model.Pessoa = _session.ServicePessoa.RetornarPorId(_model.IdPessoa);
            if (_model.Veiculo != null)
                _model.Veiculo.Marca = _session.ServiceMarca.RetornarPorId(_model.Veiculo.IdMarca);

            _ID = _model.Id;
            base.Editar();

            VincularDados();
            txtPlaca.Focus();
        }

        public override void Salvar()
        {
            _model.Id = _ID;
            _model.IdPessoa = _idPessoa;
            _model.IdVeiculo = Convert.ToInt32(txtIdVeiculo.Text);

            _session.ServiceVeiculoPessoa.Salvar(_model);
            base.Salvar();
            CarregarConsulta(_model.Id);
            txtTexto.Focus();
        }

        public override void Novo()
        {
            base.Novo();
            _model = new VeiculoPessoa();
            _model.IdPessoa = _idPessoa;
            _ID = 0;
            Limpar();
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
                _session.ServiceVeiculoPessoa.Excluir(int.Parse(dgvDados.CurrentRow.Cells["Id"].Value.ToString()));
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

        private void PesquisarVeiculo(string tipo)
        {
            Consultas.VeiculoConsulta consulta = new Consultas.VeiculoConsulta(_session);
            Veiculo veiculo = new Veiculo();
            if (tipo == "P")
                veiculo = consulta.Pesquisar(txtPlaca.Text, Geral.Enumercador.TipoConsulta.Descricao);
            else
                veiculo = consulta.Pesquisar(txtPlaca.Text, Geral.Enumercador.TipoConsulta.Tela);

            if (veiculo != null && veiculo.Id > 0)
            {
                txtPlaca.Text = veiculo.Placa;
                txtIdVeiculo.Text = veiculo.Id.ToString();
                txtIdMarca.Text = veiculo.IdMarca.ToString();
                txtDescMarca.Text = veiculo.Marca.Descricao;
                txtModelo.Text = veiculo.Modelo;
                txtAno.Text = veiculo.Ano;
                btnSalvar.Focus();
            }
            else
            {
                if (tipo == "P")
                {
                    MessageBox.Show("Veículo não Encontrado!");
                    txtPlaca.Clear();
                    txtIdVeiculo.Clear();
                    txtIdMarca.Clear();
                    txtDescMarca.Clear();
                    txtModelo.Clear();
                    txtAno.Clear();
                    txtPlaca.Focus();
                }
            }

            txtPlaca.Modified = false;
        }

        private void btnVeiculo_Click(object sender, EventArgs e)
        {
            PesquisarVeiculo("T");
            btnSalvar.Focus();
        }

        private void btnCertificado_Click(object sender, EventArgs e)
        {
            if (dgvDados.RowCount > 0)
            {
                int linha = dgvDados.CurrentRow.Index + 1;

                string letra = GetLetra(linha);

                var Pessoa = new Pessoa();
                string nomePessoa = "";

                Pessoa = _session.ServicePessoa.RetornarPorId(_idPessoa);
                nomePessoa = Pessoa.Nome;
                int numFicha = _session.ServicePessoa.ObterNumeroFichar(_idPessoa);

                string modelo = dgvDados.CurrentRow.Cells["Modelo"].Value.ToString();
                string ano = dgvDados.CurrentRow.Cells["Ano"].Value.ToString();

                int imprimir = chkImprimir.Checked ? 1 : 0;
                Impressoes.ImpressaoDLL(nomePessoa, ano, modelo, numFicha.ToString(), letra, imprimir);

                //Impressoes.Imprimir(letra + "|" + nomePessoa + "|" + modelo + "|" + ano + "|" + numFicha.ToString() + "|");

                //ImpressaoEncontro impressao = new ImpressaoEncontro()
                //{
                //    Ano = Convert.ToInt32(ano),
                //    Letra = letra,
                //    Modelo = modelo,
                //    NomePessoa = nomePessoa,
                //    NumeroFicha = numFicha
                //};

                //_unitOfWork.ServicoEncontro.Imprimir(impressao);
            }
        }

        private string GetLetra(int posicaoLinha)
        {
            if (posicaoLinha <= 1)
                return "";

            string letras = "ABCDEFGHIJKLMNOKPRSTUVXZ";
            string letra = letras.Substring(posicaoLinha - 2, 1);
            return letra;
        }

        private void frmPessoaVeiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void txtPlaca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F9)
                PesquisarVeiculo("T");
        }

        private void txtPlaca_Leave(object sender, EventArgs e)
        {
            if (txtPlaca.Modified)
                PesquisarVeiculo("P");
        }

        private void frmPessoaVeiculo_FormClosed(object sender, FormClosedEventArgs e)
        {
            _session.Dispose();
        }
    }
}
