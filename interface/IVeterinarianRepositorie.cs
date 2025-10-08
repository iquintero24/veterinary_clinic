

using models;

namespace Interface;

// esta interfaz se realizo para respetar los principios SOLID: Interface segregation

public interface IVeterinarianRepository : ICrudRepository<Veterinarian>
{
    // Aca van las consultas que no son CRUD:

    //Seach the veterinarian by specialty:
    List<Veterinarian> GetBySpecialty(string specialty);
}
