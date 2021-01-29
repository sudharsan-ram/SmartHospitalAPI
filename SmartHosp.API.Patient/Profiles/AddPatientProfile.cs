using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.API.Patient.Profiles
{
    public class AddPatientProfile :AutoMapper.Profile
    {
        public AddPatientProfile()
        {
            CreateMap<DB.Member, Models.Member>();
        }
    }
}
