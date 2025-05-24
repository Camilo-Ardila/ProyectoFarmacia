using System;
using System.Collections.Generic;
using BibliotecaFarmacia.Clases;
using BibliotecaFarmacia.Eventos;

public abstract class Inventario
{
    public static List<Medicamento> l_inventario = new List<Medicamento>();
    public Publisher_Reorden notificacion_reorden = new Publisher_Reorden();
    public Publisher_Vencimiento notificacion_vencimiento = new Publisher_Vencimiento();

    public List<string> MensajesEventos { get; private set; } = new List<string>();

    protected Inventario()
    {
        try
        {
            notificacion_reorden.evento_existencias += EventHandler;
            notificacion_vencimiento.evento_fecha += EventHandler;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al suscribirse a los eventos: {ex.Message}");
        }
    }

    public void VerificarInventario()
    {
        try
        {
            MensajesEventos.Clear();

            foreach (var med in l_inventario)
            {
                notificacion_reorden.Informar_reorden(l_inventario);
                notificacion_vencimiento.Informar_Vencimiento(med);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al verificar el inventario: {ex.Message}");
        }
    }

    public void EventHandler(Medicamento med)
    {
        try
        {
            if (med.Cantidad <= 10)
            {
                MensajesEventos.Add($"¡Advertencia! El medicamento '{med.nom_medicamento}' tiene solo {med.Cantidad} unidades.");
            }

            if ((med.fecha_vencimiento - DateTime.Now).TotalDays <= 30)
            {
                MensajesEventos.Add($"¡Atención! El medicamento '{med.nom_medicamento}' vencerá el {med.fecha_vencimiento:dd/MM/yyyy}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al manejar el evento para el medicamento '{med?.nom_medicamento}': {ex.Message}");
        }
    }
}
