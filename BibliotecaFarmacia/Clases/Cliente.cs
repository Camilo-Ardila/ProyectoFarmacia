using System;
using BibliotecaFarmacia.Eventos;

namespace BibliotecaFarmacia.Clases
{
    public class Cliente : Persona
    {
        public uint total_gastado;
        public uint ptos;
        const int div = 100000;
        const int eq = 1000;

        public Publisher_P_Acumulados notificacion_puntos;

        public Cliente(string nombre_persona, string cc, string telefono_persona, uint total_gastado = 0, uint ptos = 0, string tipo = "cliente")
            : base(nombre_persona, cc, telefono_persona, total_gastado, tipo)
        {
            try
            {
                Total_gastado = total_gastado;
                Ptos = ptos;

                // Instancia del publicador y suscripción al evento
                notificacion_puntos = new Publisher_P_Acumulados();
                notificacion_puntos.evento_ptos += EventHandler;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al inicializar Cliente: {ex.Message}");
            }
        }

        public uint Total_gastado
        {
            get => total_gastado;
            set => total_gastado = value;
        }

        public uint Ptos
        {
            get => ptos;
            set => ptos = value;
        }

        // Manejador del evento
        public void EventHandler(uint nuevosPuntos)
        {
            try
            {
                Console.WriteLine($"Cliente recibió puntos: {nuevosPuntos}");
                Ptos = nuevosPuntos;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en EventHandler: {ex.Message}");
            }
        }

        // Simulación de compra para generar puntos
        public void calcularptos(string cc, uint val_movimiento)
        {
            try
            {
                // Buscar a la persona con la cédula dada
                var persona = Farmacia.l_personas.Find(p => p.CC == cc);

                // Verificar si existe y es un Cliente
                if (persona is Cliente cliente)
                {
                    // Sumar el valor del movimiento al total gastado
                    cliente.Total_gastado += val_movimiento;

                    // Calcular puntos
                    uint puntosCalculados = (cliente.Total_gastado / div) * eq;

                    // Disparar el evento de puntos
                    cliente.notificacion_puntos.Informar_P_Acumulados(puntosCalculados);
                }
                else
                {
                    Console.WriteLine("No se encontró un cliente con esa cédula o no es un cliente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en calcularptos: {ex.Message}");
            }
        }

        // Aquí podrías incluir el override para aplicar descuento, con try-catch también si es necesario.
    }
}

