using models;
using Interface;
using Repositories;

namespace Service
{
    public class PetService : IRegistrable<Pet>
    {
        // 📦 Dependencia: el servicio necesita un repositorio para funcionar(se instacia una dependencia)
        private readonly IPetRepository _petRepository;

        // se instacia el constructor para crear la injection de dependencias que se necesita()
        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        // 🔹 Constructor por defecto (usa repositorio concreto si no se pasa ninguno)
        public PetService() : this(new PetRepository())
        {

        }

        // Registrar mascota y asociarla al dueño
        public void Register(Pet pet)
        {
            // validar que el objeto no sea null 
            if (pet == null)
            {
                Console.WriteLine("Pet a register is null");
                return;
            }

            // buscar si ya existe un perro con ese nombre
            var existPet = _petRepository.GetByName(pet.Name);
            if (existPet != null)
            {
                Console.WriteLine("Pet Exist in de database");
                return;
            }

            _petRepository.create(pet);

            // si tiene owner agregarla a su lista de mascotas:

            if (pet.Owner != null && !pet.Owner.Pets.Any(p => p.Id == pet.Id))
            {
                // esto podriamos crear un metodo en el repositorio para que el servicio no pueda modificar esto directamente
                _petRepository.AddPetToOwner(pet);
            }

        }

        // Listar mascotas de un paciente
        public void ListPets(Owner owner)
        {
            if (owner.Pets.Count > 0)
            {
                Console.WriteLine($"Pets of {owner.Name}:");
                foreach (var pet in owner.Pets)
                {
                    pet.MostrarInfo();
                }
            }
            else
            {
                Console.WriteLine("This patient has no pets registered.");
            }
        }

        // Buscar mascota por nombre en un dueño específico
        public Pet? SearchPetByName(Owner owner, string petName)
        {
            return owner.Pets.FirstOrDefault(p =>
                p.Name.Equals(petName, StringComparison.OrdinalIgnoreCase));
        }

        // Obtener todas las mascotas de la clínica
        public List<Pet> GetAllPets()
        {
            return _petRepository.GetAll();
        }
    }
}