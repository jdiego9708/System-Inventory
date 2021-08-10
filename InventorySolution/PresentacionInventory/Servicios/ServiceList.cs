using PresentacionInventory.Servicios.Interfaces;
using ServiceInventory.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionInventory.Servicios
{
    public class ServiceList : IServiceList
    {         
        public ServiceInventoryMain ServiceInventory { get; set; }

        public ServiceList(ServiceInventoryMain serviceInventoryMain)
        {
            this.ServiceInventory = serviceInventoryMain;
        }

        public async Task LoadTipoUsuarios(ComboBox c)
        {
            (_, DataSet ds) = await this.ServiceInventory.LoadCatalogo("NOMBRE TIPO", "");
            if (ds != null)
            {
                c.DataSource = null;
                c.DataSource = ds.Tables[0];
                c.ValueMember = "Id_tipo";
                c.DisplayMember = "Catalogo";
            }
        }
    }
}
