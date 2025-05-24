using System;

namespace BibliotecaFarmacia.Clases
{
    public class M_liquido : Medicamento
    {
        private ushort mililitros;
        private string envase;

        public M_liquido(string nom_medicamento, string laboratorio, DateTime fecha_vencimiento,
                         uint precio_compra, ushort cantidad, ushort mililitros, string envase, string tipo_med = "liquido", uint precio_venta = 0)
            : base(nom_medicamento, laboratorio, fecha_vencimiento, precio_compra, cantidad, tipo_med, precio_venta)
        {
            try
            {
                Mililitros = mililitros;
                Envase = envase;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en el constructor de M_liquido: {ex.Message}");
            }
        }

        public ushort Mililitros
        {
            get => mililitros;
            set
            {
                try
                {
                    if (value == 0 || value > 5000)
                        throw new Exception("Los mililitros deben estar entre 1 y 5000.\n");

                    mililitros = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al establecer Mililitros: {ex.Message}");
                }
            }
        }

        public string Envase
        {
            get => envase;
            set
            {
                try
                {
                    string val = value.Trim().ToLower();
                    if (val != "plastico" && val != "vidrio")
                        throw new ArgumentException("El envase debe ser de 'plastico' o 'vidrio'.\n");

                    envase = val;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al establecer Envase: {ex.Message}");
                }
            }
        }
    }
}
