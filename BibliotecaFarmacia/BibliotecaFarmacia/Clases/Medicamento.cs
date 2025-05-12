using System;

namespace BibliotecaFarmacia.Clases
{
    class Medicamento
    {
        private string nom_medicamento = "";
        private string laboratorio = "";
        private DateTime fecha_vencimiento;
        private uint precio_compra;
        private ushort cantidad;
        private const ushort cant_min = 1;
        private const ushort cant_max = 1000;

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
                {
                    throw new Exception("Los medicamentos deben estar por lo menos a dos semanas de vencerse \n");
                }

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

        public Medicamento(string nom_medicamento, string laboratorio, DateTime fecha_vencimiento, uint precio_compra, ushort cantidad)
        {
            Nom_medicamento = nom_medicamento;
            Laboratorio = laboratorio;
            Fecha_vencimiento = fecha_vencimiento;
            Precio_compra = precio_compra;
            Cantidad = cantidad;
        }
    }
}
