using System;

namespace utils
{
    public class MainMenu
    {
        private readonly PatientMenu _patientMenu = new PatientMenu();
        private readonly PetMenu _petMenu = new PetMenu();
        private readonly VetMenu _vetMenu = new VetMenu();
        private readonly AgendaMenu _agendaMenu = new AgendaMenu();

        public void MostrarMenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== 🏥 HEALTH CLINIC SYSTEM ======");
                Console.WriteLine("1. Patients Module");
                Console.WriteLine("2. Pets Module");
                Console.WriteLine("3. Veterinarians Module");
                Console.WriteLine("4. Appointments / Agenda");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string opcion = Console.ReadLine() ?? "";

                switch (opcion)
                {
                    case "1": _patientMenu.MostrarMenuPaciente(); break;
                    case "2": _petMenu.MostrarMenuMascotas(); break;
                    case "3": _vetMenu.MostrarMenuVeterinarios(); break;
                    case "4": _agendaMenu.MostrarMenuAgenda(); break;
                    case "5":
                        Console.WriteLine("Leaving...");
                        return;
                    default:
                        Console.WriteLine("Invalid option, press a key...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
