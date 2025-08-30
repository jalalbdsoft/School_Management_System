using DAL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassScheduleBLL
    {
        ClassScheduleDAL objclsSDAL = new ClassScheduleDAL();

        public int InsertUpdateDelete_ClassScheduleInfo(List<EClassSchedule> collection)
        {
            int ret = 0;
            ret = objclsSDAL.InsertUpdateDelete_ClassSchedule(collection);
            return ret;
        }
    }
}
