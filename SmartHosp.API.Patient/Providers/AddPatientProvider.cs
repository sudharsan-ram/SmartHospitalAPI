using AutoMapper;
using Microsoft.Extensions.Logging;
using SmartHosp.API.Patient.DB;
using SmartHosp.API.Patient.Interfaces;
using SmartHosp.API.Patient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.API.Patient.Providers
{
    public class AddPatientProvider : IAddPatient
    {
        private readonly AddPatientDBContext dbContext;
        private readonly ILogger<AddPatientProvider> logger;
        public AddPatientProvider(AddPatientDBContext dbContext, ILogger<AddPatientProvider> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        public async Task<bool> AddMemberProviderasync(Models.Member member)
        {
            try
            {
                await dbContext.patient.AddAsync(new DB.Member()
                {
                    lastName = member.lastName,
                    firstName = member.firstName,
                    age = member.age,
                    address = member.address
                });
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return false;
            }
        }
    }
   }
