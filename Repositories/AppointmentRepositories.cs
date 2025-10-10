using Repositories;
using Interface;
using models;
using ClinicaSalud.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class AppointmeRepository : IAppointmentRepository
    {
        /// <summary>
        /// Create a cita
        /// </summary>
        public void create(Cita cita)
        {
            DataBase.appointments.Add(cita);

        }

        /// <summary>
        /// List all citas
        /// </summary>
        public List<Cita> GetAll()
        {
            return DataBase.appointments;
        }

        /// <summary>
        /// Get all citas by veterinarian name
        /// </summary>
        public List<Cita> GetByName(string name)
        {
            var result = DataBase.appointments
                .Where(cita =>
                    cita.veterinario != null &&
                    cita.veterinario.Name.Trim().Equals(name.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
                
            return result;
        }
    }
}
