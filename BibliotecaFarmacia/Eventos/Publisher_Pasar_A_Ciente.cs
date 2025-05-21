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
            if (total_gastado >= valor_pasar)
            {
                evento_monto?.Invoke(total_gastado); // Dispara el evento
            }
        }
    }
}
