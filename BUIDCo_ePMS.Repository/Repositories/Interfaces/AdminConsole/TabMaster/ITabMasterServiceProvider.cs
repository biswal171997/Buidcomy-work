using BUIDCO.Domain.AdminConsole.TabMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Repository.Contract.Contract.AdminConsole.TabMaster
{
    public interface ITabMasterServiceProvider
    {
        string AddTabmaster(CreateTabMaster objbutton);

        int Addtabbmaster(CreateTabMaster objtab);

        int Edittabmaster(CreateTabMaster objMaster);

        IList<CreateTabMaster>GetAllTab(CreateTabMaster objtab);
        Task<IEnumerable<CreateTabMaster>> GetTabById(int id);
        string EditButton(CreateTabMaster objbutton);
        Task<TabMasterModel> GetAllTabview(int id);
        string MarkActive(TabMasterModel objmodel);
        string MarkInactive(TabMasterModel objmodel);
        Task<ViewTabLink> GetMaxId();
    }
}
