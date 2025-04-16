using System;
//using CSMPDK_3_0;
using System.Collections.Generic;
using System.Data.Common;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Location_Admin;
using BUIDCO.Domain.AdminConsole.Location_Admin;
using BUIDCO.Repository.AdminConsole.SqlHelper;

namespace BUIDCO.Repository.AdminConsole.Location_Admin
{
    public class LocAdminSP:BaseProvider,ILocAdmin
    {
        //CommonDLL objComnDll = new CommonDLL();
        //int intOutput = 0;
        //string strConString = DataBaseHelper.ConnectionString;
        private int intOutput = 0;
        public LocAdminSP(IDataBaseHelper dataBaseHelper) : base(dataBaseHelper)
        {

        }
        public int AddLocationAdmin(LocAdmin objLocAdmin)
        {
            try
            {
                object[] arrHierarDetails = { "chrActionCode", objLocAdmin.ActionCode,
                                        "intAssignId",objLocAdmin.AssigniD,
                                        "intHierarchyId",objLocAdmin.intHierarchyID,
                                        "intLevelId",objLocAdmin.Levelid,
                                        "intLevelDetailId",objLocAdmin.intLevelDetailId,
                                        "intUserId",objLocAdmin.UserID,
                                        "intCreatedBy",objLocAdmin.CreatedBy,
                                        "intOutPut",8};
                intOutput = Convert.ToInt32(BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_T_Admin_AssignAdmin_Manage", arrHierarDetails));
            }
            catch (Exception ex)
            {
                throw new Exception("Execution Failed", ex);
            }
            return intOutput;
        }
        public  IList<LocAdmin> FillLocationAssignAdmin(string UserId)
        {
            List<LocAdmin> list = new List<LocAdmin>();
            try
            {
                object[] objArray = new object[] { "UserId", Convert.ToInt32(UserId) };
                DbDataReader reader = SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_GetUserLocation", objArray);
                while (reader.Read())
                {
                    LocAdmin item = new LocAdmin
                    {
                        Levelid = Convert.ToInt32((reader["INTLEVELDETAILID"] == DBNull.Value) ? 0 : reader["INTLEVELDETAILID"]),
                        LocationName = Convert.ToString((reader["NVCHLEVELNAME"] == DBNull.Value) ? "" : reader["NVCHLEVELNAME"]),
                    };
                    list.Add(item);
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return list;
        }
    }
}