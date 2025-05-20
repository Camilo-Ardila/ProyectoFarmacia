using System;
using System.Collections.Generic;

namespace BibliotecaFarmacia.Clases
{
    public abstract class Inventario
    {
        public static List<Medicamento> l_inventario = new List<Medicamento>();
        protected Publisher_Reorden notificacion_reorden = new Publisher_Reorden();
        protected Publisher_Vencimiento notificacion_vencimiento = new Publisher_Vencimiento();

        public Inventario()
        {
            // Suscripciones a eventos
            notificacion_reorden.evento_existencias += EventHandler;
            notificacion_vencimiento.evento_fecha += EventHandler;
        }

        // Método que verifica si debe haber reorden o alerta de vencimiento
        public void VerificarInventario()
        {
            foreach (var med in l_inventario)
            {
                notificacion_reorden.Informar_reorden(med);
                notificacion_vencimiento.Informar_Vencimiento(med);
            }
        }

        // Manejador de ambos eventos
        public void EventHandler(Medicamento med)
        {
            if (med.Cantidad <= 10)
            {
                Console.WriteLine($"¡Advertencia! El medicamento '{med.Nom_medicamento}' tiene solo {med.Cantidad} unidades. Se requiere reorden.");
            }

            if ((med.Fecha_vencimiento - DateTime.Now).TotalDays <= 30)
            {
                Console.WriteLine($"¡Atención! El medicamento '{med.Nom_medicamento}' vencerá el {med.Fecha_vencimiento:dd/MM/yyyy}. Se debe retirar pronto.");
            }
        }
    }
}


