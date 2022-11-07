namespace Carvajal.Services.Client.Services
{
    public interface IProductoService
    {
        ICollection<Producto> Productos { get; set; }
        Producto Producto { get; set; }
        Response<object> Respuesta { get; set; }
        Task ObtenerProductos();
        Task<Response<Object>> InsertarProducto(Producto producto);
        Task<Producto> ObtenerProducto(int id);
        Task<Response<Object>> ActualizarProducto(Producto producto);
        Task<Response<Object>> EliminarProducto(int id);

    }
}
