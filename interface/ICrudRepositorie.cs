
namespace Interface;

public interface ICrudRepository<T> // Recibe cualquier tipo de objeto
{
    // Crear cualquier registro:
    void create(T Entity);

    // Listas cualquier entidad:
    List<T> GetAll();

    // Buscar por nombre:
    T? GetByName(string name);
}