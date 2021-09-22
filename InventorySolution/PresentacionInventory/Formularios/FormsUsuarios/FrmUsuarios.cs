namespace PresentacionInventory.Formularios.FormsUsuarios
{
    using ControlesCompartidos;
    using ControlesCompartidos.Interfaces;
    using EntidadesInventory.Helpers;
    using EntidadesInventory.Models;
    using PresentacionInventory.Properties;
    using ServiceInventory.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class FrmUsuarios : Form
    {
        public IServiceList ServiceList { get; set; }
        public IServiceInventory ServiceInventory { get; set; }

        public FrmUsuarios()
        {
            InitializeComponent();

            this.ServiceList = ServiceDIHelper.GetService<IServiceList>();
            this.ServiceInventory = ServiceDIHelper.GetService<IServiceInventory>();

            this.btnAddUsuario.Click += BtnAddUsuario_Click;
            this.Load += FrmUsuarios_Load;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            this.LoadUsuarios("COMPLETO", string.Empty);
        }

        public async void LoadUsuarios(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.panelUsuarios.clearDataSource();

                var (rpta, ds) =
                    await this.ServiceInventory.BuscarUsuarios(tipo_busqueda, texto_busqueda);
                if (ds != null)
                {
                    DataTable dtUsuarios = ds.Tables[0];
                    List<UserControl> controls = new List<UserControl>();
                    foreach (DataRow row in dtUsuarios.Rows)
                    {
                        Usuarios us = new Usuarios(row);
                        UsuarioSmall usuarioSmall = new UsuarioSmall
                        {
                            Usuario = us,
                        };
                        usuarioSmall.OnBtnEditarClick += UsuarioSmall_OnBtnEditarClick;
                        usuarioSmall.OnBtnNextClick += UsuarioSmall_OnBtnNextClick;
                        usuarioSmall.OnBtnPerfilClick += UsuarioSmall_OnBtnPerfilClick;

                        controls.Add(usuarioSmall);
                    }
                    this.panelUsuarios.BackgroundImage = null;
                    this.panelUsuarios.AddArrayControl(controls);
                }
                else
                {
                    Image image = (Image)Resources.ResourceManager.GetObject("SIN_IMAGENES.jpg");
                    this.panelUsuarios.BackgroundImage = image;
                }
            }
            catch (Exception ex)
            {
                ErrorModel error = new(ex);
                error.CustomMessage = $"Form: {this.Name} | Método: BtnSave_Click() | ";
                MainViewModel.GetError(error);
            }
        }

        private void UsuarioSmall_OnBtnPerfilClick(object sender, EventArgs e)
        {
            
        }

        private void UsuarioSmall_OnBtnNextClick(object sender, EventArgs e)
        {
            
        }

        private void UsuarioSmall_OnBtnEditarClick(object sender, EventArgs e)
        {
            
        }

        private void BtnAddUsuario_Click(object sender, EventArgs e)
        {
            FrmAddUsuarios frmAddUsuarios = new()
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
            };
            frmAddUsuarios.OnUsuarioSuccess += FrmAddUsuarios_OnUsuarioSuccess;
            PoperContainer container = new(frmAddUsuarios);
            container.Show(this.btnAddUsuario);
            frmAddUsuarios.Show();
        }

        private void FrmAddUsuarios_OnUsuarioSuccess(object sender, EventArgs e)
        {
            Usuarios us = (Usuarios)sender;
            UsuarioSmall usuarioSmall = new()
            {
                Usuario = us,
            };
            usuarioSmall.OnBtnEditarClick += UsuarioSmall_OnBtnEditarClick;
            usuarioSmall.OnBtnNextClick += UsuarioSmall_OnBtnNextClick;
            usuarioSmall.OnBtnPerfilClick += UsuarioSmall_OnBtnPerfilClick;

            this.panelUsuarios.RefreshPanel(usuarioSmall);
        }
    }
}
