using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTaskSpecFlow.Models
{
    public class AvailableDaysModel
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public Dictionary<string, DayModel> days { get; set; }

        public AvailableDaysModel(string startDate, string endDate, Dictionary<string, DayModel> days) 
        { 
            this.startDate = startDate;
            this.endDate = endDate;
            this.days = days;
        }
    }

    public class DayModel
    {
        public string startTime { get; set; }
        public string endTime { get; set; }

        public DayModel(string startTime, string endTime)
        {
            this.startTime = startTime;
            this.endTime = endTime;
        }
    }
}