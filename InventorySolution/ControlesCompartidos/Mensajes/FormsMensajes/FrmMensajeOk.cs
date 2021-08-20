using System;
using System.Windows.Forms;

namespace ControlesCompartidos
{
    public partial class FrmMensajeOk : Form
    {
        private Timer timer1;

        public FrmMensajeOk()
        {
            InitializeComponent();
            this.timer1 = new Timer();
            this.timer1.Tick += Timer1_Tick;
            this.Load += FrmMensajeOk_Load;
            this.btnOk.Click += BtnOk_Click;
        }

        public event EventHandler OnBtnOkClick;

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.OnBtnOkClick?.Invoke(this, e);
            this.timer1.Stop();
            this.Close();
        }

        public string Mensaje { get; set; }
        public string Texto_boton { get; set; }

        private void FrmMensajeOk_Load(object sender, EventArgs e)
        {
            this.txtInformacion.Text = Mensaje;
            this.timer1.Interval = 250;
            this.timer1.Start();
        }

        private int contador = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity *= 0.9;
            contador += 1;
            if (contador == 11)
            {
                this.Close();
            }
        }
    }
}
