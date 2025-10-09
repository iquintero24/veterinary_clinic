using models;

namespace Interface;


public interface IAppointmentRepository
{
    // En este caso no implemente La interfaces de CRUD ya que appointe maneja listas y cambiaban el retorno del metodo;

    void create(Cita cita);

    List<Cita> GetAll();

    List<Cita>? GetByName(string name);
}