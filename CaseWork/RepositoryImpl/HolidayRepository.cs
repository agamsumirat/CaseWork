using CaseWork.Model.BodyRequest;
using CaseWork.Model.DTO.Appointment;
using CaseWork.Model.DTO.Holiday;
using CaseWork.Repository.IHolidayRepository;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CaseWork.RepositoryImpl
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly IDbConnection sqlconnection;
        public HolidayRepository(IDbConnection sqlconnection)
        {
            this.sqlconnection = sqlconnection;
        }

        public IEnumerable<GetAllHoliday> GetAllHoliday()
        {
            var query = $@"SELECT Id, DayoffDate, Note from DayoffParameter";

            return sqlconnection.Query<GetAllHoliday>(query);
        }

        public void InsertHoliday(HolidayInsertRequest holidayInsertRequest)
        {
            var query = $@"INSERT INTO dbo.DayoffParameter
			            (
			                DayoffDate,
			                Note
			            )
			            VALUES
			            ( 
                           @DayoffDate,
                            @Note";
            var param = new
            {
                holidayInsertRequest.DayoffDate,
                holidayInsertRequest.Note
            };
            sqlconnection.Execute(query, param);
        }
    }
}
