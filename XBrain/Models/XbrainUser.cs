using System;
using System.Collections.Generic;

namespace XBrain.Models
{
    public partial class XbrainUser
    {
        public XbrainUser()
        {
            DailyActivity = new HashSet<DailyActivity>();
            DailyRoutine = new HashSet<DailyRoutine>();
            SleepingTime = new HashSet<SleepingTime>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public string DeviceId { get; set; }

        public virtual ICollection<DailyActivity> DailyActivity { get; set; }
        public virtual ICollection<DailyRoutine> DailyRoutine { get; set; }
        public virtual ICollection<SleepingTime> SleepingTime { get; set; }
    }
}
