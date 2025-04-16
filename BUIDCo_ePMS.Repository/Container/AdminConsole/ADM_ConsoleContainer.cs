using BUIDCO.Repository.Contract.Factory;
using BUIDCO.Repository.Factory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUIDCO.Repository.Contract.Contract.AdminConsole;
using BUIDCO.Repository.AdminConsole;
using BUIDCO.Repository.Contract.Contract.AdminConsole.User_Management;
using BUIDCO.Repository.AdminConsole.User_Management;
using BUIDCO.Repository.AdminConsole.SqlHelper;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Function_Master;
using BUIDCO.Repository.AdminConsole.Function_Master;
using BUIDCO.Repository.Contract.Contract.AdminConsole.HierarchyMaster;
using BUIDCO.Repository.AdminConsole.HierarchyMaster;
using BUIDCO.Repository.Contract.Contract.AdminConsole.LevelMaster;
using BUIDCO.Repository.AdminConsole.LevelMaster;
using BUIDCO.Repository.Contract.Contract.AdminConsole.LevelDetailsMaster;
using BUIDCO.Repository.AdminConsole.LevelDetailsMaster;
using BUIDCO.Repository.Contract.Contract.AdminConsole.DesignationMaster;
using BUIDCO.Repository.AdminConsole.DesignationMaster;
using BUIDCO.Repository.Contract.Contract.AdminConsole.ProjectLink;
using AdminConsoleCore.Persistence.ProjectLink;
using BUIDCO.Repository.Contract.Contract.AdminConsole.ButtonMaster;
using BUIDCO.Repository.AdminConsole.ButtonMaster;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Global_Link;
using BUIDCO.Repository.AdminConsole.Global_Link;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Primary_Link;
using BUIDCO.Repository.AdminConsole.Primary_Link;
using BUIDCO.Repository.Contract.Contract.AdminConsole.SetPermission;
using BUIDCO.Repository.AdminConsole.SetPermission;
using BUIDCO.Repository.Contract.Contract.AdminConsole.TabMaster;
using BUIDCO.Repository.AdminConsole.TabMaster;
using AdminConsoleCore.Persistence.User_Management;

using BUIDCO.Repository.AdminConsole.Email_Master;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Email_Master;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.Processflow;
using BUIDCo_ePMS.Repository.Repositories.Repository.Processflow;

namespace BUIDCO.Web.DIContainer
{
    public static class ADM_ConsoleContainer
    {
        public static void AddADM_ConsoleContainer(this IServiceCollection services, IConfiguration configuration)
        {
            // Register ConnectionFactory
            services.AddSingleton<IConnectionFactory>(_ =>
                new ConnectionFactory(configuration.GetConnectionString("Buidco_AdminConsole_Connectionstring")));

            // Register DataBaseHelper
            services.AddSingleton<IDataBaseHelper>(_ =>
                new DataBaseHelper(configuration.GetConnectionString("Buidco_AdminConsole_Connectionstring")));

            #region Admin Console Dependencies
            services.AddSingleton<IAdminConsoleRepository, AdminConsoleRepository>();
            services.AddSingleton<IUserServiceProvider, UserServiceProviderOracle>();
            services.AddSingleton<IFuncServiceProvider, FuncServiceProviderOracle>();
            services.AddSingleton<IHierarchyServiceProvider, HierarchyServiceProviderOracle>();
            services.AddSingleton<ILevelServiceProvider, LevelServiceProviderOracle>();
            services.AddSingleton<ILevelDetailsServiceProvider, LeveDetailslServiceProviderOracle>();
            services.AddSingleton<IDesignationServiceProvider, DesignationServiceProviderOracle>();
            services.AddSingleton<IProjectLinkServiceProvider, ProjectLinkServiceProviderOracle>();
            services.AddSingleton<IButtonMasterServiceProvider, ButtonMasterServiceProvider>();
            services.AddSingleton<IGblLinkServiceProvider, GblLinkServiceProviderOracle>();
            services.AddSingleton<IPriLinkServiceProvider, PriLinkServiceProviderOracle>();
            services.AddSingleton<ISetPermissionServiceProvider, SetPermissionServiceProviderOracle>();
            services.AddSingleton<ITabMasterServiceProvider, TabMasterServiceProvider>();
            services.AddSingleton<IEmailServiceProvider, EmailMasterServiceProvider>();
            services.AddSingleton<IProcessflowRepository, ProcessflowRepository>();
            #endregion
        }

    }
}
