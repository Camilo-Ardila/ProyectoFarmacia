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

        public string Nombre_laboratorio
        {
            get => nombre_laboratorio;
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new Exception("El nombre del laboratorio no puede estar vacío\n");
                    nombre_laboratorio = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al asignar nombre del laboratorio: {ex.Message}");
                }
            }
        }

        public string Telefono_laboratorio
        {
            get => telefono_laboratorio;
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new Exception(validaciones.Mensaje_vacio);
                    telefono_laboratorio = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al asignar teléfono del laboratorio: {ex.Message}");
                }
            }
        }

        public Laboratorio(string nombre_laboratorio, string telefono_laboratorio)
        {
            try
            {
                Nombre_laboratorio = nombre_laboratorio;
                Telefono_laboratorio = telefono_laboratorio;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear Laboratorio: {ex.Message}");
            }
        }
    }
}
