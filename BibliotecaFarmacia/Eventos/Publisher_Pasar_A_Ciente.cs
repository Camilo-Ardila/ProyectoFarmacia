using System;

namespace BibliotecaFarmacia.Eventos
{
    public delegate void MontoMinEventHandler(uint total_gastado);

    public class Publisher_Pasar_A_Cliente
    {
        const int valor_pasar = 1000000;

        // Declarar el evento
        public event MontoMinEventHandler evento_monto;

        // Método que informa del cambio y dispara el evento si se cumple la condición
        public void Informar_Cambio_A_Cliente(uint total_gastado)
        {
            try
            {
                if (total_gastado >= valor_pasar)
                {
                    if (evento_monto != null)
                    {
                        evento_monto.Invoke(total_gastado); // Dispara el evento
                    }
                    else
                    {
                        Console.WriteLine("No hay suscriptores al evento de cambio a cliente.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al informar cambio a cliente: " + ex.Message);
            }
        }
    }
}
