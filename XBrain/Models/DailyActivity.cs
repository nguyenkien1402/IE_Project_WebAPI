using System;
using System.Collections.Generic;

namespace XBrain.Models
{
    public partial class DailyActivity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ActivityTitle { get; set; }
        public string ActivityContent { get; set; }
        public DateTime DateAchieve { get; set; }
        public double NumberOfHour { get; set; }
        public double TargetHour { get; set; }

        public virtual XbrainUser User { get; set; }
    }
}
