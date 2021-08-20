using ServiceInventory.Interfaces;

namespace ControlesCompartidos
{
    using ControlesCompartidos.Interfaces;
    using ServiceInventory.Services;
    using System.Data;
    using System.Threading.Tasks;
    using System.Windows.Forms;

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
