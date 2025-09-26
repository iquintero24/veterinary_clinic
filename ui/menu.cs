namespace ClinicaSalud.ui;

public class Menu
{
    // Instance of patient service
    private patientService patientService = new patientService();

    // Instance of validation service
    private Validations validations = new Validations();

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

                    string name;
                    while (true)
                    {
                        Console.Write("Enter patient's name: ");
                        name = Console.ReadLine() ?? "";

                        if (validations.ValidateName(name))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid name. Please enter a valid name.");
                        }
                    }

                    int age;
                    while (true)
                    {
                        Console.Write("Enter patient's age: ");
                        string inputAge = Console.ReadLine() ?? "";

                        // Convert to int if int is valid age = input age and greater than 0
                        if (int.TryParse(inputAge, out age) && validations.ValidationEdad(age))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid age. Please enter a valid number.");
                        }
                    }

                    Console.Write("Enter patient's symptoms: ");
                    string sintomas = Console.ReadLine() ?? "";

                    // Create new patient and register
                    var newPatient = new models.Patient(name, age, sintomas);
                    patientService.RegisterPatient(newPatient);

                    // Confirmation message
                    Console.WriteLine("Patient registered successfully.");
                    Console.ReadKey();
                    break;

                case "2":
                    // logic to list patients
                    patientService.ListPatient();
                    Console.WriteLine("show pacients register.");
                    break;
                case "3":
                    // logic to search patient by name
                    Console.WriteLine("Search for a patient by name");

                    // Input the name to search
                    Console.WriteLine("Enter the patient's name: ");
                    string NamePatient = Console.ReadLine() ?? "";

                    // Call the search method
                    patientService.SearchPatientsByName(NamePatient);

                    break;
                case "4":
                    // Out the program
                    Console.WriteLine("leaving...");
                    return;
                default:
                    Console.WriteLine("Invalid option, try again..");
                    break;
            }
        }
    }

}