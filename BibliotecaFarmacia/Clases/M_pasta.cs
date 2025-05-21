using System;

namespace BibliotecaFarmacia.Clases
{
    public class M_pasta : Medicamento
    {
        public ushort miligramos;

        public M_pasta(string nom_medicamento, string laboratorio, DateTime fecha_vencimiento, uint precio_compra, ushort cantidad, ushort miligramos, string tipo_med = "pasta")
        : base(nom_medicamento, laboratorio, fecha_vencimiento, precio_compra, cantidad, tipo_med)
        {
            Miligramos = miligramos;
        }

        public ushort Miligramos
        {
            get => miligramos;
            set => miligramos = (value == 0 || value >= 10000)
                ? throw new Exception("Los miligramos deben estar entre 1 y 10000. \n")
                : value;
        }

    }
}
