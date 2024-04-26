using System;

namespace CaseWork.Model.DTO.Appointment
{
    public class GetAllAppointment
    {
        public int Id { get; set; }
        public string AppointmentName { get; set; }
        public string CustomerName { get; set; }    
        public string CustomerPhone { get; set; }   
        public string CustomerEmail { get; set; }    
        public DateTime AppointmetDate { get; set; }    
        public string TimeBegin { get; set; }
        public string TimeFinish { get; set; }
        public string AppointmentPlace { get; set; }
        public string Note { get; set; }
        public string Token { get; set;  }

    }
}
