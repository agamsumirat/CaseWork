using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;

namespace CaseWork.Model.BodyRequest
{
    public class AppointmentRequest
    {
        [Display(Name ="AppointmentName") ]
        [Required(ErrorMessage = "Appointment Name is required.")]
        public string AppointmentName { get; set; }

        [Display(Name = "CustomerName")]
        [Required(ErrorMessage = "Customer Name is required.")]
        public string CustomerName { get; set; }

        [Display(Name = "CustomerPhone")]
        [Required(ErrorMessage = "Customer Phone is required.")]
        public string CustomerPhone { get; set; }

        [Display(Name = "CustomerEmail")]
        [Required(ErrorMessage = "Customer Email is required.")]
        public string CustomerEmail { get; set; }

        [Display(Name = "AppointmentDate")]
        [Required(ErrorMessage = "Appointment Date is required.")]
        public DateTime AppointmenDate { get; set; }

        [Display(Name ="TimeBegin(Format time ('08:00 - 17:00))")]
        [Required(ErrorMessage ="Time Begin is required")]
        public string TimeBegin { get; set; }

        [Display(Name = "TimeEnd(Format time ('08:00 - 17:00))")]
        [Required(ErrorMessage = "Time End is required")]
        public string TimeEnd { get; set; }

        [Display(Name = "AppointmentPlace")]
        [Required(ErrorMessage = "Appointment Place is required.")]
        public string AppointmentPlace { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }
        
    }
}
