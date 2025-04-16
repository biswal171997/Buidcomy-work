using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUIDCO.Domain.AdminConsole.TabMaster;
using BUIDCO.Repository.Contract.Contract.AdminConsole.ButtonMaster;
using BUIDCO.Repository.Contract.Contract.AdminConsole.TabMaster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BUIDCO.Web.Areas.AdminConsole.Controllers
{
    [Area("AdminConsole")]
    public class TabMasterController : Controller
    {
        int intOut;
        public IButtonMasterServiceProvider _ButtonService { get; }
        public ITabMasterServiceProvider _TabMasterServiceProvider { get; }
        CreateTabMaster Model = new CreateTabMaster();
        public TabMasterController(IButtonMasterServiceProvider ButtonService, ITabMasterServiceProvider TabMasterServiceProvider)
        {
            _ButtonService = ButtonService;
            _TabMasterServiceProvider = TabMasterServiceProvider;
            
        }
        [HttpGet]
        public async Task<IActionResult> AddTab()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {

                Model.ButtonList = (await _ButtonService.GetButton()).ButtonList.ToList();
                Model.INTCREATEDBY = Convert.ToInt32(HttpContext.Session.GetString("UserId"));


                return View(Model);
            }
            else
            {
               return RedirectToAction("Logout", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> AddTabb()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {

                Model.ButtonList = (await _ButtonService.GetButton()).ButtonList.ToList();
                Model.TabModelList = (await _TabMasterServiceProvider.GetMaxId()).ViewTabLinkDetails.ToList();
                Model.TMAxid = Model.TabModelList[0].TMAxid;
                Model.INTCREATEDBY = Convert.ToInt32(HttpContext.Session.GetString("UserId"));


                return View(Model);
            }
            else
            {
               return RedirectToAction("Logout", "Home");
            }
        }
        [HttpPost]
        public ActionResult AddTabb(IFormCollection Coll, CreateTabMaster model, string Command)
        {
            if (Command == "Log")
            {
               
                return View();
            }

            if (Command == "Submit")
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        model.ActionCode = "A";
                        model.ButtonList = _ButtonService.GetButton().Result.ButtonList.ToList();
                        model.TabModelList = _TabMasterServiceProvider.GetMaxId().Result.ViewTabLinkDetails.ToList();
                        model.TMAxid = model.TabModelList[0].TMAxid;
                        model.INTBUTTONID = Convert.ToInt32(Coll["INTBUTTONID"]);
                        
                        model.NVCHTAB = Coll["NVCHTAB"].ToString();
                        model.NVCHDESCRIPTION = Coll["NVCHDESCRIPTION"].ToString();
                        model.VCHURL = Coll["VCHURL"].ToString();
                        model.intSortNum = Coll["intSortNum"].ToString();
                        if (Coll["CheckBoxAdd"].ToString() == "true,false")
                            model.FAdd = "Add";
                        else
                            model.FAdd = "N";
                        if (Coll["CheckBoxView"].ToString() == "true,false")
                            model.FView = "View";
                        else
                            model.FView = "N";
                        if (Coll["CheckBoxManage"].ToString() == "true,false")
                            model.FManage = "Manage";
                        else
                            model.FManage = "N";

                        model.INTCREATEDBY = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

                        intOut = _TabMasterServiceProvider.Addtabbmaster(model);
                        ViewData["result"] = intOut;
                        ModelState.Clear();
                        return View(model);
                    }
                    else
                    {
                        return View();
                    }
                }
                catch (Exception)
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction("AddTabb");
            }

        }
        public ActionResult EditActiveTabb(string id)
        {
            try
            {
                
                CreateTabMaster model = new CreateTabMaster();
                model.ActionCode = "E";
                model.INTTABID = Convert.ToInt32(id);
                model.ButtonList = _ButtonService.GetButton().Result.ButtonList.ToList();
                IList<CreateTabMaster> objtabList = new List<CreateTabMaster>();
                objtabList = _TabMasterServiceProvider.GetAllTab(model);
                foreach (var i in objtabList)
                {
                    
                    model.INTBUTTONID = i.INTBUTTONID;
                    model.NVCHTAB = i.NVCHTAB;
                    model.intSortNum = i.intSortNum;
                    model.VCHURL = i.VCHURL;


                    ViewData["NVCHDESCRIPTION"] = i.NVCHDESCRIPTION;
                    
                    if (i.FAdd == "Add")
                        ViewData["FAdd"] = true;
                    else
                        ViewData["FAdd"] = false;
                    if (i.FView == "View")
                        ViewData["FView"] = true;
                    else
                        ViewData["FView"] = false;
                    if (i.FManage == "Manage")
                        ViewData["FManage"] = true;
                    else
                        ViewData["FManage"] = false;

                }
                return View(model);

            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditActiveTabb(string id, IFormCollection Coll, string Command)
        {
            if (Command == "Update")
            {
                
                Model.ActionCode = "U";
                Model.INTTABID = Convert.ToInt32(id);
                Model.INTBUTTONID = Convert.ToInt32(Coll["INTBUTTONID"]);
                Model.ButtonList = _ButtonService.GetButton().Result.ButtonList.ToList();
                Model.NVCHTAB = Coll["NVCHTAB"].ToString();
                Model.NVCHDESCRIPTION = Coll["NVCHDESCRIPTION"].ToString();
                Model.VCHURL = Coll["VCHURL"].ToString();
               // Model.intSortNum = Coll["intSortNum"].ToString();
                Model.NVCHDESCRIPTION = Coll["NVCHDESCRIPTION"].ToString();
                if (Coll["CheckBoxAdd"].ToString() == "true,false")
                    Model.FAdd = "Add";
                else
                    Model.FAdd = "N";
                if (Coll["CheckBoxView"].ToString() == "true,false")
                    Model.FView = "View";
                else
                    Model.FView = "N";
                if (Coll["CheckBoxManage"].ToString() == "true,false")
                    Model.FManage = "Manage";
                else
                    Model.FManage = "N";

                Model.INTCREATEDBY = Convert.ToInt32(HttpContext.Session.GetString("UserId"));// Convert.ToInt16(Session["UserId"]);
                intOut = _TabMasterServiceProvider.Edittabmaster(Model);

                if (intOut == 2)
                {

                    TempData["funresult"] = intOut;
                    TempData.Keep("funresult");
                    ModelState.Clear();

                    return RedirectToAction("ViewActiveTab", new { Status = TempData["result"] });
                }
                else
                {
                    TempData["funresult1"] = intOut;
                    TempData.Keep("funresult1");
                    ModelState.Clear();

                    return RedirectToAction("ViewActiveTab", new { Status = TempData["result1"] });
                }

            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public IActionResult ButtonTab(CreateTabMaster objbutton)
        {
            try
            {
                var Result = _TabMasterServiceProvider.AddTabmaster(objbutton);
                return RedirectToAction("ViewActiveTab", new { Status = "Record " + Result });



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpGet]

        public async Task<IActionResult> ViewActiveTab(string Status)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                try
                {
                    TabMasterModel model = new TabMasterModel();
                    model.TabList = (await _TabMasterServiceProvider.GetAllTabview(1)).TabList.ToList();
                    TempData["CommandStatus"] = Status;
                    return View(model);

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
               return RedirectToAction("Logout", "Home");
            }



        }
        [HttpGet]
        public async Task<IActionResult>ViewInActiveTab(string Status)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                try
                {
                    TabMasterModel model = new TabMasterModel();
                    model.TabList = (await _TabMasterServiceProvider.GetAllTabview(0)).TabList.ToList();
                    TempData["CommandStatus"] = Status;
                    return View(model);

                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            else
            {
               return RedirectToAction("Logout", "Home");
            }



        }


        #region Mark As Inactive

        [HttpPost]
        public IActionResult MarkAsInactive(string[] chkbox)
        {
            try
            {
                TabMasterModel vmodel = new TabMasterModel();
                string INTTABID = string.Join(",", chkbox);
                var Result = String.Empty;
                vmodel.INTUPDATEDBY = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                foreach (string Id in chkbox)
                {
                    vmodel.INTTABID = Convert.ToInt32(Id);

                    Result = _TabMasterServiceProvider.MarkInactive(vmodel);
                }
                return RedirectToAction("ViewActiveTab", new { Status = "Record " + Result });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Mark As Active


        [HttpPost]
        public IActionResult MarkAsActive(string[] chkbox)
        {
            try
            {

                TabMasterModel vmodel = new TabMasterModel();
                vmodel.INTUPDATEDBY = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                var Result = String.Empty;
                foreach (string Id in chkbox)
                {
                    vmodel.INTTABID = Convert.ToInt32(Id);
                    Result = _TabMasterServiceProvider.MarkActive(vmodel);
                }
                return RedirectToAction("ViewActiveTab", new { Status = "Record " + Result });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IActionResult>EditActiveTab(int id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                try
                {
                    Model.ButtonList = (await _ButtonService.GetButton()).ButtonList.ToList();
                    var result = _TabMasterServiceProvider.GetTabById(id).Result;
                    Model.INTTABID = result.ToList()[0].INTTABID;
                    Model.INTBUTTONID = result.ToList()[0].INTBUTTONID;
                    Model.NVCHTAB = result.ToList()[0].NVCHTAB;
                    Model.NVCHDESCRIPTION = result.ToList()[0].NVCHDESCRIPTION;
                    Model.VCHURL = result.ToList()[0].VCHURL;
                    Model.intSortNum = result.ToList()[0].intSortNum;
                    Model.INTUPDATEDBY = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                    return View(Model);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
               return RedirectToAction("Logout", "Home");
            }
        }
        [HttpPost]
        public IActionResult EditButton(CreateTabMaster objlevel)
        {
            try
            {

                var Result = _TabMasterServiceProvider.EditButton(objlevel);
                return RedirectToAction("ViewActiveTab", new { Status = "Record " + Result });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion






        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
