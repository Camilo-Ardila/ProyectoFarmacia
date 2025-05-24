using System;
using BibliotecaFarmacia.Clases;

namespace BibliotecaFarmacia.Eventos
{
    public delegate void DelegadoFecha(Medicamento medicamento);

    public class Publisher_Vencimiento
    {
        // Evento que será disparado cuando quede un mes o menos
        public event DelegadoFecha evento_fecha;

        public void Informar_Vencimiento(Medicamento l_medicamentos)
        {
            try
            {
                TimeSpan diferencia = l_medicamentos.Fecha_vencimiento - DateTime.Now;

                if (diferencia.TotalDays <= 30)
                {
                    if (evento_fecha != null)
                    {
                        evento_fecha.Invoke(l_medicamentos); // Dispara el evento
                    }
                    else
                    {
                        Console.WriteLine($"No hay suscriptores para el evento de vencimiento del medicamento: {l_medicamentos.Nom_medicamento}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al verificar vencimiento del medicamento '{l_medicamentos?.Nom_medicamento}': {ex.Message}");
            }
        }
    }
}
