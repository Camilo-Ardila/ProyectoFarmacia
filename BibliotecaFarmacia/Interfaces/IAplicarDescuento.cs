using BibliotecaFarmacia.Clases;

namespace BibliotecaFarmacia.Interfaces
{
    public interface IAplicarDescuento
    {

        public void AplicarDescuento(Medicamento medicamento, string tipo);
    }
}
