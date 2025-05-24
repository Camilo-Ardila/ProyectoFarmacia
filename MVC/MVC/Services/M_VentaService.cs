using BibliotecaFarmacia.Clases;
using BibliotecaFarmacia.Interfaces;

namespace MVC.Services
{
    public class M_VentaService
    {
        bool descuento = false;

        public List<(Medicamento medicamento, M_venta venta)> carrito = new List<(Medicamento medicamento, M_venta venta)>();
        public List<(Medicamento, uint)> MostrarDisponibles()
        {
            Farmacia.ConstruirInventarioAgrupado();

            return Farmacia.inventario;
        }

        public bool ToggleDescuento()
        {
            descuento = !descuento;
            return descuento;
        }

        public List<(Medicamento, uint)> ListarTipo(string tipo_med)
        {
            return Farmacia.inventario
                .Where(p => p.Item1.Tipo_med.ToLower() == tipo_med.ToLower())
                .ToList();
        }

        public List<(Medicamento, uint)> BuscarPorMedicamento(string nombreParcial)
        {
            return Farmacia.inventario
                .Where(p => p.Item1.Nom_medicamento.ToLower().Contains(nombreParcial.ToLower()))
                .ToList();
        }

        public void AgregarAlCarrito(Medicamento medicamento, M_venta venta)
        {
            if (venta.Cantidad_medicamentos == 0)
            {
                Console.WriteLine("No se puede agregar una cantidad cero al carrito.");
                return;
            }

            carrito.Add((medicamento, venta));
            Console.WriteLine($"{venta.cantidad_medicamentos} unidades de '{medicamento.nom_medicamento}' agregadas al carrito.");
        }

        public bool Vender_Medicamento(Medicamento medicamento, M_venta venta)
        {
            var persona = Farmacia.l_personas.FirstOrDefault(p => p.CC == venta.CC);

            if (persona == null)
                return false; // No se encontró la persona

            var medicamentos = Inventario.l_inventario
                .Where(m => m.Nom_medicamento.ToLower() == medicamento.Nom_medicamento.ToLower())
                .OrderBy(m => m.Fecha_vencimiento)
                .ToList();

            int cantidadDisponible = medicamentos.Count;

            if (venta.Cantidad_medicamentos > cantidadDisponible)
                return false; // No hay suficientes medicamentos

            // Vender medicamentos: eliminar la cantidad solicitada del inventario
            for (int i = 0; i < venta.Cantidad_medicamentos; i++)
            {
                Inventario.l_inventario.Remove(medicamentos[i]);
            }

            if(descuento == true)
                venta.Valor_movimiento = (ulong)venta.AplicarDescuento(medicamento, venta);

            persona.Total_gastado += (uint)(venta.Valor_movimiento);

            // Si es cliente, actualizar los puntos acumulados
            if (persona is Cliente cliente)
            {
                cliente.Ptos = cliente.Total_gastado / 100;
            }

            Farmacia.l_ventas.Add(venta);

            return true;
        }

        public void CarritoCompras()
        {
            string nombre;
            int cantidad;

            foreach (var item in carrito)
            {
               nombre = item.medicamento.nom_medicamento;
               cantidad = (int)item.venta.Cantidad_medicamentos;   

                Vender_Medicamento(item.medicamento, item.venta);
             
            }

            carrito.Clear(); // Limpiar después de procesar
        }

        public List<(Medicamento, M_venta)> MostrarCarrito()
        {

            return carrito;
        }


        public List<M_venta> HistorialVentas()
        {
            List<M_venta> lista_ventas = Farmacia.l_ventas;

            return lista_ventas;
        }

    }
}
