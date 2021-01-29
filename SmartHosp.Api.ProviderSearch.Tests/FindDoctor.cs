using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHosp.Api.ProviderSearch.DB;
using SmartHosp.Api.ProviderSearch.Profiles;
using SmartHosp.Api.ProviderSearch.Providers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace SmartHosp.Api.ProviderSearch.Tests
{
    public class FindDoctor
    {
        [Fact]
        public async Task GetDoctors()
        {
            var options = new DbContextOptionsBuilder<FindDoctorDBContext>()
                .UseInMemoryDatabase(nameof(GetDoctors))
                .Options;
            var dbContext = new FindDoctorDBContext(options);
            CreateProviders(dbContext);

            var findDoctorProfile = new FindDoctorProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(findDoctorProfile));
            var mapper = new Mapper(configuration);

            var findDoctorProvider = new FindDoctorProvider(dbContext, null, mapper);

            var doctor = await findDoctorProvider.GetDoctorsAsync();
            Assert.True(doctor.IsSuccess);
            Assert.Null(doctor.ErrorMessage);
        }

        private void CreateProviders(FindDoctorDBContext dbContext)
        {
            for (int i = 1; i <= 10; i++)
            {
                dbContext.doctors.Add(new DB.FindDoctor()
                {
                    Id = i,
                    LName = Guid.NewGuid().ToString() + "_LastName",
                    FName = Guid.NewGuid().ToString() + "_FirstNAme",
                    Specialty = Guid.NewGuid().ToString() + "_Specialty"
                });

            }
            dbContext.SaveChanges();
        }
    }
}
