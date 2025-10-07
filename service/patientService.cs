
using models;
using Interface;


/// <summary>
/// Service class responsible for managing patients in memory.
/// Provides operations to register, retrieve and search patients.
/// </summary>
public class patientService : IRegistrable<Owner>, INotificable
{

    // 📦 Dependencia: el servicio necesita un repositorio para funcionar(se instacia una dependencia)
    private readonly IOwnerRepository _ownerRepository;

    // se instacia el cosntructor para crear la injection de dependencias que se necesita()
    public patientService(IOwnerRepository ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }

    public void Register(Owner owner)
    {
        // aca van las validaciones que se requieren para guardar el owner correctamente:
        // [] TODO: validar el nombre del Owner se un tipo string. 
        // [] TODO: validar la edad del Owner no sea negativa.

        // Aclaracion todo esto se debe hacer en una class de validaciones: validaciones.cs
        // Tarea para hacer en casa [].

        _ownerRepository.createOwner(owner);
    }

    public List<Owner> GetAllOwners()
    {
        //Aca no se deben de hacer validaciones ya que son datos que ya estan correctors: 
        // Obtiene la lista de owners desde el repositorio
        var owners = _ownerRepository.getAllOwners();

        // Devuelve la lista al que llame este método
        return owners;
    }

    public Owner? GetOwnerByname(string ownerName)
    {
        //aca se debe validar primero el nombre sea valido:
        //[] TODO: validar el nombre con la misma validacion de register

        // instacias una variable que reciba lo que devuelva la interracion del repositorio con la listas:

        var owner = _ownerRepository.GetOwnerByname(ownerName);

        if (owner == null)
        {
            // debes de devolver un msg al usuario donde notifiques que no se encontro el paciente con ese nombre:
            Console.WriteLine($"No se encontro ningun dueño con ese nombre {ownerName}");
        }
        else
        {
            // debes de devolver un msg al usuario donde notifiques que se encontro el paciente con ese nombre:
            // msg type success:
            Console.WriteLine($"No se encontro ningun dueño con ese nombre {owner.Name}");
        }

        //retornamos el resultado si se encontro
        return owner;
    
    }


    public void Notify()
    {
        throw new NotImplementedException();
    }


}
