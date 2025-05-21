using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaFarmacia.Interfaces;
using BibliotecaFarmacia.Clases;

namespace BibliotecaFarmacia.Clases
{
    public class M_compra : Movimiento
    {
        
        public M_compra(ulong valor_movimiento, uint cantidad_medicamentos)
            : base(valor_movimiento, cantidad_medicamentos)
        {
            this.valor_movimiento = valor_movimiento;
            this.cantidad_medicamentos = cantidad_medicamentos;
        }

        public override ulong Valor_Total()
        {
            ulong total = 0;

            foreach (var med in Farmacia.l_disponibles)
            {
                // Convertimos el precio_compra (float o decimal) a ulong
                total += (ulong)(med.precio_compra * cantidad_medicamentos);
            }

            return total;
        }
    }
}
