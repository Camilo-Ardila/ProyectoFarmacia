using BibliotecaFarmacia.Clases;

namespace MVC.Services
{
    public class M_VentaService
    {
        public List<(Medicamento medicamento, uint cantidad)> carrito = new List<(Medicamento medicamento, uint cantidad)>();
        public List<(Medicamento, uint)> MostrarDisponibles()
        {
            Farmacia.ConstruirInventarioAgrupado();

            return Farmacia.inventario;
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

        public void AgregarAlCarrito(Medicamento medicamento, uint cantidad)
        {
            if (cantidad == 0)
            {
                Console.WriteLine("No se puede agregar una cantidad cero al carrito.");
                return;
            }

            carrito.Add((medicamento, cantidad));
            Console.WriteLine($"{cantidad} unidades de '{medicamento.nom_medicamento}' agregadas al carrito.");
        }

        public bool Vender_Medicamento(string nom_medicamento, int cantidadSolicitada, string cc)
        {
            // Buscar a la persona en la lista de personas
            var persona = Farmacia.l_personas.FirstOrDefault(p => p.cc == cc);

            if (persona == null)
                return false; // No se encontró la persona

            // Buscar los medicamentos por nombre y ordenarlos por fecha de vencimiento
            var medicamentos = Inventario.l_inventario
                .Where(p => p.nom_medicamento.ToLower() == nom_medicamento.ToLower())
                .OrderBy(p => p.fecha_vencimiento)
                .ToList();

            int cantidadVendida = 0;
            ulong valorTotal = 0;
            Medicamento medicamentoReferencia = null;

            foreach (var med in medicamentos.ToList()) // .ToList() para evitar modificación de colección durante iteración
            {
                if (cantidadVendida >= cantidadSolicitada)
                    break;

                int unidadesRestantes = cantidadSolicitada - cantidadVendida;

                if (med.Cantidad <= unidadesRestantes)
                {
                    cantidadVendida += med.Cantidad;
                    valorTotal += (ulong)(med.Cantidad * med.Precio_venta);
                    Inventario.l_inventario.Remove(med);

                    if (medicamentoReferencia == null)
                        medicamentoReferencia = med;
                }
                else
                {
                    med.Cantidad -= (ushort)unidadesRestantes;
                    cantidadVendida += unidadesRestantes;
                    valorTotal += (ulong)(unidadesRestantes * med.Precio_venta);

                    if (medicamentoReferencia == null)
                        medicamentoReferencia = med;
                }
            }

            if (cantidadVendida > 0 && medicamentoReferencia != null)
            {
                // Actualizar el total gastado de la persona
                persona.Total_gastado += (uint)valorTotal;

                // Crear y registrar la venta
                var venta = new M_venta(medicamentoReferencia, valorTotal, (uint)cantidadVendida, persona);
                Farmacia.l_ventas.Add(venta);
                return true;
            }

            return false; // No se pudo vender
        }

        public void CarritoCompras(string cc)
        {
            foreach (var item in carrito)
            {
                string nombre = item.medicamento.nom_medicamento;
                int cantidad = (int)item.cantidad;

                bool ventaExitosa = Vender_Medicamento(nombre, cantidad, cc);

                if (!ventaExitosa)
                {
                    Console.WriteLine($"No se pudo vender {cantidad} unidades de {nombre} a la persona con cédula {cc}.");
                }
                else
                {
                    Console.WriteLine($"Venta exitosa: {cantidad} unidades de {nombre}.");
                }
            }

            carrito.Clear(); // Limpiar después de procesar
        }


        public List<M_venta> HistorialVentas()
        {
            List<M_venta> lista_ventas = Farmacia.l_ventas;

            return lista_ventas;
        }

    }
}
