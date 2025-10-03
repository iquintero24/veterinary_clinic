

using System.Diagnostics.Contracts;

namespace models;

public class Veterinarian
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Specialty { get; set; } = string.Empty;
    public Agenda Agenda { get; private set; } = new Agenda();

    public Veterinarian(string name, string Specialty)
    {
        Id = Guid.NewGuid();
        Name = name;
        this.Specialty = Specialty;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"Veterinarian ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Specialty: {Specialty}");
    }
}