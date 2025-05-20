using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    class Farmacia
    {
        public static List<M_compra> l_compras = new List<M_compra>();
        public static List<M_venta> l_ventas = new List<M_venta>();
        public static Dictionary<string, uint> inventario = new Dictionary<string, uint>();

    } 
}
