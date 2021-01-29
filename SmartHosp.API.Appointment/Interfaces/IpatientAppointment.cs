using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.API.Appointment.Interfaces
{
    public interface IPatientAppointment
    {
         Task<bool> bookPatientAppointmentasync(Models.Appointment appointment);
    }
}
