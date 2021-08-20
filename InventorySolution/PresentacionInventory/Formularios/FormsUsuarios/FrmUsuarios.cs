using ControlesCompartidos.Interfaces;
using EntidadesInventory.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionInventory.Formularios.FormsUsuarios
{
    public partial class FrmUsuarios : Form
    {
        private IServiceList ServiceList { get; set; }

        public FrmUsuarios(IServiceList serviceList)
        {
            this.ServiceList = serviceList;

            InitializeComponent();
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
