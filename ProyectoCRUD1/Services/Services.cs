using ProyectoCRUD1.Models;

namespace ProyectoCRUD1.Services
{
    public class Services : IServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "http://localhost:5120";

        public Services()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_url)
            };
        }

        public async Task<List<Producto>> GetAllProductos() 
            // Realiza una solicitud HTTP para obtener la lista deproductos
        {
            
            var response = await _httpClient.GetFromJsonAsync<List<Producto>>("api/Producto");
            return response;
        }

        public async Task<Producto> GetProducto(int IdProducto)
        {
            // Obtiene 1 solo producto por su Id
            var response = await _httpClient.GetFromJsonAsync<Producto>($"api/Producto/{IdProducto}");
            return response;
        }

        public async Task<Producto> CreateProducto(Producto producto)
        {
            // Realiza una solicitud HTTP POST para crear un producto
            var response = await _httpClient.PostAsJsonAsync("api/Producto", producto);
            return await response.Content.ReadFromJsonAsync<Producto>();
        }

        public async Task<Producto> UpdateProducto(int IdProducto, Producto producto)
        {
            // Realiza una solicitud HTTP PUT para modificar un producto
            var response = await _httpClient.PutAsJsonAsync($"api/Producto/{IdProducto}", producto);
            return await response.Content.ReadFromJsonAsync<Producto>();
        }

        public async void DeleteProducto(int IdProducto)
        {
            // Realiza una solicitud HTTP para eliminar un producto
            _httpClient.DeleteAsync($"api/Producto/{IdProducto}");
        }

    }
}

