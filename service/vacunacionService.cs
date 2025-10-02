using Interface;
public class vacunacionService: IAtendible
{
    public void Attend()
    {
        Console.WriteLine("Attending a vaccination service...");
    }
}