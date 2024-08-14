using Appointment_Scheduler.Models;
using Appointment_Scheduler.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_Scheduler.Controllers
{
    public class ReceptionistController : Controller
    {
        private readonly IAppointment appointmentR;

        public ReceptionistController(IAppointment appointmentR)
        {
            this.appointmentR = appointmentR;
        }


        [Route("Receptionist/Index")]
        public IActionResult Index()
        {

            ReceptionistIndexViewModel model = new ReceptionistIndexViewModel
            {
                AppointmentList = appointmentR.GetAppointments()
            };
            return View(model);
        }

        
        [Route("Receptionist/changeStatus")]
        [Route("changeStatus")]
        public IActionResult changeStatus(int id)
        {
            Appointment model = appointmentR.GetAppointmentDetails(id);
            /*int op = 0;
            if (model.Status != Status.Scheduled)
            {
                op = 1;
            }*/
            model.Status = ReceptionistIndexViewModel.statusChange(model.Status);
            appointmentR.Update(model);
            return RedirectToAction("Index");
        }


    }
}
