using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
   public class ETeacherAssign
    {
        public int Action { get; set; }
        public int TeacherId { get; set; }
        public string Shift { get; set; }
        public int ClassId { get; set; }
        public int ScheduleId { get; set; }
        public int EntryBy { get; set; }
        public bool AttendanceStatus { get; set; }
        public int StudentId { get; set; }
        public string DateofAttendance { get; set; }
    }
}
