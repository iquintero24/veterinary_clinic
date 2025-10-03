namespace models;

public class Cita
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime Date { get; set; }
    public string Reason { get; set; }
    public Pet pet { get; set; }
    public Veterinarian veterinario { get; set; }

    public Cita(DateTime date, string reason, Pet pet, Veterinarian veterinario)
    {
        Id = Guid.NewGuid();
        Date = date;
        Reason = reason;
        this.pet = pet;
        this.veterinario = veterinario;
    }

}