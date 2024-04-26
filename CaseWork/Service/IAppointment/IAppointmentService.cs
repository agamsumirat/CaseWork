using CaseWork.Model.BodyRequest;
using CaseWork.Model.DTO.Appointment;
using System;
using System.Collections.Generic;

namespace CaseWork.Service.IAppointment
{
    public interface IAppointmentService
    {
        string InsertAppointment(AppointmentRequest BodyRequest);
        IEnumerable<GetAllAppointment> GetAllAppointment(DateTime DateAppointment);

    }
}
