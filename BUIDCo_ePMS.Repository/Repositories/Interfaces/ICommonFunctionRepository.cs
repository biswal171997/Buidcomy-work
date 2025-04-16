using BUIDCo_ePMS.Model.Entities.Common;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Model.M_Financial_Year;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces
{
    public interface ICommonFunctionRepository
    {
        Task<List<FinancialYear>> GetFinancialYear();
        Task<List<ProjectCategory>> GetCategory();
        Task<List<ProjectSubcategory>> GetSubcategory(int obj);
        Task<List<LocationLevel>> GetDistrict();
        Task<List<LocationLevel>> GetBlock(int obj);
        Task<List<LocationLevel>> GetWard(int obj);
        Task<List<Director>> GetDirector();
        Task<List<Consultant>> GetConsultant();
        Task<List<ClientMaster>> GetClient();
        Task<List<ProjectTypeMaster>> GetProjectType();
    }
}
