using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartHosp.API.Patient.Models;

namespace SmartHosp.API.Patient.Interfaces
{
    public interface IAddPatient
    {
        Task<bool> AddMemberProviderasync(Models.Member member);

    }
}
