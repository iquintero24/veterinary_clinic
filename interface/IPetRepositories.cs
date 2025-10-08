

using models;

namespace Interface;

public interface IPetRepository : ICrudRepository<Pet>
{
    // Aca van las consultas que no son CRUD:
    // Vacio por el momento

    void AddPetToOwner(Pet pet);
}