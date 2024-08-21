using Appointment_Scheduler.Models;
using Appointment_Scheduler.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Appointment_Scheduler.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAppointment _appointment;

        public HomeController(ILogger<HomeController> logger, IAppointment appointment)
        {
            _logger = logger;
            _appointment = appointment;
        }

        [Route("Index")]
        [Route("Home/Index")]
        [Route("")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var viewmodel = _appointment.GetAppointments();
            return View(viewmodel);
        }


        [HttpGet]
        [Route("Home/BookAppointment")]
        public IActionResult BookAppointment()
        {
            return View();
        }


        [HttpPost]
        [Route("Home/TimeSlot")]
        public IActionResult TimeSlot(DateTime? startTime, DateTime? endTime)
        {
            TempData["start"] = startTime;
            TempData["end"] = endTime;
            if (startTime == null || endTime == null)
            {
                return Json(new { url = Url.Action("NullDataError") });

            }
            return Json(new { url = Url.Action("CreateAppointment") });

        }

        [HttpGet]
        [Route("Home/CreateAppointment")]
        [Route("CreateAppointment")]
        public IActionResult CreateAppointment()
        {
            var startTime = TempData["start"] ;
            var endTime = TempData["end"];
            Appointment model = new Appointment()
            {
                StartTime = (DateTime)startTime,
                EndTime = (DateTime) endTime,
                Service = MServices.Vaccinations,
                Status = Status.Scheduled
            };
           
            ViewBag.endTime = "now";
            return View(model);
        }


        [HttpPost]
        [Route("Home/CreateAppointment")]
        [Route("CreateAppointment")]
        public IActionResult CreateAppointment(Appointment model)
        {
            if (ModelState.IsValid)
            {
                _appointment.Add(model);
                return RedirectToAction("Index");
            }

            return View();
        }


        [Route("Home/NullDataError")]
        public IActionResult NullDataError()
        {
            ViewBag.ErrorMessage = "start or end is null";

            return View();
        }

        /* [HttpPost]
         [Route("Home/BookAppointment")]
         public IActionResult BookAppointment(string start , string end)
         {

             return RedirectToAction("PatientView/CreateAppointment");
         }*/


    }
}
