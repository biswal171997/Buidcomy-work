using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUIDCo_ePMS.Model.Responses
{
    public class AjaxResponse
    {
        public int Status { get; set; } = 0;
        public string? StatusMessage { get; set; }
        public string? Data { get; set; }
    }
}
