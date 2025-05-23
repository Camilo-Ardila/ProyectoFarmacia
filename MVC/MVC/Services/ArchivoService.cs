using System.Collections.Generic;
using BibliotecaFarmacia.Clases;

namespace MVC.Services

{
    public class ArchivoService
    {

        public List<M_venta> MostrarVentas()
        {

            return Farmacia.l_ventas;

        }

        public List<M_compra> MostrarCompras()
        {
            return Farmacia.l_compras;

        }
    }
}
