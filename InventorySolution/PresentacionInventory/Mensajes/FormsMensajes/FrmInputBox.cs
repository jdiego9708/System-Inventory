using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PresentacionInventory.Mensajes.FormsMensajes
{
    public partial class FrmInputBox : Form
    {
        public FrmInputBox()
        {
            InitializeComponent();
            this.btn1.Click += Btn1_Click;
            this.btn2.Click += Btn2_Click;
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Mensaje = this.txtInformacion.Text;
            this.Close();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Mensaje = this.txtInformacion.Text;
            this.Close();
        }

        private void FrmInputBox_Load(object sender, EventArgs e)
        {
            this.txtTitulo.Text = this.Titulo;
            this.btn1.Text = this.Texto_boton1;
            this.btn2.Text = this.Texto_boton2;
        }

        private string _mensaje;
        private string _descripcion;
        private string _texto_boton1;
        private string _texto_boton2;
        private string _texto_default;

        public string Titulo { get => _descripcion; set => _descripcion = value; }

        public string Texto_boton1
        {
            get => _texto_boton1;
            set
            {
                _texto_boton1 = value;
                this.btn1.Text = value;
            }
        }

        public string Texto_boton2
        {
            get => _texto_boton2;
            set
            {
                _texto_boton2 = value;
                this.btn2.Text = value;
            }
        }

        public string Mensaje { get => _mensaje; set => _mensaje = value; }
        public string Texto_default
        {
            get => _texto_default;
            set
            {
                _texto_default = value;
                this.txtInformacion.Text = value;
            }
        }
    }
}
