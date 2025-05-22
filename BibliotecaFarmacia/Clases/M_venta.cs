using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaFarmacia.Clases;
using BibliotecaFarmacia.Interfaces;

namespace BibliotecaFarmacia.Clases
{
    
    public class M_venta : Movimiento,  IAplicarDescuento
    {
       

        public M_venta(ulong valor_movimiento, uint cantidad_medicamentos)
            : base(valor_movimiento, cantidad_medicamentos)
        {
            this.valor_movimiento = valor_movimiento;
            this.cantidad_medicamentos = cantidad_medicamentos;
        }
        public  float descuento = 0.01f;

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
            valor_movimiento = (ulong) (valor_movimiento - (valor_movimiento * descuento));
        }

        using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaFarmacia.Clases;

namespace MVC.Services
    {
        public class M_Venta_Service
        {
            public bool Vender_Medicamento(string nom_medicamento, int cantidadSolicitada)
            {
                var medicamentos = Inventario.l_inventario
                    .Where(p => p.nom_medicamento.ToLower() == nom_medicamento.ToLower())
                    .OrderBy(p => p.fecha_vencimiento)
                    .ToList();

                int cantidadVendida = 0;
                ulong valorTotal = 0;

                foreach (var med in medicamentos)
                {
                    if (cantidadVendida >= cantidadSolicitada)
                        break;

                    int unidadesRestantes = cantidadSolicitada - cantidadVendida;

                    if (med.Cantidad <= unidadesRestantes)
                    {
                        cantidadVendida += med.Cantidad;
                        valorTotal += (ulong)(med.Cantidad * med.precio_unitario);
                        Inventario.l_inventario.Remove(med);
                    }
                    else
                    {
                        med.Cantidad -= (ushort)unidadesRestantes;
                        cantidadVendida += unidadesRestantes;
                        valorTotal += (ulong)(unidadesRestantes * med.precio_unitario);
                    }
                }

                if (cantidadVendida > 0)
                {
                    var venta = new M_venta(valorTotal, (uint)cantidadVendida);
                    Farmacia.l_ventas.Add(venta);
                    return true;
                }

                return false;
            }
        }
    }

}
}