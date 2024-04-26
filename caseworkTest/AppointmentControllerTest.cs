using CaseWork.Controllers.Appointment;
using CaseWork.Model;
using CaseWork.Model.DTO.Appointment;
using CaseWork.Service.IAppointment;
using CaseWork.ServiceImp.Appointment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using Xunit;

namespace caseworkTest
{
    public class AppointmentControllerTest
    {
        AppointmentController _appointmentController;
        IAppointmentService _appointmentService;
        IConfiguration _configuration;
        public AppointmentControllerTest()
        {
            _appointmentService = new AppointmentService(_configuration);
            _appointmentController = new AppointmentController(_configuration);
        }

        [Fact]
        public void Test1()
        {
            DateTime Appointmentdate= Convert.ToDateTime("2024-04-26");
            var result = _appointmentController.GetAllAppointments(Appointmentdate);
            Assert.IsType<ApiResponse<GetAllAppointment>>(result);

            var list = result as OkObjectResult;

            Assert.IsType<ApiResponse<GetAllAppointment>>(list);



            var apiResponse = list.Value as ApiResponse<GetAllAppointment>;

           
        }
    }
}
