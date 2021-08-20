using System;
using System.Windows.Forms;

namespace ControlesCompartidos.FormsWait
{
    public partial class FrmWait : Form
    {
        public FrmWait()
        {
            InitializeComponent();
            this.Load += FrmWait_Load;
            this.btnCerrar.Click += BtnCerrar_Click;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmWait_Load(object sender, EventArgs e)
        {
            this.txtTitulo.Text = this.Mensaje;
        }

        public string Mensaje { get; set; }
    }
}
