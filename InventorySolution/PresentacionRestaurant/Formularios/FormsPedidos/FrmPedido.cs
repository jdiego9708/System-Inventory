namespace PresentacionRestaurant.Formularios.FormsPedidos
{
    using ControlesCompartidos;
    using System.Windows.Forms;
    using System;
    using EntidadesInventory.Helpers;
    using EntidadesInventory.Models;
    using ServiceInventory.Interfaces;
    using System.Data;
    using ControlesCompartidos.CustomControls;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EntidadesInventory.BindingModels;
    using PresentacionRestaurant.Properties;
    using System.Drawing;
    using System.Linq;

    public partial class FrmPedido : Form
    {
        public IServiceInventory ServiceInventory { get; set; }
        public FrmPedido()
        {
            this.ServiceInventory = ServiceDIHelper.GetService<IServiceInventory>();

            InitializeComponent();

            ColorHelper.ChangeColorDefault(this);
            this.Load += FrmPedido_Load;
            this.rdPlatos.CheckedChanged += RdPlatos_CheckedChanged;
            this.rdBebidas.CheckedChanged += RdBebidas_CheckedChanged;
        }

        public void AddProduct(ProductoPedidoBindingModel product)
        {
            try
            {
                //Comprobar existencia del producto en los productos seleccionados
                if (this.ProductsSelected != null)
                {
                    List<ProductoPedidoBindingModel> findProductsSelected =
                        this.ProductsSelected.Where(x => x.Id_producto == product.Id_producto).ToList();
                    if (findProductsSelected.Count > 0)
                    {
                        ProductoPedidoBindingModel productSelected = findProductsSelected[0];
                        //productSelected.DetallePedido.Cantidad++;
                    }
                    else
                    {
                        this.ProductsSelected.Add(new ProductoPedidoBindingModel()
                        {
                            Producto = product.Producto,
                            Id_producto = product.Id_producto,
                            DetallePedido = product.DetallePedido,
                        });
                    }
                }

                //Comprobar existencia del producto en los productos nuevos seleccionados 
                if (this.ProductsAddSelected != null)
                {
                    List<ProductoPedidoBindingModel> findProductsSelected =
                        this.ProductsAddSelected.Where(x => x.Id_producto == product.Id_producto).ToList();
                    if (findProductsSelected.Count > 0)
                    {
                        ProductoPedidoBindingModel productSelected = findProductsSelected[0];
                        productSelected.DetallePedido.Cantidad++;
                    }
                    else
                    {
                        this.ProductsSelected.Add(new ProductoPedidoBindingModel()
                        {
                            Producto = product.Producto,
                            Id_producto = product.Id_producto,
                            DetallePedido = product.DetallePedido,
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorModel error = new(ex);
                error.CustomMessage = $"Form: {this.Name} | Método: AddProducts(ProductoPedidoBindingModel product) | ";
                MainViewModel.GetError(error);
                MensajesService.MensajeErrorCompleto(error);
            }
        }

        public void RemoveProduct(ProductoPedidoBindingModel product)
        {
            try
            {
                //Comprobar existencia del producto en los productos seleccionados
                if (this.ProductsSelected != null)
                {
                    List<ProductoPedidoBindingModel> findProductsSelected =
                        this.ProductsSelected.Where(x => x.Id_producto == product.Id_producto).ToList();
                    if (findProductsSelected.Count > 0)
                    {
                        ProductoPedidoBindingModel productSelected = findProductsSelected[0];
                        //productSelected.DetallePedido.Cantidad++;
                    }
                    else
                    {
                        this.ProductsSelected.Add(new ProductoPedidoBindingModel()
                        {
                            Producto = product.Producto,
                            Id_producto = product.Id_producto,
                            DetallePedido = product.DetallePedido,
                        });
                    }
                }

                //Comprobar existencia del producto en los productos nuevos seleccionados 
                if (this.ProductsAddSelected != null)
                {
                    List<ProductoPedidoBindingModel> findProductsSelected =
                        this.ProductsAddSelected.Where(x => x.Id_producto == product.Id_producto).ToList();
                    if (findProductsSelected.Count > 0)
                    {
                        ProductoPedidoBindingModel productSelected = findProductsSelected[0];
                        productSelected.DetallePedido.Cantidad++;
                    }
                    else
                    {
                        this.ProductsSelected.Add(new ProductoPedidoBindingModel()
                        {
                            Producto = product.Producto,
                            Id_producto = product.Id_producto,
                            DetallePedido = product.DetallePedido,
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                ErrorModel error = new(ex);
                error.CustomMessage = $"Form: {this.Name} | Método: AddProducts(ProductoPedidoBindingModel product) | ";
                MainViewModel.GetError(error);
                MensajesService.MensajeErrorCompleto(error);
            }
        }

        private async void RdBebidas_CheckedChanged(object sender, EventArgs e)
        {
            await this.LoadCategorias("CATALOGO PADRE", "TIPOS BEBIDAS");
        }

        private async void RdPlatos_CheckedChanged(object sender, EventArgs e)
        {
           await this.LoadCategorias("CATALOGO PADRE", "TIPOS PLATOS");
        }

        private async void FrmPedido_Load(object sender, EventArgs e)
        {
            this.rdPlatos.Checked = true;
            this.RdPlatos_CheckedChanged(sender, e);

            if (this.Categorias != null)
                await this.LoadProductos("ID TIPO PRODUCTO", this.Categorias[0].Id_tipo.ToString());
        }

        private async Task LoadProductos(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                var (rpta, dsProducts) =
                   await this.ServiceInventory.BuscarProductos(tipo_busqueda, texto_busqueda);

                this.panelBusqueda.clearDataSource();

                if (dsProducts != null)
                {
                    DataTable dtProducts = dsProducts.Tables[0];
                    List<UserControl> controls = new(); 
                    foreach(DataRow row in dtProducts.Rows)
                    {
                        Productos producto = new(row);
                        ProductoSmall productoSmall = new()
                        {
                            Producto = new ProductoPedidoBindingModel
                            { 
                                Producto = producto,
                            },
                        };
                        controls.Add(productoSmall);
                    }
                    this.panelBusqueda.BackgroundImage = null;
                    this.panelBusqueda.AddArrayControl(controls);
                }
                else
                {
                    Image image = (Image)Resources.ResourceManager.GetObject("SIN_IMAGENES.jpg");
                    this.panelBusqueda.BackgroundImage = image;
                }
            }
            catch (Exception ex)
            {
                ErrorModel error = new(ex);
                error.CustomMessage = $"Form: {this.Name} | Método: LoadProductosSelected() | ";
                MainViewModel.GetError(error);
                MensajesService.MensajeErrorCompleto(error);
            }
        }

        private void LoadProductosSelected(List<ProductoPedidoBindingModel> products)
        {
            try
            {
                List<UserControl> controls = new List<UserControl>();

                foreach(ProductoPedidoBindingModel product in products)
                {
                    ProductoSmall productoSmall = new()
                    {
                        Producto = product,
                    };
                    productoSmall.OnAddButtonClick += ProductoSmall_OnAddButtonClick;
                    productoSmall.OnRemoveButtonClick += ProductoSmall_OnRemoveButtonClick;
                    productoSmall.OnCommentButtonClick += ProductoSmall_OnCommentButtonClick;

                    controls.Add(productoSmall);
                }

                this.panelProductos.BackgroundImage = null;
                this.panelProductos.AddArrayControl(controls);
            }
            catch (Exception ex)
            {
                ErrorModel error = new(ex);
                error.CustomMessage = $"Form: {this.Name} | Método: LoadProductosSelected() | ";
                MainViewModel.GetError(error);
                MensajesService.MensajeErrorCompleto(error);
            }
        }

        private void ProductoSmall_OnCommentButtonClick(object sender, EventArgs e)
        {
            ProductoPedidoBindingModel product = (ProductoPedidoBindingModel)sender;
        }

        private void ProductoSmall_OnRemoveButtonClick(object sender, EventArgs e)
        {
            ProductoPedidoBindingModel product = (ProductoPedidoBindingModel)sender;
            this.RemoveProduct(product);
        }

        private void ProductoSmall_OnAddButtonClick(object sender, EventArgs e)
        {
            ProductoPedidoBindingModel product = (ProductoPedidoBindingModel)sender;
            this.AddProduct(product);
        }

        private async Task LoadCategorias(string tipo_busqueda, string texto_busqueda)
        {
            try
            {
                var (rpta, dsCategorias) = 
                    await this.ServiceInventory.BuscarCatalogo(tipo_busqueda, texto_busqueda);

                this.panelCategorias.clearDataSource();

                if (dsCategorias != null)
                {
                    DataTable dtCategorias = dsCategorias.Tables[0];
                    List<UserControl> controls = new();
                    this.Categorias = new();
                    foreach(DataRow row in dtCategorias.Rows)
                    {
                        Catalogo ca = new(row);
                        CategoriaSmall categoria = new(ca);
                        categoria.OnBtnCatalogo += Categoria_OnBtnCatalogo;
                        controls.Add(categoria);
                        this.Categorias.Add(ca);
                    }
                    this.panelCategorias.AddArrayControl(controls);
                }
            }
            catch (Exception ex)
            {
                ErrorModel error = new(ex);
                error.CustomMessage = $"Form: {this.Name} | Método: LoadProductosSelected() | ";
                MainViewModel.GetError(error);
                MensajesService.MensajeErrorCompleto(error);
            }
        }

        private async void Categoria_OnBtnCatalogo(object sender, EventArgs e)
        {
            Catalogo catalogo = (Catalogo)sender;
            await this.LoadProductos("ID TIPO PRODUCTO", catalogo.Id_tipo.ToString());
        }

        private async void AsignarDatos(Pedidos pedido)
        {
            //Obtener los detalles del pedido
            var (_, ds) = 
                await this.ServiceInventory.BuscarPedidos("DETALLE ID PEDIDO", pedido.Id_pedido.ToString());
            if (ds != null)
            {
                List<ProductoPedidoBindingModel> listProducts = new();
                DataTable dtDetalle = ds.Tables[0];
                foreach (DataRow row in dtDetalle.Rows)
                {
                    Detalle_pedido detalle = new(row);
                    ProductoPedidoBindingModel productoPedido = new()
                        { 
                            DetallePedido = detalle,
                        };
                    listProducts.Add(productoPedido);
                }
                this.ProductsSelected = listProducts;
                this.LoadProductosSelected(listProducts);
            }          
            this.label1.Text = $"Agregar/Remover productos | {pedido.Tipo_pedido}";
        }

        public event EventHandler OnBtnPedidoSucess;

        public List<ProductoPedidoBindingModel> ProductsSelected { get; set; }
        public List<ProductoPedidoBindingModel> ProductsAddSelected { get; set; }
        public List<Catalogo> Categorias { get; set; }

        private Pedidos _pedido;

        public Pedidos Pedido
        {
            get => _pedido;
            set
            {
                _pedido = value;
                this.AsignarDatos(value);
            }
        }
    }
}
