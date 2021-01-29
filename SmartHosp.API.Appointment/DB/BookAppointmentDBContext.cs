using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.API.Appointment.DB
{
    public class BookAppointmentDBContext : DbContext
    {
        public DbSet<Appointment> patientAppointment { get; set; }

        public BookAppointmentDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
