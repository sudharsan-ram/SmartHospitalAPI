using AutoMapper;
using Microsoft.Extensions.Logging;
using SmartHosp.Api.ProviderSearch.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartHosp.Api.ProviderSearch.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SmartHosp.Api.ProviderSearch.Providers
{
    public class FindDoctorProvider : IFindDoctor
    {
        private readonly FindDoctorDBContext dbContext;
        private readonly ILogger<FindDoctorProvider> logger;
        private readonly IMapper mapper;
        public FindDoctorProvider(FindDoctorDBContext dbContext, ILogger<FindDoctorProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;
            SeedData();
        }
        private void SeedData()
        {
            if (!dbContext.doctors.Any())
            {
                dbContext.doctors.Add(new FindDoctor() { Id = 1, FName = "John", LName = "Smith", Specialty = "GeneralMedicine" });
                dbContext.doctors.Add(new FindDoctor() { Id = 2, FName = "Sylvia", LName = "Amy", Specialty = "GeneralMedicine" });
                dbContext.doctors.Add(new FindDoctor() { Id = 3, FName = "Nicola", LName = "Carter", Specialty = "Orthopaedics" });
                dbContext.doctors.Add(new FindDoctor() { Id = 4, FName = "Olivia", LName = "Thesar", Specialty = "Neurologist" });
                dbContext.doctors.Add(new FindDoctor() { Id = 5, FName = "Vera", LName = "Varter", Specialty = "Peadiatrics" });
                dbContext.doctors.Add(new FindDoctor() { Id = 6, FName = "Walter", LName = "White", Specialty = "Vascular" });
                dbContext.doctors.Add(new FindDoctor() { Id = 7, FName = "Jesse", LName = "Pinkman", Specialty = "FamilyPractice" });
                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.FindDoctor> doctors, string ErrorMessage)> GetDoctorsAsync()
        {
            try
            {
                var doctors = await dbContext.doctors.ToListAsync();
                if (doctors != null && doctors.Any())
                {
                    var result = mapper.Map<IEnumerable<DB.FindDoctor>, IEnumerable<Models.FindDoctor>>(doctors);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Models.FindDoctor doctor, string ErrorMessage)> GetDoctorAsync(string firstName, string lastName, string Specialty)
        {
            try
            {
                var doctor = await dbContext.doctors.FirstOrDefaultAsync(p => (p.FName == firstName && p.LName == lastName) || p.Specialty == Specialty

            );

                if (doctor != null)
                {
                    var result = mapper.Map<DB.FindDoctor, Models.FindDoctor>(doctor);
                    return (true, result, null);
                }
                return (false, null, "Not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }

        }

    }
}
