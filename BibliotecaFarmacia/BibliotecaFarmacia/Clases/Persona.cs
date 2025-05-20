using System;
using BibliotecaFarmacia.Interfaces; // Asegúrate de importar la interfaz

namespace BibliotecaFarmacia.Clases
{
    public class Persona : IAplicarDescuento
    {
        private string nombre_persona = "";
        private string cc = "";
        private string telefono_persona = "";
        private ValidacionesGenerales validaciones = new ValidacionesGenerales();
        private byte min_long = 7, max_long = 10;

        public string Nombre_persona
        {
            get => nombre_persona;
            set => nombre_persona = value == null ? throw new Exception("El nombre de la persona no puede estar vacío \n") : value;
        }

        public string Telefono_persona
        {
            get => telefono_persona;
            set
            {
                if (value == null)
                    throw new Exception(validaciones.Mensaje_vacio);

                if (value.Length < min_long || value.Length > max_long)
                    throw new Exception("El teléfono debe tener entre 7 y 10 números \n");

                if (!validaciones.IsDigitsOnly(value))
                    throw new Exception("El número de teléfono solo puede contener dígitos del 0 al 9 \n");

                telefono_persona = value;
            }
        }

        public string CC
        {
            get => cc;
            set
            {
                if (value == null)
                    throw new Exception(validaciones.Mensaje_vacio);

                if (value.Length < min_long || value.Length > max_long)
                    throw new Exception("La cédula debe tener entre 7 y 10 números \n");

                if (!validaciones.IsDigitsOnly(value))
                    throw new Exception("La cédula solo puede contener dígitos del 0 al 9 \n");

                cc = value;
            }
        }

        public Persona(string nombre_persona, string cc, string telefono_persona)
        {
            Nombre_persona = nombre_persona;
            CC = cc;
            Telefono_persona = telefono_persona;
        }

        // Método de la interfaz
        public virtual double AplicarDescuento()
        {
            return 0.0; // Por defecto no hay descuento
        }

        // Propiedad con el total aplicado con descuento
        public virtual double TotalConDescuento(uint total_gastado)
        {
            return total_gastado - (total_gastado * AplicarDescuento());
        }
    }
}
