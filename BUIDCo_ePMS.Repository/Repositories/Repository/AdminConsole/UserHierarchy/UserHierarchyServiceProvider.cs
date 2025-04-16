using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BUIDCO.Domain.AdminConsole.UserHierarchy;
using BUIDCO.Repository.AdminConsole.SqlHelper;
using BUIDCO.Repository.Contract.Contract.AdminConsole.UserHierarchy;

namespace BUIDCO.Repository.AdminConsole.UserHierarchy
{
    public class UserHierarchyServiceProvider : BaseProvider, IUserHierarchyServiceProvider
    {
        //#region Variable Declaration
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString);

        //string strConString = DataBaseHelper.ConnectionString;
        //DbDataReader objDataReader;
        //#endregion
        public UserHierarchyServiceProvider(IDataBaseHelper dataBaseHelper) : base(dataBaseHelper)
        {

        }

        public int GetHierarchyId(int intUserId)
        {
            int intreturnval = 0;
            try
            {
                object[] Param = {
                                    "VCHACTIONCODE","1",
                                    "INTUSERID",intUserId
                                 };
                //intreturnval = Convert.ToInt32(ObjCmnDll.ExeScalar(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param));
                intreturnval = Convert.ToInt32(SqlHelper.SqlHelper.ExecuteScalar(DataBaseHelper.ConnectionString, "USP_HIERARCHY_USERCONTROL", Param));
                //intOut = Convert.ToInt32(param);
                //ObjCmnDll = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return intreturnval;
        }

        //    public List<UserHierarchyControl> BindLocation(UserHierarchyControl objUhier)
        //    {

        //        List<UserHierarchyControl> listLocation = new List<UserHierarchyControl>();
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","2",
        //                                "INTUSERID",objUhier.UserId,
        //                                "INTHIERARCHYID",objUhier.HierarchyId
        //                             };
        //            objDataReader = (DbDataReader)ObjCmnDll.ExeReader(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param);
        //            if (objDataReader.HasRows)
        //            {
        //                while (objDataReader.Read())
        //                {
        //                    listLocation.Add(new UserHierarchyControl
        //                    {
        //                        LevelDetailId = Convert.ToInt32(objDataReader["INTLEVELDETAILID"] == DBNull.Value ? 0 : objDataReader["INTLEVELDETAILID"]),
        //                        LevelDetailName = Convert.ToString(objDataReader["NVCHLEVELNAME"] == DBNull.Value ? "" : objDataReader["NVCHLEVELNAME"])
        //                    });
        //                }
        //            }

        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return listLocation;
        //    }

        //    public List<UserHierarchyControl> BindDropdownHierarchy()
        //    {
        //        List<UserHierarchyControl> listHierarchy = new List<UserHierarchyControl>();
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","3",                                    
        //                             };
        //            objDataReader = (DbDataReader)ObjCmnDll.ExeReader(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param);
        //            if (objDataReader.HasRows)
        //            {
        //                while (objDataReader.Read())
        //                {
        //                    listHierarchy.Add(new UserHierarchyControl
        //                    {
        //                        LevelDetailId = Convert.ToInt32(objDataReader["INTLEVELDETAILID"] == DBNull.Value ? 0 : objDataReader["INTLEVELDETAILID"]),
        //                        LevelDetailName = Convert.ToString(objDataReader["NVCHLEVELNAME"] == DBNull.Value ? "" : objDataReader["NVCHLEVELNAME"])
        //                    });
        //                }
        //            }

        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return listHierarchy;
        //    }

        //    public int GetParentId(int intLvldtlId)
        //    {
        //        int intreturnval = 0;
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","4",
        //                                "INTLEVELDETAILID",intLvldtlId                                   
        //                             };
        //            intreturnval = Convert.ToInt32(ObjCmnDll.ExeScalar(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param));
        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return intreturnval;
        //    }

        //    public List<UserHierarchyControl> FillFirstHirarchy(UserHierarchyControl objUhier)
        //    {
        //        List<UserHierarchyControl> listHierarchy = new List<UserHierarchyControl>();
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","5",
        //                                "INTHIERARCHYID",objUhier.HierarchyId,
        //                                "INTPARENTID",objUhier.ParentId
        //                             };
        //            objDataReader = (DbDataReader)ObjCmnDll.ExeReader(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param);
        //            if (objDataReader.HasRows)
        //            {
        //                while (objDataReader.Read())
        //                {
        //                    listHierarchy.Add(new UserHierarchyControl
        //                    {
        //                        LevelDetailId = Convert.ToInt32(objDataReader["INTLEVELDETAILID"] == DBNull.Value ? 0 : objDataReader["INTLEVELDETAILID"]),
        //                        LevelDetailName = Convert.ToString(objDataReader["NVCHLEVELNAME"] == DBNull.Value ? "" : objDataReader["NVCHLEVELNAME"])
        //                    });
        //                }
        //            }

        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return listHierarchy;
        //    }
        //    //both 6 and 7 FillHierarchy
        //    public List<UserHierarchyControl> FillHierarchy(UserHierarchyControl objUhier)
        //    {
        //        List<UserHierarchyControl> listHierarchy = new List<UserHierarchyControl>();
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE",objUhier.ActionCode,
        //                                "INTHIERARCHYID",objUhier.HierarchyId,                                  
        //                                "INTPARENTID",objUhier.ParentId,
        //                             };
        //            objDataReader = (DbDataReader)ObjCmnDll.ExeReader(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param);
        //            if (objDataReader.HasRows)
        //            {
        //                while (objDataReader.Read())
        //                {
        //                    listHierarchy.Add(new UserHierarchyControl
        //                    {
        //                        LevelDetailId = Convert.ToInt32(objDataReader["INTLEVELDETAILID"] == DBNull.Value ? 0 : objDataReader["INTLEVELDETAILID"]),
        //                        LevelDetailName = Convert.ToString(objDataReader["NVCHLEVELNAME"] == DBNull.Value ? "" : objDataReader["NVCHLEVELNAME"]),
        //                        LevelName = Convert.ToString(objDataReader["NVCHLABEL"] == DBNull.Value ? "" : objDataReader["NVCHLABEL"])
        //                    });
        //                }
        //            }

        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return listHierarchy;
        //    }

        //    public string GetLevelName(UserHierarchyControl objUhier)
        //    {
        //        string strReturnVal = "";
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","8",
        //                                "INTPARENTID",objUhier.ParentId ,
        //                                "INTLEVELDETAILID",objUhier.LevelDetailId  
        //                             };
        //            strReturnVal = Convert.ToString(ObjCmnDll.ExeScalar(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param));
        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return strReturnVal;
        //    }

        //    public int GetHierLevelNo(int intLvldtlId)
        //    {
        //        int intreturnval = 0;
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","9",
        //                                "INTLEVELDETAILID",intLvldtlId                                   
        //                             };
        //            intreturnval = Convert.ToInt32(ObjCmnDll.ExeScalar(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param));
        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return intreturnval;
        //    }

        public List<UserHierarchyControl> FillUser1(UserHierarchyControl objUhier)
        {
            List<UserHierarchyControl> listUser = new List<UserHierarchyControl>();
            try
            {
                object[] Param = {
                                        "VCHACTIONCODE","10",
                                        "INTLEVELDETAILID",objUhier.LevelDetailId,
                                        "INTSTATUS",objUhier.StatusFlag,
                                     };
             SqlDataReader objDataReader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "USP_HIERARCHY_USERCONTROL", Param);
                if (objDataReader.HasRows)
                {
                    while (objDataReader.Read())
                    {
                        listUser.Add(new UserHierarchyControl
                        {
                            UserId = Convert.ToInt32(objDataReader["INTUSERID"] == DBNull.Value ? 0 : objDataReader["INTUSERID"]),
                            UserName = Convert.ToString(objDataReader["VCHFULLNAME"] == DBNull.Value ? "" : objDataReader["VCHFULLNAME"]),
                            Symbol = Convert.ToString(objDataReader["VCHSYBMOL"] == DBNull.Value ? "" : objDataReader["VCHSYBMOL"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listUser;
        }

        //    public List<UserHierarchyControl> FillUser2(UserHierarchyControl objUhier)
        //    {
        //        List<UserHierarchyControl> listUser = new List<UserHierarchyControl>();
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","11",
        //                                "INTPARENTID",objUhier.ParentId,                                  
        //                                "INTSTATUS",objUhier.StatusFlag,
        //                             };
        //            objDataReader = (DbDataReader)ObjCmnDll.ExeReader(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param);
        //            if (objDataReader.HasRows)
        //            {
        //                if (objUhier.StatusFlag == 0)
        //                {
        //                    while (objDataReader.Read())
        //                    {
        //                        listUser.Add(new UserHierarchyControl
        //                        {
        //                            UserId = Convert.ToInt32(objDataReader["INTUSERID"] == DBNull.Value ? 0 : objDataReader["INTUSERID"]),
        //                            UserName = Convert.ToString(objDataReader["VCHFULLNAME"] == DBNull.Value ? "" : objDataReader["VCHFULLNAME"]),
        //                            Symbol = Convert.ToString(objDataReader["VCHSYBMOL"] == DBNull.Value ? "" : objDataReader["VCHSYBMOL"])
        //                        });
        //                    }
        //                }
        //                else
        //                {
        //                    while (objDataReader.Read())
        //                    {
        //                        listUser.Add(new UserHierarchyControl
        //                        {
        //                            LevelDetailId = Convert.ToInt32(objDataReader["INTLEVELDETAILID"] == DBNull.Value ? 0 : objDataReader["INTLEVELDETAILID"]),
        //                            LevelDetailName = Convert.ToString(objDataReader["NVCHLEVELNAME"] == DBNull.Value ? "" : objDataReader["NVCHLEVELNAME"]),
        //                            LevelName = Convert.ToString(objDataReader["NVCHLABEL"] == DBNull.Value ? "" : objDataReader["NVCHLABEL"])
        //                        });
        //                    }
        //                }
        //            }

        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return listUser;
        //    }

        //    public string FillLevelName(UserHierarchyControl objUhier)
        //    {
        //        string strReturnVal = "";
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","12",
        //                                "INTPARENTID",objUhier.ParentId      
        //                             };
        //            strReturnVal = Convert.ToString(ObjCmnDll.ExeScalar(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param));
        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return strReturnVal;
        //    }

        //    public string GetAdminUser(UserHierarchyControl objUhier)
        //    {
        //        string strReturnVal = "";
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","13",
        //                                "INTPARENTID",objUhier.ParentId      
        //                             };
        //            strReturnVal = Convert.ToString(ObjCmnDll.ExeScalar(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param));
        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return strReturnVal;
        //    }

        //    public List<UserHierarchyControl> FillFstHirarchy(UserHierarchyControl objUhier)
        //    {
        //        List<UserHierarchyControl> listHierarchy = new List<UserHierarchyControl>();
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","14",
        //                                "INTHIERARCHYID",objUhier.HierarchyId,
        //                                "INTPARENTID",objUhier.ParentId
        //                             };
        //            objDataReader = (DbDataReader)ObjCmnDll.ExeReader(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param);
        //            if (objDataReader.HasRows)
        //            {
        //                while (objDataReader.Read())
        //                {
        //                    listHierarchy.Add(new UserHierarchyControl
        //                    {
        //                        LevelDetailId = Convert.ToInt32(objDataReader["INTLEVELDETAILID"] == DBNull.Value ? 0 : objDataReader["INTLEVELDETAILID"]),
        //                        LevelDetailName = Convert.ToString(objDataReader["NVCHLEVELNAME"] == DBNull.Value ? "" : objDataReader["NVCHLEVELNAME"]),
        //                        LevelName = Convert.ToString(objDataReader["NVCHLABEL"] == DBNull.Value ? "" : objDataReader["NVCHLABEL"])
        //                    });
        //                }
        //            }

        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return listHierarchy;
        //    }

        //    public List<UserHierarchyControl> TotalparentId(UserHierarchyControl objUhier)
        //    {
        //        List<UserHierarchyControl> listHierarchy = new List<UserHierarchyControl>();
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","15",
        //                                "INTLEVELDETAILID",objUhier.LevelDetailId                                   
        //                             };
        //            objDataReader = (DbDataReader)ObjCmnDll.ExeReader(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param);
        //            if (objDataReader.HasRows)
        //            {
        //                while (objDataReader.Read())
        //                {
        //                    listHierarchy.Add(new UserHierarchyControl
        //                    {
        //                        LevelDetailId = Convert.ToInt32(objDataReader["Id"] == DBNull.Value ? 0 : objDataReader["Id"])

        //                    });
        //                }
        //            }
        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return listHierarchy;
        //    }



        //    public List<UserHierarchyControl> LevelId(UserHierarchyControl objUhier)
        //    {
        //        List<UserHierarchyControl> listHierarchy = new List<UserHierarchyControl>();
        //        try
        //        {

        //            string strQr = "SELECT A.intLevelDetailId, A.nvchLevelName  from KAC.M_ADM_LevelDetails A,KAC.M_ADM_Level B where  A.intLevelId=B.intLevelId And A.intParentId=" + objUhier.LevelDetailId + " AND A.bitStatus=1 And B.bitStatus=1  order by A.nvchLevelName asc";
        //            objDataReader = (DbDataReader)this.ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, strQr);
        //            while (objDataReader.Read())
        //            {
        //                listHierarchy.Add(new UserHierarchyControl
        //                  {
        //                      LevelDetailId = Convert.ToInt32(objDataReader["intLevelDetailId"].ToString()),
        //                      LevelDetailName = objDataReader["nvchLevelName"].ToString(),

        //                  });

        //            }
        //            objDataReader.Close();
        //        }
        //        catch (Exception exception)
        //        {
        //            throw new Exception("Execution Failed", exception);
        //        }
        //        return listHierarchy;

        //    }

        //    public int GetPositionValue(int intLvlDtlId )
        //    {
        //        int intReturnVal ;
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","16",
        //                                "INTLEVELDETAILID",intLvlDtlId      
        //                             };
        //            intReturnVal = Convert.ToInt32(ObjCmnDll.ExeScalar(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param));
        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return intReturnVal;
        //    }
        //    public int GetParentIdForLvlDtls(int intLvlDtlId)
        //    {
        //        int intReturnVal;
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","17",
        //                                "INTLEVELDETAILID",intLvlDtlId      
        //                             };
        //            intReturnVal = Convert.ToInt32(ObjCmnDll.ExeScalar(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param));
        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return intReturnVal;
        //    }
        public List<UserHierarchyControl> BindGradeData(UserHierarchyControl objUhier)
        {
            List<UserHierarchyControl> listGrade = new List<UserHierarchyControl>();
            try
            {

                object[] Param = {
                                        "VCHACTIONCODE","18",
                                        "INTHIERARCHYID",objUhier.HierarchyId
                                     };
               SqlDataReader objDataReader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "USP_HIERARCHY_USERCONTROL", Param);
                while (objDataReader.Read())
                {
                    listGrade.Add(new UserHierarchyControl
                    {
                        GradeId = Convert.ToInt32(objDataReader["INTGRADEID"].ToString()),
                        GradeName = objDataReader["VCHGRADENAME"].ToString(),
                        Symbol = objDataReader["SYMBOL"].ToString()
                    });

                }
                objDataReader.Close();
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return listGrade;

        }
        public List<UserHierarchyControl> BindDesignationData(UserHierarchyControl objUhier)
        {
            List<UserHierarchyControl> listGrade = new List<UserHierarchyControl>();
            try
            {

                object[] Param = {
                                        "VCHACTIONCODE","19",
                                        "INTHIERARCHYID",objUhier.HierarchyId
                                     };
              SqlDataReader  objDataReader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "USP_HIERARCHY_USERCONTROL", Param);
                while (objDataReader.Read())
                {
                    listGrade.Add(new UserHierarchyControl
                    {
                        DesigId = Convert.ToInt32(objDataReader["INTDESIGID"].ToString()),
                        DesigName = objDataReader["NVCHDESIGNAME"].ToString(),
                        Symbol = objDataReader["SYMBOL"].ToString()
                    });

                }
                objDataReader.Close();
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return listGrade;

        }
        //    public int CountLevelid(int intLvlDtlId)
        //    {
        //        int intReturnVal;
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","20",
        //                                "INTLEVELDETAILID",intLvlDtlId      
        //                             };
        //            intReturnVal = Convert.ToInt32(ObjCmnDll.ExeScalar(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param));
        //            ObjCmnDll = null;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        return intReturnVal;
        //    }

        //    public List<UserHierarchyControl> GetLevelNameUc2(int intLvlDtlId)
        //    {
        //        List<UserHierarchyControl> listLevelName = new List<UserHierarchyControl>();
        //        try
        //        {
        //            object[] Param = {
        //                                "VCHACTIONCODE","21",
        //                                "INTLEVELDETAILID",intLvlDtlId                                 
        //                             };
        //            objDataReader = (DbDataReader)ObjCmnDll.ExeReader(strConString, "KAC.USP_HIERARCHY_USERCONTROL", Param);
        //            while (objDataReader.Read())
        //            {
        //                listLevelName.Add(new UserHierarchyControl
        //                {
        //                    LevelName = objDataReader["NVCHLABEL"].ToString()                       
        //                });

        //            }
        //            objDataReader.Close();
        //        }
        //        catch (Exception exception)
        //        {
        //            throw new Exception("Execution Failed", exception);
        //        }
        //        return listLevelName;
        //    }
        public List<UserHierarchyControl> FillLabelUser(int Parent, int Position)
        {
            List<UserHierarchyControl> listHierarchy = new List<UserHierarchyControl>();
            try
            {

                string strQr = "declare @temp varchar(1000) select @temp=COALESCE(@temp +'/'+ convert(varchar, NVCHLABEL),convert(varchar, NVCHLABEL)) FROM M_ADM_LEVEL WHERE INTLEVELID in(select INTLEVELID from M_ADM_LEVEL where intparentid=(SELECT M_ADM_LevelDetails.intLevelId FROM M_ADM_LevelDetails WHERE intLevelDetailId=" + Parent + ") and intposition=" + Position + ") order by NVCHLABEL select @temp NVCHLABEL";
                //objDataReader = (DbDataReader)this.ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, strQr);
                //SqlDataReader objDataReader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "USP_HIERARCHY_USERCONTROL", strQr);
                SqlDataReader objDataReader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString,System.Data.CommandType.Text, strQr);
                while (objDataReader.Read())
                {
                    listHierarchy.Add(new UserHierarchyControl
                    {
                        LevelName = objDataReader["NVCHLABEL"].ToString(),

                    });

                }
                objDataReader.Close();
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return listHierarchy;
        }

        public List<UserHierarchyControl> FillUserByDesig(int Loc, int Desig)
        {
            List<UserHierarchyControl> listHierarchy = new List<UserHierarchyControl>();
            try
            {
                object[] Param = { "chrActionCode", "V", "intDeptId", Loc, "intDesigId", Desig };
               SqlDataReader objDataReader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString,"usp_GetUserByLocID_DesigId", Param);
                if (objDataReader.HasRows)
                {
                    while (objDataReader.Read())
                    {
                        listHierarchy.Add(new UserHierarchyControl
                        {
                            UserId = Convert.ToInt32(objDataReader["intUserId"] == DBNull.Value ? 0 : objDataReader["intUserId"]),
                            UserName = Convert.ToString(objDataReader["fullname"] == DBNull.Value ? "" : objDataReader["fullname"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listHierarchy;
        }
    }
}
