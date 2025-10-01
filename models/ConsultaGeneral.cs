namespace models;

public class ConsultaGeneral : VeterinaryService
{
    public override void attend()
    {
        Console.WriteLine("Attending a general consultation...");
    }
}