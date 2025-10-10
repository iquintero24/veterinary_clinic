using Service;
using models;

namespace utils
{
    public class PetMenu
    {
        private readonly PetService petService;
        private readonly patientService patientService;

        public PetMenu()
        {
            petService = new PetService();
            patientService = new patientService();
        }

        public void MostrarMenuMascotas()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== 🐾 PET MENU ======");
                Console.WriteLine("1. Register Pet");
                Console.WriteLine("2. List Pets");
                Console.WriteLine("3. Back");
                Console.Write("Select an option: ");

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1": RegisterPet(); break;
                    case "2": ListPets(); break;
                    case "3": return;
                    default:
                        Console.WriteLine("Invalid option"); Console.ReadKey(); break;
                }
            }
        }

        private void RegisterPet()
        {
            Console.Write("Enter the patient's name (owner): ");
            string ownerName = Console.ReadLine() ?? "";
            // TODO: VALIDAR EL NOMBRE DEL OWNER [x]:
            if (Validations.ValidateName(ownerName))
            {
                var owner = patientService.GetOwnerByname(ownerName);
                // valida si encontro el owner:

                if (owner == null)
                {
                    // en caso de no encontrarlo:
                    Console.WriteLine("Owner not found. Cannot register pet.");
                    Console.ReadKey();
                    return;
                }
                // sigue el flujo de el metodo: 

                Console.Write("Enter pet's name: ");
                string petName = Console.ReadLine() ?? "";

                Console.Write("Enter pet's age: ");
                int petAge = int.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter species (dog, cat, etc.): ");
                string species = Console.ReadLine() ?? "";

                Console.Write("Enter breed: ");
                string breed = Console.ReadLine() ?? "";

                // creacion del objeto pet
                var newPet = new models.Pet(petName, petAge, species, breed, owner);
                petService.Register(newPet);

                Console.ReadKey();
            }
            // en caso de no encontrar el owner;    
            else
            {
                Console.WriteLine("Owner is invalide.");
                return;
            }
        }

        private void ListPets()
        {
            Console.Write("Enter the patient's name: ");
            string ownerName = Console.ReadLine() ?? "";
            // TODO: VALIDAR EL NOMBRE DEL OWNER [x]:
            if (Validations.ValidateName(ownerName))
            {
                var owner = patientService.GetOwnerByname(ownerName);

                // valida si encontro el owner:
                if (owner != null) petService.ListPets(owner);
                else Console.WriteLine("Owner not found.");
                // sigue el flujo de el metodo:
                Console.ReadKey();
            }
            // en caso de no encontrar el owner;            
            else
            {
                Console.WriteLine("Owner is invalide.");
                return;
            }
        }
    }
}
