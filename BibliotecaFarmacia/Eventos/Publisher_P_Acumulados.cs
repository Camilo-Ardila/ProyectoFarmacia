using System;

namespace BibliotecaFarmacia.Eventos
{
    public delegate void delegado_ptos_compra(uint ptos);

    public class Publisher_P_Acumulados
    {
        public event delegado_ptos_compra evento_ptos;

        public void Informar_P_Acumulados(uint ptos)
        {
            try
            {
                if (evento_ptos != null)
                {
                    evento_ptos(ptos);
                }
                else
                {
                    Console.WriteLine("No hay suscriptores al evento de puntos acumulados.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al notificar puntos acumulados: " + ex.Message);
            }
        }
    }
}
