namespace PresentacionInventory.Formularios.FormsProductos
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

    public partial class FrmProductos : Form
    {
        public IServiceList ServiceList { get; set; }
        public IServiceInventory ServiceInventory { get; set; }
        public FrmProductos()
        {
            InitializeComponent();

            this.ServiceList = ServiceDIHelper.GetService<IServiceList>();
            this.ServiceInventory = ServiceDIHelper.GetService<IServiceInventory>();

            this.btnAddProduct.Click += BtnAddProduct_Click;
            this.Load += FrmProductos_Load;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            this.LoadProducts("COMPLETO", string.Empty);
        }

        public async void LoadProducts(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                this.panelProducts.clearDataSource();

                var (rpta, ds) =
                    await this.ServiceInventory.BuscarProductos(tipo_busqueda, texto_busqueda);
                if (ds != null)
                {
                    DataTable dtUsuarios = ds.Tables[0];
                    List<UserControl> controls = new List<UserControl>();
                    foreach (DataRow row in dtUsuarios.Rows)
                    {
                        Productos pr = new Productos(row);
                        ProductoSmall productoSmall = new ProductoSmall
                        {
                            Producto = pr,
                        };
                        productoSmall.OnBtnEditClick += ProductoSmall_OnBtnEditClick;
                        productoSmall.OnBtnNextClick += ProductoSmall_OnBtnNextClick;
                        productoSmall.OnBtnPerfilClick += ProductoSmall_OnBtnPerfilClick;

                        controls.Add(productoSmall);
                    }
                    this.panelProducts.BackgroundImage = null;
                    this.panelProducts.AddArrayControl(controls);
                }
                else
                {
                    Image image = (Image)Resources.ResourceManager.GetObject("SIN_IMAGENES.jpg");
                    this.panelProducts.BackgroundImage = image;
                }
            }
            catch (Exception ex)
            {
                ErrorModel error = new(ex);
                error.CustomMessage = $"Form: {this.Name} | Método: LoadProducts() | ";
                MainViewModel.GetError(error);
            }
        }

        private void ProductoSmall_OnBtnPerfilClick(object sender, EventArgs e)
        {
           
        }

        private void ProductoSmall_OnBtnNextClick(object sender, EventArgs e)
        {
           
        }

        private void ProductoSmall_OnBtnEditClick(object sender, EventArgs e)
        {
           
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            FrmAddProduct frmAddProduct = new()
            {
                TopLevel = false,
                Dock = DockStyle.Fill,
                FormBorderStyle = FormBorderStyle.None,
            };
            frmAddProduct.OnProductSuccess += FrmAddProduct_OnProductSuccess;
            PoperContainer container = new(frmAddProduct);
            container.Show(this.btnAddProduct);
            frmAddProduct.Show();
        }

        private void FrmAddProduct_OnProductSuccess(object sender, EventArgs e)
        {
            this.LoadProducts("COMPLETO", string.Empty);
        }
    }
}
