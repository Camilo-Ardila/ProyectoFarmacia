namespace MVC.Services
{
    public class ServicioInventarioConcreto : InventarioService
    {
        public Inventario InventarioInstancia { get; }

        public ServicioInventarioConcreto()
        {
            InventarioInstancia = new InventarioConcreta(); // O como se llame tu clase concreta
        }
    }
}
