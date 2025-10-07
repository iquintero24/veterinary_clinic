using models;

namespace Interface;

public interface IOwnerRepository
{
    void createOwner(Owner owner);

    List<Owner> getAllOwners();

    Owner? GetOwnerByname(string ownerName);
}