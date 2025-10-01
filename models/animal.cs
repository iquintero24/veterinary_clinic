namespace models
{
    public abstract class Animal
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Species { get; set; } = string.Empty;


        protected Animal(string name, int age, string species)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Species = species;

        }


        /// <summary>
        /// the animal makes a sound
        /// </summary>
        /// <returns>void</returns>

        public abstract void emitSound();

    }
}
