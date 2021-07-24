namespace PresentacionRestaurant.Formularios.FormsMesas
{
    using EntidadesInventory.BindingModels;
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class CustomButtonMesa : UserControl
    {
        public CustomButtonMesa()
        {
            InitializeComponent();
            this.btnMesa.Click += BtnMesa_Click;
        }

        private void ChangeStatus(string state)
        {
            if (state == null)
                state = "DISPONIBLE";

            if (state.Equals("DISPONIBLE"))
            {
                this.btnMesa.FlatStyle = FlatStyle.Flat;
                this.btnMesa.BackColor = Color.FromArgb(169, 255, 169);
                this.btnMesa.FlatAppearance.BorderColor = Color.FromArgb(169, 255, 169);
                this.btnMesa.FlatAppearance.MouseDownBackColor = Color.FromArgb(128, 255, 128);
                this.btnMesa.FlatAppearance.MouseOverBackColor = Color.FromArgb(169, 255, 169);
                this.btnMesa.ForeColor = Color.FromArgb(64, 64, 64);
                return;
            }

            if (state.Equals("PENDIENTE"))
            {
                this.btnMesa.FlatStyle = FlatStyle.Flat;
                this.btnMesa.BackColor = Color.FromArgb(247, 255, 3);
                this.btnMesa.FlatAppearance.BorderColor = Color.FromArgb(247, 255, 3);
                this.btnMesa.FlatAppearance.MouseDownBackColor = Color.FromArgb(235, 241, 28);
                this.btnMesa.FlatAppearance.MouseOverBackColor = Color.FromArgb(247, 255, 3);
                this.btnMesa.ForeColor = Color.FromArgb(64, 64, 64);
                return;
            }

            if (state.Equals("SALIENDO"))
            {
                this.btnMesa.FlatStyle = FlatStyle.Flat;
                this.btnMesa.BackColor = Color.FromArgb(255, 190, 2);
                this.btnMesa.FlatAppearance.BorderColor = Color.FromArgb(255, 190, 2);
                this.btnMesa.FlatAppearance.MouseDownBackColor = Color.FromArgb(230, 179, 31);
                this.btnMesa.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 190, 2);
                this.btnMesa.ForeColor = Color.White;
                return;
            }
        }

        private void BtnMesa_Click(object sender, EventArgs e)
        {
            this.OnBtnMesaClick?.Invoke(this.Mesa, e);
        }

        public event EventHandler OnBtnMesaClick;
        private MesaBindingModel mesa;

        public MesaBindingModel Mesa
        {
            get => mesa;
            set
            {
                mesa = value;
                this.AsignarDatos(value);
            }
        }

        private void AsignarDatos(MesaBindingModel mesa)
        {
            this.ChangeStatus(mesa.Estado_mesa);
        }
    }
}
