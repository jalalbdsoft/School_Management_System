using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class EInstitute
    {
        public int action { get; set; }
        public int InstituteId { get; set; }
        public string EIIN_RegistrationNo { get; set; }
        public string InstituteName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public int DistrictId { get; set; }
        public int UpazilaId { get; set; }
        public string Address { get; set; }
        public int InstituteTypeId { get; set; }
        public int EntryBy { get; set; }
        public DateTime EntryDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
        public Boolean IsActive { get; set; }
    }
}
