
using models;

namespace ClinicaSalud.data
{
    public class DataBase
    {
        // In-memory list to store patients
        public static List<Owner> Owner = new List<Owner>();

        // in-memory list to store veterinarians
        public static List<Veterinarian> veterinarians = new List<Veterinarian>();

        // In-memory list to store pets
        public static List<Pet> pets = new List<Pet>();

        // In-memory list to store appointments
        public static List<Cita> appointments = new List<Cita>();


    }
}