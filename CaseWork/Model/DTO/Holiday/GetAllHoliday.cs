using System;

namespace CaseWork.Model.DTO.Holiday
{
    public class GetAllHoliday
    {
        public int Id { get; set; }
        public DateTime DayoffDate { get; set; }

        public string Note { get; set; }
    }
}
