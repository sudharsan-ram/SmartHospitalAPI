using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.API.Appointment.DB
{
    public class Appointment
    {
        public int Id { get; set; }
        public string patientName { get; set; }
        public string providerName { get; set; }
        public DateTime appointmentTime { get; set; }
    }
}
