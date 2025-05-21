using System;

namespace BibliotecaFarmacia.Clases
{
    public class M_liquido : Medicamento
    {
        public ushort mililitros;
        public string envase;

        public ushort Mililitros
        {
            get => mililitros;
            set => mililitros = (value == 0 || value > 5000)
                ? throw new Exception("Los mililitros deben estar entre 1 y 5000.\n")
                : value;
        }

        public string Envase
        {
            get => envase;
            set
            {
                string val = value.Trim().ToLower();
                if (val != "plastico" && val != "vidrio")
                    throw new ArgumentException("El envase debe ser de 'plastico' o 'vidrio'.\n");
                envase = val;
            }
        }

        public M_liquido(string nom_medicamento, string laboratorio, DateTime fecha_vencimiento,
                         uint precio_compra, ushort cantidad, ushort mililitros, string envase)
            : base(nom_medicamento, laboratorio, fecha_vencimiento, precio_compra, cantidad)
        {
            Mililitros = mililitros;
            Envase = envase;
        }
    }
}
