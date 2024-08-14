

using System.ComponentModel.DataAnnotations;

namespace Appointment_Scheduler.Models
{
    public class Appointment
    {
        public int Id { get; set; }


        [Required]
        /*[DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]*/
        public DateTime StartTime { get; set; }

        [Required]
       /* [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]*/
        public DateTime EndTime { get; set; }

        [Required]
        public MServices Service { get; set; }

        public Status Status { get; set; }

    }
}
