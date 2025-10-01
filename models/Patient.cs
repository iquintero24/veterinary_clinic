namespace models
{
    /// <summary>
    /// Class representing a patient in the health clinic system
    /// </summary>
    public class Owner
    {
        // Unique patient identifier (read-only from outside)
        public Guid Id { get; private set; } = Guid.NewGuid();

        // Patient's name
        public string Name { get; set; }

        // Patient's age
        public int Age { get; set; }

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
        public Owner(string name, int age, string telefono)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            _telefono = telefono; // assign directly to the private field
        }

        /// <summary>
        /// Method to display patient information
        /// </summary>
        public void MostrarInfo()
        {
            Console.WriteLine($"ID: {Id}, Name: {Name}, Age: {Age}, Phone: {Telefono}");

            if (Pets.Count > 0)
            {
                Console.WriteLine("Pets:");
                foreach (var pet in Pets)
                {
                    Console.WriteLine($"  - {pet.Name}, Species: {pet.Species}, Breed: {pet.Breed}, Age: {pet.Age}");
                }
            }
            else
            {
                Console.WriteLine("No pets registered for this patient.");
            }
        }

        /// <summary>
        /// Secure method to update the phone number
        /// </summary>
        public void UpdateTelefono(string newTelefono)
        {
            _telefono = newTelefono;
        }
    }
}
