using Carros.Cadastros;
using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using StructureMap;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Carros
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmMarca());
        }

        private void sairDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmCidade());
        }

        private void profissõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmProfissao());
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmUsuario());
        }

        private void AbrirTela(Form tela)
        {
            tela.MdiParent = this;
            tela.Show();
        }

        private void cadastroDeEncontrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmCadEncontro());
        }

        private void sequenciaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmSequencia());
        }

        private void tabelaDeControleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmTabControle());
        }

        private void automóveisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmVeiculo());
        }

        private void expositoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmVisitante(Comum.EnTipoExpositor.expSocio));
        }

        private void expositoresVisitantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmVisitante(Comum.EnTipoExpositor.expVisitante));
        }

        private void cadastroDeSóciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmVisitante(Comum.EnTipoExpositor.expCadSocio));
        }

        private void lançamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmEncontro());
        }

        private void configurarCertificadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarCertificado();
        }

        private void ConfigurarCertificado()
        {
            ImpressaoEncontro impressao = new ImpressaoEncontro()
            {
                Ano = 1900,
                Letra = "A",
                Modelo = "modelo",
                NomePessoa = "Carros",
                NumeroFicha = 100
            };

            using (var _unitOfWork = ObjectFactory.GetInstance<IUnitOfWork>())
            {
                _unitOfWork.ServicoEncontro.Imprimir(impressao, true);
            }
        }

        private void BuscarVersao()
        {
            using (var _unitOfWork = ObjectFactory.GetInstance<IUnitOfWork>())
            {
                var versao = _unitOfWork.ServicoTabControle.RetornarTodos().FirstOrDefault(x => x.Sigla == "VERSAO").ValorInt;
                rodape.Text = "Versão: " + versao;
            }
        }

        private void exportarEmailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmEmail());
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            BuscarVersao();
        }

        private void btnExpositores_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmVisitante(Comum.EnTipoExpositor.expVisitante));
        }

        private void btnAutomovel_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmVeiculo());
        }

        private void btnEncontro_Click(object sender, EventArgs e)
        {
            AbrirTela(new frmEncontro());
        }
    }
}
