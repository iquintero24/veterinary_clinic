namespace models;

/// <summary>
/// Class representing a patient in the health clinic system
/// </summary>
public class Patient
{
    // Unique patient identifier
    public Guid Id { get; set; } = Guid.NewGuid();

    // Patient's name
    public string Name { get; set; }

    // Patient's age
    public int Age { get; set; }

    // Patient's symptoms
    public string Sintomas { get; set; }

    // List of pets owned by this patient
    public List<Pet> Pets { get; set; } = new List<Pet>();

    // Constructor to initialize a new patient
    public Patient(string name, int age, string sintomas)
    {
        Id = Guid.NewGuid(); // generate a new unique identifier
        Name = name;
        Age = age;
        Sintomas = sintomas;
    }

    /// <summary>
    /// Method to display patient information
    /// </summary>
    public void mostrarInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}, Symptoms: {Sintomas}");

        if (Pets.Count > 0)
        {
            Console.WriteLine("Pets:");
            foreach (var pet in Pets)
            {
                Console.WriteLine($"  - {pet.Name}, Species: {pet.Species}, Breed: {pet.Breed}, Age: {pet.Age}");
            }
        }
        else
        {
            Console.WriteLine("No pets registered for this patient.");
        }
    }
}
