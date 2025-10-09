
using ClinicaSalud.data;
using Interface;
using models;

namespace Repositories;

public class PetRepository : IPetRepository
{
    /// <summary>
    /// Create the pet.
    /// </summary>
    /// <param name="pet"></param>
    public void create(Pet pet)
    {
        DataBase.pets.Add(pet);
    }

    /// <summary>
    /// List the All pets.
    /// </summary>
    /// <returns></returns>
    public List<Pet> GetAll()
    {
        return DataBase.pets;
    }

    /// <summary>
    /// seach the pet by name
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Pet? GetByName(string name)
    {
        return DataBase.pets.FirstOrDefault(pet => pet.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    ///  Add the pet a Owner
    /// </summary>
    /// <param name="pet"></param>
    public void AddPetToOwner(Pet pet)
    {
        pet.Owner.Pets.Add(pet);
    }

    /// <summary>
    /// List Pets by Owner.
    /// </summary>
    /// <param name="owner"></param>
    /// <returns></returns>
    public List<Pet> GetPetsByOwner(Owner owner)
    {
        return owner.Pets;
    }

    /// <summary>
    /// search Pet By name in owner
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="petName"></param>
    /// <returns></returns>
    public Pet? SearchPetByName(Owner owner, string petName)
    {
        return owner.Pets.FirstOrDefault(p =>
               p.Name.Equals(petName, StringComparison.OrdinalIgnoreCase));
    }

}