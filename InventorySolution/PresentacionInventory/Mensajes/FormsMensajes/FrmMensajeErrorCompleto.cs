using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PresentacionInventory.Mensajes.FormsMensajes
{
    public partial class FrmMensajeErrorCompleto : Form
    {
        private Timer timer1;
        private ToolTip toolTip1;

        public FrmMensajeErrorCompleto()
        {
            InitializeComponent();
            this.timer1 = new Timer();
            this.toolTip1 = new ToolTip();
            this.btnOk.Click += BtnOk_Click;
            this.btnEnviarTicket.Click += BtnEnviarTicket_Click;
        }

        private void BtnEnviarTicket_Click(object sender, EventArgs e)
        {
            
        }

        public event EventHandler OnBtnOkClick;

        private int contador = 20;
        private bool first_color = true;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(this.txtInformacion, contador.ToString() +
                " segundos para que se cierre el mensaje");
            contador -= 1;
            if (this.first_color)
            {
                this.panel1.BackColor = Color.Red;
                first_color = false;
            }
            else
            {
                first_color = true;
                this.panel1.BackColor = Color.Silver;
            }

            if (contador == -2)
            {
                this.Close();
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.OnBtnOkClick?.Invoke(this, e);
            this.Close();
        }

        private void FrmMensajeInformacion_Load(object sender, EventArgs e)
        {
            this.txtTitulo.ReadOnly = true;
            this.txtInformacion.ReadOnly = true;
            this.btnOk.Focus();
        }

        private string _metodoError;
        private string _formularioError;
        private string _informacionCorta;
        private string _detalleInformacion;

        public string MetodoError { get => _metodoError; set => _metodoError = value; }
        public string FormularioError { get => _formularioError; set => _formularioError = value; }
        public string InformacionCorta
        {
            get => _informacionCorta;
            set
            {
                _informacionCorta = value;
                this.txtTitulo.Text = value;
            }      
        }
        public string DetalleInformacion
        {
            get => _detalleInformacion;
            set
            {
                _detalleInformacion = value;
                this.txtInformacion.Text = value;
            }
        }
    }
}
