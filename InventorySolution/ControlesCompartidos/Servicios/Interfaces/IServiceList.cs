using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesCompartidos.Interfaces
{
    public interface IServiceList
    {
        Task LoadTipoUsuarios(ComboBox c);
    }
}
