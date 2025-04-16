using BUIDCO.Domain.AdminConsole.ButtonMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Repository.Contract.Contract.AdminConsole.ButtonMaster
{
    public interface IButtonMasterServiceProvider
    {
        string AddButtonmaster(CreateButtonMaster objbutton);


        int AddButtnmaster(CreateButtonMaster objbutton);

        int EditButtonmaster(CreateButtonMaster objMaster);

        IList<CreateButtonMaster> GetAllbutton(CreateButtonMaster objButtonMaster);
        Task<IEnumerable<CreateButtonMaster>> GetButtonById(int id);
        string EditButton(CreateButtonMaster objbutton);
        Task<ButtonMasterModel> GetAllButtonview(int id);
        string MarkActive(ButtonMasterModel objmodel);
        string MarkInactive(ButtonMasterModel objmodel);
        Task<ButtonMasterModel> GetButton();

        Task<ViewButtonLink> GetMaxId();


    }
}
