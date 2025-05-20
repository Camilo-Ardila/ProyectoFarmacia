using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public class M_compra : Movimiento
    {

        public List<Medicamento> l_disponibles = new List<Medicamento>();

        public M_compra(ulong valor_movimiento, uint cantidad_medicamentos): base (valor_movimiento, cantidad_medicamentos)
        {
            this.valor_movimiento = valor_movimiento;
            this.cantidad_medicamentos = cantidad_medicamentos;
        }

    }
}
