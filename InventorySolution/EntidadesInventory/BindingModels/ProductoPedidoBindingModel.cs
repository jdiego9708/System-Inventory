namespace EntidadesInventory.BindingModels
{
    using EntidadesInventory.Models;

    public class ProductoPedidoBindingModel
    {
        public Detalle_pedido DetallePedido { get; set; }
        public int Id_producto {  get; set; }   
        public Productos Producto { get; set; }
    }
}
