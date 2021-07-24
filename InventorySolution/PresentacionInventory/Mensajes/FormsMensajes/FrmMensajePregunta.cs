using System;
using System.Windows.Forms;

namespace PresentacionInventory.Mensajes.FormsMensajes
{
    public partial class FrmMensajePregunta : Form
    {
        public FrmMensajePregunta()
        {
            InitializeComponent();
            this.Load += FrmMensajePregunta_Load;
            this.btn1.Click += Btn1_Click;
            this.btn2.Click += Btn2_Click;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void FrmMensajePregunta_Load(object sender, EventArgs e)
        {
            this.btn1.Text = this.Boton1;
            this.btn2.Text = this.Boton2;
            this.txtInformacion.Text = this.Pregunta;
            this.txtInformacion.ReadOnly = true;
            this.btn2.Focus();
        }

        private string boton1;
        private string boton2;
        private string pregunta;

        public string Boton1 { get => boton1; set => boton1 = value; }
        public string Boton2 { get => boton2; set => boton2 = value; }
        public string Pregunta { get => pregunta; set => pregunta = value; }
    }
}
