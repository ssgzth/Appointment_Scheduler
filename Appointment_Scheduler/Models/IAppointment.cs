namespace Appointment_Scheduler.Models
{
    public interface IAppointment
    {
        Appointment GetAppointmentDetails(int id);

        IEnumerable<Appointment> GetAppointments();

        Appointment Add(Appointment appointment);

        Appointment Update(Appointment appointment);

        Appointment Delete(Appointment appointment);

        
    }
}
