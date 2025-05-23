using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public class Laboratorio
    {

         public string nombre_laboratorio = "";
         public string telefono_laboratorio = "";
        public byte min_long = 7, max_long = 10;
        ValidacionesGenerales validaciones = new ValidacionesGenerales();

        public string Nombre_laboratorio { 
            get => nombre_laboratorio;
            set => nombre_laboratorio = value == null ? throw new Exception("El nombre del labpratorio no puede estar vacío \n") : value;
        }
        public string Telefono_laboratorio { 
            get => telefono_laboratorio;
            set
            {
                if (value == null) 
                    throw new Exception(validaciones.Mensaje_vacio);

                telefono_laboratorio = value;
            }
        }

        public Laboratorio(string nombre_laboratorio, string telefono_laboratorio)
        {
            Nombre_laboratorio = nombre_laboratorio;
            Telefono_laboratorio = telefono_laboratorio;
        }

       

    }
}
