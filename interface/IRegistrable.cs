
namespace Interface;

    public interface IRegistrable<T>
    {
        /// <summary>
        /// Method to register an entity example: patient, pet implement in services;
        /// </summary>
       public void Register(T entity);
    }
