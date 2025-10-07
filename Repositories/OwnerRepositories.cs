using models;
using ClinicaSalud.data;
using Interface;

namespace Repositories;

public class OwnerRepositories : IOwnerRepository
{

    /// <summary>
    /// Method to add a new owner to the database
    /// </summary>
    /// <param name="owner"></param>

    public void createOwner(Owner owner)
    {
        DataBase.Owner.Add(owner);
    }

    /// <summary>
    /// Method to retrieve all owners from the database
    /// </summary>
    /// <returns>List of owners</returns>
    public List<Owner> getAllOwners()
    {
        return DataBase.Owner;
    }

    /// <summary>
    /// Method to search for an owner by name (case-insensitive)
    /// </summary>
    /// <param name="ownerName">The name of the owner to search for</param
    public Owner? GetOwnerByname(string ownerName)
    {
        return DataBase.Owner.FirstOrDefault(owner => owner.Name.Equals(ownerName, StringComparison.OrdinalIgnoreCase));
    }
    
}