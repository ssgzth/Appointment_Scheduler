using Appointment_Scheduler.Models;
using Appointment_Scheduler.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_Scheduler.Controllers
{
    public class PatientController : Controller
    {
        private readonly IAppointment appointment;

        public PatientController(IAppointment appointment)
        {
            this.appointment = appointment;
        }

        [Route("Patient/Appointment")]
        public IActionResult Appointments()
        {
            var model = appointment.GetAppointments();
            return View(model);
        }

        [Route("Patient/Service")]
        public IActionResult Services_Available()
        {
           
            return View();
        }
    }
}
