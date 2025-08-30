using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity;
using System.Data;
namespace BLL
{
    public class InstituteBLL
    {
       InstituteDAL objInsDAL   = new InstituteDAL();
        
        public int InsertUpdateDelete_InstituteInfo(EInstitute objEIns)
        {
            int ret = 0;
            ret = objInsDAL.InsertUpdateDelete_Institute(objEIns);
            return ret;
        }
        public DataTable Get_SpInstituteList(int InstituteId=0 )
        {
            DataTable dt = new DataTable();
            dt = objInsDAL.Get_SpInstitute(InstituteId);
            return dt;
        }
        
    }
}
