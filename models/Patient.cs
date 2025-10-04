using System.Data.Common;

namespace models
{
    /// <summary>
    /// Class representing a patient in the health clinic system
    /// </summary>
    public class Owner : Person
    {


        // 🔒 Phone number (sensitive data → encapsulated)
        private string _telefono;
        public string Telefono
        {
            get => _telefono;   // can be read from outside
            private set => _telefono = value; // can only be modified inside the class
        }

        // List of pets owned by the patient
        public List<Pet> Pets { get; private set; } = new List<Pet>();

        // Constructor
        public Owner(string name, int age, string telefono) : base(name, age)
        {
            Name = name;
            Age = age;
            _telefono = telefono; // assign directly to the private field
        }

        /// <summary>
        /// Method to display patient information
        /// </summary>
        public override void MostrarInfo()
        {
            Console.WriteLine($"Owner ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Phone: {_telefono}");
            Console.WriteLine("Pets:");
            foreach (var pet in Pets)
            {
                Console.WriteLine($" - {pet.Name} ({pet.Species}, {pet.Breed}, Age: {pet.Age})");
            }
        }

    }
}
