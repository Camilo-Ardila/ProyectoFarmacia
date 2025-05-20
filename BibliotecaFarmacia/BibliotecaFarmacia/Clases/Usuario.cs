using System;

namespace BibliotecaFarmacia.Clases
{
    public class Usuario : Persona
    {
        private Publisher_Pasar_A_Cliente notificacion_cliente;

        public Usuario(string nombre_persona, string cc, string tipo, string telefono_persona)
            : base(nombre_persona, cc, tipo, telefono_persona)
        {
        }

        public override double AplicarDescuento()
        {
            return 0.05; // 5% de descuento
        }

        // Método para suscribirse al evento
        public void Suscribirse(Publisher_Pasar_A_Cliente publisher)
        {
            notificacion_cliente = publisher;
            notificacion_cliente.evento_monto += EventHandler;
        }

        // Método manejador del evento
        public void EventHandler(uint total_gastado)
        {
            Console.WriteLine($"¡Felicidades {NombrePersona}! Has gastado {total_gastado:C} y ahora puedes ser cliente.");
        }
    }
}


