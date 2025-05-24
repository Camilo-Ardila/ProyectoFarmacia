using System;

namespace BibliotecaFarmacia.Clases
{
    public class Medicamento
    {
        public string nom_medicamento = "";
        public string laboratorio = "";
        public DateTime fecha_vencimiento;
        public uint precio_compra;
        private uint precio_venta;
        public ushort cantidad;
        private string tipo_med;
        public const ushort cant_min = 1;
        public const ushort cant_max = 1000;

        public Medicamento(string nom_medicamento, string laboratorio, DateTime fecha_vencimiento, uint precio_compra, ushort cantidad, string tipo_med, uint precio_venta = 0)
        {
            try
            {
                Nom_medicamento = nom_medicamento;
                Laboratorio = laboratorio;
                Fecha_vencimiento = fecha_vencimiento;
                Precio_compra = precio_compra;
                Cantidad = cantidad;
                Tipo_med = tipo_med;
                Precio_venta = (uint)(precio_compra * 1.5);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en el constructor de Medicamento: " + ex.Message);
                throw;
            }
        }

        public string Nom_medicamento
        {
            get => nom_medicamento;
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("El nombre del medicamento no puede estar vacío.");
                    nom_medicamento = value.Trim();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al asignar Nom_medicamento: " + ex.Message);
                    throw;
                }
            }
        }

        public string Laboratorio
        {
            get => laboratorio;
            set
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("El laboratorio no puede estar vacío.");
                    laboratorio = value.Trim();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al asignar Laboratorio: " + ex.Message);
                    throw;
                }
            }
        }

        public DateTime Fecha_vencimiento
        {
            get => fecha_vencimiento;
            set
            {
                try
                {
                    // Puedes descomentar esta validación si es necesaria
                    // DateTime now = DateTime.Now;
                    // if (value > now.AddDays(30))
                    //     throw new Exception("Los medicamentos deben estar por lo menos a dos semanas de vencerse.");

                    fecha_vencimiento = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al asignar Fecha_vencimiento: " + ex.Message);
                    throw;
                }
            }
        }

        public uint Precio_compra
        {
            get => precio_compra;
            set
            {
                try
                {
                    if (value == 0)
                        throw new ArgumentException("El precio de compra debe ser mayor que 0.");
                    precio_compra = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al asignar Precio_compra: " + ex.Message);
                    throw;
                }
            }
        }

        public ushort Cantidad
        {
            get => cantidad;
            set
            {
                try
                {
                    if (value < cant_min || value > cant_max)
                        throw new ArgumentOutOfRangeException(nameof(Cantidad), $"Debe estar entre {cant_min} y {cant_max}.");
                    cantidad = value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al asignar Cantidad: " + ex.Message);
                    throw;
                }
            }
        }

        public string Tipo_med
        {
            get => tipo_med;
            set => tipo_med = value; // No tiene validación, no se requiere try-catch
        }

        public uint Precio_venta
        {
            get => precio_venta;
            set => precio_venta = value; // No tiene validación, no se requiere try-catch
        }
    }
}
