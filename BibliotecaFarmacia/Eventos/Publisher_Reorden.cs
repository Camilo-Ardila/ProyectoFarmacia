using System;
using BibliotecaFarmacia.Clases;

namespace BibliotecaFarmacia.Eventos
{
    public delegate void DelegadoExistencias(Medicamento medicamento);

    public class Publisher_Reorden
    {
        // Evento que será disparado cuando queden 10 o menos unidades
        public event DelegadoExistencias evento_existencias;

        // Método que verifica si es necesario disparar el evento
        public void Informar_reorden(Medicamento l_medicamentos)
        {
            if (l_medicamentos.Cantidad <= 10)
            {
                evento_existencias?.Invoke(l_medicamentos); // Disparar evento
            }
        }
    }
}
