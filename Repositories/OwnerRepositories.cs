using models;
using ClinicaSalud.data;
using Interface;

namespace Repositories;

public class OwnerRepository : IOwnerReposiroty
{

    /// <summary>
    /// Method to add a new owner to the database
    /// </summary>
    /// <param name="owner"></param>

    public void create(Owner owner)
    {
        DataBase.Owner.Add(owner);
    }

    /// <summary>
    /// Method to retrieve all owners from the database
    /// </summary>
    /// <returns>List of owners</returns>
    public List<Owner> GetAll()
    {
        return DataBase.Owner;
    }

    /// <summary>
    /// Method to search for an owner by name (case-insensitive)
    /// </summary>
    /// <param name="ownerName">The name of the owner to search for</param
    public Owner? GetByName(string name)
    {
        return DataBase.Owner.FirstOrDefault(owner => owner.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    
}

