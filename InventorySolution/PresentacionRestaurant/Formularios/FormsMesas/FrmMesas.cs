using EntidadesInventory.BindingModels;
using EntidadesInventory.Helpers;
using EntidadesInventory.Models;
using PresentacionRestaurant.Properties;
using PresentacionRestaurant.ServicesRestaurant;
using ServiceInventory.Interfaces;
using ServiceInventory.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionRestaurant.Formularios.FormsMesas
{
    public partial class FrmMesas : Form
    {
        public IServiceInventory ServiceInventory { get; set; }
        public FrmMesas()
        {
            this.ServiceInventory = ServiceDIHelper.GetService<IServiceInventory>();

            InitializeComponent();
            this.Load += FrmMesas_Load;
        }

        public event EventHandler OnError;

        private void FrmMesas_Load(object sender, EventArgs e)
        {
            bool isDomicilio = ConfigRestaurant.Default.IsModuloDomicilio;
            this.btnDomicilios.Visible = isDomicilio;
            this.LoadMesas();
        }

        public async void LoadMesas()
        {
            try
            {
                List<Pedidos> pedidosPendientes = new();
                var (rpta, ds) =
                    await this.ServiceInventory.BuscarPedidos("PENDIENTE FECHA", DateTime.Now.ToString("yyyy-MM-dd"));
                if (ds != null)
                {
                    DataTable dtPedidos = ds.Tables[0];
                    pedidosPendientes = (from DataRow dr in dtPedidos.Rows
                                   select new Pedidos(dr)).ToList();
                }
            
                int cantidad_mesas = ConfigRestaurant.Default.CantidadMesas;
                int conteo_mesas = 0;
                List<MesaBindingModel> mesas = new();
                List<UserControl> controls = new();
                while (conteo_mesas <= cantidad_mesas)
                {
                    CustomButtonMesa customButtonMesa = new();
                    customButtonMesa.OnBtnMesaClick += CustomButtonMesa_OnBtnMesaClick;

                    Pedidos mesaPedido =
                        pedidosPendientes.Where(x => x.NumeroMesa == conteo_mesas && 
                        x.Tipo_pedido.Nombre_tipo.Equals("MESA")).ToList().FirstOrDefault();
                    if (mesaPedido == null)
                    {
                        MesaBindingModel mesa = new()
                        {
                            Nombre_mesa = $"Mesa {conteo_mesas}",
                            Estado_mesa = "DISPONIBLE",
                            Pedido = null,
                        };
                    }
                    else
                    {
                        string estado_mesa = mesaPedido.Estado_pedido;
                        MesaBindingModel mesa = new()
                        {
                            Nombre_mesa = $"Mesa {conteo_mesas}",
                            Estado_mesa = estado_mesa,
                            Pedido = mesaPedido,
                        };
                    }

                    conteo_mesas++;
                    controls.Add(customButtonMesa);
                }  
                
                if (controls.Count > 0)
                {
                    this.panelMesas.AddArrayControl(controls);
                    this.panelMesas.BackgroundImage = null;
                }
                else
                {
                    this.panelMesas.clearDataSource();
                    Image image = (Image)Resources.ResourceManager.GetObject("SIN IMAGENES.jpg");
                    this.panelMesas.BackgroundImage = image;
                }
            }
            catch (Exception ex)
            {
                ErrorModel error = new(ex);
                error.CustomMessage = $"Form: {this.Name} | Método: LoadMesas() | ";
                MainViewModel.GetError(error);
                this.OnError?.Invoke(error, null);
            }
        }

        private void CustomButtonMesa_OnBtnMesaClick(object sender, EventArgs e)
        {
            
        }
    }
}
