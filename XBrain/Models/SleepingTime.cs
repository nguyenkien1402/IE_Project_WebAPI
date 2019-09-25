using System;
using System.Collections.Generic;

namespace XBrain.Models
{
    public partial class SleepingTime
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? DateAchieve { get; set; }
        public TimeSpan? SleepTime { get; set; }
        public TimeSpan? WakingupTime { get; set; }

        public virtual XbrainUser User { get; set; }
    }
}
