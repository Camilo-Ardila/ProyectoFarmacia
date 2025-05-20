using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaFarmacia.Clases
{
    public class Movimiento
    {

        public ulong valor_movimiento;
        public uint cantidad_medicamentos;

        public Movimiento(ulong valor_movimiento, uint cantidad_medicamentos)
        {
            this.valor_movimiento = valor_movimiento;
            this.cantidad_medicamentos = cantidad_medicamentos;
        }

        public ulong Valor_movimiento { get => valor_movimiento; set => valor_movimiento = value; }
        public uint Cantidad_medicamentos { get => cantidad_medicamentos; set => cantidad_medicamentos = value; }
    }
}
