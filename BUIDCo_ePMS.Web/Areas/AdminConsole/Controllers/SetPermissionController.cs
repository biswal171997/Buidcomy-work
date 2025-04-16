using BUIDCO.Domain.AdminConsole.Set_Permission;
using BUIDCO.Domain.AdminConsole.User_Management;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Primary_Link;
using BUIDCO.Repository.Contract.Contract.AdminConsole.ProjectLink;
using BUIDCO.Repository.Contract.Contract.AdminConsole.SetPermission;
using BUIDCO.Repository.Contract.Contract.AdminConsole.User_Management;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BUIDCO.Web.Areas.AdminConsole.Controllers
{
    [Area("AdminConsole")]
    public class SetPermissionController : Controller
    {
        private readonly ISetPermissionServiceProvider _setpermissionservice;
        private readonly IUserServiceProvider _userService;
        private readonly IProjectLinkServiceProvider _projectLinkService;
        public IPriLinkServiceProvider _priLinkServiceProvider { get; }

        SetPermissionModel model = new SetPermissionModel();
        public IActionResult Index()
        {

            return View();
        }
        public SetPermissionController(ISetPermissionServiceProvider setPermissionProvider, IUserServiceProvider userService, IProjectLinkServiceProvider projectLinkService, IPriLinkServiceProvider priLinkServiceProvider)
        {
            _setpermissionservice = setPermissionProvider;
            _userService = userService;
            _projectLinkService = projectLinkService;
            _priLinkServiceProvider = priLinkServiceProvider;

        }
       
        public async Task<IActionResult> SetPermission()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {

                try
                {
                    ViewBag.Designation = _userService.GetDesignations();
                    ViewBag.UserDetails = _userService.GetAllUsers(new User { ActionCode = "VF" });
                    model.ProjectList = (await _priLinkServiceProvider.GetAllProjectLink()).ViewProjectLinkList.ToList();
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
          public async Task<IActionResult> BindSetPermissionUser()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {

                try
                {
                    ViewBag.Designation = _userService.GetDesignations();
                    ViewBag.UserDetails = _userService.GetAllUsers(new User { ActionCode = "VF" });
                    model.ProjectList = (await _priLinkServiceProvider.GetAllProjectLink()).ViewProjectLinkList.ToList();
                    return View("SetPermission",model);

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
        public async Task<IActionResult>BindSetPermission()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {

                try
                {
                    ViewBag.Designation = _userService.GetDesignations();
                    ViewBag.UserDetails = _userService.GetAllUsers(new User { ActionCode = "VF" });
                    model.ProjectList = (await _priLinkServiceProvider.GetAllProjectLink()).ViewProjectLinkList.ToList();
                    return View("SetPermission", model);

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
        public async Task<IActionResult> BindSetPermission(SetPermissionModel objpermission)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                ViewBag.Designation = _userService.GetDesignations();
                ViewBag.UserDetails = _userService.GetAllUsers(new User { ActionCode = "VF" });
                model.GlobalPrimaryList = (await _setpermissionservice.GetAllPrimaryLinkByGlobalLink(objpermission)).GlobalPrimaryList.ToList();
                model.ProjectList = (await _priLinkServiceProvider.GetAllProjectLink()).ViewProjectLinkList.ToList();
                return View("SetPermission", model);
            }
            else
            {
               return RedirectToAction("Logout", "Home");
            }

        }

        
        [HttpPost]
        public async Task<IActionResult> BindSetPermissionUser(SetPermissionModel objpermission)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                ViewBag.Designation = _userService.GetDesignations();
                ViewBag.UserDetails = _userService.GetAllUsers(new User { ActionCode = "VF" });
                model.GlobalPrimaryListUser = (await _setpermissionservice.GetAllPrimaryLinkByGlobalLinkUserwise(objpermission)).GlobalPrimaryList.ToList();
                model.ProjectList = (await _priLinkServiceProvider.GetAllProjectLink()).ViewProjectLinkList.ToList();
                //return View(model);
                return View("SetPermissionUser", model);
            }
            else
            {
               return RedirectToAction("Logout", "Home");
            }

        }
        //public async Task<IActionResult> BindSetPermission(int DId)
        //{

        //    try
        //    {
        //        ViewBag.Designation = _userService.GetDesignations();
        //         model.GlobalPrimaryList = (await _setpermissionservice.GetAllPrimaryLinkByGlobalLink()).GlobalPrimaryList.ToList();
        //        return View("SetPermission", model);



        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        #region Set permission
        [HttpPost]
        //public async Task<IActionResult> SetPermission(SetPermissionModel objpermission, string[] chkbox,string [] radio)
        public IActionResult SetPermissionData([FromBody] SetPermissionModel objpermission)
        {
            try
            {
                var Result = String.Empty;
                string[] permissionlist = objpermission.setpermissionList.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);

                var designations = _setpermissionservice.DeletePermissionLink_Designation(Convert.ToInt32(permissionlist[0].Split('|')[0]), Convert.ToInt32(permissionlist[0].Split('|')[1]));

                foreach (string item in permissionlist)
                {
                    SetPermissionModel s = new SetPermissionModel();
                    string[] permission = item.Split('|');
                    var projid = Convert.ToInt32(permission[1]);
                    Result = _setpermissionservice.SetPermissionLink_Designation(Convert.ToInt32(permission[0]), Convert.ToInt32(permission[2]), Convert.ToInt32(permission[3]), Convert.ToInt32(HttpContext.Session.GetString("UserId")), projid);

                }
                return Json(Result);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]

        public IActionResult SetPermissionDataUser([FromBody] SetPermissionModel objpermission)
        {
            try
            {
                var Result = String.Empty;
                string[] permissionlistUser = objpermission.setpermissionListUser.Split(new char[] { '^' }, StringSplitOptions.RemoveEmptyEntries);
                var userid = permissionlistUser[0].Split('|')[0];

                var s = _setpermissionservice.DeletePermissionLink_User(Convert.ToInt32(permissionlistUser[0].Split('|')[0]), Convert.ToInt32(permissionlistUser[0].Split('|')[1]));
                foreach (string item in permissionlistUser)
                {
                    string[] permission = item.Split('|');
                    var uid = Convert.ToInt32(permission[0]);
                    var projid = Convert.ToInt32(permission[1]);
                    var prilink = Convert.ToInt32(permission[2]);
                    var accessid = Convert.ToInt32(permission[3]);
                    Result = _setpermissionservice.SetPermissionLink_User(uid, prilink, accessid, Convert.ToInt32(HttpContext.Session.GetString("UserId")), projid);
                    //Result = _setpermissionservice.SetPermissionLink_User(Convert.ToInt32(permission[0]), Convert.ToInt32(permission[2]), Convert.ToInt32(permission[3]), Convert.ToInt32(HttpContext.Session.GetString("UserId")),Convert.ToInt32(permissionlistUser[1]));

                }
                return Json(Result);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion


        [HttpGet]
        public async Task<IActionResult> ViewUser(string Status)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                model.UserList = (await _setpermissionservice.GetAllUser()).UserList.ToList();
                TempData["CommandStatus"] = Status;
                return View("RemoveUserPermission", model);
            }
            else
            {
               return RedirectToAction("Logout", "Home");
            }
        }
        #region Remove User Permission List
        [HttpPost]
        public IActionResult MarkAsInActive(string[] chkbox)
        {
            try
            {
                var Result = String.Empty;
                foreach (string userId in chkbox)
                {
                    Result = _setpermissionservice.RemovePermissionList_User(Convert.ToInt32(userId), Convert.ToInt32(HttpContext.Session.GetString("UserId")));
                }
                return RedirectToAction("ViewUser", new { Status = Result });
                // return RedirectToAction("RemoveUserPermission");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}