using  Microsoft.Extensions.DependencyInjection;
using  Microsoft.Extensions.Configuration;
using BUIDCo_ePMS.Repository.Factory;
using BUIDCo_ePMS.Repository.Repository;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using CodeGen.Repository.Repositories.Interfaces;
using CodeGen.Repository.Repository;
using BUIDCo_ePMS.Repository.Repositories.Repository;
using BUIDCo_ePMS.Core.Services;
using BUIDCo_ePMS.Repository.Repositories.Repository.CreateProject;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.CreateProject;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TenderBidder;
using BUIDCo_ePMS.Repository.Repositories.Repository.TenderBidder;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TechnicalBid;
using BUIDCo_ePMS.Repository.Repositories.Repository.TechnicalBid;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TAapproval;
using BUIDCo_ePMS.Repository.Repositories.Repository.TAapproval;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TakeAction;
using BUIDCo_ePMS.Repository.Repositories.Repository.TakeAction;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.FinancialBid;
using BUIDCo_ePMS.Repository.Repositories.Repository.FinancialBid;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.AdministartiveApproval;
using BUIDCo_ePMS.Repository.Repositories.Repository.AdministartiveApproval;
namespace BUIDCo_ePMS.Repository.Container
{
	public static class CustomContainer
	{
		public static void AddCustomContainer(this IServiceCollection services, IConfiguration configuration)
		{
			IDb_BUIDCo_PMSConnectionFactory Db_BUIDCo_PMSconnectionFactory=new Db_BUIDCo_PMSConnectionFactory(configuration.GetConnectionString("DBconnectionDb_BUIDCo_PMS"));
			services.AddSingleton<IDb_BUIDCo_PMSConnectionFactory> (Db_BUIDCo_PMSconnectionFactory);

			services.AddScoped<IMasterRepository, MasterRepository>();
			services.AddScoped<ICodeGenLoginRepository, CodeGenLoginRepository>();
			services.AddScoped<ISendSMSRepository, SendSMSRepository>();
            services.AddScoped<ICommonFunctionRepository, CommonFunctionRepository>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
			services.AddScoped<IProjectTender, ProjectTender>();
			services.AddScoped<IPreBidQueries, PreBidQueries>();
            services.AddScoped<ICreateProject, CreateProject>();
            services.AddScoped<ITAapproval, TAapprovalRepository>();
            services.AddScoped<IJwtService, JwtService>();
			services.AddScoped<ITenderBidder, TenderBidder>();
            services.AddScoped<ISearchRepository, SearchRepository>();
            services.AddScoped<ITakeAction, TakeActionRepository>();
            services.AddScoped<ITechnicalBid, TechnicalBid>();
            services.AddScoped<IFinancialBid, FinancialBid>();
			services.AddScoped<IAssignWorkRepository, AssignWorkRepository>();
            services.AddScoped<IAdministartiveApproval, AdministartiveApproval>();
            //Write code here

        }
	}
}
