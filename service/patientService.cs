
using models;
using Interface;

/// <summary>
/// Service class responsible for managing patients in memory.
/// Provides operations to register, retrieve and search patients.
/// </summary>
public class patientService : IRegistrable<Owner>, INotificable
{
    /// <summary>
    /// Internal list that stores all registered patients.
    /// </summary>
    private List<Owner> Patients = new List<Owner>();

    /// <summary>
    /// Registers a new patient into the system.
    /// </summary>
    /// <param name="patient">The patient object to be added.</param>
    public void Register(Owner patient)
    {
        Patients.Add(patient);
    }
    

    /// <summary>
    /// Retrieves all registered patients.
    /// </summary>
    /// <returns>A list containing all patients.</returns>
    public List<Owner> GetAllPatients()
    {
        return Patients;
    }

    /// <summary>
    /// Searches for a patient by name (case-insensitive).
    /// </summary>
    /// <param name="patientName">The name of the patient to search for.</param>
    /// <returns>
    /// The patient object if found; otherwise, null.
    /// </returns>
    public Owner? SearchPatientsByName(string patientName)
    {
        return Patients.FirstOrDefault(p =>
            p.Name.Equals(patientName, StringComparison.OrdinalIgnoreCase));
    }

    public void Notify()
    {
        Console.WriteLine("Recording the citation in the patient's agenda...");  
    }
}
