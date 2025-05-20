using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    internal class ValidacionesGenerales
    {

        string mensaje_vacio = "Este campo no puede estar vacío \n";

        public string Mensaje_vacio { get => mensaje_vacio; set => mensaje_vacio = value; }

        public ValidacionesGenerales()
        {
            
        }

        internal bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }


    }
}
