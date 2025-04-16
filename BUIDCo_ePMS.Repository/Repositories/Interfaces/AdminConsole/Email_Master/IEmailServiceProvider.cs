using BUIDCO.Domain.AdminConsole.EmailMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCO.Repository.Contract.Contract.AdminConsole.Email_Master
{
    public interface IEmailServiceProvider
    {
        Task<int> AddEmail(EmailMaster em);
        Task<IEnumerable<BUIDCO.Domain.AdminConsole.EmailMaster.EmailMaster>> GetallEmail();
        Task<IEnumerable<BUIDCO.Domain.AdminConsole.EmailMaster.EmailMaster>> Getemailbyid(int configid);
        Task<int> UpdateEmail(EmailMaster em);
    }
}
