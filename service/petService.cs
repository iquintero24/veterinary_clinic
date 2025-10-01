using models;

namespace ClinicaSalud
{
    public class PetService
    {
        private List<Pet> Pets = new List<Pet>();

        // Registrar mascota y asociarla al dueño
        public void RegisterPet(Pet pet)
        {
            // Evitar registrar duplicados por Id
            if (!Pets.Any(p => p.Id == pet.Id))
            {
                Pets.Add(pet);

                // Si el dueño no la tiene en su lista, la agregamos
                if (pet.Owner != null && !pet.Owner.Pets.Any(p => p.Id == pet.Id))
                {
                    pet.Owner.Pets.Add(pet);
                }

                Console.WriteLine($"Pet '{pet.Name}' registered successfully!");
            }
            else
            {
                Console.WriteLine("This pet is already registered.");
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
            return Pets;
        }
    }
}