using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BUIDCO.Domain.AdminConsole.ButtonMaster;
using BUIDCO.Repository.Contract.Contract.AdminConsole.ButtonMaster;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Function_Master;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BUIDCO.Web.Areas.AdminConsole.Controllers
{
    [Area("AdminConsole")]
    public class ButtonMasterController : Controller
    {
        int intOut;
        public IFuncServiceProvider _functionService { get; }
        public IButtonMasterServiceProvider _ButtonMasterServiceProvider { get; }
        CreateButtonMaster Model = new CreateButtonMaster();
        public ButtonMasterController(IFuncServiceProvider functionService, IButtonMasterServiceProvider ButtonMasterServiceProvider)
        {
            _functionService = functionService;
            _ButtonMasterServiceProvider = ButtonMasterServiceProvider;
            //currentUserId = 1;
        }
        [HttpGet]
        public async Task<IActionResult>ButtonTab()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
               
                Model.FunctionList = (await _functionService.GetFunction()).FunctionList.ToList();
                Model.INTCREATEDBY = Convert.ToInt32(HttpContext.Session.GetString("UserId"));

             
                return View(Model);
            }
            else
            {
               return RedirectToAction("Logout", "Home");
            }
        }
        [HttpGet]
        public async Task<IActionResult> ButtonTabb()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {

                Model.FunctionList = (await _functionService.GetFunction()).FunctionList.ToList();
                Model.INTCREATEDBY = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                Model.ButtonModelList = (await _ButtonMasterServiceProvider.GetMaxId()).ViewButtonLinkDetails.ToList();
                Model.BMAxid = Model.ButtonModelList[0].BMAxid; //_gblLinkService.GetGlobalLinkMaxId();

                return View(Model);
            }
            else
            {
               return RedirectToAction("Logout", "Home");
            }
        }
        [HttpPost]
        public ActionResult ButtonTabb(IFormCollection Coll, CreateButtonMaster model, string Command)
        {
            if (Command == "Log")
            {
                //FileLogger fileLogger = new FileLogger();
                //string path = fileLogger.ShowLogFile();
                //ViewData["log"] = path;
                return View();
            }

            if (Command == "Submit")
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        model.ActionCode = "A";
                        model.FunctionList = _functionService.GetFunction().Result.FunctionList.ToList();
                        model.ButtonModelList = _ButtonMasterServiceProvider.GetMaxId().Result.ViewButtonLinkDetails.ToList();
                        model.BMAxid = model.ButtonModelList[0].BMAxid;
                        model.INTFUNCTIONID = Convert.ToInt32(Coll["INTFUNCTIONID"]);
                        //model.INTFUNCTIONID = Convert.ToInt32(Coll["INTFUNCTIONID"].ToString());
                        model.NVCHBUTTON = Coll["NVCHBUTTON"].ToString();
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
                        
                        model.INTCREATEDBY = Convert.ToInt32(HttpContext.Session.GetString("UserId"));//Convert.ToInt16(Session["UserId"]);
                        
                        intOut = _ButtonMasterServiceProvider.AddButtnmaster(model);
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
                return RedirectToAction("ButtonTabb");
            }

        }

        [HttpPost]
        public IActionResult ButtonTab(CreateButtonMaster objbutton)
        {
            try
            {

                var Result = _ButtonMasterServiceProvider.AddButtonmaster(objbutton);
                return RedirectToAction("ViewActiveButton", new { Status = "Record " + Result });

               

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<IActionResult>EditActiveButton(int id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                try
                {

                    Model.FunctionList = (await _functionService.GetFunction()).FunctionList.ToList();
                    var result = _ButtonMasterServiceProvider.GetButtonById(id).Result;
                    Model.INTBUTTONID = result.ToList()[0].INTBUTTONID;
                    Model.INTFUNCTIONID = result.ToList()[0].INTFUNCTIONID;
                    Model.NVCHBUTTON= result.ToList()[0].NVCHBUTTON;
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

        public ActionResult EditActiveButtonTabb(string id)
        {
            try
            {
                //id = (CommonFunction.Decrypt(id));
                CreateButtonMaster model = new CreateButtonMaster();
                model.ActionCode = "E";
                model.INTBUTTONID = Convert.ToInt32(id);
                model.FunctionList = _functionService.GetFunction().Result.FunctionList.ToList();
                IList<CreateButtonMaster> objButList = new List<CreateButtonMaster>();
                objButList = _ButtonMasterServiceProvider.GetAllbutton(model);
                foreach (var i in objButList)
                {
                    model.INTFUNCTIONID = i.INTFUNCTIONID;
                    model.NVCHBUTTON = i.NVCHBUTTON;
                    model.intSortNum = i.intSortNum;
                    model.VCHURL = i.VCHURL;
                    

                    ViewData["NVCHDESCRIPTION"] = i.NVCHDESCRIPTION;
                    //ViewData["NVCHDESCRIPTION"] = 500 - Convert.ToInt16(i.NVCHDESCRIPTION.Length);
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
        public ActionResult EditActiveButtonTabb(string id, IFormCollection Coll, string Command)
        {
            if (Command == "Update")
            {
                //id = (CommonFunction.Decrypt(id));
                Model.ActionCode = "U";
                Model.INTBUTTONID = Convert.ToInt32(id);
                Model.INTFUNCTIONID = Convert.ToInt32(Coll["INTFUNCTIONID"]);
                Model.FunctionList = _functionService.GetFunction().Result.FunctionList.ToList();
                Model.NVCHBUTTON = Coll["NVCHBUTTON"].ToString();
                Model.NVCHDESCRIPTION = Coll["NVCHDESCRIPTION"].ToString();
                Model.VCHURL = Coll["VCHURL"].ToString();
                //Model.intSortNum = Coll["intSortNum"].ToString();
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
                intOut = _ButtonMasterServiceProvider.EditButtonmaster(Model);
               
                if (intOut == 2)
                {
                   
                    TempData["funresult"] = intOut;
                    TempData.Keep("funresult");
                    ModelState.Clear(); 
                                       
                    return RedirectToAction("ViewActiveButton", new { Status = TempData["result"] });
                }
                else
                {
                    TempData["funresult1"] = intOut;
                    TempData.Keep("funresult1");
                    ModelState.Clear(); 
                    
                    return RedirectToAction("ViewActiveButton", new { Status = TempData["result1"] });
                }
                
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult>ViewActiveButton(string Status)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                try
                {
                    ButtonMasterModel model = new ButtonMasterModel();
                    model.ButtonList = (await _ButtonMasterServiceProvider.GetAllButtonview(1)).ButtonList.ToList();
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
        public async Task<IActionResult>ViewInActiveButton(string Status)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                try
                {
                    ButtonMasterModel model = new ButtonMasterModel();
                    model.ButtonList = (await _ButtonMasterServiceProvider.GetAllButtonview(0)).ButtonList.ToList();
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
                ButtonMasterModel vmodel = new ButtonMasterModel();
                string INTBUTTONID = string.Join(",", chkbox);
                var Result = String.Empty;
                vmodel.INTUPDATEDBY = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                foreach (string Id in chkbox)
                {
                    vmodel.INTBUTTONID =Convert.ToInt32( Id);
                    Result = _ButtonMasterServiceProvider.MarkInactive(vmodel);

                }
                return RedirectToAction("ViewActiveButton", new { Status = "Record " + Result });

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

                ButtonMasterModel vmodel = new ButtonMasterModel();
                vmodel.INTUPDATEDBY = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                var Result = String.Empty;
                foreach (string Id in chkbox)
                {
                    vmodel.INTBUTTONID = Convert.ToInt32(Id);
                    Result = _ButtonMasterServiceProvider.MarkActive(vmodel);
                }
                return RedirectToAction("ViewActiveButton", new { Status = "Record " + Result });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        [HttpPost]
        public IActionResult EditButton(CreateButtonMaster objlevel)
        {
            try
            {

                var Result = _ButtonMasterServiceProvider.EditButton(objlevel);
                return RedirectToAction("ViewActiveButton", new { Status = "Record " + Result });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion






        public IActionResult Index()
        {
            return View();
        }


    }
}
