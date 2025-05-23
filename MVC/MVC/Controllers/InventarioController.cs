using Microsoft.AspNetCore.Mvc;
using MVC.Services;
using BibliotecaFarmacia.Clases;

namespace MVC.Controllers
{
    public class InventarioController : Controller
    {
        private readonly InventarioService _service;

        public InventarioController(InventarioService service)
        {
            _service = service;
        }

        // GET: Muestra todo el inventario (usando MostrarDisponibles)
        public IActionResult Index()
        {
            var inventario = _service.MostrarDisponibles();
            return View(inventario);
        }

        // POST: Elimina un medicamento por nombre
        [HttpPost]
        public IActionResult EliminarPorNombre(string nom_medicamento)
        {
            if (!string.IsNullOrWhiteSpace(nom_medicamento))
            {
                _service.Eliminar(nom_medicamento);
            }

            return RedirectToAction("Index");
        }

        // GET: Buscar medicamentos por nombre parcial
        [HttpGet]
        public IActionResult Buscar(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
            {
                return RedirectToAction("Index");
            }

            var resultados = _service.BuscarPorMedicamento(nombre);
            return View("Index", resultados); // Reutiliza la vista Index para mostrar resultados
        }

        // GET: Filtrar medicamentos por tipo
        [HttpGet]
        public IActionResult FiltrarPorTipo(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                return RedirectToAction("Index");
            }

            var resultados = _service.ListarTipo(tipo);
            return View("Index", resultados); // Reutiliza la vista Index para mostrar resultados
        }
    }
}

