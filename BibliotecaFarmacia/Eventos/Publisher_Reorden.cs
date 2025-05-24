using System;
using System.Collections.Generic;
using BibliotecaFarmacia.Clases;

namespace BibliotecaFarmacia.Eventos
{
    public delegate void DelegadoExistencias(Medicamento medicamento);

    public class Publisher_Reorden
    {
        public event DelegadoExistencias evento_existencias;

        public void Informar_reorden(List<Medicamento> medicamentos)
        {
            try
            {
                // Construir agrupación primero
                Farmacia.ConstruirInventarioAgrupado();

                foreach (var (medicamento, cantidad) in Farmacia.inventario)
                {
                    try
                    {
                        if (cantidad <= 10)
                        {
                            if (evento_existencias != null)
                            {
                                evento_existencias.Invoke(medicamento);
                            }
                            else
                            {
                                Console.WriteLine($"No hay suscriptores para el evento de reorden del medicamento: {medicamento.Nom_medicamento}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al manejar el evento para el medicamento '{medicamento.Nom_medicamento}': {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al procesar la notificación de reorden: " + ex.Message);
            }
        }
    }
}

}
