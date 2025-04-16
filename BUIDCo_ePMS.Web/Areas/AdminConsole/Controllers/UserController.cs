using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
//using OfficeOpenXml;
using Newtonsoft.Json;
using BUIDCO.Repository.Contract.Contract.AdminConsole.User_Management;
using BUIDCO.Repository.Contract.Contract.AdminConsole.HierarchyMaster;
using BUIDCO.Domain.AdminConsole.User_Management;
using BUIDCO.Repository.AdminConsole;
using OfficeOpenXml;
//using OfficeOpenXml.Core.ExcelPackage;

namespace BUIDCO.Web.Areas.AdminConsole.Controllers
{
    [Area("AdminConsole")]
    public class UserController : Controller
    {
        private readonly IUserServiceProvider _userService;
        private IWebHostEnvironment _hostingEnvironment;
        public IHierarchyServiceProvider _hirerarchyServiceProvider { get; }
        public UserController(IUserServiceProvider userService, IWebHostEnvironment hostingEnvironment, IHierarchyServiceProvider hirerarchyServiceProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            _hirerarchyServiceProvider = hirerarchyServiceProvider;
        }
        [HttpGet]
        public async Task<IActionResult> AddUser()   
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                ViewBag.ParentLoc = (await _hirerarchyServiceProvider.GetAllHierarchy(1)).HierarchyList.ToList();
                // ViewBag.Location = _userService.GetLevelDetails();
                ViewBag.PhysicalLoc = _userService.GetLocation();
                ViewBag.Designation = _userService.GetDesignations();
                return View("AddUser");
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }
        [HttpPost]
        public JsonResult AddUserData()
        {
            try
            {
                User user = new User();
                string ext = string.Empty;
                string Result = string.Empty;
                if (Request.Form.Files.Count == 0)
                {
                    user.UserImage = "";
                }
                else
                {
                    string ProcDocPath = _hostingEnvironment.WebRootPath + "\\UserImage";
                    if (!Directory.Exists(ProcDocPath))
                        Directory.CreateDirectory(ProcDocPath);

                    var file = Request.Form.Files;
                    var filename = Path.GetExtension(ContentDispositionHeaderValue.Parse(file[0].ContentDisposition).FileName.Trim('"'));
                    var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    var fullname = "User" + timestamp + "" + filename;
                    using (var stream = new FileStream(Path.Combine(ProcDocPath, fullname), FileMode.Create))
                    {
                        file[0].CopyTo(stream);
                    }
                    ext = Path.GetExtension(fullname);
                    user.UserImage = fullname;
                    //if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
                    //{
                    //    //Result = "Please upload a valid document of type jpg/jpeg/png.!!!";
                    //    return Json(Result);
                    //}
                }
                user.ActionCode = "A";              
                user.UserName = HttpContext.Request.Form["UserName"].ToString();
                user.FullName = HttpContext.Request.Form["Name"].ToString();
                user.UserPasswaord = CommonFunction.EncryptData(HttpContext.Request.Form["Password"].ToString()).ToString();
                user.intHLocation = Convert.ToInt32(HttpContext.Request.Form["HLocation"].ToString());
                //user.intLG = Convert.ToInt32(HttpContext.Request.Form["LG"].ToString());
                user.DesignationID = HttpContext.Request.Form["Designation"].ToString();
                user.ReportingUserID = HttpContext.Request.Form["intRptUserId"].ToString();
                user.Gender = HttpContext.Request.Form["Gender"].ToString();
                user.ISADMIN=Convert.ToInt32( HttpContext.Request.Form["ISADMIN"].ToString());
                user.email = HttpContext.Request.Form["Email"].ToString();
                user.Mobile = HttpContext.Request.Form["Mobile"].ToString();
                user.CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                if (HttpContext.Request.Form["Department"].ToString()=="null")
                {
                    user.intDepartment = 0;
                }
                else
                {
                    user.intDepartment = Convert.ToInt32(HttpContext.Request.Form["Department"].ToString());
                }
                if (HttpContext.Request.Form["LG"].ToString() == "null")
                {
                    user.intLG = 0;
                }
                else
                {
                    user.intLG = Convert.ToInt32(HttpContext.Request.Form["LG"].ToString());
                }
                //user.intLocation = Convert.ToInt32(HttpContext.Request.Form["PhyscalLocation"].ToString());

                if (HttpContext.Request.Form["Location"].ToString() == "")
                {
                    user.LeveleID = 0;
                }
                else
                {
                    user.LeveleID = Convert.ToInt32(HttpContext.Request.Form["Location"].ToString());
                }


                //user.LeveleID = Convert.ToInt32(HttpContext.Request.Form["Location"].ToString());
                if (HttpContext.Request.Form["DOJ"].ToString() == "")
                {
                    user.DateOfJoing = "";
                }
                else
                {
                    user.DateOfJoing = Convert.ToDateTime(HttpContext.Request.Form["DOJ"].ToString()).ToString("dd-MMM-yyyy");
                }
                if (HttpContext.Request.Form["DOB"].ToString() == "")
                {
                    user.DateOfBirth = "";
                }
                else
                {
                    user.DateOfBirth = Convert.ToDateTime(HttpContext.Request.Form["DOB"].ToString()).ToString("dd-MMM-yyyy");
                }
               
                Result = _userService.CreateUser(user).ToString();
                return Json(Result);
            }
            catch(Exception ex) {
                return Json(ex.Message);
            } 
            
        }
        [HttpPost]
        public JsonResult EditUserData()
        {

            try
            {
                User user = new User();
                //string ProcDocPath = _hostingEnvironment.WebRootPath + "\\UserImage";
                //string ext=string.Empty;
                //if (!Directory.Exists(ProcDocPath))
                //    Directory.CreateDirectory(ProcDocPath);
                //var file = Request.Form.Files;
                //if (file.Count > 0)
                //{
                //    var filename = Path.GetExtension(ContentDispositionHeaderValue.Parse(file[0].ContentDisposition).FileName.Trim('"'));
                //    var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                //    var fullname = "User" + timestamp + "" + filename;
                //    using (var stream = new FileStream(Path.Combine(ProcDocPath, fullname), FileMode.Create))
                //    {
                //        file[0].CopyTo(stream);
                //    }
                //    user.UserImage = fullname;
                //    ext = Path.GetExtension(user.UserImage);
                //}
                //else
                //{
                //    user.UserImage = HttpContext.Request.Form["Image"].ToString();
                //   ext = Path.GetExtension(user.UserImage);
                //}
                //if (ext== ".jpg" || ext == ".jpeg" || ext == ".png")//jpg/jpeg/png
                //{
                    user.ActionCode = "U";
                    user.UserName = HttpContext.Request.Form["UserName"].ToString();
                    user.FullName = HttpContext.Request.Form["Name"].ToString();
                    user.intuserid = Convert.ToInt32(HttpContext.Request.Form["UserId"].ToString());
                    //user.intLocation = Convert.ToInt32(HttpContext.Request.Form["PhyscalLocation"].ToString());
                    user.LeveleID = Convert.ToInt32(HttpContext.Request.Form["Location"].ToString());
                   // user.DateOfJoing = Convert.ToDateTime(HttpContext.Request.Form["DOJ"].ToString()).ToString("dd-MMM-yyyy");
                    //user.DateOfBirth = Convert.ToDateTime(HttpContext.Request.Form["DOB"].ToString()).ToString("dd-MMM-yyyy");
                    user.DesignationID = HttpContext.Request.Form["Designation"].ToString();
                    user.ReportingUserID = HttpContext.Request.Form["intRptUserId"].ToString();
                    user.Gender = HttpContext.Request.Form["Gender"].ToString();
                    user.ISADMIN = Convert.ToInt32(HttpContext.Request.Form["ISADMIN"].ToString());
                    user.email = HttpContext.Request.Form["Email"].ToString();
                    user.Mobile = HttpContext.Request.Form["Mobile"].ToString();
                    user.CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));


                    if (HttpContext.Request.Form["Location"].ToString() == "")
                    {
                        user.LeveleID = 0;
                    }
                    else
                    {
                        user.LeveleID = Convert.ToInt32(HttpContext.Request.Form["Location"]);

                    }

                    if (HttpContext.Request.Form["hLoc"].ToString() == "")
                    {
                        user.intHLocation = 0;
                    }
                    else 
                    {
                        user.intHLocation = Convert.ToInt32(HttpContext.Request.Form["hLoc"]);

                    }
                    
                    if (HttpContext.Request.Form["Lg"].ToString() == "null")
                    {
                        user.intLG = 0;

                    }
                    else
                    {
                        user.intLG = Convert.ToInt32(HttpContext.Request.Form["Lg"]);

                    }
                    if (HttpContext.Request.Form["Department"].ToString() == "null")
                    {
                        user.intDepartment = 0;
                    }
                    else
                    {
                        user.intDepartment = Convert.ToInt32(HttpContext.Request.Form["Department"]);
                    }


                    var result = _userService.EditUser(user);
                    TempData["userResult"] = result;
                    return Json(result);
                //}
                //else
                //{
                //    return Json("Please upload a valid document of type jpg/jpeg/png.!!!");
                //}

               
              
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public IActionResult UserExportExcelAsync()
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32("_UserId"));
            if (!string.IsNullOrEmpty(UserId.ToString()))
            {

                var User = _userService.GetuserExport();
                var stream = new MemoryStream();

                using (var package = new ExcelPackage(stream))
                {
                    var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                    workSheet.Cells.LoadFromCollection(User, true);
                    package.Save();
                }
                stream.Position = 0;

                string excelName = $"UserDetails-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
            }
            else
            {
                return RedirectToAction("Logout", "Login");                
            }
        }

        //public JsonResult BindUser(int ParentId)
        //{

        //    var value = HttpContext.Session.GetInt32("_UserId");
        //    if (!string.IsNullOrEmpty(value.ToString()))
        //    {
        //        var result = _userService.GetLevelDetailsByuser(ParentId).ToList();
        //        string jsonnresult = JsonConvert.SerializeObject(result);
        //        return Json(jsonnresult);
        //    }
        //    else
        //    {
        //        RedirectToAction("Logout", "Login");
        //        return Json(null);
        //    }

        //}

        [HttpGet]
        public JsonResult GetLevelDetailsByuser(int ParentId)
        {

            var result = _userService.GetLevelDetailsByuser(ParentId);
           
            return Json(result);
        }
        [HttpGet]
        public JsonResult getLevelDetailsByParentId(int ParentId)
        {
            var result = _userService.GetLevelDetailsByParentId(ParentId);
            return Json(result);
        }
        [HttpGet]
        public JsonResult getleveldetailsbyhirarchyid(int hirarchyid)
        {
            var result = _userService.GetLevelDetails(hirarchyid);
            return Json(result);
        }
        [HttpGet]
        public IActionResult ViewUser(string msg)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                // TempData.Keep("userResult");
                TempData["userResult"] = msg;
                ViewBag.DesigId = 0;
                ViewBag.LocId = 0;
                ViewBag.Mob = "";
                ViewBag.Uname = "";
                ViewBag.PhysicalLoc = _userService.GetLocation();
                ViewBag.Designation = _userService.GetDesignations();

                ViewBag.UserDetails = _userService.GetAllUsers(new User { ActionCode = "VF" });
                return View("ViewUser");
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }
        [HttpPost]
        public IActionResult ViewSearchUser(User user)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                ViewBag.DesigId = user.intDesignationID;
                ViewBag.LocId = user.intLocation;
                ViewBag.Mob = user.vchmobtel;
                ViewBag.Uname = user.vchusername;
                ViewBag.PhysicalLoc = _userService.GetLocation();
                ViewBag.Designation = _userService.GetDesignations();
                ViewBag.UserDetails = _userService.GetAllUsers(new User { ActionCode = "VF", intDesignationID = user.intDesignationID, intLocation = user.intLocation, vchmobtel = user.vchmobtel, vchusername = user.vchusername });
                return View("ViewUser");
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }
        public async Task<IActionResult> EditUser(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                ViewBag.ParentLoc = (await _hirerarchyServiceProvider.GetAllHierarchy(1)).HierarchyList.ToList();
                // ViewBag.Location = _userService.GetLevelDetails(1);
                //ViewBag.PhysicalLoc = _userService.GetLocation();
                ViewBag.Designation = _userService.GetDesignations();
                ViewBag.UserDetails = _userService.GetUserById(Id, "VS");
                return View("EditUser");
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }
        [HttpPost]

        public JsonResult DeleteUser(int Id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                //TempData["userResult"] = _userService.DeleteUser(new User { ActionCode = "I", intuserid = Id, CreatedBy = 1 });
               
                var result = _userService.DeleteUser(new User { ActionCode = "I", intuserid = Id, CreatedBy = 1 });
                TempData["userResult"] = result;
                return Json(result);
              //  return RedirectToAction("ViewUser");
            }
            else
            {
                return Json("");
            }
        }
    }
}