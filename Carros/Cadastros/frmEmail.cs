using Carros.Dominio.Entidades;
using Carros.Dominio.Interfaces;
using Carros.Servico;
using StructureMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carros.Cadastros
{
    public partial class frmEmail : Form
    {
        private readonly IUnitOfWorkOld _unitOfWork;

        public frmEmail()
        {
            InitializeComponent();
            _unitOfWork = ObjectFactory.GetInstance<IUnitOfWorkOld>();
        }

        private void frmEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            CarregarEncontro();
            btnEmail.Focus();
        }

        private void CarregarEncontro()
        {
            var CadEncontro = _unitOfWork.ServicoCadEncontro.ObterNumeroEncontroAtual();
            txtNumEncontro.Text = CadEncontro.NumeroEncontro.ToString();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            ListarEmail();
        }

        private void ListarEmail()
        {
            var tipo = new Comum.EnTipoExpositor();

            if (rbExpSocio.Checked)
                tipo = Comum.EnTipoExpositor.expSocio;
            else if (rbExpVisita.Checked)
                tipo = Comum.EnTipoExpositor.expVisitante;
            else
                tipo = Comum.EnTipoExpositor.expCadSocio;

            var pessoas = _unitOfWork.ServicoPessoa.ListarEmails(Convert.ToInt32(txtNumEncontro.Text), tipo);
            string email = "";
            foreach (var pessoa in pessoas)
            {
                if (!string.IsNullOrEmpty(pessoa))
                    email = email + pessoa + ";\n";
            }
            rtbEmail.Text = email;
        }

        private void frmEmail_FormClosed(object sender, FormClosedEventArgs e)
        {
            _unitOfWork.Dispose();
        }
    }
}
