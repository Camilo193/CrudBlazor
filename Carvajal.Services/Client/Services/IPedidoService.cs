namespace Carvajal.Services.Client.Services
{
    public interface IPedidoService
    {
        ICollection<Pedido> Pedidos { get; set; }
        Pedido Pedido { get; set; }
        Response<object> Respuesta { get; set; }
        Task ObtenerPedidos();
        Task<Response<Object>> InsertarPedido(Pedido pedido);
        Task<Pedido> ObtenerPedido(int id);
        Task<Response<Object>> ActualizarPedido(Pedido pedido);
        Task<Response<Object>> EliminarPedido(int id);
    }
}
