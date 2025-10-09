

using models;

namespace Interface;

public interface IPetRepository : ICrudRepository<Pet>
{
    // Aca van las consultas que no son CRUD:
    // Vacio por el momento

    // Add pet the Owner
    void AddPetToOwner(Pet pet);

    //List the pets by owner
    List<Pet> GetPetsByOwner(Owner owner);

    // seach the pets by name
    Pet? SearchPetByName(Owner owner, string petName);
}