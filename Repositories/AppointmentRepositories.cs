
using Repositories;
using Interface;
using models;
using ClinicaSalud.data;

namespace Repositories;


public class AppointmeRepository : IAppointmentRepository
{
    /// <summary>
    /// Create a cita
    /// </summary>
    /// <param name="cita"></param>
    public void create(Cita cita)
    {
        DataBase.appointments.Add(cita);
    }

    /// <summary>
    /// List all citas
    /// </summary>
    /// <returns></returns>
    public List<Cita> GetAll()
    {
        return DataBase.appointments;
    }

    // Quiero tarea todas las citas por el nombre del veterinario ??? como lo haces???

    // TODO: recibir el nombre del veterinario [x]
    // TODO: hacer una consulta donde por ese nombre del veterinario traiga todas las citas??? [x]

    public List<Cita>? GetByName(string name)
    {
        var citas = DataBase.appointments
           .Where(cita => cita.veterinario != null &&
                          cita.veterinario.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
           .ToList();

        // Si no hay citas, devolver null
        if (citas.Count == 0)
            return null;

        return citas;
    }

}