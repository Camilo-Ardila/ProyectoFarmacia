using Microsoft.AspNetCore.Mvc;
using MVC.Services;
using BibliotecaFarmacia.Clases;

namespace MVC.Controllers
{
    public class M_VentaController : Controller
    {
        private readonly M_VentaService _ventaService;

        public M_VentaController()
        {
            _ventaService = new M_VentaService();
        }

        // GET: /Venta/
        public IActionResult Index()
        {
            var disponibles = _ventaService.MostrarDisponibles();
            return View(disponibles);
        }

        // POST: /Venta/Agregar
        [HttpPost]
        public IActionResult Agregar(string nombreMedicamento)
        {
            var medicamento = Inventario.l_inventario
                .FirstOrDefault(m => m.nom_medicamento.ToLower() == nombreMedicamento.ToLower());

            if (medicamento != null)
            {
                _ventaService.AgregarAlCarrito(medicamento, 1); // por ahora, 1 unidad
            }

            return RedirectToAction("Index");
        }
    }
}
