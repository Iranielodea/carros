namespace Carros.Cadastros
{
    partial class frmEmail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumEncontro = new System.Windows.Forms.TextBox();
            this.btnEmail = new System.Windows.Forms.Button();
            this.rtbEmail = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCadSocio = new System.Windows.Forms.RadioButton();
            this.rbExpVisita = new System.Windows.Forms.RadioButton();
            this.rbExpSocio = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Encontro";
            // 
            // txtNumEncontro
            // 
            this.txtNumEncontro.Location = new System.Drawing.Point(316, 70);
            this.txtNumEncontro.Name = "txtNumEncontro";
            this.txtNumEncontro.ReadOnly = true;
            this.txtNumEncontro.Size = new System.Drawing.Size(72, 20);
            this.txtNumEncontro.TabIndex = 1;
            // 
            // btnEmail
            // 
            this.btnEmail.Location = new System.Drawing.Point(414, 67);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(155, 23);
            this.btnEmail.TabIndex = 2;
            this.btnEmail.Text = "Listar os emails do encontro";
            this.btnEmail.UseVisualStyleBackColor = true;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // rtbEmail
            // 
            this.rtbEmail.Location = new System.Drawing.Point(3, 99);
            this.rtbEmail.Name = "rtbEmail";
            this.rtbEmail.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbEmail.Size = new System.Drawing.Size(566, 229);
            this.rtbEmail.TabIndex = 3;
            this.rtbEmail.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCadSocio);
            this.groupBox1.Controls.Add(this.rbExpVisita);
            this.groupBox1.Controls.Add(this.rbExpSocio);
            this.groupBox1.Location = new System.Drawing.Point(3, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 81);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo:";
            // 
            // rbCadSocio
            // 
            this.rbCadSocio.AutoSize = true;
            this.rbCadSocio.Location = new System.Drawing.Point(6, 58);
            this.rbCadSocio.Name = "rbCadSocio";
            this.rbCadSocio.Size = new System.Drawing.Size(117, 17);
            this.rbCadSocio.TabIndex = 2;
            this.rbCadSocio.Text = "Cadastro de Sócios";
            this.rbCadSocio.UseVisualStyleBackColor = true;
            // 
            // rbExpVisita
            // 
            this.rbExpVisita.AutoSize = true;
            this.rbExpVisita.Location = new System.Drawing.Point(6, 38);
            this.rbExpVisita.Name = "rbExpVisita";
            this.rbExpVisita.Size = new System.Drawing.Size(127, 17);
            this.rbExpVisita.TabIndex = 1;
            this.rbExpVisita.Text = "Expositores Visitantes";
            this.rbExpVisita.UseVisualStyleBackColor = true;
            // 
            // rbExpSocio
            // 
            this.rbExpSocio.AutoSize = true;
            this.rbExpSocio.Checked = true;
            this.rbExpSocio.Location = new System.Drawing.Point(6, 19);
            this.rbExpSocio.Name = "rbExpSocio";
            this.rbExpSocio.Size = new System.Drawing.Size(114, 17);
            this.rbExpSocio.TabIndex = 0;
            this.rbExpSocio.TabStop = true;
            this.rbExpSocio.Text = "Expositores Sócios";
            this.rbExpSocio.UseVisualStyleBackColor = true;
            // 
            // frmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 340);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rtbEmail);
            this.Controls.Add(this.btnEmail);
            this.Controls.Add(this.txtNumEncontro);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emails do Encontro";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEmail_FormClosed);
            this.Load += new System.EventHandler(this.frmEmail_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEmail_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumEncontro;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.RichTextBox rtbEmail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCadSocio;
        private System.Windows.Forms.RadioButton rbExpVisita;
        private System.Windows.Forms.RadioButton rbExpSocio;
    }
}