using System;
using System.Collections.Generic;

namespace XBrain.Models
{
    public partial class DailyRoutine
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string RoutineTitle { get; set; }
        public string RoutineContent { get; set; }
        public string DayOperation { get; set; }
        public DateTime DateAchieve { get; set; }
        public TimeSpan PlanStartTime { get; set; }
        public TimeSpan PlanEndTime { get; set; }
        public TimeSpan? ActualStartTime { get; set; }
        public TimeSpan? ActualEndTime { get; set; }

        public virtual XbrainUser User { get; set; }
    }
}
