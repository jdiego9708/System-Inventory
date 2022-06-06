using ControlesCompartidos.Interfaces;
using EntidadesInventory.Helpers;
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

namespace PresentacionInventory.Formularios.FormsProductos
{
    public partial class FrmPerfilProducto : Form
    {
        public IServiceList ServiceList { get; set; }
        public FrmPerfilProducto()
        {
            InitializeComponent();

            this.ServiceList = ServiceDIHelper.GetService<IServiceList>();

            this.btnBuscar.Click += BtnBuscar_Click;
            this.Load += FrmPerfilProducto_Load;
        }

        private void FrmPerfilProducto_Load(object sender, EventArgs e)
        {
            this.ServiceList.LoadTipoReporteProducto(cbListaFiltros);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            
        }
        private void AsignarDatos(Productos producto)
        {
            StringBuilder info = new();
            info.Append(this.txtDatosPrincipales.Text = producto.Nombre_producto).Append(Environment.NewLine);
            if (!string.IsNullOrEmpty(producto.Descripcion_producto))
                info.Append(producto.Descripcion_producto).Append(Environment.NewLine);
            this.txtDatosPrincipales.Text = info.ToString();
        }

        private Productos _producto;
        public Productos Producto
        {
            get => _producto;
            set
            {
                _producto = value;
                this.AsignarDatos(value);
            }
        }
    }
}
