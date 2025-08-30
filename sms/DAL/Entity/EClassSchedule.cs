using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
     public class EClassSchedule
    {
        public int Action { get; set; }
        public string Shift { get; set; }
        public int ClassId { get; set; }
        public string WeekDay { get; set; }
        public int SubjectId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
    }
}
