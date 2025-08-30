using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class EStudent
    {
        public int action { get; set; }
        public int StudentId { get; set; }
        public string RegistrationNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public int ReligionId { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string BloodGroup { get; set; }
        public int DistrictId { get; set; }
        public int UpazilaId { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string FatherContact { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherName { get; set; }
        public string MotherContact { get; set; }
        public string MotherOccupation { get; set; }
        public string GuardianName { get; set; }
        public string GuardianRelation { get; set; }
        public string GuardianContact { get; set; }
        public string StudentImg { get; set; }
        public int EntryBy { get; set; }
        public string EntryDate { get; set; }
        public Nullable<int> UpdateBy { get; set; }
        public string UpdateDate { get; set; }
        public Boolean IsActive { get; set; }
    }
}
