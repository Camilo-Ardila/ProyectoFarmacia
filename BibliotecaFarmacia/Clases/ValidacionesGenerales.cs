using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public class ValidacionesGenerales
    {

        public string mensaje_vacio = "Este campo no puede estar vacío \n";

        public string Mensaje_vacio { get => mensaje_vacio; set => mensaje_vacio = value; }

        public ValidacionesGenerales()
        {
            
        }


    }
}
