using CaseWork.Model;
using CaseWork.Model.BodyRequest;
using CaseWork.Model.DTO.Appointment;
using CaseWork.Service.GlobalParameter;
using CaseWork.Service.IAppointment;
using CaseWork.ServiceImp.Appointment;
using CaseWork.ServiceImp.GlobalParameter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace CaseWork.Controllers.GlobalParameter
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlobalParameterController : ControllerBase
    {
        private readonly IGlobalParameterService globalParameterService;

        public GlobalParameterController(IConfiguration configuration)
        {
            this.globalParameterService = new GlobalParameterService(configuration);
        }

        [HttpPut("/update-parameter")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<>), StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateParameter([FromBody] GlobalParameterUpdateRequest BodyRequest)
        {

            ApiResponse<string> response = new();
            try
            {
               globalParameterService.updateGlobalParameter(BodyRequest);
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

    }
}
