using Microsoft.AspNetCore.Mvc;
using BibliotecaFarmacia.Clases;
using MVC.Services;

namespace MVC.Controllers
{
    public class PersonaController : Controller
    {
        private readonly PersonaService service;

        public PersonaController(PersonaService servicio)
        {
            service = servicio;
        }

        public IActionResult Index()
        {
            return View(service.ListarPersonas());
        }

        [HttpGet]
        public IActionResult BuscarPorNombre(string nombre)
        {
            var resultado = service.BuscarPorNombre(nombre);
            return View("Index", resultado);
        }

        [HttpGet]
        public IActionResult BuscarPorCC(string cc)
        {
            var resultado = service.BuscarPorCC(cc);
            return View("Index", resultado);
        }

        [HttpGet]
        public IActionResult ListarPorTipo(string tipo)
        {
            var resultado = service.ListarTipo(tipo);
            return View("Index", resultado);
        }

        [HttpGet]
        public IActionResult CrearUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearUsuario(string CC, string Nombre_persona, string Telefono_persona)
        {
            Usuario nuevo = new Usuario(CC, Nombre_persona, Telefono_persona);
            // Lógica para agregar el nuevo usuario a la lista o base de datos
            // ...
            TempData["Success"] = "Usuario creado exitosamente.";
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult CrearCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearCliente(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                service.CrearCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Actualizar(string cc, string nombre, string telefono)
        {
            service.ActualizarPersona(cc, nombre, telefono);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult PasarACliente(string cc)
        {
            service.Pasar_A_Cliente(cc);
            return RedirectToAction("Index");
        }
    }
}
