using Microsoft.AspNetCore.Mvc;
using BibliotecaFarmacia.Clases;
using MVC.Services;

namespace MVC.Controllers
{
    public class M_VentaController : Controller
    {
        private readonly M_VentaService ventaService;

        public M_VentaController(M_VentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        public IActionResult Index()
        {
            var inventario = ventaService.MostrarDisponibles();
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

        [HttpPost]
        public IActionResult BuscarPorNombre(string nombreParcial)
        {
            var resultados = ventaService.BuscarPorMedicamento(nombreParcial);
            return View("Index", resultados);
        }

        [HttpPost]
        public IActionResult BuscarPorTipo(string tipoParcial)
        {
            var resultados = ventaService.BuscarPorTipo(tipoParcial);
            return View("Index", resultados);
        }

        [HttpPost]
        public IActionResult BuscarPersona(string cc)
        {
            ventaService.AsignarCC(cc);
            TempData["Mensaje"] = "Cédula registrada. Si existe, se usará en las operaciones.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AgregarAlCarrito(string nom_medicamento, uint cantidad)
        {
            var cc = ventaService.cedulaActual;

            if (string.IsNullOrEmpty(cc))
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
            var venta = new M_venta(medicamento, valor, cantidad, cc);

            ventaService.AgregarAlCarrito(medicamento, venta);
            TempData["Success"] = $"{venta.Medicamento_objeto.Nom_medicamento} agregado al carrito exitosamente.";
            return RedirectToAction("Index");
        }

        public IActionResult Carrito()
        {
            return View(carrito);
        }

        [HttpPost]
        public IActionResult EliminarDelCarrito(string nom_medicamento)
        {
            var carrito = ventaService.MostrarCarrito();
            var item = carrito.FirstOrDefault(i => i.Item1.Nom_medicamento == nom_medicamento);

            if (item.Item1 != null)
                ventaService.carrito.Remove(item);

            return RedirectToAction("Carrito");
        }

        [HttpPost]
        public IActionResult Comprar()
        {
            ventaService.CarritoCompras();
            TempData["Mensaje"] = "Compra realizada exitosamente.";
            return RedirectToAction("Index");
        }
    }
}
