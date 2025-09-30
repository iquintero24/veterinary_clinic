namespace models
{
    /// <summary>
    /// Class representing a pet in the clinic system
    /// </summary>
    public class Pet
    {
        // Unique identifier for the pet
        public Guid Id { get; set; } = Guid.NewGuid();

        // Pet's name
        public string Name { get; set; }

        // Pet's age in years
        public int Age { get; set; }

        // Type of pet (dog, cat, etc.)
        public string Species { get; set; }

        // Breed of the pet
        public string Breed { get; set; }

        // Pet's weight in kilograms
        public double Weight { get; set; }

        // Relationship: each pet belongs to a patient (the owner)
        public Patient Owner { get; set; }

        // Constructor to initialize a new pet
        public Pet(string name, int age, string species, string breed, double weight, Patient owner)
        {
            Id = Guid.NewGuid(); // generate unique identifier for the pet
            Name = name;         // assign pet's name
            Age = age;           // assign pet's age
            Species = species;   // assign pet's species
            Breed = breed;       // assign pet's breed
            Weight = weight;     // assign pet's weight
            Owner = owner;       // assign pet's owner

            // Ensure the pet is added to the owner's list of pets
            owner?.Pets.Add(this);
        }

        /// <summary>
        /// Method to display pet information including owner
        /// </summary>
        public void mostrarInfo()
        {
            Console.WriteLine($"Pet: {Name}, Species: {Species}, Breed: {Breed}, Age: {Age}, Weight: {Weight}kg");
            Console.WriteLine($"Owner: {Owner?.Name}, Owner Age: {Owner?.Age}");
        }
    }
}
