namespace PresentacionInventory.Formularios.FormsUsuarios
{
    using EntidadesInventory.Models;
    using System;
    using System.Text;
    using System.Windows.Forms;

    public partial class UsuarioSmall : UserControl
    {
        public UsuarioSmall()
        {
            InitializeComponent();
            this.btnNext.Click += BtnNext_Click;
            this.btnEditInfo.Click += BtnEditInfo_Click;
            this.btnPerfil.Click += BtnPerfil_Click;
        }

        private void BtnPerfil_Click(object sender, EventArgs e)
        {
            this.OnBtnPerfilClick?.Invoke(this.Usuario, e);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            this.OnBtnNextClick?.Invoke(this.Usuario, e);
        }

        private void BtnEditInfo_Click(object sender, EventArgs e)
        {
            this.OnBtnEditarClick?.Invoke(this.Usuario, e);
        }

        private void AsignarDatos(Usuarios usuario)
        {
            StringBuilder info = new StringBuilder();
            info.Append($"{usuario.Nombre_usuario} {Environment.NewLine}");
            info.Append($"{usuario.Telefono_usuario} {Environment.NewLine}");
            this.txtInfo.Text = info.ToString();
        }

        public event EventHandler OnBtnNextClick;
        public event EventHandler OnBtnPerfilClick;
        public event EventHandler OnBtnEditarClick;

        private Usuarios _usuario;

        public Usuarios Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                this.AsignarDatos(value);
            }
        }
    }
}
