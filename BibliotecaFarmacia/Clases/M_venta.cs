using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaFarmacia.Clases;
using BibliotecaFarmacia.Interfaces;

namespace BibliotecaFarmacia.Clases
{

    public class M_venta : Movimiento, IAplicarDescuento
    {

        public M_venta(Medicamento medicamento, ulong valor_movimiento, uint cantidad_medicamentos, string cc)
            : base(medicamento, valor_movimiento, cantidad_medicamentos)
        {
            CC = cc;
        }
        public float descuento = 0.02f;

        public override ulong Valor_Total() 
        {
            ulong total = 0;

            foreach (var med in Inventario.l_inventario)
            {
                total += (ulong)(med.Precio_venta * cantidad_medicamentos);

            }

            return total;
        }

        public int AplicarDescuento(Medicamento medicamento, M_venta venta)
        {

            int precio_descuento = 0;
            float descuento = 0.02f;

            var persona = Farmacia.l_personas.FirstOrDefault(p => p.CC == venta.CC);

            if (persona.Tipo == "cliente")
            {
                // Descuento base para clientes
                descuento += 0.03f;

                // Verificar si el medicamento es una cápsula
                if (medicamento is M_capsula capsula)
                {
                    switch (capsula.relleno.ToLower())
                    {
                        case "polvo":
                            descuento += 0.08f;
                            break;
                        case "gel":
                            descuento += 0.05f;
                            break;
                        default:
                            break; // No se aplica descuento extra si el relleno no es reconocido
                    }
                }
            }
            else
            {
                // Descuento para usuarios (no clientes)
                descuento = 0.02f;
            }

            precio_descuento = (int)(venta.Valor_movimiento - (float)(venta.Valor_movimiento * descuento));

            return precio_descuento;
        }

        public string CC { get; set; }
    }
}