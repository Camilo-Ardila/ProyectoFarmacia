using BibliotecaFarmacia.Clases;

namespace MVC.Services
{
    public class M_Venta_Service
    {

        public List<Medicamento> MostrarDisponibles()
        {
            List<Medicamento> l_inventario = Inventario.l_inventario;

            return l_inventario;
        }

        public List<Medicamento> ListarTipo(string tipo_med)
        {
            return Inventario.l_inventario
                .Where(p => p.Tipo_med.ToLower() == tipo_med.ToLower())
                .ToList();
        }
        public List<Medicamento> BuscarPorMedicamento(string nombreParcial)
        {
            var medicamentosEncontrados = Inventario.l_inventario
                .Where(p => p.nom_medicamento.ToLower().Contains(nombreParcial.ToLower()))
                .ToList();

            return medicamentosEncontrados;
        }

        public bool Vender_Medicamento(string nom_medicamento, int cantidadSolicitada)
        {
            var medicamentos = Inventario.l_inventario
                .Where(p => p.nom_medicamento.ToLower() == nom_medicamento.ToLower())
                .OrderBy(p => p.fecha_vencimiento)
                .ToList();

            int cantidadVendida = 0;
            ulong valorTotal = 0;

            foreach (var med in medicamentos)
            {
                if (cantidadVendida >= cantidadSolicitada)
                    break;

                int unidadesRestantes = cantidadSolicitada - cantidadVendida;

                if (med.Cantidad <= unidadesRestantes)
                {
                    cantidadVendida += med.Cantidad;
                    valorTotal += (ulong)(med.Cantidad * med.precio_unitario);
                    Inventario.l_inventario.Remove(med);
                }
                else
                {
                    med.Cantidad -= (ushort)unidadesRestantes;
                    cantidadVendida += unidadesRestantes;
                    valorTotal += (ulong)(unidadesRestantes * med.Precio);
                }
            }

            if (cantidadVendida > 0)
            {
                var venta = new M_venta(valorTotal, (uint)cantidadVendida);
                Farmacia.l_ventas.Add(venta);
                return true;
            }

            return false;
        }

    }
}
