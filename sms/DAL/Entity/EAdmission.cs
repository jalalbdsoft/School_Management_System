using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class EAdmission
    {
        public int action { get; set; }
        public int AdmissionId { get; set; }
        public string RegistrationNo { get; set; }
        public int RegSl { get; set; }
        public int StudentId { get; set; }
        public string Shift { get; set; }
        public int ClassId { get; set; }
        public string RollNo { get; set; }
        public int SessionYear { get; set; }
        public string AdmissionDate { get; set; }
        public int EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
        public Nullable<Boolean> IsActive { get; set; }
    }
}
