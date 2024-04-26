using CaseWork.Model.BodyRequest;
using CaseWork.Model.DTO.Holiday;
using System.Collections.Generic;

namespace CaseWork.Service.IHoliday
{
    public interface IHolidayService
    {
        void InsertHoliday(HolidayInsertRequest holidayInsertRequest);
        IEnumerable<GetAllHoliday> GetAllHoliday();
    }
}
