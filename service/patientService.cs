
using models;

public class patientService
{

    private List<Patient> Patients = new List<Patient>();

    /// <summary>
    /// Method to register a new Patient
    /// </summary>
    /// <param name="Patient">
    public void RegisterPatient(Patient Patient)
    {
        try
        {
            Patients.Add(Patient);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while registering the patient.{ex.Message}");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// List the patient 
    /// </summary>
    public void ListPatient()
    {
        // list the patient
        try
        {
            if (Patients.Count > 0)
            {
                int i = 1;
                foreach (var Patient in Patients)
                {
                    Console.WriteLine($"{i}: Name: {Patient.Name} Age: {Patient.Age} Symptoms: {Patient.Sintomas}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("No patients registered.");
            }
            Console.ReadKey();
        }
        catch (Exception ex)
        {

            Console.WriteLine($"An error occurred while listing patients. {ex.Message}");
            Console.ReadKey();
        }

    }

    /// <summary>
    ///  seach the patient by name.
    /// </summary>
    /// <param name="PatientName"></param>
    public void SearchPatientsByName(string PatientName)
    {
        // Search for a patient by name
        try
        {
            //create the linq query
            var Patient = Patients.FirstOrDefault(p => p.Name == PatientName);

            // conditional to check if the patient was found
            if (Patient != null)
            {

                Console.WriteLine($"Patient found: Name: {Patient.Name}, Age: {Patient.Age}, Symptoms: {Patient.Sintomas}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }
        // catch any exception that may occur
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while Seach patients. {ex.Message}");
            throw;
        }

    }


}