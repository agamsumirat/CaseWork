using System;
using System.ComponentModel.DataAnnotations;

namespace CaseWork.Model.BodyRequest
{
    public class HolidayInsertRequest
    {
        [Required(ErrorMessage ="Day off date is required")]
        public DateTime DayoffDate { get; set; }

        [Required(ErrorMessage ="Note of Day off is required")]
        public string Note { get; set; }
    }
}
