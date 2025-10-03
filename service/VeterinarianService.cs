
using models;
using Interface;

public class VeterinarianService : IRegistrable<Veterinarian>
{
    private List<Veterinarian> Veterinarians = new List<Veterinarian>();
    public void Register(Veterinarian vet)
    {
        Veterinarians.Add(vet);
    }

    /// <summary>
    /// List all registered veterinarians.
    /// </summary>

    public List<Veterinarian> GetAllVeterinarians()
    {
        return Veterinarians;
    }

    /// <summary>
    /// List all veterinarians with a specific specialty.
    /// </summary>
    
    public List<Veterinarian> ListVeterinariansBySpecialty(string specialty)
    {
        return Veterinarians.Where(v => v.Specialty.Equals(specialty, StringComparison.OrdinalIgnoreCase)).ToList();
    }

}