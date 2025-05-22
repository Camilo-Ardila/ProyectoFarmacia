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


        public M_venta(Medicamento medicamento, ulong valor_movimiento, uint cantidad_medicamentos, Persona persona)
            : base(medicamento, valor_movimiento, cantidad_medicamentos)
        {

        }
        public float descuento = 0.01f;

        public override ulong Valor_Total()
        {
            ulong total = 0;

            foreach (var med in Inventario.l_inventario)
            {
                total += (ulong)(med.Precio_venta * cantidad_medicamentos);

            }

            return total;
        }

        public void AplicarDescuento(Medicamento medicamento, string tipo)
        {

            if (tipo == "cliente")
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
                descuento = 0.01f;
            }
        }


        // Propiedad con el total aplicado con descuento
        public virtual void TotalConDescuento(uint total_gastado)
        {
            valor_movimiento = (ulong)(valor_movimiento - (valor_movimiento * descuento));
        }

    }
}