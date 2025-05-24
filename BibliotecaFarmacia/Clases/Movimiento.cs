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
            try
            {
                Valor_movimiento = valor_movimiento;
                Cantidad_medicamentos = cantidad_medicamentos;
                Medicamento_objeto = medicamento ?? throw new ArgumentNullException(nameof(medicamento), "El objeto medicamento no puede ser nulo.");
                Fecha_creacion = DateTime.Now;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al construir Movimiento: " + ex.Message);
                throw;
            }
        }

        public ulong Valor_movimiento
        {
            get => valor_movimiento;
            set
            {
                try
                {
                    valor_movimiento = value; // Aquí podrías agregar validaciones si lo deseas
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al asignar Valor_movimiento: " + ex.Message);
                    throw;
                }
            }
        }

        public uint Cantidad_medicamentos
        {
            get => cantidad_medicamentos;
            set
            {
                try
                {
                    cantidad_medicamentos = value; // Puedes validar si se requiere ser mayor que 0
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al asignar Cantidad_medicamentos: " + ex.Message);
                    throw;
                }
            }
        }

        public Medicamento Medicamento_objeto
        {
            get; set;
        }

        public DateTime Fecha_creacion
        {
            get => fecha;
            set
            {
                try
                {
                    fecha = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al asignar Fecha_creacion: " + ex.Message);
                    throw;
                }
            }
        }

        // Método de la interfaz
        public virtual ulong Valor_Total()
        {
            try
            {
                return valor_movimiento * cantidad_medicamentos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al calcular Valor_Total: " + ex.Message);
                throw;
            }
        }
    }
}
