using System;

namespace BibliotecaFarmacia.Clases
{
    internal class M_capsula : Medicamento
    {
        internal ushort miligramos;
        internal string relleno;

        internal ushort Miligramos
        {
            get => miligramos;
            set => miligramos = (value == 0 || value >= 10000)
                ? throw new Exception("Los miligramos deben estar entre 1 y 9999.\n")
                : value;
        }

        internal string Relleno
        {
            get => relleno;
            set
            {
                string val = value.Trim().ToLower();
                if (val != "gel" && val != "polvo")
                    throw new ArgumentException("El relleno debe ser 'gel' o 'polvo'.\n");
                relleno = val;
            }
        }

        public M_capsula(string nom_medicamento, string laboratorio, DateTime fecha_vencimiento,
                         uint precio_compra, ushort cantidad, ushort miligramos, string relleno)
            : base(nom_medicamento, laboratorio, fecha_vencimiento, precio_compra, cantidad)
        {
            Miligramos = miligramos;
            Relleno = relleno;
        }
    }
}
