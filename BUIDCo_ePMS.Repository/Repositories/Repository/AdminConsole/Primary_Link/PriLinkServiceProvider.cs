
using BUIDCO.Domain.AdminConsole.Primary_Link;
using BUIDCO.Repository.AdminConsole.SqlHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BUIDCO.Repository.AdminConsole.Primary_Link
{
    //public class PriLinkServiceProvider: BaseProvider, IPriLinkServiceProvider
    public class PriLinkServiceProvider : BaseProvider
    {
        #region Variable Declaration        
        object param = new object();
        int intOutput;
        #endregion

        public PriLinkServiceProvider(IDataBaseHelper dataBaseHelper) : base(dataBaseHelper)
        {

        }
        public int ActivatePrimaryLink(Primary objPrimaryLink)
        {
            try
            {
                object[] objArray = new object[] { "CHRACTIONCODE", objPrimaryLink.ActionCode, "INTPLINKID", objPrimaryLink.PlinkId, "int_UpdatedBy", objPrimaryLink.UpdatedBy };
                intOutput = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_PrimaryLink_Manage", out param, objArray);
                intOutput = Convert.ToInt32(param);
                if (intOutput == 2)
                {
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return this.intOutput;
        }

        public int AddPrimaryLink(Primary objPrimaryLink)
        {
            try
            {
                object[] objArray = new object[] {
                    "CHRACTIONCODE", objPrimaryLink.ActionCode, "INTPLINKID", objPrimaryLink.PlinkId, "NVCHPLINKNAME", objPrimaryLink.PlinkName,"nvchPlinkNameOL",objPrimaryLink.PlinkNameinAhmaric ,"INTGLINKID", objPrimaryLink.GlinkId,  "INTFUNCTIONID", objPrimaryLink.FunctionId, "INTSLNO", objPrimaryLink.SlNo, "VCHFILENAME", objPrimaryLink.FileName,
                "VCHEXTERNALURL",objPrimaryLink.Browser,  "BIT_SHOWONHOMEPAGE", objPrimaryLink.OnHomePage, "int_UpdatedBy", objPrimaryLink.UpdatedBy
                 };
                intOutput = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_PrimaryLink_Manage",out param, objArray);
                intOutput = Convert.ToInt32(param);
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return this.intOutput;
        }

        public int DeletePrimaryLink(Primary objPrimaryLink)
        {
            try
            {
                object[] objArray = new object[] { "chrActionCode", objPrimaryLink.ActionCode, "intPlinkId", objPrimaryLink.PlinkId, "vcUpdatedBy", objPrimaryLink.UpdatedBy };
                intOutput = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_PrimaryLink_Manage",out param, objArray);
                intOutput = Convert.ToInt32(param);
                if (Convert.ToInt32(this.intOutput) == 3)
                {
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return intOutput;
        }

        public string FillSLno(Primary objPrimaryLink)
        {
            string str = null;
            object[] objArray = new object[] { "ActionCode", objPrimaryLink.ActionCode, "Plinkid", objPrimaryLink.PlinkId, "PGlinkId", objPrimaryLink.GlinkId };

            SqlDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_PrimaryLink_View", objArray);
            if (reader.Read())
            {
                str = Convert.ToString(reader["SLNO"]);
            }
            return str;
        }

        public IList<Primary> GetAllPrimaryLink(Primary objPrimaryLink)
        {
            IList<Primary> list = new List<Primary>();
            try
            {
                object[] objArray = new object[] { "ActionCode", objPrimaryLink.ActionCode, "Plinkid", objPrimaryLink.PlinkId, "PGlinkId", objPrimaryLink.GlinkId };
                SqlDataReader reader =BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_PrimaryLink_View",  objArray);
                while (reader.Read())
                {
                    Primary item = new Primary
                    {
                        PlinkId = reader["PlinkId"].ToString(),
                        PlinkName = reader["nvchPlinkName"].ToString(),
                        GlinkId = Convert.ToInt32(reader["intGlinkId"].ToString()),
                        GLinkName = reader["GLINKNAME"].ToString(),
                        PlinkNameinAhmaric = reader["nvchPlinkNameOL"].ToString(),
                        //DeptId = reader["DeptId"].ToString(),
                        FunctionId = Convert.ToInt32(reader["intFunctionId"].ToString()),
                        SlNo = Convert.ToInt32(reader["intSlNo"].ToString()),
                        ExternalURL = reader["vchExternalURL"].ToString(),
                        LinkType = Convert.ToInt16(reader["bitLinkType"].ToString()),
                        //AccessLevel = Convert.ToDecimal(reader["AccessLevel"].ToString()),
                        //Browser = reader["Browser"].ToString(),
                        OnHomePage = Convert.ToBoolean(reader["BIT_SHOWONHOMEPAGE"].ToString())
                    };
                    list.Add(item);
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return list;
        }

        public int InactivatePrimaryLink(Primary objPrimaryLink)
        {
            try
            {
                object[] objArray = new object[] { "CHRACTIONCODE", objPrimaryLink.ActionCode, "INTPLINKID", objPrimaryLink.PlinkId, "int_UpdatedBy", objPrimaryLink.UpdatedBy};
                this.intOutput = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_PrimaryLink_Manage",out param, objArray);
                intOutput = Convert.ToInt32(param);
                if (intOutput == 2)
                {
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return this.intOutput;
        }

        public int UpdatePrimaryLink(Primary objPrimaryLink)
        {
            try
            {
                object[] objArray = new object[] {
                    "CHRACTIONCODE", objPrimaryLink.ActionCode, "INTPLINKID", objPrimaryLink.PlinkId, "NVCHPLINKNAME", objPrimaryLink.PlinkName,"nvchPlinkNameOL",objPrimaryLink.PlinkNameinAhmaric ,"INTGLINKID", objPrimaryLink.GlinkId,  "INTFUNCTIONID", objPrimaryLink.FunctionId, "INTSLNO", objPrimaryLink.SlNo, "VCHFILENAME", objPrimaryLink.FileName,
                "VCHEXTERNALURL",objPrimaryLink.Browser,  "BIT_SHOWONHOMEPAGE", objPrimaryLink.OnHomePage, "int_UpdatedBy", objPrimaryLink.UpdatedBy
                 };
                intOutput =BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_PrimaryLink_Manage",out param, objArray);
                intOutput = Convert.ToInt32(param);
                if (intOutput == 2)
                {
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return this.intOutput;
        }

        public int UpdateSlnoPrimaryLink(Primary objPrimaryLink)
        {
            try
            {
                object[] objArray = new object[] {
                    "CHRACTIONCODE", objPrimaryLink.ActionCode, "INTPLINKID", objPrimaryLink.PlinkId,"NVCHPLINKNAME", objPrimaryLink.PlinkName,"INTGLINKID", objPrimaryLink.GlinkId,  "INTFUNCTIONID", objPrimaryLink.FunctionId, "INTSLNO", objPrimaryLink.SlNo, "VCHFILENAME", objPrimaryLink.FileName,
                "VCHEXTERNALURL",objPrimaryLink.Browser,  "BIT_SHOWONHOMEPAGE", objPrimaryLink.OnHomePage, "int_UpdatedBy", objPrimaryLink.UpdatedBy 
                 };
                intOutput = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteNonQuery(DataBaseHelper.ConnectionString, "usp_PrimaryLink_Manage",out param, objArray);
                intOutput = Convert.ToInt32(param);
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return this.intOutput;
        }
        public IList<Primary> FillFunctionType()
        {
            IList<Primary> list = new List<Primary>();
            try
            {

                SqlDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString,System.Data.CommandType.Text , "select intFunctionId,replace(vchFunction,'X+HIcwPJE/4=',' & ') as vchFunction from M_ADM_Function where bitStatus=1 ORDER BY vchFunction");
                while (reader.Read())
                {
                    Primary item = new Primary
                    {
                        PlinkId = reader["intFunctionId"].ToString(),
                        PlinkName = reader["vchFunction"].ToString(),

                    };
                    list.Add(item);
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return list;
        }
        public IList<Primary> FillGlink(string UserId)
        {
            IList<Primary> list = new List<Primary>();
            try
            {
                object[] objArray = new object[] { "UserId", Convert.ToInt32(UserId) };
                SqlDataReader reader =BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_GetGlobalLInkByPrevil",  objArray);
                while (reader.Read())
                {
                    Primary item = new Primary
                    {
                        GlinkId = Convert.ToInt32(reader["intGLinkID"].ToString()),
                        GLinkName = reader["nvchGLinkName"].ToString(),

                    };
                    list.Add(item);
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return list;

        }

        public IList<Primary> FillGridview(int glinkid, Char ActionCode, string Plinkid)
        {
            IList<Primary> list = new List<Primary>();
            try
            {
                object[] objArray = new object[] { "ActionCode", ActionCode, "Plinkid", Plinkid, "PGlinkId", glinkid };
                SqlDataReader reader =BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, "usp_PrimaryLink_View",  objArray);
                while (reader.Read())
                {
                    Primary item = new Primary
                    {
                        PlinkId = reader["PlinkId"].ToString(),
                        PlinkName = reader["nvchPlinkName"].ToString(),
                        GlinkId = Convert.ToInt32(reader["intGlinkId"].ToString()),
                        GLinkName = reader["GLINKNAME"].ToString(),
                        PlinkNameinAhmaric = reader["nvchPlinkNameOL"].ToString(),
                        FunctionId = Convert.ToInt32(reader["intFunctionId"].ToString()),
                        SlNo = Convert.ToInt32(reader["intSlNo"].ToString())   
                    };
                    list.Add(item);
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return list;

        }

        public IList<Primary> FillGlinkReport(int Flag)
        {
            IList<Primary> list = new List<Primary>();
            try
            {
                string strQuery="";
                if (Flag == 0)
                {
                    strQuery = "select DISTINCT g.nvchGlinkName,g.intGLinkId from M_ADM_PrimaryLink p,M_ADM_GlobalLink g where p.intGlinkId=g.intGLinkId and p.intFunctionId=0 and p.bitStatus=1 and g.bitStatus=1 order by g.nvchGLinkName";
                }
                else
                {
                    strQuery = "select DISTINCT g.nvchGlinkName,g.intGLinkId from M_ADM_PrimaryLink p,M_ADM_GlobalLink g where p.intGlinkId=g.intGLinkId and p.intFunctionId<>0 and p.bitStatus=1 and g.bitStatus=1 order by g.nvchGLinkName";
                }
                SqlDataReader reader =BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString, strQuery);
                while (reader.Read())
                {
                    Primary item = new Primary
                    {
                        GlinkId = Convert.ToInt32(reader["intGLinkId"].ToString()),
                        GLinkName = reader["nvchGlinkName"].ToString(),

                    };
                    list.Add(item);
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return list;
        }
        public IList<Primary> FillPlinkReport(int GlinkId, int Flag)
        {
            IList<Primary> list = new List<Primary>();
            try
            {
                string strQuery = "";
                strQuery = "SELECT ROW_NUMBER() OVER (order BY intPLinkId asc) id, p.intPLinkId ,p.nvchPlinkName,p.intSlNo,g.intGLinkId,g.nvchGLinkName from M_ADM_PrimaryLink p,M_ADM_GlobalLink g where p.intGlinkId=g.intGLinkId  and p.bitStatus=1 and p.intGlinkId= " + GlinkId + "";
                SqlDataReader reader =BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString,System.Data.CommandType.Text, strQuery);
                while (reader.Read())
                {
                    Primary item = new Primary
                    {
                        FunctionId = Convert.ToInt32(reader["id"].ToString()),
                        PlinkId = reader["intPLinkId"].ToString(),
                        PlinkName = reader["nvchPlinkName"].ToString(),
                        GlinkId= Convert.ToInt32(reader["intGLinkId"].ToString()),
                        GLinkName= reader["nvchGLinkName"].ToString(),
                        SlNo = Convert.ToInt32(reader["intSlNo"].ToString()),

                    };
                    list.Add(item);
                }
                reader.Close();
            }
            catch (Exception exception)
            {
                throw new Exception("Execution Failed", exception);
            }
            return list;
        }

    }
}