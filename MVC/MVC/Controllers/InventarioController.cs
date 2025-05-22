using System;
using System.Collections.Generic;
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

        // GET: Muestra todo el inventario
        public IActionResult Index()
        {
            var inventario = Inventario.l_inventario;
            return View(inventario);
        }

        // POST: Elimina un medicamento por nombre y cantidad
        [HttpPost]
        [ActionName("EliminarPorNombre")]
        public IActionResult EliminarPorNombre(string nom_medicamento, int cantidad)
        {
            if (!string.IsNullOrWhiteSpace(nom_medicamento) && cantidad > 0)
            {
                _service.Eliminar(nom_medicamento, cantidad);
            }

            return RedirectToAction("Index");
        }

        // POST: Elimina múltiples medicamentos (cada uno con nombre y cantidad)
        [HttpPost]
        [ActionName("Eliminar")]
        public IActionResult EliminarMultiple([FromForm] Medicamento[] l_inventario)
        {
            foreach (var med in l_inventario)
            {
                if (!string.IsNullOrWhiteSpace(med.nom_medicamento) && med.Cantidad > 0)
                {
                    _service.Eliminar(med.nom_medicamento, med.Cantidad);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
