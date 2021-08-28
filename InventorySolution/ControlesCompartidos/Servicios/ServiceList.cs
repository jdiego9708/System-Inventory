using ServiceInventory.Interfaces;

namespace ControlesCompartidos
{
    using ControlesCompartidos.Interfaces;
    using EntidadesInventory.Helpers;
    using ServiceInventory.Services;
    using System.Data;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public class ServiceList : IServiceList
    {         
        public IServiceInventory ServiceInventory { get; set; }

        public ServiceList()
        {
            this.ServiceInventory = ServiceDIHelper.GetService<IServiceInventory>();
        }

        public async Task LoadTipoUsuarios(ComboBox c)
        {
            (_, DataSet ds) = await this.ServiceInventory.LoadCatalogo("CATALOGO PADRE", "TIPO DE USUARIOS");
            if (ds != null)
            {
                c.DataSource = null;
                c.DataSource = ds.Tables[0];
                c.ValueMember = "Id_tipo";
                c.DisplayMember = "Nombre_tipo";
            }
        }
    }
}
