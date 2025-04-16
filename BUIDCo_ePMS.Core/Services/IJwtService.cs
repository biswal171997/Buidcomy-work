using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Core.Services
{
    public interface IJwtService
    {
        string GenerateToken(string username,string rolid,string userid,string leveldetailsid);
       
    }
}
