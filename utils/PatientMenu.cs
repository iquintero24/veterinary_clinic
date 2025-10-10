using Service;
using models;

namespace utils
{
    public class PatientMenu
    {
        private readonly patientService patientService; // servicio (Logica de negocio)
        public PatientMenu()
        {
            patientService = new patientService();
        }

        public void MostrarMenuPaciente()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== 👩‍⚕️ PATIENT MENU ======");
                Console.WriteLine("1. Register new patient");
                Console.WriteLine("2. List patients");
                Console.WriteLine("3. Search patient by name");
                Console.WriteLine("4. Back");
                Console.Write("Select an option: ");
                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1": RegisterPatient(); break;
                    case "2": ListPatients(); break;
                    case "3": SearchByName(); break;
                    case "4": return;
                    default: Console.WriteLine("Invalid option"); Console.ReadKey(); break;
                }
            }
        }

        private void RegisterPatient()
        {
            Console.WriteLine("Register patient.");

            string name;
            while (true)
            {
                Console.Write("Enter patient's name: ");
                name = Console.ReadLine() ?? "";
                if (Validations.ValidateName(name)) break;
                Console.WriteLine("Invalid name. Please enter a valid name.");
            }

            int age;
            while (true)
            {
                Console.Write("Enter patient's age: ");
                string inputAge = Console.ReadLine() ?? "";
                if (int.TryParse(inputAge, out age) && Validations.ValidationEdad(age)) break;
                Console.WriteLine("Invalid age. Please enter a valid number.");
            }

            Console.Write("Enter patient's telefono : ");
            string telefono = Console.ReadLine() ?? "";

            var newPatient = new models.Owner(name, age, telefono);
            patientService.Register(newPatient);

            Console.WriteLine("Owner registered successfully.");
            Console.ReadKey();
        }

        private void ListPatients()
        {
            var patients = patientService.GetAllOwners();
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

        private void SearchByName()
        {
            Console.Write("Enter the patient's name: ");

            string name = Console.ReadLine() ?? "";

            var found = patientService.GetOwnerByname(name);
            
            if (found != null) found.MostrarInfo();
            else Console.WriteLine("Owner not found.");
            Console.ReadKey();
        }
    }
}
