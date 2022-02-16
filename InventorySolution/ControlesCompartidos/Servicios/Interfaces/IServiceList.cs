using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesCompartidos.Interfaces
{
    public interface IServiceList
    {
        Task LoadTipoUsuarios(ComboBox c);
        Task LoadTipoProductos(ComboBox c);
        Task LoadListGenericXIdPadre(ComboBox c, int id_catalogo);
    }
}
