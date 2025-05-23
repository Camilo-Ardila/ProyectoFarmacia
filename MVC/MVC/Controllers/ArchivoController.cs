using Microsoft.AspNetCore.Mvc;
using MVC.Services;
using MVC.ViewModels;
using System.Linq; // para Reverse()

namespace MVC.Controllers
{
    public class ArchivoController : Controller
    {
        private readonly ArchivoService archivoService = new ArchivoService();

        public ActionResult Index()
        {
            var ventasReversed = archivoService.MostrarVentas()?.AsEnumerable().Reverse().ToList();
            var comprasReversed = archivoService.MostrarCompras()?.AsEnumerable().Reverse().ToList();

            var viewModel = new ArchivoViewModel
            {
                Ventas = ventasReversed ?? new List<BibliotecaFarmacia.Clases.M_venta>(),
                Compras = comprasReversed ?? new List<BibliotecaFarmacia.Clases.M_compra>()
            };

            return View(viewModel);
        }
    }
}
