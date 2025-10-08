using ClinicaSalud.data;
using Interface;
using models;

namespace Repositories;

public class VeterinarianRepository : IVeterinarianRepository
{
    /// <summary>
    /// create a veterinarian.
    /// </summary>
    /// <param name="veterinarian"></param>
    public void create(Veterinarian veterinarian)
    {
        DataBase.veterinarians.Add(veterinarian);
    }

    /// <summary>
    /// List the veterinarian    
    /// </summary>
    /// <returns></returns>
    public List<Veterinarian> GetAll()
    {
        return DataBase.veterinarians;
    }

    /// <summary>
    /// Seach the veterinarian
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Veterinarian? GetByName(string name)
    {
        return DataBase.veterinarians.FirstOrDefault(veterinarian => veterinarian.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Seach veterinarian by specialty
    /// </summary>
    /// <param name="specialty"></param>
    /// <returns></returns>
    public List<Veterinarian> GetBySpecialty(string specialty)
    {
        return DataBase.veterinarians.Where(v => v.Specialty.Equals(specialty, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}