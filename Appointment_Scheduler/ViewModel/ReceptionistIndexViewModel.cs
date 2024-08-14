using Appointment_Scheduler.Models;

namespace Appointment_Scheduler.ViewModel
{
    public class ReceptionistIndexViewModel : Appointment
    {
        public IEnumerable<Appointment> AppointmentList { get; set; }

        public static Status statusChange (Status status)
        {
           /* if (op == 0)
            {*/
                int n = (int)status;
                n += 1;
                status = (Status)n;
          /*  }*/
           /* else if (op == 1)
            {
                int n = (int)status;
                n -= 1;
                status = (Status)n;
            }*/
            return status;
        }

       
    }
}
