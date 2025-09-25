namespace models;

/// <summary>
/// Class representing a patient in the health clinic system
/// </summary>
public class Patient
{
    //public, private ,pretected, internal is emcapsulations

    public Guid Id { get; set; } = Guid.NewGuid(); // unique patient identifier 
    public string Name { get; set; }  // patient's name
    public int Age { get; set; } // patient's age
    public string Sintomas { get; set; } // patient's symptoms

    // Constructor to initialize a new patient
    public Patient(string name, int age, string sintomas)
    {
        Id = Guid.NewGuid(); // generate a new unique identifier
        Name = name; // set patient's name
        Age = age; // set patient's age
        Sintomas = sintomas; // set patient's symptoms
    }

    /// <summary>
    /// Method to display patient information
    /// </summary>
    public void mostrarInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}, Symptoms: {Sintomas}");
    }


}