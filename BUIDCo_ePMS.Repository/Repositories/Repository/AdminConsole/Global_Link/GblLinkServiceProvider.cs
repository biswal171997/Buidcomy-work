using BUIDCO.Domain.AdminConsole.Global_Link;
using BUIDCO.Repository.AdminConsole.SqlHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BUIDCO.Repository.AdminConsole.Global_Link
{
    public class GblLinkServiceProvider : BaseProvider
    {
        #region Variable Declaration        
        object param = new object();
        int intOutput;
        #endregion

        public GblLinkServiceProvider(IDataBaseHelper dataBaseHelper) : base(dataBaseHelper)
        {

        }
        public int ActivateGlobalLink(Global objGloballink)
        {
            int num;
            try
            {
                num = ActivateInactivateGL(objGloballink, "T");
            }

            catch (Exception exception2)
            {
                throw new Exception("Execution Failed", exception2);
            }
            return num;
        }

        public int ActivateInactivateGL(Global objGloballink, string StrAction)
        {
            int intOut = 0;

            object[] objArray = new object[] { "chrActionCode", objGloballink.ActionCode, "intGLinkID", objGloballink.IntGlobalLinkID, "vchUpdatedBy", objGloballink.CreatedBy};
            intOut = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_GlobalLink_Manage",out param, objArray);
            intOut = Convert.ToInt32(param);
            if (StrAction == "D")
            {
                if (intOut == 3)
                {
                    intOut = 1;
                }
            }
            else if (intOut == 2)
            {
                intOut = 1;
            }           

            return intOut;
        }

        public int AddGlobalLink(Global objGloballink)
        {
            try
            {
                object[] objArray = new object[] { 
                                                    "chrActionCode", objGloballink.ActionCode, 
                                                    "nvchGLinkName", objGloballink.GlobalLinkName,
                                                    "nvchGLinkNameOL",objGloballink.GlobalLinkNameinAhmaric,
                                                    //"vcLocation", objGloballink.Location, 
                                                    //"vchDeptId", objGloballink.DeptID, 
                                                    "intSortNum", objGloballink.SLNO, 
                                                    "bit_ShowOnHomePage", objGloballink.OnHomePage, 
                                                    "vchUpdatedBy", objGloballink.CreatedBy
                                                    //"vch_GlobalLinkImg", objGloballink.GlobalLinkImg, 
                                                    
                                                };
                intOutput = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_GlobalLink_Manage",out param, objArray);
                intOutput = Convert.ToInt32(param);
            }

            catch (Exception exception2)
            {
                throw new Exception("Execution Failed", exception2);
            }
            return intOutput;
        }

        public int DeleteGlobalLink(Global objGloballink)
        {
            int num;
            try
            {
                num = ActivateInactivateGL(objGloballink, "D");
            }

            catch (Exception exception2)
            {
                throw new NotImplementedException(exception2.Message, exception2);
            }
            return num;
        }

        public int EditGlobalLink(Global objGloballink)
        {
            try
            {

                object[] objArray = new object[] { 
                                                        "chrActionCode", objGloballink.ActionCode, 
                                                        "intGLinkID", objGloballink.IntGlobalLinkID, 
                                                        "nvchGLinkName", objGloballink.GlobalLinkName, 
                                                         "nvchGLinkNameOL",objGloballink.GlobalLinkNameinAhmaric,
                                                        //"vchDeptId", link.DeptID, 
                                                        "intSortNum", objGloballink.SLNO, 
                                                        //"vcLocation", link.Location, 
                                                        "vchUpdatedBy", objGloballink.CreatedBy, 
                                                        "bit_ShowOnHomePage", objGloballink.OnHomePage 
                                                        //"vch_GlobalLinkImg", objGloballink.GlobalLinkImg, 
                                                        
                                                    };
                intOutput = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_GlobalLink_Manage",out param, objArray);
                return Convert.ToInt32(param);

            }

            catch (Exception exception2)
            {
                throw new NotImplementedException(exception2.Message, exception2);
            }
           
        }

        public IList<Global> GetAllGlobalLink(Global objGloballink)
        {
            List<Global> list = new List<Global>();
            try
            {
                object[] objArray = new object[] { "ActionCode", objGloballink.ActionCode };

                SqlDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_GlobalLink_View", new object[] { "ActionCode", objGloballink.ActionCode });
                while (reader.Read())
                {
                    if (objGloballink.ActionCode == "V")
                    {
                        Global item = new Global
                        {
                            IntGlobalLinkID = Convert.ToString((reader["intGLinkID"] == DBNull.Value) ? "" : reader["intGLinkID"]),
                            GlobalLinkName = Convert.ToString((reader["nvchGLinkName"] == DBNull.Value) ? "" : reader["nvchGLinkName"]),
                            SLNO = Convert.ToInt32((reader["intSortNum"] == DBNull.Value) ? 0 : reader["intSortNum"]),
                            //GlobalLinkNameinAhmaric = Convert.ToString((reader["nvchGlinkNameOL"] == DBNull.Value) ? "" : reader["nvchGlinkNameOL"]),
                            //Location = Convert.ToString((reader["Location"] == DBNull.Value) ? "" : reader["Location"]),
                            DeletedStatus = Convert.ToString((reader["bitStatus"] == DBNull.Value) ? "" : reader["bitStatus"]),
                            //GlobalLinkImg = Convert.ToString((reader["vch_GlinkImg"] == DBNull.Value) ? "" : reader["vch_GlinkImg"])

                        };
                        list.Add(item);
                    }
                    else
                    {
                        Global link2 = new Global
                        {
                            IntGlobalLinkID = Convert.ToString((reader["intGLinkID"] == DBNull.Value) ? "" : reader["intGLinkID"]),
                            GlobalLinkName = Convert.ToString((reader["nvchGLinkName"] == DBNull.Value) ? "" : reader["nvchGLinkName"]),
                            //GlobalLinkNameinAhmaric = Convert.ToString((reader["nvchGlinkNameOL"] == DBNull.Value) ? "" : reader["nvchGlinkNameOL"]),
                            SLNO = Convert.ToInt32((reader["intSortNum"] == DBNull.Value) ? 0 : reader["intSortNum"]),

                        };
                        list.Add(link2);
                    }
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return list;
        }

        public string GetGlobalLinkById(Global objGloballink)
        {
            try
            {
                SqlDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_GlobalLink_View",  new object[] { "intGlinkId", objGloballink.IntGlobalLinkID, "ActionCode", objGloballink.ActionCode });
                while (reader.Read())
                {
                    objGloballink.GlobalLinkName = reader["GLinkName"].ToString();
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw new NotImplementedException(exception.Message);
            }
            return objGloballink.GlobalLinkName;
        }

        public IList<Global> GetGlobalLinkDetails(Global objGloballink)
        {
            List<Global> list = new List<Global>();
            try
            {
                SqlDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_GlobalLink_View", new object[] { "ActionCode", objGloballink.ActionCode, "intGlinkId", objGloballink.IntGlobalLinkID });
                while (reader.Read())
                {
                    Global item = new Global
                    {
                        GlobalLinkName = Convert.ToString((reader["nvchGLinkName"] == DBNull.Value) ? "" : reader["nvchGLinkName"]),
                        GlobalLinkNameinAhmaric = Convert.ToString((reader["nvchGLinkNameOL"] == DBNull.Value) ? "" : reader["nvchGLinkNameOL"]),
                        SLNO = Convert.ToInt32((reader["intSortNum"] == DBNull.Value) ? 0 : reader["intSortNum"]),
                        OnHomePage = Convert.ToBoolean((reader["bitHomePage"] == DBNull.Value) ? 0 : reader["bitHomePage"]),

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

        public int InActivateGlobalLink(Global objGloballink)
        {
            int num;
            try
            {
                num = ActivateInactivateGL(objGloballink, "I");
            }

            catch (Exception exception2)
            {
                throw new NotImplementedException(exception2.Message, exception2);
            }
            return num;
        }

        public int UpdateSlno(Global objGloballink)
        {
            try
            {
                object[] objArray = new object[] { "chrActionCode", objGloballink.ActionCode, "intGLinkID", objGloballink.IntGlobalLinkID, "intSortNum", objGloballink.SLNO, "vchUpdatedBy", objGloballink.CreatedBy };
                intOutput = Convert.ToInt32(BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_GlobalLink_Manage",out param, objArray));
                intOutput = Convert.ToInt32(param);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return intOutput;
        }
        public int GetMaxGlinkId()
        {
            try
            {
                intOutput = Convert.ToInt32(SqlHelper.SqlHelper.ExecuteScalar(DataBaseHelper.ConnectionString, System.Data.CommandType.Text ,"SELECT isnull(MAX([intGLinkId]),0)+1 FROM M_ADM_GlobalLink"));
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return intOutput;
        }

        public IList<Global> GetAllLocation(Global objGloballink)
        {
            List<Global> list = new List<Global>();


            try
            {
                Global item1 = new Global
                {
                    HierarchyID = 0,
                    HierarchyName = "All",


                };
                list.Add(item1);
                SqlDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_GlobalLink_View",  new object[] { "ActionCode", objGloballink.ActionCode });
                while (reader.Read())
                {


                    Global item = new Global
                    {
                        HierarchyID = Convert.ToInt32((reader["inthierarchyid"] == DBNull.Value) ? 0 : reader["inthierarchyid"]),
                        HierarchyName = Convert.ToString((reader["nvchHierarchyName"] == DBNull.Value) ? "" : reader["nvchHierarchyName"]),


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