namespace ClinicaSalud.ui;
public class Menu
{
    private patientService patientService = new patientService();

    public void MostrarMenu()
    {
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Health Clinic Menu");
            Console.WriteLine("1. Register Patient");
            Console.WriteLine("2. List patients");
            Console.WriteLine("3. Seach patient by name");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
            string opcion = Console.ReadLine() ?? "";

            switch (opcion)
            {
                case "1":
                    // Lógica para agregar paciente
                    Console.WriteLine("Register patient.");

                    Console.Write("Enter patient's name: ");
                    string name = Console.ReadLine() ?? "";

                    Console.Write("Enter patient's age: ");
                    int age = int.Parse(Console.ReadLine() ?? "0");
                    
                    Console.Write("Enter patient's symptoms: ");
                    string sintomas = Console.ReadLine() ?? "";

                    // Create a new patient instance
                    var newPatient = new models.Patient(name, age, sintomas);
                    patientService.RegisterPatient(newPatient);
                    Console.WriteLine("Patient registered successfully.");
                    Console.ReadKey();

                    break;
                case "2":
                    // logic to list patients
                    patientService.ListPatient();
                    Console.WriteLine("Ver Pacientes seleccionado.");
                    break;
                case "3":
                    Console.WriteLine("Buscar un paciente por el nombre");
                    Console.WriteLine("Ingrese el nombre del paciente: ");
                    string NamePatient = Console.ReadLine() ?? "";
                    patientService.SearchPatientsByName(NamePatient);
                    break;
                case "4":
                    // Salir del programa
                    Console.WriteLine("Saliendo...");
                    return;
                default:
                    Console.WriteLine("Opcion no valida, intente de nuevo.");
                    break;
            }
        }
    }

}