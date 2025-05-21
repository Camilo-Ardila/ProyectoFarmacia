using System;
using BibliotecaFarmacia.Eventos;

namespace BibliotecaFarmacia.Clases
{
    public class Usuario : Persona
    {
        public Publisher_Pasar_A_Cliente notificacion_cliente;

        public Usuario(string nombre_persona, string cc,  string telefono_persona,uint total_gastado=0, string tipo = "usuario")
            : base(nombre_persona, cc, tipo,total_gastado, telefono_persona)
        {
        }

        
        // Método para suscribirse al evento
        public void Suscribirse(Publisher_Pasar_A_Cliente publisher)
        {
            notificacion_cliente = publisher;
            notificacion_cliente.evento_monto += EventHandler;
        }
        public void calcularptos(string cc, uint val_movimiento)
        {


            // Buscar a la persona con la cédula dada
            var persona = Farmacia.l_personas.Find(p => p.CC == cc);

            // Verificar si existe y es un Cliente
            if (persona is Usuario usuario)
            {
                // Sumar el valor del movimiento al total gastado
                usuario.Total_gastado += val_movimiento;

              

                
            }
            else
            {
                Console.WriteLine("No se encontró un cliente con esa cédula o no es un cliente.");
            }
        }

        // Método manejador del evento
        public void EventHandler(uint total_gastado)
        {
            Console.WriteLine($"¡Felicidades! Has gastado {total_gastado:C} y ahora puedes ser cliente.");
        }
    }
}


