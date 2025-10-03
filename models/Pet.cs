namespace models
{
    /// <summary>
    /// Class representing a pet in the clinic system
    /// </summary>
    public class Pet : Animal
    {
        // Unique identifier for the pet
        public string Breed { get; set; }

        // Relationship: each pet belongs to a patient (the owner)
        public Owner Owner { get; set; }

        // Constructor to initialize a new pet
        public Pet(string name, int age, string species, string breed, Owner owner): base(name, age, species)
        {

            Breed = breed;       // assign pet's breed
            Owner = owner;       // assign pet's owner

            // Ensure the pet is added to the owner's list of pets
            owner?.Pets.Add(this);
        }

        /// <summary>
        /// Method to display pet information including owner
        /// </summary>
        public void MostrarInfo()
        {
            Console.WriteLine($"Pet: {Name}, Species: {Species}, Breed: {Breed}, Age: {Age}");
            Console.WriteLine($"Owner: {Owner?.Name}, Owner Age: {Owner?.Age}");
        }

        public override void emitSound()
        {
             switch (Species.ToLower())
            {
                case "perro":
                    Console.WriteLine($"{Name} dice: Guau 🐶");
                    break;
                case "gato":
                    Console.WriteLine($"{Name} dice: Miau 🐱");
                    break;
                case "ave":
                    Console.WriteLine($"{Name} dice: Pío 🐦");
                    break;
                case "conejo":
                    Console.WriteLine($"{Name} dice: Sniff 🐰");
                    break;
                default:
                    Console.WriteLine($"{Name} hace un sonido desconocido.");
                    break;
            }
        }
    }
}
