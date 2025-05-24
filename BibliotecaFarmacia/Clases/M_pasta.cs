using System;

namespace BibliotecaFarmacia.Clases
{
    public class M_pasta : Medicamento
    {
        public ushort miligramos;

        public M_pasta(string nom_medicamento, string laboratorio, DateTime fecha_vencimiento, uint precio_compra, ushort cantidad, ushort miligramos, string tipo_med = "pasta", uint precio_venta = 0)
        : base(nom_medicamento, laboratorio, fecha_vencimiento, precio_compra, cantidad, tipo_med, precio_venta)
        {
            try
            {
                Miligramos = miligramos;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al asignar miligramos en el constructor de M_pasta: " + ex.Message);
                throw;
            }
        }

        public ushort Miligramos
        {
            get => miligramos;
            set
            {
                try
                {
                    if (value == 0 || value >= 10000)
                        throw new Exception("Los miligramos deben estar entre 1 y 10000. \n");
                    miligramos = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al asignar la propiedad Miligramos: " + ex.Message);
                    throw;
                }
            }
        }
    }
}
