using BUIDCO.Domain.AdminConsole.Login;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BUIDCO.Repository.Contract.Contract.AdminConsole.Login
{
    public interface ILoginServiceProvider
    {
        #region Login
        Task<IList<BUIDCO.Domain.AdminConsole.Login.Login>> LoginUser(string ActionCode, string strUserName, string strPassword, int intLocID, string ipAddress);

        Task<string> GetUserAccess(int intUserId);
        #endregion

        #region IP Tracking
        int IpTracking(IPTrack objiptrack);
        #endregion

        #region Login Customize
        string GetLoginLogo();
        string GetLoginHeader();
        string GetLoginFooter();
        #endregion
    }
}