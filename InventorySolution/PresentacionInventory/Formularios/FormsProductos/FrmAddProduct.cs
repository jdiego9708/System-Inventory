namespace PresentacionInventory.Formularios.FormsProductos
{
    using ControlesCompartidos;
    using ControlesCompartidos.Interfaces;
    using EntidadesInventory.Helpers;
    using EntidadesInventory.Models;
    using ServiceInventory.Interfaces;
    using System;
    using System.Windows.Forms;

    public partial class FrmAddProduct : Form
    {
        private IServiceList ServiceList { get; set; }
        public IServiceInventory ServiceInventory { get; set; }

        public FrmAddProduct()
        {
            InitializeComponent();

            this.ServiceList = ServiceDIHelper.GetService<IServiceList>();
            this.ServiceInventory = ServiceDIHelper.GetService<IServiceInventory>();

            this.btnSave.Click += BtnSave_Click;
            this.Load += FrmAddProduct_Load;
            this.listaTipoProductos.SelectedIndexChanged += ListaTipoProductos_SelectedIndexChanged;
        }

        private void ListaTipoProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(Convert.ToString(this.listaTipoProductos.SelectedValue), out int id_tipo_producto))
                this.ServiceList.LoadListGenericXIdPadre(this.listaSubTipo, id_tipo_producto);         
        }

        private void FrmAddProduct_Load(object sender, EventArgs e)
        {
            if (!this.IsEditar)
            {
                this.ServiceList.LoadTipoProductos(this.listaTipoProductos);
            }
        }

        public event EventHandler OnProductSuccess;

        private Productos Comprobaciones()
        {
            if (string.IsNullOrEmpty(this.txtNombre.Text))
            {
                MensajesService.MensajeInformacion("Verifique los campos");
                return null;
            }

            if (!decimal.TryParse(this.txtPrecio.Text, out decimal precio))
            {
                MensajesService.MensajeInformacion("Verifique el precio");
                return null;
            }
            else
            {
                if (precio == 0)
                {
                    MensajesService.MensajeInformacion("Verifique el precio del producto");
                    return null;
                }
            }

            if (!int.TryParse(Convert.ToString(this.listaSubTipo.SelectedValue), out int id_tipo_producto))
            {
                MensajesService.MensajeInformacion("Verifique el tipo de producto");
                return null;
            }
            else
            {
                if (precio == 0)
                {
                    MensajesService.MensajeInformacion("Verifique el tipo de producto");
                    return null;
                }
            }

            return new Productos
            {
                Id_tipo_producto = id_tipo_producto,
                Nombre_producto = this.txtNombre.Text,
                Precio_producto = precio,
                Descripcion_producto = this.txtDescripcion.Text,
                Estado_producto = "ACTIVO",
            };
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Productos product = this.Comprobaciones();
                if (product != null)
                {
                    string mensaje = string.Empty;
                    var (rpta, id_producto) =
                        await this.ServiceInventory.InsertarProducto(product);
                    if (rpta.Equals("OK"))
                    {
                        mensaje = "Producto guardado con exito";

                        if (!string.IsNullOrEmpty(this.uploadImagenProcuto.Nombre_imagen))
                        {
                            rpta = AttachedHelper.GuardarArchivo(this.uploadImagenProcuto.Nombre_imagen,
                                this.uploadImagenProcuto.Ruta_origen);
                            if (rpta.Equals("OK"))
                                mensaje = "Producto guardado con exito";
                            else
                                mensaje = "Producto guardado con exito pero no se pudo guardar su imagen";
                        }

                        MensajesService.MensajeOk(mensaje);
                        product.Id_producto = id_producto;
                        this.OnProductSuccess?.Invoke(product, e);
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

        private void AsignarDatos(Productos product)
        {
            this.txtNombre.Text = product.Nombre_producto;
            this.txtPrecio.Text = product.Precio_producto.ToString("N2");
            this.txtDescripcion.Text = product.Descripcion_producto;

            this.ServiceList.LoadTipoProductos(this.listaTipoProductos);
            this.listaTipoProductos.SelectedValue = product.Id_tipo_producto;
        }

        private bool _isEditar;
        private Productos _product;

        public Productos Producto
        {
            get => _product;
            set
            {
                _product = value;
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
