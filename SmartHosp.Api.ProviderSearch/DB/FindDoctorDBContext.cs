using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.Api.ProviderSearch.DB
{
    public class FindDoctorDBContext : DbContext
    {
        public DbSet<FindDoctor> doctors { get; set; }

        public FindDoctorDBContext(DbContextOptions options) : base(options)
        {
        }
    }
}
