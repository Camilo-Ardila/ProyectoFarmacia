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
            service.CrearUsuario(nuevo); // <- Faltaba esta línea
            TempData["Success"] = "Usuario creado exitosamente.";
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult CrearCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CrearCliente(string CC, string Nombre_persona, string Telefono_persona)
        {
            Cliente nuevo = new Cliente(CC, Nombre_persona, Telefono_persona);
            service.CrearCliente(nuevo);
            TempData["Success"] = "Cliente creado exitosamente.";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Actualizar(string cc, string nombre, string telefono, string tipo)
        {
            var persona = Farmacia.l_personas.FirstOrDefault(p => p.CC == cc);
            if (persona != null)
            {
                persona.Nombre_persona = nombre;
                persona.Telefono_persona = telefono;
                persona.Tipo = tipo; // mantener el tipo
            }

            return RedirectToAction("Index");
        }






        [HttpPost]
        public IActionResult PasarACliente(string cc)
        {
            var persona = Farmacia.l_personas.FirstOrDefault(p => p.CC == cc);
            if (persona == null)
            {
                TempData["Success"] = "Persona no encontrada.";
            }
            else if (persona.Tipo.ToLower() != "usuario")
            {
                TempData["Success"] = "La persona ya es cliente.";
            }
            else if (persona.Total_gastado < service.limite_usuario)
            {
                TempData["Success"] = "El usuario no tiene suficiente gasto para ser cliente.";
            }
            else
            {
                service.Pasar_A_Cliente(cc);
                TempData["Success"] = "Usuario promovido a cliente.";
            }

            return RedirectToAction("Index");
        }

    }
}
