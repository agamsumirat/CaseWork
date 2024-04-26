using CaseWork.Model.BodyRequest;
using CaseWork.Model.DTO.Appointment;
using CaseWork.Repository.IAppointmentRepository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;

namespace CaseWork.RepositoryImpl
{

    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDbConnection sqlConnection;

        public AppointmentRepository(IDbConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public IEnumerable<GetAllAppointment> GetAllAppointment(DateTime DateAppointment)
        {
            var query = $@"SELECT
			Id,
		    AppointmentName,
		    CustomerName,
		    CustomerPhone,
		    CustomerEmail,
		    AppointmenDate,
		    CONVERT(VARCHAR(5), TimeBegin) AS TimeBegin,
		    CONVERT(VARCHAR(5), TimeEnd) TimeFinish,
		    AppointmentPlace,
		    Note,
		    Token from Appointment where AppointmenDate=@DateAppointment";

            var param = new
            {
                DateAppointment
            };
            return sqlConnection.Query<GetAllAppointment>(query, param);
        }

	
		public string InsertAppointment(AppointmentRequest BodyRequest)
        {
			string countData = "";
			countData = sqlConnection.QueryFirstOrDefault<string>("select count(1) from appointment where AppointmenDate='" + BodyRequest.AppointmenDate + "'");
			int ParameterMax = sqlConnection.QueryFirstOrDefault<int>("select ValueParameter from Globalparameter where Id=1");

			if(Convert.ToInt32(countData) >= ParameterMax)
			{
				BodyRequest.AppointmenDate = BodyRequest.AppointmenDate.AddDays(1);
                countData = sqlConnection.QueryFirstOrDefault<string>("select count(1) from appointment where AppointmenDate='" + BodyRequest.AppointmenDate + "'");
            }
            var Token = "";
            Token = BodyRequest.AppointmenDate.ToString("yyyyMMdd") + countData.ToString();
			var query = $@"INSERT INTO dbo.Appointment
		(
		    AppointmentName,
		    CustomerName,
		    CustomerPhone,
		    CustomerEmail,
		    AppointmenDate,
		    TimeBegin,
		    TimeEnd,
		    AppointmentPlace,
		    Note,
		    Token
		)values 
			(@AppointmentName,
			@CustomerName,
			@CustomerPhone, 
			@CustomerEmail,
			@AppointmenDate,
			@TimeBegin, 
			@TimeEnd,
			@AppointmentPlace, 
			@Note, 
			@Token)";
			var param = new
			{
				BodyRequest.AppointmentName,
				BodyRequest.CustomerName,
				BodyRequest.CustomerPhone,
				BodyRequest.CustomerEmail,
				BodyRequest.AppointmenDate,
				BodyRequest.TimeBegin,
				BodyRequest.TimeEnd,
				BodyRequest.AppointmentPlace,
				BodyRequest.Note,
				Token
			};
			sqlConnection.Execute(query, param);
			return Token;
        }

		
	}
}
