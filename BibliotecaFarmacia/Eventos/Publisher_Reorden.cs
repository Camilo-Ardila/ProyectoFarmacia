using System;
using BibliotecaFarmacia.Clases;

namespace BibliotecaFarmacia.Eventos
{
    public delegate void DelegadoExistencias(Medicamento medicamento);

    public class Publisher_Reorden
    {
        public event DelegadoExistencias evento_existencias;

        public void Informar_reorden(List<Medicamento> medicamentos)
        {
            // Construir agrupación primero
            Farmacia.ConstruirInventarioAgrupado();

            foreach (var (medicamento, cantidad) in Farmacia.inventario)
            {
                if (cantidad <= 10)
                {
                    evento_existencias?.Invoke(medicamento);
                }
            }
        }
    }

}
