using Service;
using models;

namespace utils
{
    public class VetMenu
    {
        private readonly VeterinarianService veterinarianService;

        public VetMenu()
        {
            veterinarianService = new VeterinarianService();
        }

        public void MostrarMenuVeterinarios()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== 👨‍⚕️ VETERINARIANS MENU ======");
                Console.WriteLine("1. Register Veterinarian");
                Console.WriteLine("2. List Veterinarians");
                Console.WriteLine("3. Search by Name");
                Console.WriteLine("4. Back");
                Console.Write("Select an option: ");

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1": RegisterVet(); break;
                    case "2": ListVets(); break;
                    case "3": SearchVet(); break;
                    case "4": return;
                    default:
                        Console.WriteLine("Invalid option"); Console.ReadKey(); break;
                }
            }
        }

        private void RegisterVet()
        {
            Console.WriteLine("Register veterinarian.");

            string name;
            while (true)
            {
                Console.Write("Enter veterinarian's name: ");
                name = Console.ReadLine() ?? "";
                if (Validations.ValidateName(name)) break;
                Console.WriteLine("Invalid name. Please enter a valid name.");
            }

            int age;
            while (true)
            {
                Console.Write("Enter veterinarian's age: ");
                string inputAge = Console.ReadLine() ?? "";
                if (int.TryParse(inputAge, out age) && Validations.ValidationEdad(age)) break;
                Console.WriteLine("Invalid age. Please enter a valid number.");
            }

            Console.Write("Enter veterinarian's specialty: ");
            string specialty = Console.ReadLine() ?? "";

            var newVet = new Veterinarian(name, age, specialty);
            veterinarianService.Register(newVet);


            // Aquí podrías agregar el veterinario a una lista si tienes un servicio para eso

            Console.WriteLine("Veterinarian registered successfully.");
            Console.ReadKey();
        }

        private void ListVets()
        {
            var vets = veterinarianService.GetAllVeterinarians();
            if (vets.Count > 0)
            {
                Console.WriteLine("\nRegistered Veterinarians:");
                foreach (var v in vets)
                {
                    Console.WriteLine($"ID: {v.Id}, Name: {v.Name}, Specialty: {v.Specialty}");
                }
            }
            else
            {
                Console.WriteLine("No veterinarians registered.");
            }
            Console.ReadKey();
        }

        private void SearchVet()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine() ?? "";
            if (!Validations.ValidateName(name))
            {
                Console.WriteLine($"Name is invalide {name}");
            }
            var vet = veterinarianService.SearchVeterinarianByName(name);

            if (vet != null)
                Console.WriteLine($"✅ Found: {vet.Name} - {vet.Specialty}");
            else
                Console.WriteLine("❌ Veterinarian not found.");

            Console.ReadKey();
        }
    }
}
