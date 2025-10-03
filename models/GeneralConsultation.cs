namespace models;

public class GeneralConsultation : VeterinaryService
{
    public override void attend()
    {
        Console.WriteLine("Attending a general consultation...");
    }
}