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
            return Inventario.l_inventario
                .Where(p => p.nom_medicamento.ToLower().Contains(nombreParcial.ToLower()))
                .ToList();
        }


        public List<Medicamento> ListarTipo(string tipo_med)
        {
            return Inventario.l_inventario
                .Where(p => p.Tipo_med.ToLower() == tipo_med.ToLower())
                .ToList();
        }

        // Método Eliminar solicitado
        public bool Eliminar(string nom_medicamento)
        {
            // Buscar el medicamento con ese nombre que tenga la fecha de vencimiento más próxima
            var medicamento = Inventario.l_inventario
                .Where(p => p.nom_medicamento.ToLower() == nom_medicamento.ToLower())
                .OrderBy(p => p.fecha_vencimiento)
                .FirstOrDefault();

            if (medicamento == null)
                return false;

            Inventario.l_inventario.Remove(medicamento);
            return true;
        }




    }
}

