using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaFarmacia.Clases;

namespace MVC.Services
{
    public class InventarioService
    {

        public List<Medicamento> MostrarDisponibles()
        {
            List<Medicamento> l_inventario = Inventario.l_inventario;

            return l_inventario;
        }

        public List<Medicamento> BuscarPorMedicamento(string nombreParcial)
        {
            var medicamentosEncontrados = Inventario.l_inventario
                .Where(p => p.nom_medicamento.ToLower().Contains(nombreParcial.ToLower()))
                .ToList();

            return medicamentosEncontrados;
        }

        public List<Medicamento> ListarTipo(string tipo_med)
        {
            return Inventario.l_inventario
                .Where(p => p.Tipo_med.ToLower() == tipo_med.ToLower())
                .ToList();
        }

        // Método Eliminar solicitado
        public bool Eliminar(string nom_medicamento, int cantidadAEliminar)
        {
            var medicamentos = Inventario.l_inventario
                .Where(p => p.nom_medicamento.ToLower() == nom_medicamento.ToLower())
                .OrderBy(p => p.fecha_vencimiento)
                .ToList();

            int cantidadEliminada = 0;

            foreach (var med in medicamentos)
            {
                if (cantidadEliminada >= cantidadAEliminar)
                    break;

                int unidadesRestantes = cantidadAEliminar - cantidadEliminada;

                if (med.Cantidad <= unidadesRestantes)
                {
                    cantidadEliminada += med.Cantidad;
                    Inventario.l_inventario.Remove(med);
                }
                else
                {
                    med.Cantidad -= (ushort)unidadesRestantes;
                    cantidadEliminada += unidadesRestantes;
                }
            }

            return cantidadEliminada == cantidadAEliminar;
        }

    }
}

