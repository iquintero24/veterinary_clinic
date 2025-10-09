
using models;
using Interface;
using Repositories;

public class VeterinarianService : IRegistrable<Veterinarian>
{
    //📦 Dependency: The service needs a repository to work (a dependency is instantiated)
    //📦 Dependencia: el servicio necesita un repositorio para funcionar(se instacia una dependencia)

    private readonly IVeterinarianRepository _veterinarianRepositoy;

    // the constructor is instantiated to create the dependency injection that is needed()
    // se instacia el cosntructor para crear la injection de dependencias que se necesita()

    public VeterinarianService(IVeterinarianRepository veterinarianRepository)
    {
        _veterinarianRepositoy = veterinarianRepository;
    }

    public VeterinarianService() : this(new VeterinarianRepository())
    {
        
    }

    /// <summary>
    /// Register veterinarian 
    /// </summary>
    /// <param name="vet"></param>

    public void Register(Veterinarian vet)
    {
        _veterinarianRepositoy.create(vet);
    }

    /// <summary>
    /// List all registered veterinarians.
    /// </summary>

    public List<Veterinarian> GetAllVeterinarians()
    {
        var veterinarians = _veterinarianRepositoy.GetAll();
        return veterinarians;
    }



    /// <summary>
    /// Search for a veterinarian by name (case-insensitive).
    /// </summary>
    /// <param name="vetName">The name of the veterinarian to search for.</param>
    /// <returns>
    /// The veterinarian object if found; otherwise, null.
    /// </returns>


    public Veterinarian? SearchVeterinarianByName(string vetName)
    {
        // instacias una variable que reciba lo que devuelva la interracion del repositorio con la listas:

        var veterinarian = _veterinarianRepositoy.GetByName(vetName);

        if (veterinarian == null)
        {
            // debes de devolver un msg al usuario donde notifiques que no se encontro el paciente con ese nombre:
            Console.WriteLine($"No se encontro ningun dueño con ese nombre {vetName}");
        }
        else
        {
            // debes de devolver un msg al usuario donde notifiques que se encontro el paciente con ese nombre:
            // msg type success:
            Console.WriteLine($"se encontro un veterinario con ese  nombre {veterinarian.Name}");
        }

        //retornamos el resultado si se encontro
        return veterinarian;
    }
    
    /// <summary>
    /// List all veterinarians with a specific specialty.
    /// </summary>

    public List<Veterinarian> ListVeterinariansBySpecialty(string specialty)
    {
        return _veterinarianRepositoy.GetBySpecialty(specialty);
    }

}