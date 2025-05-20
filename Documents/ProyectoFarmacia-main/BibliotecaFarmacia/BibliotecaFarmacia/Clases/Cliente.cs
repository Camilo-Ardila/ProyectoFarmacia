using System;

namespace BibliotecaFarmacia.Clases
{
    public class Cliente : Persona
    {
        private uint total_gastado;
        private string ptos;

        // Evento: instancia del publicador
        private Publisher_P_Acumulados notificacion_puntos;

        public uint Total_gastado
        {
            get => total_gastado;
            set => total_gastado = value;
        }

        public string Ptos
        {
            get => ptos;
            set => ptos = value ?? "0";
        }

        public Cliente(string nombre_persona, string cc, string telefono_persona, uint total_gastado, string ptos)
            : base(nombre_persona, cc, telefono_persona)
        {
            Total_gastado = total_gastado;
            Ptos = ptos;

            // Instancia del publicador y suscripción al evento
            notificacion_puntos = new Publisher_P_Acumulados();
            notificacion_puntos.evento_ptos += EventHandler;
        }

        // Manejador del evento
        public void EventHandler(string nuevosPuntos)
        {
            Console.WriteLine($"Cliente recibió puntos: {nuevosPuntos}");
            Ptos = nuevosPuntos;
        }

        // Simulación de compra para generar puntos
        public void SimularCompra(uint montoCompra)
        {
            Total_gastado += montoCompra;

            // Regla: cada 100000 gastados equivale a 1000 puntos
            uint puntosCalculados = (Total_gastado / 100000) * 1000;

            // Disparar evento con nuevos puntos
            notificacion_puntos.Informar_P_Acumulados(puntosCalculados.ToString());

            public override double AplicarDescuento()
        {
            return 0.08;
        }
    }
    }
}
