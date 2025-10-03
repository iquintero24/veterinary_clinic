using models;
using Interface;

public class AgendaService : IRegistrable<Cita>
{
    
    public void Register(Cita cita)
    {
        cita.veterinario.Agenda.Citas.Add(cita);
    }

}
