namespace PresentacionInventory.Formularios.FormsPrincipales
{
    using ControlesCompartidos;
    using EntidadesInventory;
    using EntidadesInventory.Helpers;
    using PresentacionRestaurant.Formularios.FormsMesas;
    using System;
    using System.Windows.Forms;

    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            this.Load += FrmPrincipal_Load;
            this.btnMesas.Click += BtnMesas_Click;
            this.FormClosed += FrmPrincipal_FormClosed;
            ColorHelper.ChangeColorDefault(this);
        }

        private void FrmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnMesas_Click(object sender, EventArgs e)
        {
            if (this.panelPrincipal.Controls.Count > 0)
                this.panelPrincipal.Controls.Clear();

            MainController main = MainController.GetInstancia();

            FrmMesas frmMesas = new()
            {
                WindowState = FormWindowState.Maximized,
                FormBorderStyle = FormBorderStyle.None,
                TopLevel = false,
                Dock = DockStyle.Fill
            };
            frmMesas.OnError += FrmMesas_OnError;
            this.panelPrincipal.Controls.Add(frmMesas);
            frmMesas.Show();
        }

        private void FrmMesas_OnError(object sender, EventArgs e)
        {
            ErrorModel error = (ErrorModel)sender;
            MensajesService.MensajeErrorCompleto(error);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //MainController main = MainController.GetInstancia();
        }
    }
}
