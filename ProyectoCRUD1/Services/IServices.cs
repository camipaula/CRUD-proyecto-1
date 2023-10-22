using ProyectoCRUD1.Models;

namespace ProyectoCRUD1.Services
{
    public interface IServices
    {
        Task<List<Producto>> GetAllProductos();
        Task<Producto> GetProducto(int IdProducto);
        Task<Producto> CreateProducto(Producto producto);
        Task<Producto> UpdateProducto(int IdProducto, Producto producto);
        void DeleteProducto(int IdProducto);
       // Task<Producto> GetProducto(Producto producto);
    }
}
