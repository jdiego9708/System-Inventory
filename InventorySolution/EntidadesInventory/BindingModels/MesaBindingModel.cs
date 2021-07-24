namespace EntidadesInventory.BindingModels
{
    using EntidadesInventory.Models;

    public class MesaBindingModel
    {
        public string Nombre_mesa { get; set; }
        public string Estado_mesa { get; set; }
        public Pedidos Pedido { get; set; }
    }
}
