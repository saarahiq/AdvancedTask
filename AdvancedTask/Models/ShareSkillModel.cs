using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTask.Models
{
    public class ShareSkillModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string subCategory { get; set; }
        public List<string> tagsToRemove { get; set; }
        public List<string> tagsToAdd { get; set; }
        public string serviceType { get; set; }
        public string locationType { get; set; }
        public AvailableDaysModel availableDays { get; set; }
        public string skillTrade { get; set; }
        public string credit { get; set; }
        public List<string> skillExchangeTagsToRemove { get; set; }
        public List<string> skillExchangeTagsToAdd { get; set; }
        public string workSampleFilename { get; set; }
        public string active { get; set; }
    }

    public class AvailableDaysModel
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public Dictionary<string, DayModel> days { get; set; }
    }

    public class DayModel
    {
        public string startTime { get; set; }
        public string endTime { get; set; }
    }
}