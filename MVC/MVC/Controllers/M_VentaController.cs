using Microsoft.AspNetCore.Mvc;
using BibliotecaFarmacia.Clases;
using MVC.Services;

namespace MVC.Controllers
{
    public class M_VentaController : Controller
    {
        private readonly M_VentaService ventaService;
        private static string cedulaActual = "";

        public M_VentaController(M_VentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        // Mostrar inventario general
        public IActionResult Index()
        {
            var inventario = ventaService.MostrarDisponibles();
            ViewBag.CC = cedulaActual;
            return View(inventario);
        }

        [HttpPost]
        public IActionResult ToggleDescuento()
        {
            bool descuentoActivo = ventaService.ToggleDescuento();

            TempData["DescuentoEstado"] = descuentoActivo ? "Activo" : "Inactivo";
            TempData["Color"] = descuentoActivo ? "green" : "red";

            return RedirectToAction("Index");
        }

        // Buscar persona por cédula
        [HttpPost]
        public IActionResult BuscarPersona(string cc)
        {
            var persona = Farmacia.l_personas.FirstOrDefault(p => p.CC == cc);
            if (persona != null)
            {
                cedulaActual = cc;
                TempData["Mensaje"] = $"Persona encontrada: {persona.Nombre_persona}";
            }
            else
            {
                TempData["Mensaje"] = "Persona no encontrada.";
            }

            return RedirectToAction("Index");
        }

        // Agregar al carrito desde inventario
        [HttpPost]
        public IActionResult AgregarAlCarrito(string nom_medicamento, uint cantidad)
        {
            if (string.IsNullOrEmpty(cedulaActual))
            {
                TempData["Mensaje"] = "Debe buscar primero a la persona.";
                return RedirectToAction("Index");
            }

            var inventario = ventaService.MostrarDisponibles();
            var item = inventario.FirstOrDefault(i => i.Item1.Nom_medicamento == nom_medicamento);

            if (item.Item2 < cantidad)
            {
                TempData["Mensaje"] = "No hay suficiente cantidad disponible.";
                return RedirectToAction("Index");
            }

            var medicamento = item.Item1;
            ulong valor = medicamento.Precio_venta * cantidad;
            var venta = new M_venta(medicamento, valor, cantidad, cedulaActual);

            ventaService.AgregarAlCarrito(medicamento, venta);

            return RedirectToAction("Index");
        }

        // Mostrar carrito
        public IActionResult Carrito()
        {
            var carrito = ventaService.MostrarCarrito();
            return View(carrito);
        }

        // Eliminar un artículo del carrito
        [HttpPost]
        public IActionResult EliminarDelCarrito(string nom_medicamento)
        {
            var carrito = ventaService.MostrarCarrito();
            var item = carrito.FirstOrDefault(i => i.Item1.Nom_medicamento == nom_medicamento);

            if (item.Item1 != null)
            {
                ventaService.carrito.Remove(item);
            }

            return RedirectToAction("Carrito");
        }

        // Finalizar compra
        [HttpPost]
        public IActionResult Comprar()
        {
            ventaService.CarritoCompras();
            TempData["Mensaje"] = "Compra realizada exitosamente.";
            return RedirectToAction("Index");
        }
    }
}
