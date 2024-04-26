using CaseWork.Model.BodyRequest;
using CaseWork.Model.DTO.Appointment;
using CaseWork.Model.DTO.Holiday;
using CaseWork.Repository.IAppointmentRepository;
using CaseWork.Repository.IGlobalParameterRepository;
using CaseWork.Repository.IHolidayRepository;
using CaseWork.RepositoryImpl;
using CaseWork.Service.IHoliday;
using CaseWork.Utils.DatabaseHelper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Transactions;

namespace CaseWork.ServiceImp.Holiday
{
    public class HolidayService : IHolidayService
    {
        private readonly DatabaseHelper databaseHelper;

        public HolidayService(IConfiguration configuration)
        {
            databaseHelper = new(configuration);
        }

        public IEnumerable<GetAllHoliday> GetAllHoliday()
        {
            using var sqlConnection = databaseHelper.GetConnection();
            IHolidayRepository holidayRepository = new HolidayRepository(sqlConnection);
            IEnumerable<GetAllHoliday> AllHoliday = holidayRepository.GetAllHoliday();
            return AllHoliday;
        }

        public void InsertHoliday(HolidayInsertRequest holidayInsertRequest)
        {
            using var transaction = new TransactionScope();
            using var sqlConnection = databaseHelper.GetConnection();

            IHolidayRepository holidayRepository = new HolidayRepository(sqlConnection);
            holidayRepository.InsertHoliday(holidayInsertRequest);
            transaction.Complete();
        }
    }
    
}
