using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Model.M_SubMileStone_Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces
{
    public interface IProjectTender
    {
        Task<List<Projects>> GetProject(string VCH_PRO);
        Task<Projects> GetProjectDetailsById(int PId);
        Task<int> SaveProjectTender(ProjectTenderEF TBL);
        Task<List<ViewProjectTenderEF>> GetProjectTenderDetails(ViewProjectTenderEF model);
        Task<ViewProjectTenderEF> Edit_GetTenderDetailsById(int Id);
        Task<int> DeleteProjectTender(int Id);
        Task<List<UserMasterModelEF>> GetUserName(UserMasterModelEF model);
        Task<int> SaveProjectTenderCorrigendum(ProjectTenderCorrigendumEF model);
       
        Task<List<VewProjectTenderCorrigendumEF>> ViewProjectTenderCorrigendum(int INT_ID);
        Task<List<ViewCorrigendumAddendumDetailsEF>> GetCorrigendumAddendumDetails(int INT_ID);
        Task<int> DeleteCorrigeduma_Addedum(int Id);
        Task<VewProjectTenderCorrigendumEF> EditCorrigendumAddendum(int Id);
    }
}
