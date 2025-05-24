using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaFarmacia.Interfaces;

namespace BibliotecaFarmacia.Clases
{
    public class M_compra : Movimiento
    {
        public M_compra(Medicamento medicamento, ulong valor_movimiento, uint cantidad_medicamentos)
            : base(medicamento, valor_movimiento, cantidad_medicamentos)
        {
            try
            {
                // Puedes agregar lógica de validación aquí si lo necesitas.
                // Por ejemplo:
                if (medicamento == null)
                    throw new ArgumentNullException(nameof(medicamento), "El medicamento no puede ser nulo.");

                if (cantidad_medicamentos == 0)
                    throw new ArgumentException("La cantidad de medicamentos debe ser mayor que cero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en el constructor de M_compra: {ex.Message}");
            }
        }

        public override ulong Valor_Total()
        {
            ulong total = 0;

            try
            {
                foreach (var med in Farmacia.l_disponibles)
                {
                    total += (ulong)(med.precio_compra * cantidad_medicamentos);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular el valor total de la compra: {ex.Message}");
            }

            return total;
        }
    }
}
