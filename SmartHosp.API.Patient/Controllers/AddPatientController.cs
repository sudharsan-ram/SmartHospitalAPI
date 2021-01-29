using Microsoft.AspNetCore.Mvc;
using SmartHosp.API.Patient.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.API.Patient.Controllers
{
    [ApiController]
    [Route("api/AddPatient")]
    public class AddPatientController : Controller
    {
        private readonly IAddPatient addPatientProvider;
        public AddPatientController(IAddPatient addPatientProvider)
        {
            this.addPatientProvider = addPatientProvider;
        }

        [HttpPost]
        public async Task<IActionResult> AddPatient([FromBody] Models.Member member)
        {
            var result =  await addPatientProvider.AddMemberProviderasync(member);
            if (result == true)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
