using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoCRUD1.Models;
using System.Text.Json;
using System.Text;
using ProyectoCRUD1.Services;

public class ProductoController : Controller
    {
        private readonly IServices _Services;

        public ProductoController(IServices Services)
        {
            _Services = Services;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _Services.GetAllProductos();
            return View(productos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            await _Services.CreateProducto(producto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int IdProducto)
        {
            var producto = await _Services.GetProducto(IdProducto);
            if (producto != null) return View(producto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int IdProducto)
        {
            var producto = await _Services.GetProducto(IdProducto);
            if (producto != null) return View(producto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int IdProducto, Producto producto)
        {
            await _Services.UpdateProducto(IdProducto, producto);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int IdProducto)
        {
            _Services.DeleteProducto(IdProducto);
            return RedirectToAction("Index");
        }

    }

