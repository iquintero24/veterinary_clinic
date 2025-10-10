using Service;
using models;

namespace utils
{
    public class AgendaMenu
    {
        private readonly AgendaService agendaService;
        private readonly patientService patientService; // servicio (Logica de negocio)
        private readonly PetService petService;



        private readonly VeterinarianService veterinarianService;

        public AgendaMenu()
        {
            agendaService = new AgendaService();
            patientService = new patientService();
            veterinarianService = new VeterinarianService();
            petService = new PetService();
        }

        public void MostrarMenuAgenda()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== 📅 AGENDA MENU ======");
                Console.WriteLine("1. Schedule Appointment");
                Console.WriteLine("2. View All Appointments");
                Console.WriteLine("3. Search Appointments by Veterinarian");
                Console.WriteLine("4. Back");
                Console.Write("Select an option: ");

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1": AgendarCita(); break;
                    case "2": GetAllAgenda(); break;
                    case "3": GetCitaByNameOfVet(); break;
                    case "4": return;
                    default: Console.WriteLine("Invalid option"); Console.ReadKey(); break;
                }
            }
        }

        private void AgendarCita()
        {
            Console.WriteLine("Enter the veterinarian's name: ");
            string vetName = Console.ReadLine() ?? "";

            // ✅ Validar nombre del veterinario
            if (!Validations.ValidateName(vetName))
            {
                Console.WriteLine($"The veterinarian name '{vetName}' is invalid.");
                return;
            }

            // ✅ Buscar veterinario
            Veterinarian? vet = veterinarianService.SearchVeterinarianByName(vetName);
            if (vet == null)
            {
                Console.WriteLine($"The veterinarian '{vetName}' was not found.");
                return;
            }

            // ✅ Solicitar nombre de la mascota
            Console.Write("Enter the pet's name: ");
            string petName = Console.ReadLine() ?? "";

            if (!Validations.ValidateName(petName))
            {
                Console.WriteLine($"The pet name '{petName}' is invalid.");
                return;
            }

            Console.Write("Enter the owner's name: ");
            string ownerName = Console.ReadLine() ?? "";

            if (!Validations.ValidateName(ownerName))
            {
                Console.WriteLine($"The owner name '{ownerName}' is invalid.");
                return;
            }

            var owner = patientService.GetOwnerByname(ownerName);
            if (owner == null)
            {
                Console.WriteLine($"Owner '{ownerName}' not found.");
                return;
            }

            // ✅ Buscar la mascota dentro del dueño
            var pet = petService.SearchPetByName(owner, petName);
            if (pet == null)
            {
                Console.WriteLine($"No pet named '{petName}' found for owner '{ownerName}'.");
                return;
            }

            // ✅ Pedir fecha y hora
            Console.Write("Enter appointment date (yyyy-mm-dd): ");
            DateTime date;
            if (!DateTime.TryParse(Console.ReadLine(), out date))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            //Pedir la razon de la cita
            Console.Write("Enter the appointment reason: ");
            string reason = Console.ReadLine() ?? "General checkup";

            // ✅ Crear la cita
            Cita nuevaCita = new Cita(date, reason, pet, vet);
            // ✅ Registrar la cita usando el servicio
            agendaService.Register(nuevaCita);

            Console.WriteLine($"Appointment scheduled successfully for {pet.Name} with Dr. {vet.Name} on {date.ToShortDateString()}.");
            Console.ReadKey();
        }

        private void GetAllAgenda()
        {
            var agendas = agendaService.GetAllAgenda();
            if (agendas.Count > 0)
            {
                Console.WriteLine("\nRegistered Agendas:");
                foreach (var a in agendas)
                {
                    Console.WriteLine($"ID: {a.Id}, : fecha: {a.Date}, reason: {a.Reason} Dr. {a.veterinario.Name} pet: {a.pet.Name}");
                }
            }
            else
            {
                Console.WriteLine("No pets registered.");
            }
            Console.ReadKey();
        }

        private void GetCitaByNameOfVet()
        {
             // Pedir el nombre del veterinario
            Console.Write("Enter the veterinarian's name: ");
            string vetName = Console.ReadLine() ?? "";
            if (!Validations.ValidateName(vetName))
            {
                Console.WriteLine($"The veterinarian name '{vetName}' is invalid.");
                return;
            }
            var citas = agendaService.GetCitaByNameOfVet(vetName);
            if (citas != null && citas.Count > 0)
            {
                Console.WriteLine($"\nAppointments for Dr. {vetName}:");
                foreach (var c in citas)
                {
                    Console.WriteLine($"ID: {c.Id}, Date: {c.Date}, Reason: {c.Reason}, Pet: {c.pet.Name}");
                }
            }
            else
            {
                Console.WriteLine($"No appointments found for Dr. {vetName}.");
            }
            Console.ReadKey();
        }
    }
}
