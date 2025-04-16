using Microsoft.AspNetCore.Mvc;

namespace BUIDCo_ePMS.Web.Controllers
{
    public class MilestoneController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MilestoneView()
        {
            return View();
        }

        public IActionResult MilestoneDetails()
        {
            return View();
        }
    }
}
