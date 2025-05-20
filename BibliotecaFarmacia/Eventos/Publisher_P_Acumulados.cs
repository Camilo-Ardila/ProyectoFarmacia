using System;

namespace BibliotecaFarmacia.Clases
{
    public delegate void delegado_ptos_compra(string ptos);

    public class Publisher_P_Acumulados
    {
        public event delegado_ptos_compra evento_ptos;

        public void Informar_P_Acumulados(string ptos)
        {
            if (evento_ptos != null)
            {
                evento_ptos(ptos);
            }
        }
    }
}


