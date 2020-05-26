using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carros.Base
{
    public partial class frmConsultaBase : Form
    {
        public frmConsultaBase()
        {
            InitializeComponent();

            btnSair.Click += (s, e) => Sair();
            btnNovo.Click += (s, e) => Novo();
            btnEditar.Click += (s, e) => Editar();
            btnExcluir.Click += (s, e) => Excluir();
            btnSalvar.Click += (s, e) => Salvar();
            btnVoltar.Click += (s, e) => Voltar();
            btnVoltar2.Click += (s, e) => Voltar();
            btnImprimir.Click += (s, e) => Imprimir();
            btnFiltrar.Click += (s, e) => Filtrar();
            btnFiltro.Click += (s, e) => Filtro();
            btnPesquisar.Click += (s, e) => Pesquisar();
        }

        public virtual void Pesquisar()
        {
            if (tabControl1.SelectedTab == tpPesquisa)
                Close();
        }
        public virtual void Sair()
        {
            this.Close();
        }

        public virtual void Novo()
        {
            if (tabControl1.SelectedTab == tpPesquisa)
                TelaEdicao();
        }

        public virtual void Editar()
        {
            if (tabControl1.SelectedTab == tpPesquisa)
                TelaEdicao();
        }

        public virtual void Salvar()
        {
            if (tabControl1.SelectedTab == tpEditar)
                TelaPesquisa();
        }

        public virtual void Voltar()
        {
            TelaPesquisa();
            txtTexto.Focus();
        }

        public virtual void Filtrar()
        {
            if (tabControl1.SelectedTab == tpFiltro)
                TelaPesquisa();
        }

        public virtual void Filtro()
        {
            if (tabControl1.SelectedTab == tpPesquisa)
                TelaFiltro();
        }

        public virtual void Excluir()
        {

        }

        public virtual void Imprimir()
        {

        }

        private void TelaEdicao()
        {
            tabControl1.TabPages.Remove(tpPesquisa);
            tabControl1.TabPages.Add(tpEditar);
            tabControl1.TabPages.Remove(tpFiltro);
        }

        private void TelaPesquisa()
        {
            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Add(tpPesquisa);
            tabControl1.TabPages.Remove(tpFiltro);
        }

        private void TelaFiltro()
        {
            tabControl1.TabPages.Remove(tpEditar);
            tabControl1.TabPages.Remove(tpPesquisa);
            tabControl1.TabPages.Add(tpFiltro);
        }

        private void frmConsultaBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void frmConsultaBase_Shown(object sender, EventArgs e)
        {
            txtTexto.Focus();
        }

        private void frmConsultaBase_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    if (tabControl1.SelectedTab == tpPesquisa)
                        Novo();
                    break;
                case Keys.F2:
                    if (tabControl1.SelectedTab == tpPesquisa)
                        Editar();
                    break;
                case Keys.F3:
                    if (tabControl1.SelectedTab == tpPesquisa)
                        Excluir();
                    break;
                case Keys.F4:
                    if (tabControl1.SelectedTab == tpPesquisa)
                        Filtro();
                    break;
                case Keys.F8:
                    if (tabControl1.SelectedTab == tpEditar)
                    {
                        if (btnSalvar.Enabled)
                            Salvar();
                    }
                    break;
                case Keys.F12:
                    if (btnPesquisar.Visible)
                        Pesquisar();
                    break;
                case Keys.Escape:
                    if (tabControl1.SelectedTab == tpPesquisa)
                    {
                        if (txtTexto.Focused)
                            Sair();
                        else
                            txtTexto.Focus();
                    }

                    if (tpEditar.Focus() || tpFiltro.Focus())
                    {
                        Voltar();
                    }
                    break;
            }
        }

        private void frmConsultaBase_Load(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.btnNovo, "[Insert] para inserir");
            toolTip1.SetToolTip(this.btnEditar, "[F2] para editar");
            toolTip1.SetToolTip(this.btnExcluir, "[F3] para excluir");
            toolTip1.SetToolTip(this.btnFiltro, "[F4] para filtrar");
            toolTip1.SetToolTip(this.btnSair, "[ESC] para sair");
            toolTip1.SetToolTip(this.btnSalvar, "[F8] para salvar");
            toolTip1.SetToolTip(this.btnVoltar, "[ESC] para voltar");
            toolTip1.SetToolTip(this.btnVoltar2, "[ESC] para voltar");
        }
    }
}
