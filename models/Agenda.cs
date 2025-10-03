namespace models;

public class Agenda
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Cita> Citas { get; set; } = new List<Cita>();


    public void ListarCitas()
    {
        foreach (var cita in Citas)
        {
            Console.WriteLine($"Cita ID: {cita.Id}, Fecha: {cita.Date}, Motivo: {cita.Reason}, Mascota: {cita.pet.Name}, Veterinario: {cita.veterinario.Name}");
        }
    }

}
