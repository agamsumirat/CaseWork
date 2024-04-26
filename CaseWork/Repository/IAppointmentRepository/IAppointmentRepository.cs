using CaseWork.Model.BodyRequest;
using CaseWork.Model.DTO.Appointment;
using System;
using System.Collections.Generic;

namespace CaseWork.Repository.IAppointmentRepository
{
    public interface IAppointmentRepository
    {
        public string InsertAppointment(AppointmentRequest BodyRequest);
        IEnumerable<GetAllAppointment> GetAllAppointment(DateTime DateAppointment);

    }
}
