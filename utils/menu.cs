namespace ClinicaSalud.ui
{
    public class Menu
    {
        private patientService patientService = new patientService();
        private PetService petService = new PetService();
        private Validations validations = new Validations();

        public void MostrarMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Health Clinic Menu");
                Console.WriteLine("1. Register Owner");
                Console.WriteLine("2. List Patients");
                Console.WriteLine("3. Search Owner by Name");
                Console.WriteLine("4. Register Pet");
                Console.WriteLine("5. List Pets of a Owner");
                Console.WriteLine("6. Search Pet by Name");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1":
                        RegistrarPaciente();
                        break;
                    case "2":
                        ListarPacientes();
                        break;
                    case "3":
                        BuscarPaciente();
                        break;
                    case "4":
                        RegistrarMascota();
                        break;
                    case "5":
                        ListarMascotas();
                        break;
                    case "6":
                        BuscarMascota();
                        break;
                    case "7":
                        Console.WriteLine("Leaving...");
                        return;
                    default:
                        Console.WriteLine("Invalid option, try again..");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // --- Métodos privados del menú ---
        private void RegistrarPaciente()
        {
            Console.WriteLine("Register patient.");

            string name;
            while (true)
            {
                Console.Write("Enter patient's name: ");
                name = Console.ReadLine() ?? "";
                if (validations.ValidateName(name)) break;
                Console.WriteLine("Invalid name. Please enter a valid name.");
            }

            int age;
            while (true)
            {
                Console.Write("Enter patient's age: ");
                string inputAge = Console.ReadLine() ?? "";
                if (int.TryParse(inputAge, out age) && validations.ValidationEdad(age)) break;
                Console.WriteLine("Invalid age. Please enter a valid number.");
            }

            Console.Write("Enter patient's telefono : ");
            string telefono = Console.ReadLine() ?? "";

            var newPatient = new models.Owner(name, age, telefono);
            patientService.Register(newPatient);

            Console.WriteLine("Owner registered successfully.");
            Console.ReadKey();
        }

        private void ListarPacientes()
        {
            var patients = patientService.GetAllPatients();
            if (patients.Count > 0)
            {
                Console.WriteLine("\nRegistered Patients:");
                foreach (var p in patients)
                {
                    p.MostrarInfo();
                }
            }
            else
            {
                Console.WriteLine("No patients registered.");
            }
            Console.ReadKey();
        }

        private void BuscarPaciente()
        {
            Console.Write("Enter the patient's name: ");
            string name = Console.ReadLine() ?? "";
            var found = patientService.SearchPatientsByName(name);
            if (found != null) found.MostrarInfo();
            else Console.WriteLine("Owner not found.");
            Console.ReadKey();
        }

        private void RegistrarMascota()
        {
            Console.Write("Enter the patient's name (owner): ");
            string ownerName = Console.ReadLine() ?? "";
            var owner = patientService.SearchPatientsByName(ownerName);

            if (owner == null)
            {
                Console.WriteLine("Owner not found. Cannot register pet.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter pet's name: ");
            string petName = Console.ReadLine() ?? "";

            Console.Write("Enter pet's age: ");
            int petAge = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter species (dog, cat, etc.): ");
            string species = Console.ReadLine() ?? "";

            Console.Write("Enter breed: ");
            string breed = Console.ReadLine() ?? "";

            var newPet = new models.Pet(petName, petAge, species, breed, owner);
            petService.Register(newPet);

            Console.ReadKey();
        }

        private void ListarMascotas()
        {
            Console.Write("Enter the patient's name: ");
            string ownerName = Console.ReadLine() ?? "";
            var owner = patientService.SearchPatientsByName(ownerName);

            if (owner != null) petService.ListPets(owner);
            else Console.WriteLine("Owner not found.");
            Console.ReadKey();
        }

        private void BuscarMascota()
        {
            Console.Write("Enter the patient's name: ");
            string ownerName = Console.ReadLine() ?? "";
            var owner = patientService.SearchPatientsByName(ownerName);

            if (owner == null)
            {
                Console.WriteLine("Owner not found.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter the pet's name: ");
            string petName = Console.ReadLine() ?? "";
            var pet = petService.SearchPetByName(owner, petName);

            if (pet != null) pet.MostrarInfo();
            else Console.WriteLine("Pet not found.");
            Console.ReadKey();
        }
    }
}
