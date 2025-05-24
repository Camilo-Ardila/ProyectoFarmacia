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
        notificacion_reorden.evento_existencias += EventHandler;
        notificacion_vencimiento.evento_fecha += EventHandler;
    }

    public void VerificarInventario()
    {
        // Recalcular agrupación antes de emitir eventos
        Farmacia.ConstruirInventarioAgrupado();

        MensajesEventos.Clear();

        notificacion_reorden.Informar_reorden(Inventario.l_inventario);

        foreach (var med in l_inventario)
        {
            notificacion_vencimiento.Informar_Vencimiento(med);
        }
    }




    public void EventHandler(Medicamento med)
    {
        // Buscar cantidad directamente desde Farmacia.inventario
        var entry = Farmacia.inventario.FirstOrDefault(x =>
            x.medicamento.Nom_medicamento.ToLower() == med.Nom_medicamento.ToLower());

        if (entry.cantidad <= 10)
        {
            MensajesEventos.Add($"¡Advertencia! Solo hay {entry.cantidad} registros de '{med.Nom_medicamento}'.");
        }

        // Verifica vencimiento como antes
        if ((med.Fecha_vencimiento - DateTime.Now).TotalDays <= 30)
        {
            MensajesEventos.Add($"¡Atención! '{med.Nom_medicamento}' vencerá el {med.Fecha_vencimiento:dd/MM/yyyy}.");
        }
    }



}
