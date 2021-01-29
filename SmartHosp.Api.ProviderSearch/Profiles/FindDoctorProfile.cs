using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.Api.ProviderSearch.Profiles
{
    public class FindDoctorProfile : AutoMapper.Profile
    {
        public FindDoctorProfile()
        {
            CreateMap<DB.FindDoctor, Models.FindDoctor>();
        }
    }
}
