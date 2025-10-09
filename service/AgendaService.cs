using models;
using Interface;
using Repositories;

public class AgendaService : IRegistrable<Cita>
{

    // Dependencia: el servicio necesita un repositorio para funcionar(se instacia una dependencia)
    private readonly IAppointmentRepository _appointmentRepository;

    // se debe de crear el constructor para este servicio:
    public AgendaService(IAppointmentRepository appointmentRepository)
    {
        _appointmentRepository = appointmentRepository;
    }

    // Constructor por defecto (usa el repositorio si no se pasa ninguno):
    public AgendaService() : this(new AppointmeRepository())
    {

    }

    /// <summary>
    /// Register Cita
    /// </summary>
    /// <param name="cita"></param>
    public void Register(Cita cita)
    {
        _appointmentRepository.create(cita);
    }

    /// <summary>
    /// Get all citas in the database
    /// </summary>
    /// <returns></returns>
    public List<Cita> GetAllAgenda()
    {
        return _appointmentRepository.GetAll();
    }

    /// <summary>
    /// get Citas by Name of vet
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public List<Cita> GetCitaByNameOfVet(string name)
    {
        var vetCita = _appointmentRepository.GetByName(name);

        if (vetCita == null || vetCita.Count == 0)
        {
            Console.WriteLine("The vet has no appointments.");
        }

        // evitamos checks ( null )
        return vetCita ?? new List<Cita>();
    }

}
