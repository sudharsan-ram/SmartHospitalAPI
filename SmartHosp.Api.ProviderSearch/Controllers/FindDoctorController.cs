using Microsoft.AspNetCore.Mvc;
using SmartHosp.Api.ProviderSearch.Interfaces;
using SmartHosp.Api.ProviderSearch.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.Api.ProviderSearch.Controllers
{
    [ApiController]
    [Route("api/FindDoctor")]
    public class FindDoctorController : Controller
    {
        private readonly IFindDoctor findDoctorProvider;
        public FindDoctorController(IFindDoctor findDoctorProvider)
        {
            this.findDoctorProvider = findDoctorProvider;
        }
       
        
        [HttpGet]
        public async Task<IActionResult> GetDoctorsAsync()
        {
            var result = await findDoctorProvider.GetDoctorsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.doctors);
            }
            return NotFound();
        }

        [HttpGet("GetDoctor")]
        public async Task<IActionResult> GetDoctorAsync([FromBody] Models.FindDoctor doctor)
        {
            var result = await findDoctorProvider.GetDoctorAsync(doctor.FName, doctor.LName, doctor.Specialty);
            if (result.IsSuccess)
            {
                return Ok(result.doctor);
            }
            return NotFound();
        }
    }
}
