using System;
using System.Collections.Generic;
using System.Linq; // Necesario para usar GroupBy y Select

namespace BibliotecaFarmacia.Clases
{
    public abstract class Farmacia
    {
        // Atributos privados
        public static string nombre_farmacia;
        public static List<M_compra> l_compras = new List<M_compra>();
        public static List<M_venta> l_ventas = new List<M_venta>();
        public static ulong totalRecaudado = 0;
        public static ulong totalComprado = 0;
        public static List<Laboratorio> l_laboratorios = new List<Laboratorio>();
        public static List<Persona> l_personas = new List<Persona>();
        public static List<Medicamento> l_disponibles = new List<Medicamento>();
        public static List<(Medicamento medicamento, uint cantidad)> inventario = new List<(Medicamento medicamento, uint cantidad)>();

        public static void ConstruirInventarioAgrupado()
        {
            try
            {
                // Limpiar lista estática para actualizar
                Farmacia.inventario.Clear();

                // Agrupar por nombre (ignorando mayúsculas/minúsculas)
                var agrupado = Inventario.l_inventario
                    .GroupBy(m => m.Nom_medicamento.ToLower())
                    .Select(g =>
                    {
                        Medicamento medRepresentativo = g.First();

                        // Cantidad total: contar número de objetos en el grupo
                        uint cantidadTotal = (uint)g.Count();

                        return (medicamento: medRepresentativo, cantidad: cantidadTotal);
                    }).ToList();

                // Asignar resultado a la lista estática
                Farmacia.inventario.AddRange(agrupado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al construir el inventario agrupado: {ex.Message}");
            }
        }
    }
}
