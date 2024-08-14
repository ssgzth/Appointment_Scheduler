using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Appointment_Scheduler.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage ="Password and confirm password does not match")]
        public string ConfirmPassword { get; set; }

    }
}
