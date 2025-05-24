using BibliotecaFarmacia.Clases;

namespace BibliotecaFarmacia.Interfaces
{
    public interface IAplicarDescuento
    {

        public int AplicarDescuento(Medicamento medicamento, M_venta venta);
    }
}
