using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class ClassScheduleDAL
    {
        public int InsertUpdateDelete_ClassSchedule(List<Entity.EClassSchedule> collection)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            using (DbConnection connection = db.CreateConnection())
            {
                connection.Open();
                DbTransaction transaction = connection.BeginTransaction();
                try
                {
                    foreach (Entity.EClassSchedule EclsS in collection)
                    {
                        dbcmd = db.GetStoredProcCommand("conSp_InsertUpdateClassSchedule");
                        db.AddInParameter(dbcmd, "Shift", DbType.String, EclsS.Shift);
                        db.AddInParameter(dbcmd, "ClassId", DbType.Int32, EclsS.ClassId);
                        db.AddInParameter(dbcmd, "SubjectId", DbType.Int32, EclsS.SubjectId);
                        db.AddInParameter(dbcmd, "WeekDay", DbType.String, EclsS.WeekDay);
                        db.AddInParameter(dbcmd, "StartTime", DbType.DateTime, EclsS.StartTime);
                        db.AddInParameter(dbcmd, "EndTime", DbType.DateTime, EclsS.EndTime);
                        db.AddInParameter(dbcmd, "EntryBy", DbType.Int32, EclsS.EntryBy);
                        ret = db.ExecuteNonQuery(dbcmd);
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    ret = 0;
                    transaction.Rollback();
                }


            }


            return ret;
        }
    }
}
