using BibliotecaFarmacia.Clases;

namespace MVC.Services
{
    public class M_CompraService
    {
        
        public List<Medicamento> MostrarDisponibles()
        {
            List<Medicamento> l_disponibles = Farmacia.l_disponibles;

            return l_disponibles;
        }

        public List<Medicamento> FiltrarPorNombre(string nombre)
        {

            var medsEncontrados = Farmacia.l_disponibles
                 .Where(p => p.Nom_medicamento.ToLower().Contains(nombre.ToLower()))
                 .ToList();

            return medsEncontrados;
        }

        public List<Medicamento> FiltrarPorTipo(string tipo)
        {

            var medsEncontrados = Farmacia.l_disponibles
                 .Where(p => p.Tipo_med.ToLower().Contains(tipo.ToLower()))
                 .ToList();

            return medsEncontrados;
        }

        public bool Eliminar(string nom_medicamento, int cantidadAEliminar)
        {
            var ahora = DateTime.Now;

            // Filtrar medicamentos por nombre, ordenados por vencimiento
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
                    // Eliminar completamente este objeto
                    cantidadEliminada += med.Cantidad;
                    Inventario.l_inventario.Remove(med);
                }
                else
                {
                    // Solo restar la cantidad necesaria y dejar el objeto
                    med.Cantidad -= (ushort) unidadesRestantes;
                    cantidadEliminada += unidadesRestantes;
                }
            }

            return cantidadEliminada == cantidadAEliminar;
        }

    }
}
