using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.API.Patient.DB
{
    public class AddPatientDBContext : DbContext
    {
        public DbSet<Member> patient { get; set; }

        public AddPatientDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
