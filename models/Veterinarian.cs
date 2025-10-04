
namespace models;

public class Veterinarian: Person
{
    public string Specialty { get; set; } = string.Empty;
    public Agenda Agenda { get; private set; } = new Agenda();

    public Veterinarian(string name, int age, string Specialty): base(name,age)
    {
        Name = name;
        this.Specialty = Specialty;
    }

    public override void MostrarInfo()
    {
        Console.WriteLine($"Veterinarian ID: {Id}");
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Specialty: {Specialty}");
    }
}