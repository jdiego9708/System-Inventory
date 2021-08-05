using PresentacionInventory;
using PresentacionRestaurant.ServicesRestaurant;
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
        public FrmMesas()
        {
            InitializeComponent();
            this.Load += FrmMesas_Load;
        }

        private void FrmMesas_Load(object sender, EventArgs e)
        {
            bool isDomicilio = ConfigRestaurant.Default.IsModuloDomicilio;
            this.btnDomicilios.Visible = isDomicilio;
        }

        public void LoadMesas()
        {
            try
            {
                int cantidad_mesas = ConfigRestaurant.Default.CantidadMesas;

            }
            catch (Exception ex)
            {
                MensajesService.MensajeErrorCompleto(this.Name, "LoadMesas()",
                    "Hubo un error cargando las mesas", ex.Message);
            }
        }
    }
}
