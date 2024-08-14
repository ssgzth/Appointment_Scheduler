
namespace Appointment_Scheduler.Models
{
    public class SQLAppointmentRepo : IAppointment
    {
        private readonly AppDbContext context;

        public SQLAppointmentRepo( AppDbContext context)
        {
            this.context = context;
        }


        public Appointment Add(Appointment appointment)
        {
            context.appointments.Add(appointment);
            context.SaveChanges();

            return appointment;
        }

        public Appointment Delete(Appointment appointment)
        {  if (appointment != null)
            {
                context.appointments.Remove(appointment);
                context.SaveChanges();

            }

                return appointment;
        }

        public Appointment GetAppointmentDetails(int Id)
        {
           Appointment appointment= context.appointments.FirstOrDefault(x => x.Id == Id);
           return appointment;
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return context.appointments;
        }

        public Appointment Update(Appointment changed_appointment)
        {
            var appointment = context.appointments.Attach(changed_appointment);

            appointment.State= Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return changed_appointment;
        }
    }
}
