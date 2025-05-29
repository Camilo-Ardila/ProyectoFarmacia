using BibliotecaFarmacia.Clases;
using BibliotecaFarmacia.Interfaces;

namespace MVC.Services
{
    public class M_VentaService
    {
        private bool descuento = false;

        // NUEVO: Atributo para guardar la cédula actual
        public string cedulaActual = "";

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

        public List<(Medicamento, uint)> BuscarPorMedicamento(string nombreParcial)
        {
            return Farmacia.inventario
                .Where(p => p.Item1.Nom_medicamento.ToLower().Contains(nombreParcial.ToLower()))
                .ToList();
        }

        public List<(Medicamento, uint)> BuscarPorTipo(string tipoParcial)
        {
            return Farmacia.inventario
                .Where(p => p.Item1.Tipo_med.ToLower().Contains(tipoParcial.ToLower()))
                .ToList();
        }

        // NUEVO: Guardar la cédula ingresada
        public void AsignarCC(string cc)
        {
            if (string.IsNullOrWhiteSpace(cc))
            {
                Console.WriteLine("Llene el campo");
                return;
            }

            if (!cc.All(char.IsDigit)){
                Console.WriteLine("Todo el campo debe ser números ");
            }

            else
                cedulaActual = cc.Trim();
        }

        public void AgregarAlCarrito(Medicamento medicamento, M_venta venta)
        {
            if (venta.Cantidad_medicamentos == 0)
            {
                Console.WriteLine("No se puede agregar una cantidad cero al carrito.");
                return;
            }

            carrito.Add((medicamento, venta));
        }

        public void Vender_Medicamento(Medicamento medicamento, M_venta venta)
        {
            var persona = Farmacia.l_personas.FirstOrDefault(p => p.CC == venta.CC);

            if (persona == null) return;

            var medicamentos = Inventario.l_inventario
                .Where(m => m.Nom_medicamento.ToLower() == medicamento.Nom_medicamento.ToLower())
                .OrderBy(m => m.Fecha_vencimiento)
                .ToList();

            if (venta.Cantidad_medicamentos > medicamentos.Count) return;

            for (int i = 0; i < venta.Cantidad_medicamentos; i++)
            {
                Inventario.l_inventario.Remove(medicamentos[i]);
            }

            if (descuento)
            {
                venta.Valor_movimiento = (ulong)venta.AplicarDescuento(medicamento, venta);
            }


            persona.Total_gastado += (uint)venta.Valor_movimiento;

            if (persona is Cliente cliente)
                cliente.Ptos = cliente.Total_gastado / 100;

            Farmacia.l_ventas.Add(venta);
           
        }

        public void CarritoCompras()
        {
            foreach (var item in carrito)
            {
                Vender_Medicamento(item.medicamento, item.venta);
            }

            Console.WriteLine("Ventas Realizadas");

            carrito.Clear();
            cedulaActual = "";
        }

        public List<(Medicamento, M_venta)> MostrarCarrito() => carrito;

        public List<M_venta> HistorialVentas() => Farmacia.l_ventas;
    }
}
