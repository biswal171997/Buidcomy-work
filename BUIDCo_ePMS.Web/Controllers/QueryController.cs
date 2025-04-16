using Microsoft.AspNetCore.Mvc;

namespace BUIDCo_ePMS.Web.Controllers
{
    public class QueryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult QueryManagement()
        {
            return View();
        }
    }
}
