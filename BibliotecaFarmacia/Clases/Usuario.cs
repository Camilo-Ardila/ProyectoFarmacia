using System;
using BibliotecaFarmacia.Eventos;

namespace BibliotecaFarmacia.Clases
{
    public class Usuario : Persona
    {
        public Publisher_Pasar_A_Cliente notificacion_cliente;

        public Usuario(string nombre_persona, string cc, string telefono_persona, uint total_gastado = 0, string tipo = "usuario")
            : base(nombre_persona, cc, telefono_persona, total_gastado, tipo)
        {
            try
            {
                // Aquí podrían ir inicializaciones adicionales si se requieren
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear Usuario: " + ex.Message);
                throw;
            }
        }

        // Método para suscribirse al evento
        public void Suscribirse(Publisher_Pasar_A_Cliente publisher)
        {
            try
            {
                notificacion_cliente = publisher ?? throw new ArgumentNullException(nameof(publisher), "El publicador no puede ser nulo.");
                notificacion_cliente.evento_monto += EventHandler;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al suscribirse al evento: " + ex.Message);
                throw;
            }
        }

        public void calcularptos(string cc, uint val_movimiento)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cc))
                    throw new ArgumentException("La cédula no puede estar vacía.");

                var persona = Farmacia.l_personas.Find(p => p.CC == cc);

                if (persona is Usuario usuario)
                {
                    usuario.Total_gastado += val_movimiento;
                }
                else
                {
                    Console.WriteLine("No se encontró un cliente con esa cédula o no es un cliente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en calcularptos: " + ex.Message);
                throw;
            }
        }

        // Método manejador del evento
        public void EventHandler(uint total_gastado)
        {
            try
            {
                Console.WriteLine($"¡Felicidades! Has gastado {total_gastado:C} y ahora puedes ser cliente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el manejador de evento: " + ex.Message);
            }
        }
    }
}


