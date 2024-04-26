using CaseWork.Model;
using CaseWork.Model.BodyRequest;
using CaseWork.Model.DTO.Appointment;
using CaseWork.Service.IAppointment;
using CaseWork.ServiceImp.Appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace CaseWork.Controllers.Appointment
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService appointmentService;

        public AppointmentController(IConfiguration configuration)
        {
            this.appointmentService = new AppointmentService(configuration);
        }

        [HttpPost("/create-appointment")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status500InternalServerError)]
        public IActionResult CreateAppointment([FromBody] AppointmentRequest BodyRequest)
        {
            ApiResponse<AppointmentResponse> response = new();
            AppointmentResponse appointmentResponse= new AppointmentResponse();

           
            try
            {
                appointmentResponse.Token = appointmentService.InsertAppointment(BodyRequest);

                response.Message = "Success";
                response.StatusCode= StatusCodes.Status200OK;
                response.Data = appointmentResponse;
            }
            catch (Exception error)
            {
                response.Message = error.Message;
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Data = null;
            }
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("/get-all-appointments")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllAppointments([FromQuery(Name = "DateAppointment")] DateTime DateAppointment)
        {
            ApiResponse<IEnumerable<GetAllAppointment>> response = new();

            try
            {

                IEnumerable<GetAllAppointment> getAllAppointments = appointmentService.GetAllAppointment(DateAppointment);

                response.Message = "Success";
                response.StatusCode = StatusCodes.Status200OK;
                response.Data = getAllAppointments;
            }
            catch (Exception error)
            {
                response.Message = error.Message;
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Data = null;
            }

            return StatusCode(response.StatusCode, response);
        }

    }
}
