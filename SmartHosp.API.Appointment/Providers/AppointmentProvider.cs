using Microsoft.Extensions.Logging;
using SmartHosp.API.Appointment.DB;
using SmartHosp.API.Appointment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.API.Appointment.Providers
{
    public class AppointmentProvider : IPatientAppointment
    {
        private readonly BookAppointmentDBContext dbContext;
        private readonly ILogger<AppointmentProvider> logger;
        public AppointmentProvider(BookAppointmentDBContext dbContext, ILogger<AppointmentProvider> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        public async Task<bool> bookPatientAppointmentasync(Models.Appointment patientAppointment)
        {
            try
            {
                await dbContext.patientAppointment.AddAsync(new DB.Appointment()
                {
                    patientName = patientAppointment.patientName,
                    providerName = patientAppointment.providerName,
                    appointmentTime = patientAppointment.appointmentTime
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
