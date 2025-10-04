namespace models;

public abstract class Person
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }

    protected Person(string name, int age)
    {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;
    }

    public abstract void MostrarInfo();

}