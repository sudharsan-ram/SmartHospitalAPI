using SmartHosp.Api.ProviderSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.Api.ProviderSearch.Interfaces
{
    public interface IFindDoctor 
    {
        Task<(bool IsSuccess, IEnumerable<FindDoctor> doctors, string ErrorMessage)> GetDoctorsAsync();

        Task<(bool IsSuccess, FindDoctor doctor, string ErrorMessage)> GetDoctorAsync(string firstName, string lastName, string Specialty);

    }
}
