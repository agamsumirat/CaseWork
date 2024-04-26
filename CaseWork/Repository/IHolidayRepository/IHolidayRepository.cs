using CaseWork.Model.BodyRequest;
using CaseWork.Model.DTO.Holiday;
using System.Collections;
using System.Collections.Generic;

namespace CaseWork.Repository.IHolidayRepository
{
    public interface IHolidayRepository
    {
        void InsertHoliday(HolidayInsertRequest holidayInsertRequest);

        IEnumerable<GetAllHoliday> GetAllHoliday();
    }
}
