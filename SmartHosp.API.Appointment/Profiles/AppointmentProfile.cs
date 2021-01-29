using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.API.Appointment.Profiles
{
    public class AppointmentProfile:AutoMapper.Profile
    {
        public AppointmentProfile()
        {
            CreateMap<DB.Appointment, Models.Appointment>();
        }
    }
}
