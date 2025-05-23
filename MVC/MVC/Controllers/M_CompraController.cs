using BibliotecaFarmacia.Clases;
using Microsoft.AspNetCore.Mvc;
using MVC.Services;

namespace MVC.Controllers
{
    public class M_CompraController : Controller
    {

        private static M_CompraService service;

        public M_CompraController(M_CompraService servicio)
        {
            service = servicio;
        }

        public IActionResult Index()
        {
            return View(service.MostrarDisponibles());
        }

        [HttpGet]
        public IActionResult BuscarPorNombre(string nombre)
        {
            var resultado = service.FiltrarPorNombre(nombre);
            return View("Index", resultado);
        }

        [HttpGet]
        public IActionResult BuscarPorTipo(string tipo)
        {
            var resultado = service.FiltrarPorTipo(tipo);
            return View("Index", resultado);
        }

        [HttpPost]
        public IActionResult AgregarOpcion(string tipo, string nombre, string laboratorio, DateTime fecha_vencimiento,
                                   uint precio_compra, ushort cantidad, ushort miligramos = 0,
                                   ushort mililitros = 0, string relleno = null, string envase = null)
        {
            Medicamento nuevo;

            switch (tipo.ToLower())
            {
                case "pasta":
                    nuevo = new M_pasta(nombre, laboratorio, fecha_vencimiento, precio_compra, cantidad, miligramos);
                    break;
                case "capsulas":
                    if (relleno != "gel" && relleno != "polvo")
                        return BadRequest("Relleno inválido. Debe ser 'gel' o 'polvo'.");
                    nuevo = new M_capsula(nombre, laboratorio, fecha_vencimiento, precio_compra, cantidad, miligramos, relleno);
                    break;
                case "liquido":
                    if (envase != "plastico" && envase != "vidrio")
                        return BadRequest("Envase inválido. Debe ser 'plastico' o 'vidrio'.");
                    nuevo = new M_liquido(nombre, laboratorio, fecha_vencimiento, precio_compra, cantidad, mililitros, envase);
                    break;
                default:
                    return BadRequest("Tipo de medicamento no reconocido.");
            }

            service.AgregarOpción(nuevo);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult EliminarOpcion(string nombre)
        {
            service.EliminarOpción(nombre);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ComprarMedicamentos(string nombre, ushort cantidad)
        {
            var medicamento = Farmacia.l_disponibles.FirstOrDefault(m => m.Nom_medicamento.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (medicamento == null)
            {
                return NotFound("Medicamento no encontrado.");
            }

            M_compra compra = new M_compra(medicamento, medicamento.Precio_compra * cantidad, cantidad);

            service.ComprarMedicamentos(medicamento, compra);

            TempData["Success"] = "Medicamentos agregados al inventario exitosamente";

            return RedirectToAction("Index");
        }


    }
}