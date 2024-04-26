using CaseWork.Model.BodyRequest;
using CaseWork.Model;
using CaseWork.Service.GlobalParameter;
using CaseWork.Service.IHoliday;
using CaseWork.ServiceImp.GlobalParameter;
using CaseWork.ServiceImp.Holiday;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using CaseWork.Model.DTO.Holiday;
using System.Collections.Generic;
using CaseWork.Model.DTO.Appointment;

namespace CaseWork.Controllers.Holiday
{
    [Route("api/[controller]")]
    [ApiController]
    public class HolidayController : ControllerBase
    {
        private readonly IHolidayService holidayService;

        public HolidayController(IConfiguration configuration)
        {
            this.holidayService= new HolidayService(configuration);
        }

        [HttpPost("/insert-dayoff")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status500InternalServerError)]
        public IActionResult InsertHoliday([FromBody] HolidayInsertRequest BodyRequest)
        {

            ApiResponse<string> response = new();
            try
            {
                holidayService.InsertHoliday(BodyRequest);
                response.Message = "Success";
                response.StatusCode = StatusCodes.Status200OK;
                response.Data = "";
            }
            catch (Exception error)
            {
                response.Message = error.Message;
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.Data = null;
            }
            return StatusCode(response.StatusCode, response);
        }
        [HttpGet("/getall-dayoff")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllHoliday()
        {
            ApiResponse<IEnumerable<GetAllHoliday>> response = new();
            try
            {
                IEnumerable<GetAllHoliday> Holidays= holidayService.GetAllHoliday();
                response.Message = "Success";
                response.StatusCode = StatusCodes.Status200OK;
                response.Data = Holidays;
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
