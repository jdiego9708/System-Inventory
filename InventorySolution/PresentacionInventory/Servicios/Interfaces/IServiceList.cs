using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionInventory.Servicios.Interfaces
{
    public interface IServiceList
    {
        Task LoadTipoUsuarios(ComboBox c);
    }
}
