namespace PresentacionInventory.Formularios.FormsUsuarios
{
    using ControlesCompartidos;
    using ControlesCompartidos.Interfaces;
    using EntidadesInventory.Helpers;
    using EntidadesInventory.Models;
    using ServiceInventory.Interfaces;
    using System;
    using System.Windows.Forms;

    public partial class FrmAddUsuarios : Form
    {
        private IServiceList ServiceList { get; set; }
        public IServiceInventory ServiceInventory { get; set; }

        public FrmAddUsuarios()
        {           
            InitializeComponent();

            this.ServiceList = ServiceDIHelper.GetService<IServiceList>();
            this.ServiceInventory = ServiceDIHelper.GetService<IServiceInventory>();

            this.btnSave.Click += BtnSave_Click;
            this.Load += FrmAddUsuarios_Load;
        }
         
        private void FrmAddUsuarios_Load(object sender, EventArgs e)
        {
            if (!this.IsEditar)
            {
                this.ServiceList.LoadTipoUsuarios(this.listaTipoUsuario);
            }
        }

        public event EventHandler OnUsuarioSuccess;

        private Usuarios Comprobaciones()
        {
            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                MensajesService.MensajeInformacion("Verifique los campos");
                return null;
            }

            if (string.IsNullOrEmpty(this.txtIdentificacion.Text))
            {
                MensajesService.MensajeInformacion("Verifique los campos");
                return null;
            }

            if (string.IsNullOrEmpty(this.txtTelefono.Text))
            {
                MensajesService.MensajeInformacion("Verifique los campos");
                return null;
            }

            if (!int.TryParse(Convert.ToString(this.listaTipoUsuario.SelectedValue), out int id_tipo_usuario))
            {
                MensajesService.MensajeInformacion("Verifique el tipo de usuario");
                return null;
            }

            return new Usuarios
            {
                Fecha_ingreso = DateTime.Now,
                Nombre_usuario = this.txtNombre.Text,
                Telefono_usuario = this.txtTelefono.Text,
                Identificacion_usuario = this.txtIdentificacion.Text,
                Email_usuario = this.txtCorreo.Text,
                Id_tipo_usuario = id_tipo_usuario,
                Estado_usuario = "ACTIVO",
            };
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios usuario = this.Comprobaciones();
                if (usuario != null)
                {
                    var (rpta, id_usuario) = 
                        await this.ServiceInventory.InsertarUsuario(usuario);
                    if (rpta.Equals("OK"))
                    {                        
                        MensajesService.MensajeOk("Usuario guardado con exito");
                        usuario.Id_usuario = id_usuario;
                        this.OnUsuarioSuccess?.Invoke(usuario, e);
                        this.Close();
                    }
                    else
                        throw new Exception(rpta);
                }
            }
            catch (Exception ex)
            {
                ErrorModel error = new(ex);
                error.CustomMessage = $"Form: {this.Name} | Método: BtnSave_Click() | ";
                MainViewModel.GetError(error);
            }
        }

        private void AsignarDatos(Usuarios usuario)
        {
            this.txtNombre.Text = usuario.Nombre_usuario;
            this.txtIdentificacion.Text = usuario.Identificacion_usuario;
            this.txtCorreo.Text = usuario.Email_usuario;
            this.txtTelefono.Text = usuario.Telefono_usuario;

            this.ServiceList.LoadTipoUsuarios(this.listaTipoUsuario);
            this.listaTipoUsuario.SelectedValue = usuario.Id_tipo_usuario;
        }

        private bool _isEditar;
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

        public bool IsEditar
        {
            get => _isEditar;
            set
            {
                _isEditar = value;
                this.Text = "Editar usuarios";
            }
        }
    }
}
