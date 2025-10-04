
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

    /// <summary>
    /// Search for a veterinarian by name (case-insensitive).
    /// </summary>
    /// <param name="vetName">The name of the veterinarian to search for.</param>
    /// <returns>
    /// The veterinarian object if found; otherwise, null.
    /// </returns>
    
    
    public Veterinarian? SearchVeterinarianByName(string vetName)
    {
        return Veterinarians.FirstOrDefault(v =>
            v.Name.Equals(vetName, StringComparison.OrdinalIgnoreCase));
    }

}