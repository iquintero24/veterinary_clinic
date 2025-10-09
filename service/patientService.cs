
using models;
using Interface;
using Repositories;


/// <summary>
/// Service class responsible for managing patients in memory.
/// Provides operations to register, retrieve and search patients.
/// </summary>
public class patientService : IRegistrable<Owner>, INotificable
{

    //  Dependencia: el servicio necesita un repositorio para funcionar(se instacia una dependencia)
    private readonly IOwnerReposiroty _ownerRepository;

    // se instacia el constructor para crear la injection de dependencias que se necesita()
    public patientService(IOwnerReposiroty ownerRepository)
    {
        _ownerRepository = ownerRepository;
    }

    // 🔹 Constructor por defecto (usa repositorio concreto si no se pasa ninguno)
    public patientService() : this(new OwnerRepository())
    {
    }

    public void Register(Owner owner)
    {
        // aca van las validaciones que se requieren para guardar el owner correctamente:
        // [x] TODO: validar el nombre del Owner se un tipo string. 
        // [x] TODO: validar la edad del Owner no sea negativa.
        // [x] TODO: validar que el telefono sea valido.

        // Aclaracion todo esto se debe hacer en una class de validaciones: validaciones.cs
        // Tarea para hacer en casa [x].

        _ownerRepository.create(owner);
    }

    public List<Owner> GetAllOwners()
    {
        //Aca no se deben de hacer validaciones ya que son datos que ya estan correctors: 
        // Obtiene la lista de owners desde el repositorio
        var owners = _ownerRepository.GetAll();

        // Devuelve la lista al que llame este método
        return owners;
    }

    public Owner? GetOwnerByname(string ownerName)
    {
        //aca se debe validar primero el nombre sea valido:
        //[] TODO: validar el nombre con la misma validacion de register

        // instacias una variable que reciba lo que devuelva la interracion del repositorio con la listas:

        var owner = _ownerRepository.GetByName(ownerName);

        if (owner == null)
        {
            // debes de devolver un msg al usuario donde notifiques que no se encontro el paciente con ese nombre:
            Console.WriteLine($"No se encontro ningun dueño con ese nombre {ownerName}");
        }
        else
        {
            // debes de devolver un msg al usuario donde notifiques que se encontro el paciente con ese nombre:
            // msg type success:
            Console.WriteLine($"Dueño encontrado con exito:  {owner.Name}");
        }

        //retornamos el resultado si se encontro
        return owner;
    
    }


    public void Notify()
    {
        throw new NotImplementedException();
    }


}
