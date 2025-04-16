using Microsoft.AspNetCore.Mvc;

namespace BUIDCo_ePMS.Web.Controllers
{
    public class AdminConsoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
