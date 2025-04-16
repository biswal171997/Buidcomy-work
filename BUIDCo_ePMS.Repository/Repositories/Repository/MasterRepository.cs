using BUIDCo_ePMS.Model.categoryIdAdd;
using System.Collections.Generic;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.BaseRepository;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Repository;


using Dapper;
using System.Data;
using BUIDCo_ePMS.Model.M_Assembly_Master;
using BUIDCo_ePMS.Model.M_Assembly_Tagging;
using BUIDCo_ePMS.Model.M_Client_Master;
using BUIDCo_ePMS.Model.M_Constituency_Master;
using BUIDCo_ePMS.Model.M_Financial_Year;
using BUIDCo_ePMS.Model.M_MileStone_Master;
using BUIDCo_ePMS.Model.M_Module_Master;
using BUIDCo_ePMS.Model.M_Project_Part;
using BUIDCo_ePMS.Model.M_SubMileStone_Master;
using BUIDCo_ePMS.Model.M_Unit_Master;
using BUIDCo_ePMS.Model.Entities.Master;
using System.Reflection;
namespace BUIDCo_ePMS.Repository.Repository
{
	public class MasterRepository : Db_BUIDCo_PMSRepositoryBase, IMasterRepository
	{
		public MasterRepository(IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSConnectionFactory) : base(Db_BUIDCo_PMSConnectionFactory)
		{

		}
		public async Task<int> Insert_M_Application_Status_Master(ApplicationStatus TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.statusId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_createdBy", TBL.createdBy);
					p.Add("@P_statusId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_updatedBy", TBL.updatedBy);
					p.Add("@P_statusId", TBL.statusId);
				}
				p.Add("@P_statusName", TBL.statusName);

				//p.Add("@P_createdOn",TBL.createdOn);

				//p.Add("@P_updatedOn",TBL.updatedOn);
				//p.Add("@P_deletedFlag",TBL.deletedFlag);
				var results = await Connection.ExecuteAsync("USP_M_Application_Status_Master ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<int> Delete_M_Application_Status_Master(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "D");
				p.Add("@P_statusId", Id);

				var results = await Connection.ExecuteAsync("USP_M_Application_Status_Master ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<ApplicationStatus> GetM_Application_Status_MasterById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "E");
				p.Add("@P_statusId", Id);

				var results = await Connection.QueryAsync<ApplicationStatus>("USP_M_Application_Status_Master ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<ApplicationStatus>> Getall_M_Application_Status_Master(ApplicationStatus TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "V");
				var results = await Connection.QueryAsync<ApplicationStatus>("USP_M_Application_Status_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<ApplicationStatus>> Search_M_Application_Status_Master(ApplicationStatus TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_statusId", TBL.statusId);

				p.Add("@P_statusName", TBL.statusName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<ApplicationStatus>("USP_M_Application_Status_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_Assembly_Master(M_Assembly_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.assemblyId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_assemblyId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_assemblyId", TBL.assemblyId);
				}
				p.Add("@P_Leveldetailid", TBL.Leveldetailid);
				p.Add("@P_assemblyName", TBL.assemblyName);
				p.Add("@P_assemblyDesc", TBL.assemblyDesc);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.ExecuteAsync("USP_M_Assembly_Master ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<int> Delete_M_Assembly_Master(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "D");
				p.Add("@P_assemblyId", Id);

				var results = await Connection.ExecuteAsync("USP_M_Assembly_Master ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<M_Assembly_Master> GetM_Assembly_MasterById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "E");
				p.Add("@P_assemblyId", Id);

				var results = await Connection.QueryAsync<M_Assembly_Master>("USP_M_Assembly_Master ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<M_Assembly_Master>> Getall_M_Assembly_Master(M_Assembly_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "V");
				var results = await Connection.QueryAsync<M_Assembly_Master>("USP_M_Assembly_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<M_Assembly_Master>> Search_M_Assembly_Master(M_Assembly_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_assemblyId", TBL.assemblyId);

				p.Add("@P_Leveldetailid", TBL.Leveldetailid);
				p.Add("@P_assemblyName", TBL.assemblyName);
				p.Add("@P_assemblyDesc", TBL.assemblyDesc);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<M_Assembly_Master>("USP_M_Assembly_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_Assembly_Tagging(M_Assembly_Tagging TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.taggingId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_taggingId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_taggingId", TBL.taggingId);
				}
				p.Add("@P_districtId", TBL.districtId);
				p.Add("@P_assemblyId", TBL.assemblyId);
				p.Add("@P_blockId", TBL.blockId);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.ExecuteAsync("USP_M_Assembly_Tagging ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<int> Delete_M_Assembly_Tagging(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "D");
				p.Add("@P_taggingId", Id);

				var results = await Connection.ExecuteAsync("USP_M_Assembly_Tagging ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<M_Assembly_Tagging> GetM_Assembly_TaggingById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "E");
				p.Add("@P_taggingId", Id);

				var results = await Connection.QueryAsync<M_Assembly_Tagging>("USP_M_Assembly_Tagging ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<M_Assembly_Tagging>> Getall_M_Assembly_Tagging(M_Assembly_Tagging TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "V");
				var results = await Connection.QueryAsync<M_Assembly_Tagging>("USP_M_Assembly_Tagging ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<M_Assembly_Tagging>> Search_M_Assembly_Tagging(M_Assembly_Tagging TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_taggingId", TBL.taggingId);

				p.Add("@P_districtId", TBL.districtId);
				p.Add("@P_assemblyId", TBL.assemblyId);
				p.Add("@P_blockId", TBL.blockId);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<M_Assembly_Tagging>("USP_M_Assembly_Tagging ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_Client_Master(M_Client_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.clientId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_clientId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_clientId", TBL.clientId);
				}
				p.Add("@P_clientId", TBL.clientId);
				p.Add("@P_clientName", TBL.clientName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.ExecuteAsync("USP_M_Client_Master ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<int> Delete_M_Client_Master(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "D");
				p.Add("@P_clientId", Id);

				var results = await Connection.ExecuteAsync("USP_M_Client_Master ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<M_Client_Master> GetM_Client_MasterById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "E");
				p.Add("@P_clientId", Id);

				var results = await Connection.QueryAsync<M_Client_Master>("USP_M_Client_Master ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<M_Client_Master>> Getall_M_Client_Master(M_Client_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "V");
				var results = await Connection.QueryAsync<M_Client_Master>("USP_M_Client_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<M_Client_Master>> Search_M_Client_Master(M_Client_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_clientId", TBL.clientId);

				p.Add("@P_clientId", TBL.clientId);
				p.Add("@P_clientName", TBL.clientName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<M_Client_Master>("USP_M_Client_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_Constituency_Master(M_Constituency_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.constituencyId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_constituencyId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_constituencyId", TBL.constituencyId);
				}
				p.Add("@P_districtId", TBL.districtId);
				p.Add("@P_constituencyName", TBL.constituencyName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.ExecuteAsync("USP_M_Constituency_Master ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<int> Delete_M_Constituency_Master(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "D");
				p.Add("@P_constituencyId", Id);

				var results = await Connection.ExecuteAsync("USP_M_Constituency_Master ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<M_Constituency_Master> GetM_Constituency_MasterById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "E");
				p.Add("@P_constituencyId", Id);

				var results = await Connection.QueryAsync<M_Constituency_Master>("USP_M_Constituency_Master ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<M_Constituency_Master>> Getall_M_Constituency_Master(M_Constituency_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "V");
				var results = await Connection.QueryAsync<M_Constituency_Master>("USP_M_Constituency_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<M_Constituency_Master>> Search_M_Constituency_Master(M_Constituency_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_constituencyId", TBL.constituencyId);

				p.Add("@P_districtId", TBL.districtId);
				p.Add("@P_constituencyName", TBL.constituencyName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<M_Constituency_Master>("USP_M_Constituency_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_Financial_Year(FinancialYear TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.fyId == 0)
				{
					p.Add("@P_Action", "A");
					p.Add("@P_fyId", 0);
				}
				else
				{
					p.Add("@P_Action", "B");
					p.Add("@P_fyId", TBL.fyId);
				}
                p.Add("@P_fyIds", null);
                p.Add("@P_fyName", TBL.fyName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_Financial_Year ", p, commandType: CommandType.StoredProcedure);
				string result = p.Get<string>("@P_MSG_OUT");
				return Convert.ToInt32(result);
			}
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<int> Delete_M_Financial_Year(string Id)
		{
			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "C");
				p.Add("@P_fyId", null);
                p.Add("@P_fyIds", Id);
                p.Add("@P_fyName", null);
                p.Add("@P_createdBy", null);
                p.Add("@P_deletedFlag", null);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_Financial_Year ", p, commandType: CommandType.StoredProcedure);
				string result = p.Get<string>("@P_MSG_OUT");
				return Convert.ToInt32(result);
			}
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<FinancialYear> GetM_Financial_YearById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "C");
				p.Add("@P_fyId", Id);
                p.Add("@P_fyName", null);
                p.Add("@P_createdBy", null);
                var results = await Connection.QueryAsync<FinancialYear>("USP_V_Financial_Year ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<FinancialYear>> Getall_M_Financial_Year(FinancialYear TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "A");
                p.Add("@P_fyId", null);
                p.Add("@P_fyName", null);
                p.Add("@P_createdBy", null);
                var results = await Connection.QueryAsync<FinancialYear>("USP_V_Financial_Year ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<FinancialYear>> Search_M_Financial_Year(FinancialYear TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "B");
				p.Add("@P_fyId", TBL.fyId);

				p.Add("@P_fyId", TBL.fyId);
				p.Add("@P_fyName", TBL.fyName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<FinancialYear>("USP_M_Financial_Year ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_MileStone_Master(M_MileStone_Master TBL)
		{
			try
			{
				var p = new DynamicParameters();
				if (TBL.milestoneId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_milestoneId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_milestoneId", TBL.milestoneId);
				}
				p.Add("@P_categoryId", TBL.categoryId);
				p.Add("@P_milestoneName", TBL.milestoneName);
				p.Add("@P_MileStoneDesc", TBL.MileStoneDesc);
				p.Add("@P_Str_MilestoneId", null);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_MSG_OUT",dbType:DbType.String,direction:ParameterDirection.Output,size:100);
				await Connection.ExecuteAsync("USP_M_MileStone_Master ", p, commandType: CommandType.StoredProcedure);
				string result = p.Get<string>("@P_MSG_OUT");
				return Convert.ToInt32(result);
			}
			catch (Exception EX)
			{
				throw EX;
			}
           
        }
		public async Task<string> Delete_M_MileStone_Master(string Id)
		{
			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "C");
				p.Add("@P_Str_MilestoneId", Id);
                p.Add("@P_categoryId", 0);
                p.Add("@P_milestoneId",0);
                p.Add("@P_milestoneName",null);
                p.Add("@P_MileStoneDesc",null);
                p.Add("@P_createdBy",0);
                p.Add("@P_updatedBy",1);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                 await Connection.ExecuteAsync("USP_M_MileStone_Master ", p, commandType: CommandType.StoredProcedure);
				string result = p.Get<string>("@P_MSG_OUT");
				return result;
			}
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<M_MileStone_Master> GetM_MileStone_MasterById(int Id)
		{
			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "B");
				p.Add("@P_milestoneId", Id);

				var results = await Connection.QueryAsync<M_MileStone_Master>("USP_V_MileStone_Master ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<M_MileStone_Master>> Getall_M_MileStone_Master(M_MileStone_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "A");
				p.Add("@P_milestoneId", TBL.milestoneId);
				var results = await Connection.QueryAsync<M_MileStone_Master>("USP_V_MileStone_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<M_MileStone_Master>> Search_M_MileStone_Master(M_MileStone_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_milestoneId", TBL.milestoneId);

				p.Add("@P_milestoneName", TBL.milestoneName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<M_MileStone_Master>("USP_M_MileStone_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_Module_Master(M_Module_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.moduleId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_moduleId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_moduleId", TBL.moduleId);
				}
				p.Add("@P_moduleName", TBL.moduleName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.ExecuteAsync("USP_M_Module_Master ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<int> Delete_M_Module_Master(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "D");
				p.Add("@P_moduleId", Id);

				var results = await Connection.ExecuteAsync("USP_M_Module_Master ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<M_Module_Master> GetM_Module_MasterById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "E");
				p.Add("@P_moduleId", Id);

				var results = await Connection.QueryAsync<M_Module_Master>("USP_M_Module_Master ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<M_Module_Master>> Getall_M_Module_Master(M_Module_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "V");
				var results = await Connection.QueryAsync<M_Module_Master>("USP_M_Module_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<M_Module_Master>> Search_M_Module_Master(M_Module_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_moduleId", TBL.moduleId);

				p.Add("@P_moduleName", TBL.moduleName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<M_Module_Master>("USP_M_Module_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_Project_Category_Master(ProjectCategory TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.categoryId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_categoryId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_categoryId", TBL.categoryId);
				}
                p.Add("@P_categoryIds", TBL.categoryIds);
                p.Add("@P_categoryName", TBL.categoryName);
				p.Add("@P_categoryDesc", TBL.categoryDesc);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_updatedBy", TBL.createdBy);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_Project_Category_Master ", p, commandType: CommandType.StoredProcedure);
                string results = p.Get<string>("@P_MSG_OUT");
				return Convert.ToInt32(results);

            }
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<int> Delete_M_Project_Category_Master(string Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "D");
				p.Add("@P_categoryId", null);
                p.Add("@P_categoryIds", Id);
                p.Add("@P_categoryName", null);
                p.Add("@P_categoryDesc", null);
                p.Add("@P_createdBy", null);
                p.Add("@P_updatedBy", null);
                p.Add("@P_deletedFlag", null);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_Project_Category_Master ", p, commandType: CommandType.StoredProcedure);
                string results = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(results);
            }
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<ProjectCategory> GetM_Project_Category_MasterById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "E");
				p.Add("@P_categoryId", Id);
                p.Add("@P_categoryName", null);
                p.Add("@P_categoryDesc", null);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                var results = await Connection.QueryAsync<ProjectCategory>("USP_V_Project_Category_Master ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<ProjectCategory>> Getall_M_Project_Category_Master(ProjectCategory TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "V");
                p.Add("@P_categoryId", null);
                p.Add("@P_categoryName", null);
                p.Add("@P_categoryDesc", null);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                var results = await Connection.QueryAsync<ProjectCategory>("USP_V_Project_Category_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<ProjectCategory>> Search_M_Project_Category_Master(ProjectCategory TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_categoryId", TBL.categoryId);
				p.Add("@P_categoryName", TBL.categoryName);
				p.Add("@P_categoryDesc", TBL.categoryDesc);
				var results = await Connection.QueryAsync<ProjectCategory>("USP_V_Project_Category_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_Project_Part(M_Project_Part TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.partId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_partId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_partId", TBL.partId);
				}
				p.Add("@P_partName", TBL.partName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.ExecuteAsync("USP_M_Project_Part ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<int> Delete_M_Project_Part(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "D");
				p.Add("@P_partId", Id);

				var results = await Connection.ExecuteAsync("USP_M_Project_Part ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<M_Project_Part> GetM_Project_PartById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "E");
				p.Add("@P_partId", Id);

				var results = await Connection.QueryAsync<M_Project_Part>("USP_M_Project_Part ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<M_Project_Part>> Getall_M_Project_Part(M_Project_Part TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "V");
				var results = await Connection.QueryAsync<M_Project_Part>("USP_M_Project_Part ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<M_Project_Part>> Search_M_Project_Part(M_Project_Part TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_partId", TBL.partId);

				p.Add("@P_partName", TBL.partName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<M_Project_Part>("USP_M_Project_Part ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_Project_Subcategory_Master(ProjectSubcategory TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.subCategoryId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_subCategoryId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_subCategoryId", TBL.subCategoryId);
				}
				p.Add("@P_categoryId", TBL.categoryId);
				p.Add("@P_subCategoryName", TBL.subCategoryName);
				p.Add("@P_subCategoryDesc", TBL.subCategoryDesc);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_Str_SubCategoryId", 0);
				//p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                //p.Add("@P_updatedOn", TBL.updatedOn);
                //p.Add("@P_deletedFlag", TBL.deletedFlag);
                await Connection.ExecuteAsync("USP_M_Project_Subcategory_Master ", p, commandType: CommandType.StoredProcedure);
                string results = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(results);
            }
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<string> Delete_M_Project_Subcategory_Master(string Id)
		{

			try
			{

				var p = new DynamicParameters();
				p.Add("@P_Action", "D");
				p.Add("@P_Str_SubCategoryId", Id);
				p.Add("@P_categoryId", 0);
				p.Add("@P_subCategoryId", 0);
                p.Add("@P_subCategoryName", null);
                p.Add("@P_subCategoryDesc", null);
                p.Add("@P_createdBy", 1);
				p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                 await Connection.ExecuteAsync("USP_M_Project_Subcategory_Master ", p, commandType: CommandType.StoredProcedure);
                string results = p.Get<string>("@P_MSG_OUT");
				return results;


            }
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<ProjectSubcategory> GetM_Project_Subcategory_MasterById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "E");
				p.Add("@P_subCategoryId", Id);
				p.Add("@P_categoryId", null);
                p.Add("@P_subCategoryName", null);
                p.Add("@P_subCategoryDesc", null);
                p.Add("@P_createdBy", null);
                var results = await Connection.QueryAsync<ProjectSubcategory>("USP_V_Project_Subcategory_Master ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<ProjectSubcategory>> Getall_M_Project_Subcategory_Master(ProjectSubcategory TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "V");
				p.Add("@P_subCategoryId", null);
                p.Add("@P_categoryId", null);
                p.Add("@P_subCategoryName", null);
                p.Add("@P_subCategoryDesc", null);
                p.Add("@P_createdBy", null);
                p.Add("@P_createdOn", null);
                p.Add("@P_updatedBy", null);
                p.Add("@P_updatedOn", null);
				p.Add("@P_deletedFlag", null);
                var results = await Connection.QueryAsync<ProjectSubcategory>("USP_V_Project_Subcategory_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<ProjectSubcategory>> Search_M_Project_Subcategory_Master(ProjectSubcategory TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_subCategoryId", TBL.subCategoryId);

				p.Add("@P_categoryId", TBL.categoryId);
				p.Add("@P_subCategoryName", TBL.subCategoryName);
				p.Add("@P_subCategoryDesc", TBL.subCategoryDesc);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<ProjectSubcategory>("USP_M_Project_Subcategory_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_Project_Type_Master(ProjectTypeMaster TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.typeId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_typeId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_typeId", TBL.typeId);
				}
                p.Add("@P_typeIds", null);
                p.Add("@P_projectType", TBL.projectType);
				p.Add("@P_typeDesc", TBL.typeDesc);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                 await Connection.ExecuteAsync("USP_M_Project_Type_Master ", p, commandType: CommandType.StoredProcedure);
				string results = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(results);
			}
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<int> Delete_M_Project_Type_Master(string Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "D");
				p.Add("@P_typeId", null);
                p.Add("@P_typeIds", Id);
                p.Add("@P_projectType", null);
                p.Add("@P_typeDesc", null);
                p.Add("@P_createdBy", null);
                p.Add("@P_deletedFlag", null);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_Project_Type_Master ", p, commandType: CommandType.StoredProcedure);
                string results = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(results);
            }
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<ProjectTypeMaster> GetM_Project_Type_MasterById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "E");
				p.Add("@P_typeId", Id);
                p.Add("@P_projectType", null);
                p.Add("@P_typeDesc", null);
                var results = await Connection.QueryAsync<ProjectTypeMaster>("USP_V_Project_Type_Master ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<ProjectTypeMaster>> Getall_M_Project_Type_Master(ProjectTypeMaster TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "V");
                p.Add("@P_typeId", null);
                p.Add("@P_projectType", null);
                p.Add("@P_typeDesc", null);
                var results = await Connection.QueryAsync<ProjectTypeMaster>("USP_V_Project_Type_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<ProjectTypeMaster>> Search_M_Project_Type_Master(ProjectTypeMaster TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
                p.Add("@P_typeId", null);
                p.Add("@P_projectType", null);
                p.Add("@P_typeDesc", null);
                var results = await Connection.QueryAsync<ProjectTypeMaster>("USP_V_Project_Type_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_Scheme_Master(Scheme TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.schemeId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_schemeId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_schemeId", TBL.schemeId);
				}
				p.Add("@P_SchemeName", TBL.SchemeName);
				p.Add("@P_schemeDesc", TBL.schemeDesc);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.ExecuteAsync("USP_M_Scheme_Master ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<int> Delete_M_Scheme_Master(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "D");
				p.Add("@P_schemeId", Id);

				var results = await Connection.ExecuteAsync("USP_M_Scheme_Master ", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<Scheme> GetM_Scheme_MasterById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "E");
				p.Add("@P_schemeId", Id);

				var results = await Connection.QueryAsync<Scheme>("USP_M_Scheme_Master ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<Scheme>> Getall_M_Scheme_Master(Scheme TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "V");
				var results = await Connection.QueryAsync<Scheme>("USP_M_Scheme_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<Scheme>> Search_M_Scheme_Master(Scheme TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_schemeId", TBL.schemeId);

				p.Add("@P_SchemeName", TBL.SchemeName);
				p.Add("@P_schemeDesc", TBL.schemeDesc);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<Scheme>("USP_M_Scheme_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_SubMileStone_Master(M_SubMileStone_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.submilestoneId == 0)
				{
					p.Add("@P_Action", "A");
					p.Add("@P_submilestoneId", 0);
				}
				else
				{
					p.Add("@P_Action", "B");
					p.Add("@P_submilestoneId", TBL.submilestoneId);
				}
				p.Add("@P_milestoneId", TBL.milestoneId);
				p.Add("@P_categoryId", TBL.categoryId);
				p.Add("@P_submilestoneName", TBL.submilestoneName);
				p.Add("@P_SubMilestoneDesc", TBL.SubMilestoneDesc);
				p.Add("@P_Str_submilestoneId",null);
				p.Add("@P_createdBy", TBL.createdBy);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                //p.Add("@P_createdOn", TBL.createdOn);
                //p.Add("@P_updatedBy", TBL.updatedBy);
                //p.Add("@P_updatedOn", TBL.updatedOn);
                //p.Add("@P_deletedFlag", TBL.deletedFlag);
                await Connection.ExecuteAsync("USP_M_SubMileStone_Master ", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);
            }
			catch (Exception EX)
			{
				throw EX;
			}
		}

		public async Task<string> Delete_M_SubMileStone_Master(string Id)
		{
			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "C");
				p.Add("@P_Str_submilestoneId", Id);
				p.Add("@P_submilestoneId", 0);
                p.Add("@P_milestoneId", 0);
				p.Add("@P_categoryId", 0);
                p.Add("@P_submilestoneName", null);
				p.Add("@P_SubMilestoneDesc", null);
                p.Add("@P_createdBy", 1);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_SubMileStone_Master", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("@P_MSG_OUT");
				return result;
			   // return Convert.ToInt32(result);
            }
			catch (Exception EX)
			{ 
				throw EX;
			}

		}
		public async Task<M_SubMileStone_Master> GetM_SubMileStone_MasterById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "B");
				p.Add("@P_submilestoneId", Id);
				var results = await Connection.QueryAsync<M_SubMileStone_Master>("USP_V_SubMileStone_Master ", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<M_SubMileStone_Master>> Getall_M_SubMileStone_Master(M_SubMileStone_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "A");
				p.Add("@P_submilestoneId",0);
				var results = await Connection.QueryAsync<M_SubMileStone_Master>("USP_V_SubMileStone_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<M_SubMileStone_Master>> Search_M_SubMileStone_Master(M_SubMileStone_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_submilestoneId", TBL.submilestoneId);

				p.Add("@P_milestoneId", TBL.milestoneId);
				p.Add("@P_submilestoneName", TBL.submilestoneName);
				p.Add("@P_createdBy", TBL.createdBy);
				//p.Add("@P_createdOn", TBL.createdOn);
				//p.Add("@P_updatedBy", TBL.updatedBy);
				//p.Add("@P_updatedOn", TBL.updatedOn);
				//p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<M_SubMileStone_Master>("USP_M_SubMileStone_Master ", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}

		public async Task<int> Insert_M_Unit_Master(M_Unit_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				if (TBL.unitId == 0)
				{
					p.Add("@P_Action", "I");
					p.Add("@P_unitId", 0);
				}
				else
				{
					p.Add("@P_Action", "U");
					p.Add("@P_unitId", TBL.unitId);
				}
				p.Add("@P_unitName", TBL.unitName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.ExecuteAsync("USP_M_Unit_Master", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<int> Delete_M_Unit_Master(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "D");
				p.Add("@P_unitId", Id);

				var results = await Connection.ExecuteAsync("USP_M_Unit_Master", p, commandType: CommandType.StoredProcedure);
				return results;
			}
			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<M_Unit_Master> GetM_Unit_MasterById(int Id)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "E");
				p.Add("@P_unitId", Id);

				var results = await Connection.QueryAsync<M_Unit_Master>("USP_M_Unit_Master", p, commandType: CommandType.StoredProcedure);
				return results.FirstOrDefault();
			}

			catch (Exception EX)
			{
				throw EX;
			}
		}
		public async Task<List<M_Unit_Master>> Getall_M_Unit_Master(M_Unit_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "V");
				var results = await Connection.QueryAsync<M_Unit_Master>("USP_M_Unit_Master", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}


			catch (Exception EX)
			{
				throw EX;
			}

		}
		public async Task<List<M_Unit_Master>> Search_M_Unit_Master(M_Unit_Master TBL)
		{

			try
			{
				var p = new DynamicParameters();
				p.Add("@P_Action", "S");
				p.Add("@P_unitId", TBL.unitId);

				p.Add("@P_unitName", TBL.unitName);
				p.Add("@P_createdBy", TBL.createdBy);
				p.Add("@P_createdOn", TBL.createdOn);
				p.Add("@P_updatedBy", TBL.updatedBy);
				p.Add("@P_updatedOn", TBL.updatedOn);
				p.Add("@P_deletedFlag", TBL.deletedFlag);
				var results = await Connection.QueryAsync<M_Unit_Master>("USP_M_Unit_Master", p, commandType: CommandType.StoredProcedure);
				return results.ToList();
			}

			catch (Exception EX)
			{
				throw EX;
			}

		}


		public async Task<List<categoryId_M_Project_Subcategory_Master_DBBindAdd>> BinD_categoryIdAdd()
		{
			var p = new DynamicParameters();
			p.Add("@P_Action", "V");
			var results = await Connection.QueryAsync<categoryId_M_Project_Subcategory_Master_DBBindAdd>("USP_M_Project_Category_Master", p, commandType: CommandType.StoredProcedure);
			return results.ToList();

		}

        public async Task<List<ProjectSubcategory>> GetCategory(ProjectSubcategory TBL)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "E");
				p.Add("@P_INT_ID", null);
                var results = await Connection.QueryAsync<ProjectSubcategory>("USP_Common_Provider ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<M_MileStone_Master>> GetMilestone(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "G");
                p.Add("@P_INT_ID", Id);
                var results = await Connection.QueryAsync<M_MileStone_Master>("USP_Common_Provider ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }
        }


        public async Task<int> AddScheme(Scheme TBL)
        {

            try
            {
                var p = new DynamicParameters();
                if (TBL.schemeId > 0)
                {
                    p.Add("@P_Action", "B");
                    p.Add("@P_schemeId", TBL.schemeId);

                }
                else
                {
                    p.Add("@P_Action", "A");
                    p.Add("@P_schemeId", 0);
                }
                p.Add("@P_SchemeName", TBL.SchemeName);
                p.Add("@P_schemeDesc", TBL.schemeDesc);
                p.Add("@P_createdBy", TBL.createdBy);
                p.Add("@P_Str_schemeId", null);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_Scheme_Master ", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<string> DeleteScheme(string Id)
        {

            try
            {

                var p = new DynamicParameters();
                p.Add("@P_Action", "D");
                p.Add("@P_Str_schemeId", Id);
                p.Add("@P_schemeId", 0);
                // p.Add("@P_subCategoryId", 0);
                p.Add("@P_SchemeName", null);
                p.Add("@P_schemeDesc", null);
                p.Add("@P_createdBy", 1);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_Scheme_Master ", p, commandType: CommandType.StoredProcedure);
                string results = p.Get<string>("@P_MSG_OUT");
                return results;
                //return Convert.ToInt32(results);
            }
            catch (Exception EX)
            {
                throw EX;
            }

        }
        public async Task<Scheme> GetSchemeDetailsByID(int Id)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "B");
                p.Add("@P_schemeId", Id);
                p.Add("@P_SchemeName", null);
                p.Add("@P_schemeDesc", null);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                var results = await Connection.QueryAsync<Scheme>("USP_V_Scheme_Master ", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }

            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<Scheme>> Get_Scheme_Master(Scheme TBL)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "A");
                p.Add("@P_schemeId", 0);

                var results = await Connection.QueryAsync<Scheme>("USP_V_Scheme_Master ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }
        public async Task<List<Scheme>> SearchProjectHead(Scheme TBL)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "S");
                p.Add("@P_schemeId", TBL.schemeId);
                p.Add("@P_SchemeName", TBL.SchemeName);
                p.Add("@P_schemeDesc", TBL.schemeDesc);
                var results = await Connection.QueryAsync<Scheme>("USP_M_Scheme_Master ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }

            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<int> AddClient(ClientMaster TBL)
        {

            try
            {
                var p = new DynamicParameters();
                if (TBL.ClientId > 0)
                {
                    p.Add("@P_Action", "B");
                    p.Add("@P_clientId", TBL.ClientId);

                }
                else

                {
                    p.Add("@P_Action", "A");
                    p.Add("@P_clientId", 0);
                }
                p.Add("@P_clientName", TBL.ClientName);
                p.Add("@P_clientDesc", TBL.clientDesc);
                p.Add("@P_createdBy", TBL.createdBy);
                p.Add("@P_Str_clientId", null);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_Client_Master ", p, commandType: CommandType.StoredProcedure);

                string result = p.Get<string>("@P_MSG_OUT");
                return Convert.ToInt32(result);

               
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<string> DeleteClient(string Id)
        {

            try
            {

                var p = new DynamicParameters();
                p.Add("@P_Action", "C");
                p.Add("@P_Str_clientId", Id);
                p.Add("@P_clientId", 0);
                // p.Add("@P_subCategoryId", 0);
                p.Add("@P_clientName", null);
                p.Add("@P_clientDesc", null);
                p.Add("@P_createdBy", 1);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                await Connection.ExecuteAsync("USP_M_Client_Master ", p, commandType: CommandType.StoredProcedure);
                string results = p.Get<string>("@P_MSG_OUT");
                return results;
            }
            catch (Exception EX)
            {
                throw EX;
            }

        }
        public async Task<ClientMaster> GetClientByID(int Id)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "B");
                p.Add("@P_clientId", Id);
                p.Add("@P_clientName", null);
                p.Add("@P_clientDesc", null);
                p.Add("@P_MSG_OUT", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                var results = await Connection.QueryAsync<ClientMaster>("USP_V_Client_Master ", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();
            }

            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<List<ClientMaster>> Get_Client(ClientMaster TBL)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "A");
                p.Add("@P_clientId", 0);

                var results = await Connection.QueryAsync<ClientMaster>("USP_V_Client_Master ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }


            catch (Exception EX)
            {
                throw EX;
            }

        }


        public async Task<List<ClientMaster>> SearchProposal(ClientMaster TBL)
        {

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "S");
                p.Add("@P_clientId", TBL.ClientId);
                p.Add("@P_clientName", TBL.ClientName);
                p.Add("@P_clientDesc", TBL.clientDesc);
                var results = await Connection.QueryAsync<ClientMaster>("USP_M_Scheme_Master ", p, commandType: CommandType.StoredProcedure);
                return results.ToList();
            }

            catch (Exception EX)
            {
                throw EX;
            }
        }


        #region Document


        public async Task<int> AddDocument(AddDocument TBL)
        {
            try
            {
                var p = new DynamicParameters();

                // Action determines whether it's create or update
                if (TBL.Id > 0)
                {
                    p.Add("P_Action", "UPDATE");  // 'UPDATE' action for existing record
                    p.Add("P_Id", TBL.Id);
                    p.Add("Id", TBL.Id);// Pass Id for update
                }
                else
                {
                    p.Add("@P_Action", "CREATE");
                    p.Add("P_Id", 0);
                    p.Add("Id", 0);
                    // 0 indicates new record
                }

                p.Add("P_Title", TBL.Title);
                p.Add("P_remarks","");
                p.Add("P_ImagePath", TBL.ImagePath);
                p.Add("P_FormName", TBL.Plink);
                p.Add("P_PendingWithUser", 0);
                p.Add("P_ImageDescription", TBL.ImageDescription);
                p.Add("P_Status", TBL.Status);
                p.Add("P_ActiveFrom", TBL.ActiveFrom);
                p.Add("P_ActiveTo", TBL.ActiveTo);
                p.Add("P_CreatedBy", 0);  // Assuming 0 for created by user (to be modified as needed)
                p.Add("P_UpdatedBy", 0);  // Assuming 0 for updated by user (to be modified as needed)

                p.Add("P_ResultMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                await Connection.ExecuteAsync("sp_Banner_CRUD", p, commandType: CommandType.StoredProcedure);

                string result = p.Get<string>("P_ResultMessage");
                return Convert.ToInt32(result);  // Assuming the result message is an integer (status code)
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<List<AddDocument>> Get_Document(AddDocument TBL)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Action", "GETALL");
                p.Add("P_Id", 0);
                p.Add("Id", 0);
                p.Add("P_Title", null);
                p.Add("P_ImagePath", null);
                p.Add("P_Plink", null);
                p.Add("P_FormName", "");
                p.Add("P_PendingWithUser", TBL.PendingWithUser);
                p.Add("P_remarks", "");
                p.Add("P_ImageDescription", null);
                p.Add("P_Status", null);
                p.Add("P_ActiveFrom", null);
                p.Add("P_ActiveTo", null);
                p.Add("P_CreatedBy", 0);
                p.Add("P_UpdatedBy", 0);
              
                p.Add("P_ResultMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                var results = await Connection.QueryAsync<AddDocument>("sp_Banner_CRUD", p, commandType: CommandType.StoredProcedure);
                return results.ToList();  // Return a list of banners
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<string> ApproveDocument(AddDocument bn)//int id, int Userid)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Action", "ApproveBanner");
                p.Add("P_Id", bn.Id);
                p.Add("Id", 0);
               
                p.Add("P_Title", null);
                p.Add("P_ImagePath", null);
                p.Add("P_FormName", bn.Plink);
                p.Add("P_PendingWithUser", bn.PendingWithUser);
                p.Add("P_remarks", bn.remarks);
                p.Add("P_ImageDescription", null);
                p.Add("P_Status", null);
                p.Add("P_ActiveFrom", null);
                p.Add("P_ActiveTo", null);
                p.Add("P_CreatedBy", 0);
                p.Add("P_UpdatedBy", bn.PendingWithUser);
                p.Add("P_ResultMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);


                await Connection.ExecuteAsync("sp_Banner_CRUD", p, commandType: CommandType.StoredProcedure);
                string result = p.Get<string>("P_ResultMessage");
                return result;  // Return result message (confirmation of deletion)
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<string> DeleteDocument(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "DELETE");  // 'DELETE' action for deleting record
                p.Add("@Id", Id);              // Pass Id to delete
                p.Add("@UpdatedBy", 1);        // Assuming 1 for the user who performs the deletion

                p.Add("@ResultMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);

                await Connection.ExecuteAsync("sp_Banner_CRUD", p, commandType: CommandType.StoredProcedure);

                string result = p.Get<string>("@ResultMessage");
                return result;  // Return result message (confirmation of deletion)
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }
        public async Task<AddDocument> GetBannerByID(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "GETBYID");  // 'GETBYID' action for fetching specific banner by Id
                p.Add("@Id", Id);                // Pass the Id to retrieve the record
                p.Add("@ResultMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                
                var results = await Connection.QueryAsync<AddDocument>("sp_Banner_CRUD", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();  // Return the first result (should be only one)
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        public async Task<AddDocument> GetDocumentByID(int Id)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Action", "GETBYID");  // 'GETBYID' action for fetching specific banner by Id
                p.Add("@Id", Id);                // Pass the Id to retrieve the record
                p.Add("@ResultMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 200);
                var results = await Connection.QueryAsync<AddDocument>("sp_Banner_CRUD", p, commandType: CommandType.StoredProcedure);
                return results.FirstOrDefault();  // Return the first result (should be only one)
            }
            catch (Exception EX)
            {
                throw EX;
            }
        }

        #endregion
    }
}