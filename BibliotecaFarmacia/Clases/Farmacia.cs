using System;
using System.Collections.Generic;

namespace BibliotecaFarmacia.Clases
{
    class Farmacia
    {
        // Atributos privados
        public string nombre_farmacia;
        public List<M_compra> l_compras;
        public List<M_venta> l_ventas;
        public Dictionary<string, uint> inventario;
        public ulong totalRecaudado;
        public ulong totalComprado;
        public List<Laboratorio> l_laboratorios;

        // Constructor
        public Farmacia(string nombre_farmacia)
        {
            this.nombre_farmacia = nombre_farmacia;
            this.l_compras = new List<M_compra>();
            this.l_ventas = new List<M_venta>();
            this.inventario = new Dictionary<string, uint>();
            this.totalRecaudado = 0;
            this.totalComprado = 0;
            this.l_laboratorios = new List<Laboratorio>();
        }

        // Aquí puedes agregar métodos públicos para interactuar con los datos si es necesario
    }
}
