using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    class Laboratorio
    {

        string nombre_laboratorio = "";
        string telefono_laboratorio = "";
        byte min_long = 7, max_long = 10;
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

                if (value.Length < min_long || value.Length > max_long)
                    throw new Exception("El teléfono debe tener entre 7 y 10 números \n");

                if (!validaciones.IsDigitsOnly(telefono_laboratorio))
                    throw new Exception("El número de teléfono solo puede contener dígitos del 0 al 9 \n");

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
