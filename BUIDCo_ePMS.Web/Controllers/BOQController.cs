using Microsoft.AspNetCore.Mvc;

namespace BUIDCo_ePMS.Web.Controllers
{
    public class BOQController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BoqComponentView()
        {
            return View();
        }

        public IActionResult BoqComponentDetails()
        {
            return View();
        }

        public IActionResult ParticularsView()
        {
            return View();
        }
        public IActionResult ParticularsDetails()
        {
            return View();
        }
    }
}
