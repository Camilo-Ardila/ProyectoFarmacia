using System;

namespace BibliotecaFarmacia.Clases
{
    public class Medicamento
    {
        public string nom_medicamento = "";
        public string laboratorio = "";
        public DateTime fecha_vencimiento;
        public uint precio_compra;
        public ushort cantidad;
        private string tipo_med;
        public const ushort cant_min = 1;
        public const ushort cant_max = 1000;

        public Medicamento(string nom_medicamento, string laboratorio, DateTime fecha_vencimiento, uint precio_compra, ushort cantidad, string tipo_med)
        {
            Nom_medicamento = nom_medicamento;
            Laboratorio = laboratorio;
            Fecha_vencimiento = fecha_vencimiento;
            Precio_compra = precio_compra;
            Cantidad = cantidad;
            Tipo_med = tipo_med;
        }

        public string Nom_medicamento
        {
            get => nom_medicamento;
            set => nom_medicamento = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("El nombre del medicamento no puede estar vacío.")
                : value.Trim();
        }

        public string Laboratorio
        {
            get => laboratorio;
            set => laboratorio = string.IsNullOrWhiteSpace(value)
                ? throw new ArgumentException("El laboratorio no puede estar vacío.")
                : value.Trim();
        }

        public DateTime Fecha_vencimiento
        {
            get => fecha_vencimiento;
            set
            {
                DateTime now = DateTime.Now;
                if (value > now.AddDays(30))
                    throw new Exception("Los medicamentos deben estar por lo menos a dos semanas de vencerse \n");

                fecha_vencimiento = value;
            }
        }

        public uint Precio_compra
        {
            get => precio_compra;
            set => precio_compra = value == 0
                ? throw new ArgumentException("El precio de compra debe ser mayor que 0.")
                : value;
        }

        public uint Precio_venta => (uint)(precio_compra * 1.2);

        public ushort Cantidad
        {
            get => cantidad;
            set => cantidad = (value < cant_min || value > cant_max)
                ? throw new ArgumentOutOfRangeException(nameof(Cantidad), $"Debe estar entre {cant_min} y {cant_max}.")
                : value;
        }
        public string Tipo_med { get => tipo_med; set => tipo_med = value; }
    }
}
