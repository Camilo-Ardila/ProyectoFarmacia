using BibliotecaFarmacia.Clases;

namespace MVC.Services
{
    public class M_CompraService
    {

        public List<(Medicamento medicamento, M_compra movimiento)> carrito = new List<(Medicamento medicamento, M_compra movimiento)>();

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

        public void EliminarOpción(string nombre)
        {
            Medicamento medicamento = Farmacia.l_disponibles.FirstOrDefault(p => p.Nom_medicamento == nombre);

            Farmacia.l_disponibles.Remove(medicamento);
        }

        public void AgregarOpción(Medicamento medicamento)
        {
            Farmacia.l_disponibles.Add(medicamento);
        }

        public void AgregarAlCarrito(Medicamento medicamento, M_compra movimiento)
        {
            if (movimiento.Cantidad_medicamentos == 0)
            {
                Console.WriteLine("No se puede agregar una cantidad cero al carrito.");
                return;
            }

            carrito.Add((medicamento, movimiento));
            Console.WriteLine($"{movimiento.Cantidad_medicamentos} unidades de '{medicamento.nom_medicamento}' agregadas al carrito, movimiento pendiente");
        }


        public void ComprarMedicamentos(Medicamento medicamento, M_compra movimiento)
        {
            for (int i = 1; i <= movimiento.Cantidad_medicamentos; i++)
            {
                Inventario.l_inventario.Add(medicamento);
            }

            Farmacia.l_compras.Add(movimiento);
        }

        public void CarritoCompras()
        {
            string nombre;
            uint cantidad;

            foreach (var item in carrito)
            {
                nombre = item.medicamento.Nom_medicamento;
                cantidad = (uint)item.movimiento.Cantidad_medicamentos;

                ComprarMedicamentos(item.medicamento, item.movimiento);

            }

            carrito.Clear(); // Limpiar después de procesar
        }

        public List<(Medicamento, M_compra)> MostrarCarrito(){

            return carrito;
         }

    }
}