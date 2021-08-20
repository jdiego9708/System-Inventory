using System;
using System.Windows.Forms;

namespace ControlesCompartidos
{
    public partial class FrmMensajeInformacion : Form
    {
        public FrmMensajeInformacion()
        {
            InitializeComponent();
            this.Load += FrmMensajeInformacion_Load;
            this.btnOk.Click += BtnOk_Click;
        }

        public event EventHandler OnBtnOkClick;

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.OnBtnOkClick?.Invoke(this, e);
            this.Close();
        }

        private void FrmMensajeInformacion_Load(object sender, EventArgs e)
        {
            this.txtInformacion.ReadOnly = true;
            this.btnOk.Focus();
        }

        private string _informacion;
        private string _textoBoton;

        public string Informacion
        {
            get => _informacion;
            set
            {
                _informacion = value;
                this.txtInformacion.Text = value;
            }
        }

        public string TextoBoton
        {
            get => _textoBoton;
            set
            {
                _textoBoton = value;
                this.btnOk.Text = value;
            }
        }
    }
}
