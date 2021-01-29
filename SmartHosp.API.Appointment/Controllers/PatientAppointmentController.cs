using Microsoft.AspNetCore.Mvc;
using SmartHosp.API.Appointment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHosp.API.Appointment.Controllers
{
    [ApiController]
    [Route("api/BookAppointment")]
    public class PatientAppointmentController : Controller
    {
        private readonly IPatientAppointment patientAppointmentProvider;
        public PatientAppointmentController(IPatientAppointment patientAppointment)
        {
            this.patientAppointmentProvider = patientAppointment;
        }

        [HttpPost]
        public async Task<IActionResult> bookAppointment([FromBody] Models.Appointment patientAppointment)
        {
            var result = await patientAppointmentProvider.bookPatientAppointmentasync(patientAppointment);
            if (result == true)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
