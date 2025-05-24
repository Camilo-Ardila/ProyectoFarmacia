using System;
using BibliotecaFarmacia.Interfaces;

namespace BibliotecaFarmacia.Clases
{
    public class Persona
    {
        public string tipo = "";
        public string nombre_persona = "";
        public string cc = "";
        public string telefono_persona = "";
        public ValidacionesGenerales validaciones = new ValidacionesGenerales();
        public byte min_long = 7, max_long = 15;
        private uint total_gastado = 0;

        // Constructor vacío requerido por ASP.NET Core
        public Persona()
        {
        }

        // Constructor adicional con manejo de excepciones
        public Persona(string nombre_persona, string cc, string telefono_persona, uint total_gastado, string tipo)
        {
            try
            {
                Nombre_persona = nombre_persona;
                CC = cc;
                Telefono_persona = telefono_persona;
                Total_gastado = total_gastado;
                Tipo = tipo;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al construir Persona: " + ex.Message);
                throw;
            }
        }

        public string Nombre_persona
        {
            get => nombre_persona;
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new Exception("El nombre de la persona no puede estar vacío.");
                    nombre_persona = value.Trim();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en Nombre_persona: " + ex.Message);
                    throw;
                }
            }
        }

        public string Telefono_persona
        {
            get => telefono_persona;
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new Exception(validaciones.Mensaje_vacio);

                    if (value.Length < min_long || value.Length > max_long)
                        throw new Exception("El teléfono debe tener entre 7 y 10 números.");

                    telefono_persona = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en Telefono_persona: " + ex.Message);
                    throw;
                }
            }
        }

        public string CC
        {
            get => cc;
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new Exception(validaciones.Mensaje_vacio);

                    cc = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en CC: " + ex.Message);
                    throw;
                }
            }
        }

        public uint Total_gastado
        {
            get => total_gastado;
            set
            {
                try
                {
                    total_gastado = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en Total_gastado: " + ex.Message);
                    throw;
                }
            }
        }

        public string Tipo
        {
            get => tipo;
            set
            {
                try
                {
                    tipo = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en Tipo: " + ex.Message);
                    throw;
                }
            }
        }
    }
}
