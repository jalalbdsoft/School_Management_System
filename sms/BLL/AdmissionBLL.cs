using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class AdmissionBLL
    {

        AdmissionDAL objAdmDAL = new AdmissionDAL();

        public int InsertUpdateDelete_AdmissionInfo(EAdmission objEAdm)
        {
            int ret = 0;
            ret = objAdmDAL.InsertUpdateDelete_Admission(objEAdm);
            return ret;
        }
        public DataTable Get_SpAdmissionList(int AdmissionId = 0)
        {
            DataTable dt = new DataTable();
            dt = objAdmDAL.Get_SpAdmission(AdmissionId);
            return dt;
        }
    }
}
