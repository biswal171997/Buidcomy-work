using BUIDCo_ePMS.Model.categoryIdAdd;
using System.Collections.Generic;


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
namespace BUIDCo_ePMS.Repository.Repositories.Interfaces
{
  public interface IMasterRepository
  {
  	 
        Task<int> Insert_M_Application_Status_Master(ApplicationStatus TBL);
        Task<int> Delete_M_Application_Status_Master(int Id);
        Task<ApplicationStatus> GetM_Application_Status_MasterById(int Id);
        Task<List<ApplicationStatus>> Search_M_Application_Status_Master(ApplicationStatus TBL);
        Task<List<ApplicationStatus>> Getall_M_Application_Status_Master(ApplicationStatus TBL);
	 
        Task<int> Insert_M_Assembly_Master(M_Assembly_Master TBL);
        Task<int> Delete_M_Assembly_Master(int Id);
        Task<M_Assembly_Master> GetM_Assembly_MasterById(int Id);
        Task<List<M_Assembly_Master>> Search_M_Assembly_Master(M_Assembly_Master TBL);
        Task<List<M_Assembly_Master>> Getall_M_Assembly_Master(M_Assembly_Master TBL);
	 
        Task<int> Insert_M_Assembly_Tagging(M_Assembly_Tagging TBL);
        Task<int> Delete_M_Assembly_Tagging(int Id);
        Task<M_Assembly_Tagging> GetM_Assembly_TaggingById(int Id);
        Task<List<M_Assembly_Tagging>> Search_M_Assembly_Tagging(M_Assembly_Tagging TBL);
        Task<List<M_Assembly_Tagging>> Getall_M_Assembly_Tagging(M_Assembly_Tagging TBL);
	 
        Task<int> Insert_M_Client_Master(M_Client_Master TBL);
        Task<int> Delete_M_Client_Master(int Id);
        Task<M_Client_Master> GetM_Client_MasterById(int Id);
        Task<List<M_Client_Master>> Search_M_Client_Master(M_Client_Master TBL);
        Task<List<M_Client_Master>> Getall_M_Client_Master(M_Client_Master TBL);
	 
        Task<int> Insert_M_Constituency_Master(M_Constituency_Master TBL);
        Task<int> Delete_M_Constituency_Master(int Id);
        Task<M_Constituency_Master> GetM_Constituency_MasterById(int Id);
        Task<List<M_Constituency_Master>> Search_M_Constituency_Master(M_Constituency_Master TBL);
        Task<List<M_Constituency_Master>> Getall_M_Constituency_Master(M_Constituency_Master TBL);
	 
        Task<int> Insert_M_Financial_Year(FinancialYear TBL);
        Task<int> Delete_M_Financial_Year(string Id);
        Task<FinancialYear> GetM_Financial_YearById(int Id);
        Task<List<FinancialYear>> Search_M_Financial_Year(FinancialYear TBL);
        Task<List<FinancialYear>> Getall_M_Financial_Year(FinancialYear TBL);
	 
        Task<int> Insert_M_MileStone_Master(M_MileStone_Master TBL);
        Task<string> Delete_M_MileStone_Master(string Id);
        Task<M_MileStone_Master> GetM_MileStone_MasterById(int Id);
        Task<List<M_MileStone_Master>> Search_M_MileStone_Master(M_MileStone_Master TBL);
        Task<List<M_MileStone_Master>> Getall_M_MileStone_Master(M_MileStone_Master TBL);
	 
        Task<int> Insert_M_Module_Master(M_Module_Master TBL);
        Task<int> Delete_M_Module_Master(int Id);
        Task<M_Module_Master> GetM_Module_MasterById(int Id);
        Task<List<M_Module_Master>> Search_M_Module_Master(M_Module_Master TBL);
        Task<List<M_Module_Master>> Getall_M_Module_Master(M_Module_Master TBL);
	 
        Task<int> Insert_M_Project_Category_Master(ProjectCategory TBL);
        Task<int> Delete_M_Project_Category_Master(string Id);
        Task<ProjectCategory> GetM_Project_Category_MasterById(int Id);
        Task<List<ProjectCategory>> Search_M_Project_Category_Master(ProjectCategory TBL);
        Task<List<ProjectCategory>> Getall_M_Project_Category_Master(ProjectCategory TBL);
	 
        Task<int> Insert_M_Project_Part(M_Project_Part TBL);
        Task<int> Delete_M_Project_Part(int Id);
        Task<M_Project_Part> GetM_Project_PartById(int Id);
        Task<List<M_Project_Part>> Search_M_Project_Part(M_Project_Part TBL);
        Task<List<M_Project_Part>> Getall_M_Project_Part(M_Project_Part TBL);
	 
        Task<int> Insert_M_Project_Subcategory_Master(ProjectSubcategory TBL);
        Task<List<ProjectSubcategory>> GetCategory(ProjectSubcategory TBL);
        Task<string> Delete_M_Project_Subcategory_Master(string Id);
        Task<ProjectSubcategory> GetM_Project_Subcategory_MasterById(int Id);
        Task<List<ProjectSubcategory>> Search_M_Project_Subcategory_Master(ProjectSubcategory TBL);
        Task<List<ProjectSubcategory>> Getall_M_Project_Subcategory_Master(ProjectSubcategory TBL);
	 
        Task<int> Insert_M_Project_Type_Master(ProjectTypeMaster TBL);
        Task<int> Delete_M_Project_Type_Master(string Id);
        Task<ProjectTypeMaster> GetM_Project_Type_MasterById(int Id);
        Task<List<ProjectTypeMaster>> Search_M_Project_Type_Master(ProjectTypeMaster TBL);
        Task<List<ProjectTypeMaster>> Getall_M_Project_Type_Master(ProjectTypeMaster TBL);
	 
        Task<int> Insert_M_Scheme_Master(Scheme TBL);
        Task<int> Delete_M_Scheme_Master(int Id);
        Task<Scheme> GetM_Scheme_MasterById(int Id);
        Task<List<Scheme>> Search_M_Scheme_Master(Scheme TBL);
        Task<List<Scheme>> Getall_M_Scheme_Master(Scheme TBL);
	 
        Task<int> Insert_M_SubMileStone_Master(M_SubMileStone_Master TBL);
        Task<List<M_MileStone_Master>> GetMilestone(int Id);
        Task<string> Delete_M_SubMileStone_Master(string Id);
        Task<M_SubMileStone_Master> GetM_SubMileStone_MasterById(int Id);
        Task<List<M_SubMileStone_Master>> Search_M_SubMileStone_Master(M_SubMileStone_Master TBL);
        Task<List<M_SubMileStone_Master>> Getall_M_SubMileStone_Master(M_SubMileStone_Master TBL);
	 
        Task<int> Insert_M_Unit_Master(M_Unit_Master TBL);
        Task<int> Delete_M_Unit_Master(int Id);
        Task<M_Unit_Master> GetM_Unit_MasterById(int Id);
        Task<List<M_Unit_Master>> Search_M_Unit_Master(M_Unit_Master TBL);
        Task<List<M_Unit_Master>> Getall_M_Unit_Master(M_Unit_Master TBL);

	Task<List<categoryId_M_Project_Subcategory_Master_DBBindAdd>> BinD_categoryIdAdd();


        Task<int> AddScheme(Scheme TBL);
        Task<string> DeleteScheme(string Id);
        //Task<ProjectHeadMaster> GetProjectHeadMaster(int Id);
        Task<Scheme> GetSchemeDetailsByID(int Id);

        Task<List<Scheme>> SearchProjectHead(Scheme TBL);
        Task<List<Scheme>> Get_Scheme_Master(Scheme TBL);


        Task<int> AddClient(ClientMaster TBL);
        Task<string> DeleteClient(string Id);
        //Task<ProjectHeadMaster> GetProjectHeadMaster(int Id);
        Task<ClientMaster> GetClientByID(int Id);

        Task<List<ClientMaster>> SearchProposal(ClientMaster TBL);
        Task<List<ClientMaster>> Get_Client(ClientMaster TBL);


        #region Document
        Task<int> AddDocument(AddDocument TBL);
        Task<string> DeleteDocument(int Id);
        Task<string> ApproveDocument(AddDocument bn);
        Task<AddDocument> GetDocumentByID(int Id);
        Task<List<AddDocument>> Get_Document(AddDocument TBL);

        #endregion
    }
}