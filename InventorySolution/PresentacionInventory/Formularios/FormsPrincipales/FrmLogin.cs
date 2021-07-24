using EntidadesInventory;
using EntidadesInventory.Models;
using ServiceInventory;
using System;
using System.Windows.Forms;

namespace PresentacionInventory.Formularios.FormsPrincipales
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            this.btnLogin.Click += BtnLogin_Click;
            this.txtPIN.GotFocus += TxtPIN_GotFocus;
            this.Load += FrmLogin_Load;
            this.txtPIN.KeyPress += TxtPIN_KeyPress;
            this.btnCancelar.Click += BtnCancelar_Click;
            this.FormClosed += FrmLogin_FormClosed;
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!this.IsComprobacion)
                Application.Exit();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtPIN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                this.btnLogin.PerformClick();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.txtPIN.MaxLength = 4;
            this.Show();
            this.txtPIN.Focus();
        }

        private void TxtPIN_GotFocus(object sender, EventArgs e)
        {
            this.txtPIN.SelectAll();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtPIN.Text))
                {
                    MensajesService.MensajeInformacion("Verifique el PIN");
                    return;
                }

                if (!int.TryParse(this.txtPIN.Text, out int pin))
                {
                    MensajesService.MensajeInformacion("Verifique el PIN");
                    return;
                }

                MainController main = MainController.GetInstancia();
                var (rpta, objs) = await NEmpleados.Login(pin, DateTime.Now.ToString("yyyy-MM-dd"));

                if (rpta.Equals("OK"))
                {
                    if (!this.IsComprobacion)
                    {
                        Empleados empleado = (Empleados)objs[0];
                        Turno turno = (Turno)objs[1];                      
                        main.EmpleadoLogin = empleado;
                        main.EmpleadoClaveMaestra = empleado;
                        main.Turno = turno;

                        FrmPrincipal frmPrincipal = new FrmPrincipal
                        {
                            WindowState = FormWindowState.Maximized,
                        };
                        frmPrincipal.Show();
                        frmPrincipal.Tag = this;                        
                        this.Hide();
                    }
                    else
                    {
                        Empleados empleado = (Empleados)objs[0];
                        main.EmpleadoClaveMaestra = empleado;
                        this.Close();
                    }
                }
                else
                {
                    if (this.IsComprobacion)
                        main.EmpleadoClaveMaestra = null;

                    throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                MensajesService.MensajeErrorCompleto(this.Name, "BtnLogin_Click",
                    "Hubo un error al iniciar sesión", ex.Message); ;
            }
        }

        private string _titulo;

        public string Titulo
        {
            get => _titulo;
            set
            {
                _titulo = value;
                this.txtTitulo.Text = value;
            }
        }

        public bool IsComprobacion
        {
            get => _isComprobacion;
            set
            {
                _isComprobacion = value;

            }
        }

        private bool _isComprobacion;
    }
}
