using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaFarmacia.Interfaces;

namespace BibliotecaFarmacia.Clases
{
    public class Movimiento : ICalcularValor
    {
        public ulong valor_movimiento;
        public uint cantidad_medicamentos;
        private DateTime fecha;

        public Movimiento(Medicamento medicamento, ulong valor_movimiento, uint cantidad_medicamentos)
        {
            Valor_movimiento = valor_movimiento;
            Cantidad_medicamentos = cantidad_medicamentos;
            Medicamento_objeto = medicamento;
            Fecha_creacion = DateTime.Now;
        }

        public ulong Valor_movimiento { get => valor_movimiento; set => valor_movimiento = value; }
        public uint Cantidad_medicamentos { get => cantidad_medicamentos; set => cantidad_medicamentos = value; }
        public Medicamento Medicamento_objeto { get; set;}
        public DateTime Fecha_creacion { get => fecha; set => fecha = value; }

        // Método de la interfaz
        public virtual ulong Valor_Total()
        {
            return valor_movimiento * cantidad_medicamentos;
        }
    }
}
