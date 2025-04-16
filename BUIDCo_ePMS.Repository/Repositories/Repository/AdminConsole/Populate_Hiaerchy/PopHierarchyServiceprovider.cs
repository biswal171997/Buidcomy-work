using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BUIDCO.Domain.AdminConsole.Populate_Hiaerchy;
using BUIDCO.Repository.AdminConsole.SqlHelper;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Populate_Hiaerchy;

namespace BUIDCO.Repository.AdminConsole.Persistence
{
    public class PopHierarchyServiceprovider:BaseProvider,IPopHierarchyServiceprovider
    {
        //#region Variable Declaration
        //SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[DataBaseHelper.ConnectionString].ConnectionString);
        //CSMPDK_3_0.CommonDLL ObjCmnDll = new CSMPDK_3_0.CommonDLL();
        public PopHierarchyServiceprovider(IDataBaseHelper dataBaseHelper) : base(dataBaseHelper)
        {

        }

        string StrQuery = "";

        //#endregion

        //public override int GetPOSId(PopHierarchy objPopHier)
        //{
        //    int PosId = 0;
        //    string StrQuerys = "SELECT COUNT(*) FROM KAC.UDF_UPPERPARENTIDS(" + objPopHier.LocationId + ")";
        //    PosId = Convert.ToInt32(ObjCmnDll.ExeScalar(DataBaseHelper.ConnectionString, StrQuerys, 0));
        //    return PosId;
        //}
        //public override IList<PopHierarchy> FillLabel(PopHierarchy objPopHier)
        //{
        //    List<PopHierarchy> list = new List<PopHierarchy>();
        //    string StrQuery = "SELECT NVCHLABEL FROM KAC.M_ADM_LEVEL WHERE INTLEVELID IN(SELECT * FROM KAC.UDF_UPPERPARENTIDS(" + objPopHier.LocationId + ")) ORDER BY INTPOSITION ASC";
        //    IDataReader reader = (IDataReader)this.ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, StrQuery);

        //    try
        //    {
        //        while (reader.Read())
        //        {
        //            PopHierarchy item = new PopHierarchy
        //            {
        //                LevelName = reader["NVCHLABEL"].ToString()
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return list;
        //}
        public IList<PopHierarchy> FillLocation(PopHierarchy objPopHier)
        {
            List<PopHierarchy> list = new List<PopHierarchy>();
            if (objPopHier.HierachyId == 0)
            {
                StrQuery = "SELECT A.intLevelDetailId,A.nvchLevelName from M_Adm_LevelDetails A,M_Adm_Level B where  A.intLevelId=B.intLevelId AND A.intParentId=0 And A.bitStatus=1 And B.bitStatus=1 order by A.nvchLevelName";
            }
            else if (objPopHier.HierachyId != 0)
            {
                StrQuery = "SELECT A.intLevelDetailId,A.nvchLevelName from M_Adm_LevelDetails A,M_Adm_Level B where  A.intLevelId=B.intLevelId And B.intHierarchyId=" + objPopHier.HierachyId + " AND A.intParentId=0  ";
            }
            else
            {
                StrQuery = "SELECT A.intLevelDetailId,A.nvchLevelName from M_Adm_LevelDetails A,M_Adm_Level B where  A.intLevelId=B.intLevelId AND A.intParentId=0 AND B.intHierarchyId=" + objPopHier.HierachyId + " And B.intPosition=1 And A.bitStatus=1 And B.bitStatus=1 order by A.nvchLevelName";
            }
            SqlDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString,System.Data.CommandType.Text, StrQuery);

            try
            {
                while (reader.Read())
                {
                    PopHierarchy item = new PopHierarchy
                    {
                        LevelID = reader["intLevelDetailId"].ToString(),
                        LevelName = reader["nvchLevelName"].ToString()
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
        //public IList<PopHierarchy> FillFirstHierchy1(int intCID, int HiracrcyId, int LID)
        //{
        //    List<PopHierarchy> list = new List<PopHierarchy>();
        //    StrQuery = "SELECT A.intLevelDetailId,A.nvchLevelName from KAC.M_Adm_LevelDetails A,KAC.M_Adm_Level B where  A.intLevelId=B.intLevelId And A.bitStatus=1 And B.bitStatus=1  AND A.intParentId=" + intCID + " And B.intHierarchyId=" + HiracrcyId + " and A.intLevelId=(select max(ID) from  UDF_UPPERPARENTIDS(" + LID.ToString() + ") where ID in(select top 2 ID FROM UDF_UPPERPARENTIDS(" + LID.ToString() + ") order by id asc)) order by A.nvchLevelName";
        //    IDataReader reader = (IDataReader)this.ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, StrQuery);

        //    try
        //    {
        //        while (reader.Read())
        //        {
        //            PopHierarchy item = new PopHierarchy
        //            {
        //                LevelID = reader["intLevelDetailId"].ToString(),
        //                LevelName = reader["nvchLevelName"].ToString()
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return list;
        //}
        public IList<PopHierarchy> FillFirstHierchy2(int Parent)
        {
            List<PopHierarchy> list = new List<PopHierarchy>();
            StrQuery = "SELECT A.intLevelDetailId,replace(A.nvchLevelName,'X+HIcwPJE/4=','&') as nvch_LevelName from M_Adm_LevelDetails A,M_Adm_Level B where  A.intLevelId=B.intLevelId And A.intParentId=" + Parent.ToString() + " AND A.bitStatus=1 And B.bitStatus=1  order by A.nvchLevelName asc";
             SqlDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString,System.Data.CommandType.Text,StrQuery);
            try
            {
                while (reader.Read())
                {
                    PopHierarchy item = new PopHierarchy
                    {
                        LevelID = reader["intLevelDetailId"].ToString(),
                        LevelName = reader["nvch_LevelName"].ToString()
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
        //public override IList<PopHierarchy> FillHierchy1(int intCID, int HiracrcyId)
        //{
        //    List<PopHierarchy> list = new List<PopHierarchy>();
        //    StrQuery = "SELECT A.intLevelDetailId, nvchLevelName from KAC.M_Adm_LevelDetails A,KAC.M_Adm_Level B where  A.intLevelId=B.intLevelId And A.bitStatus=1 And B.bitStatus=1  And B.intHierarchyId=" + HiracrcyId + " AND A.intParentId=" + intCID + " order by A.nvchLevelName";
        //    IDataReader reader = (IDataReader)this.ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, StrQuery);

        //    try
        //    {
        //        while (reader.Read())
        //        {
        //            PopHierarchy item = new PopHierarchy
        //            {
        //                LevelID = reader["intLevelDetailId"].ToString(),
        //                LevelName = reader["nvchLevelName"].ToString()
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return list;
        //}
        public  IList<PopHierarchy> FillHierchy2(int HiracrcyId,int Parent)
        {
            List<PopHierarchy> list = new List<PopHierarchy>();
            StrQuery = "SELECT A.intLevelDetailId,A.nvchLevelName from M_Adm_LevelDetails A, M_Adm_Level B where  A.intLevelId=B.intLevelId And A.bitStatus=1 And B.bitStatus=1 And B.intHierarchyId=" + HiracrcyId + " AND A.intParentId=" + Parent + " order by A.nvchLevelName";
            SqlDataReader reader = BUIDCO.Repository.AdminConsole.SqlHelper.SqlHelper.ExecuteReader(DataBaseHelper.ConnectionString,System.Data.CommandType.Text, StrQuery);

            try
            {
                while (reader.Read())
                {
                    PopHierarchy item = new PopHierarchy
                    {
                        LevelID = reader["intLevelDetailId"].ToString(),
                        LevelName = reader["nvchLevelName"].ToString()
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
        //public override IList<PopHierarchy> FillUser(int DetId)
        //{
        //    List<PopHierarchy> list = new List<PopHierarchy>();
        //    StrQuery = "select intUserId,vchFullName from KAC.M_POR_User where bitStatus=1 and intLevelDetailId=" + DetId + "";
        //    IDataReader reader = (IDataReader)this.ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, StrQuery);

        //    try
        //    {
        //        while (reader.Read())
        //        {
        //            PopHierarchy item = new PopHierarchy
        //            {
        //                UserID = reader["intUserId"].ToString(),
        //                UserName = reader["vchFullName"].ToString()
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return list;
        //}
        //public override string GetLevel(int Parent, int Levelid)
        //{
        //    string LevelName = "";
        //    string StrQuerys = "SELECT  nvchLevelName from KAC.M_Adm_LevelDetails where intParentId=" + Parent + " and bitStatus=1   and intLevelDetailId  =" + Levelid + "";
        //    LevelName = Convert.ToString(ObjCmnDll.ExeScalar(DataBaseHelper.ConnectionString, StrQuerys, 0));
        //    return LevelName;
        //}

        //public override IList<PopHierarchy> FillLevelFromParent(int Parent)
        //{
        //    List<PopHierarchy> list = new List<PopHierarchy>();
        //    StrQuery = "select intLevelDetailId from KAC.M_Adm_LevelDetails where  intParentId=" + Parent + "";
        //    IDataReader reader = (IDataReader)this.ObjCmnDll.ExeReader(DataBaseHelper.ConnectionString, StrQuery);

        //    try
        //    {
        //        while (reader.Read())
        //        {
        //            PopHierarchy item = new PopHierarchy
        //            {
        //                LevelID = reader["intLevelDetailId"].ToString(),
        //            };
        //            list.Add(item);
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw exception;
        //    }
        //    return list;
        //}

      
    }

}