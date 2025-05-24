using System;

namespace BibliotecaFarmacia.Clases
{
    public class M_capsula : Medicamento
    {
        public ushort miligramos;
        public string relleno;

        public M_capsula(string nom_medicamento, string laboratorio, DateTime fecha_vencimiento,
                         uint precio_compra, ushort cantidad, ushort miligramos, string relleno, string tipo_med = "capsulas", uint precio_venta = 0)
            : base(nom_medicamento, laboratorio, fecha_vencimiento, precio_compra, cantidad, tipo_med, precio_venta)
        {
            try
            {
                Miligramos = miligramos;
                Relleno = relleno;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear M_capsula: {ex.Message}");
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
                        throw new Exception("Los miligramos deben estar entre 1 y 9999.\n");
                    miligramos = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al asignar miligramos: {ex.Message}");
                }
            }
        }

        public string Relleno
        {
            get => relleno;
            set
            {
                try
                {
                    string val = value.Trim().ToLower();
                    if (val != "gel" && val != "polvo")
                        throw new ArgumentException("El relleno debe ser 'gel' o 'polvo'.\n");
                    relleno = val;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al asignar relleno: {ex.Message}");
                }
            }
        }
    }
}
