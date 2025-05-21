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
            TimeSpan diferencia = l_medicamentos.Fecha_vencimiento - DateTime.Now;

            if (diferencia.TotalDays <= 30)
            {
                evento_fecha?.Invoke(l_medicamentos); // Dispara el evento
            }
        }
    }
}

