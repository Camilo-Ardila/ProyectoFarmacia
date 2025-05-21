using System;
using System.Collections.Generic;

namespace BibliotecaFarmacia.Clases
{
    public abstract class Farmacia
    {
        // Atributos privados
        public static string nombre_farmacia;
        public static List<M_compra> l_compras = new List<M_compra>();
        public static  List<M_venta> l_ventas = new List<M_venta>();
        public static Dictionary<string, uint> inventario;
        public static ulong totalRecaudado = 0;
        public static ulong totalComprado = 0;
        public static List<Laboratorio> l_laboratorios = new List<Laboratorio>();
        public static List<Persona> l_personas = new List<Persona>();

        // Constructor
        

        // Aquí puedes agregar métodos públicos para interactuar con los datos si es necesario
    }
}
