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
    public class AuthBLL
    {
        AuthDAL objAuthDAL = new AuthDAL();
        public DataTable ChekUserInfo(string UserName, string UPasswod)
        {
            DataTable dt = new DataTable();
            dt=objAuthDAL.ChekUser(UserName, UPasswod);
            return dt;
        }
        public int Insert_UserRegInfo(EUserReg objEUR)
        {
            int ret = 0;
            ret = objAuthDAL.Insert_UserReg(objEUR);
            return ret;
        }
        public DataTable GetUserRegList(int ReligionId, int Gender,int UserId=0)
        {
            DataTable dt = new DataTable();
            dt = objAuthDAL.GetUserReg(ReligionId, Gender, UserId);
            return dt;
        }
        public int Approved_UserRegInfo(int UserId, string AppStatus, string Password)
        {
            int ret = 0;
            ret = objAuthDAL.Approved_UserReg( UserId,  AppStatus,  Password);
            return ret;
        }
    }
}
