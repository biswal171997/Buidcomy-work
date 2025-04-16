using BUIDCo_ePMS.Model.Entities.CreateProject;
using BUIDCo_ePMS.Model.Entities.TakeAction;
using BUIDCo_ePMS.Model.M_Assembly_Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Repository.Repositories.Interfaces.TakeAction
{
  
    public interface ITakeAction
    {
        Task <TakeActionDetails> GetActionPageDetails(TakeActionSearch obj);
        Task<int> SaveTakeAction(TakeActionSave obj);
    }
}
