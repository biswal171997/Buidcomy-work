using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using BUIDCO.Repository.Contract.Contract.AdminConsole.User_Management;
using BUIDCO.Domain.AdminConsole;
using BUIDCO.Domain.AdminConsole.User_Management;
using BUIDCO.Repository.AdminConsole;
using System.DirectoryServices;

namespace BUIDCO.Web.Areas.AdminConsole.Controllers
{
    [Area("AdminConsole")]
    //[Authorize]
    // [EnableCors("AllowAllHeaders,AllowAnyOrigin")]
    public class HomeController : Controller
    {
        private readonly IUserServiceProvider _userService;
        private IWebHostEnvironment _hostingEnvironment;
        //private bool authentic;

        public IConfiguration Configuration { get; }
       // public object Configuration { get; private set; }

        public HomeController(IUserServiceProvider userService, IWebHostEnvironment hostingEnvironment, IConfiguration configurations)
        {
            _hostingEnvironment = hostingEnvironment;
            _userService = userService;
            Configuration = configurations;
        }
        public IActionResult Index()
        {
           // TempData.Keep("UserName");
            TempData.Keep("UserName");
            TempData.Keep("Image");


            return View();
        }
        public IActionResult AdminIndex()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        public IActionResult Login()
        {
            TempData["Result"] = null;
            //TempData.Keep("Result");
            //string data;

            //if (TempData["Result"] != null)
            //{
            //    data = TempData["Result"] as string;

            //    TempData.Keep();
            //    ViewBag.DisplayMessage = data;
            //    TempData["Result"] = data;

            //}

            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Login(User user, string display)
        {
            var AKey = Configuration.GetValue<string>("MySettings:AKey");
            if (AKey == "DB")
            {
                if (user.UserName == null)
                {
                    TempData["Result"] = "Please enter user name!";
                    ViewBag.DisplayMessage = "Please enter user name!";                   
                    return View();                   
                }
                else if (user.UserPasswaord == null)
                {
                    TempData["Result"] = "Please enter password!";
                    ViewBag.DisplayMessage = "Please enter password!";
                    return View();                   
                }
                else
                {
                    var result = _userService.ValidateUser(new User { ActionCode = "L", UserName = user.UserName, UserPasswaord = CommonFunction.EncryptData(user.UserPasswaord) });
                    if (result == 4)
                    {
                        TempData["Result"] = "Invalid username or password!";
                        ViewBag.DisplayMessage = "Invalid username or password!";                        
                        return View();
                    }
                    else
                    {
                        var res = _userService.GetUserInfo(new User { ActionCode = "L", UserName = user.UserName, UserPasswaord = CommonFunction.EncryptData(user.UserPasswaord) });
                        HttpContext.Session.SetString("UserName", res.vchusername);
                        //  HttpContext.Session.SetString("Image", res.vchuserimage);
                        HttpContext.Session.SetString("UserId", res.UserID);
                        TempData["UserName"] = res.vchusername;
                        //  TempData["Image"] = res.vchuserimage;
                        //var results = _userService.GetLinkAccessByUserId(Convert.ToInt32(HttpContext.Session.GetString("UserId")));tempory
                        return RedirectToAction("Index");
                        //return View("AdminIndex",results);
                        // return View("Index", results);
                    }
                }
            }
            else
            {
                bool authentic = false;
                try
                {
                  
                    if (user.UserName == null)
                    {
                        TempData["Result"] = "Please enter user name!";
                        ViewBag.DisplayMessage = "Please enter user name!";
                        return View();
                    }
                    else if (user.UserPasswaord == null)
                    {
                        TempData["Result"] = "Please enter password!";
                        ViewBag.DisplayMessage = "Please enter password!";
                        return View();
                    }
                    else
                    {
                        var domain = Configuration.GetValue<string>("MySettings:Domain");
                        DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain, user.UserName, user.UserPasswaord, AuthenticationTypes.Secure);
                        //if (entry.Properties.Count > 0)
                        //{
                            object nativeObject = entry.NativeObject;
                            authentic = true;
                        //}
                    }
                }
                catch (DirectoryServicesCOMException)
                {
                    authentic = false;
                }
                if (authentic == true)
                {
                    var result = _userService.LDAPValidateUser(new User { ActionCode = "LDAP", UserName = user.UserName});
                    if (result == 4)
                    {
                        TempData["Result"] = "Invalid username or password!";
                        ViewBag.DisplayMessage = "Invalid username or password!";
                        return View();
                    }
                    else
                    {
                        var res = _userService.LDAPGetUserInfo(new User { ActionCode = "LDAP", UserName = user.UserName });
                        HttpContext.Session.SetString("UserName", res.vchusername);
                        //  HttpContext.Session.SetString("Image", res.vchuserimage);
                        HttpContext.Session.SetString("UserId", res.UserID);
                        TempData["UserName"] = res.vchusername;
                        //  TempData["Image"] = res.vchuserimage;
                        //var results = _userService.GetLinkAccessByUserId(Convert.ToInt32(HttpContext.Session.GetString("UserId")));tempory
                        return RedirectToAction("Index");
                       
                        //return View("AdminIndex",results);
                        // return View("Index", results);
                    }
                }
                else
                {
                    TempData["Result"] = "Invalid username or password!";
                    ViewBag.DisplayMessage = "Invalid username or password!";
                    return View();
                }
            }
        }

        //[HttpPost]
        //public IActionResult Login(User user, string display)
        //{
        //    if ((!string.IsNullOrEmpty(user.UserName)) || (!string.IsNullOrEmpty(user.UserPasswaord)))
        //    {
        //        if (!string.IsNullOrEmpty(user.UserPasswaord))
        //        {
        //            var result = _userService.ValidateUser(new User { ActionCode = "L", UserName = user.UserName, UserPasswaord = CommonFunction.EncryptData(user.UserPasswaord) });
        //            if (result == 4)
        //            {
        //                TempData["Result"] = "Invalid username or password!";
        //                ViewBag.DisplayMessage = "Invalid username or password!";
        //                //return RedirectToAction("Login");
        //                return View();
        //            }
        //            else
        //            {
        //                var res = _userService.GetUserInfo(new User { ActionCode = "L", UserName = user.UserName, UserPasswaord = CommonFunction.EncryptData(user.UserPasswaord) });
        //                HttpContext.Session.SetString("UserName", res.vchusername);
        //                //  HttpContext.Session.SetString("Image", res.vchuserimage);
        //                HttpContext.Session.SetString("UserId", res.UserID);
        //                TempData["UserName"] = res.vchusername;
        //                //  TempData["Image"] = res.vchuserimage;
        //                //var results = _userService.GetLinkAccessByUserId(Convert.ToInt32(HttpContext.Session.GetString("UserId")));tempory
        //                return RedirectToAction("Index");
        //                //return View("AdminIndex",results);
        //                // return View("Index", results);
        //            }
        //        }
        //        else
        //        {
        //            TempData["Result"] = "Please enter  password!";
        //            ViewBag.DisplayMessage = "Please enter  password!";
        //            //return RedirectToAction("Login");
        //            return View();

        //        }
        //    }
        //    else
        //    {
        //        ViewBag.DisplayMessage = "Please enter username or password!";
        //        TempData["Result"] = "Please enter username or password!";
        //        //return RedirectToAction("Login");
        //        return View();
        //    }

        //}
        [HttpGet]
        public IActionResult ChangePassword()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }
        [HttpPost]
        public IActionResult ChangePassword(User user)
        {
            var res = _userService.ChangePasswod(new User
            {
                ActionCode = "C",
                UserPasswaord = CommonFunction.EncryptData(user.UserPasswaord),
                CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId")),
                UserID = HttpContext.Session.GetString("UserId")
            });
            if (res == 2)
            {
                TempData["Result"] = "password changed successfully!";
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult UpdateProfile()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                ViewBag.UserDetails = _userService.GetUserById(Convert.ToInt32(HttpContext.Session.GetString("UserId")), "VS");
                return View();
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }
        [HttpPost]
        public JsonResult UpdateProfileData()
        {
            try
            {
                User user = new User();
                string ProcDocPath = _hostingEnvironment.WebRootPath + "\\UserImage";
                if (!Directory.Exists(ProcDocPath))
                    Directory.CreateDirectory(ProcDocPath);
                var file = Request.Form.Files;
                if (file.Count > 0)
                {
                    var filename = Path.GetExtension(ContentDispositionHeaderValue.Parse(file[0].ContentDisposition).FileName.Trim('"'));
                    var timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    var fullname = "User" + timestamp + "" + filename;
                    using (var stream = new FileStream(Path.Combine(ProcDocPath, fullname), FileMode.Create))
                    {
                        file[0].CopyTo(stream);
                    }
                    user.UserImage = fullname;
                }
                else
                {
                    user.UserImage = HttpContext.Request.Form["Image"].ToString();
                }

                user.ActionCode = "U";
                user.UserName = HttpContext.Request.Form["UserName"].ToString();
                user.FullName = HttpContext.Request.Form["Name"].ToString();
                user.intuserid = Convert.ToInt32(HttpContext.Request.Form["UserId"].ToString());
                user.intLocation = Convert.ToInt32(HttpContext.Request.Form["PhyscalLocation"].ToString());
                user.LeveleID = Convert.ToInt32(HttpContext.Request.Form["Location"].ToString());
                user.DateOfJoing = Convert.ToDateTime(HttpContext.Request.Form["DOJ"].ToString()).ToString("dd-MMM-yyyy");
                user.DateOfBirth = Convert.ToDateTime(HttpContext.Request.Form["DOB"].ToString()).ToString("dd-MMM-yyyy");
                user.DesignationID = HttpContext.Request.Form["Designation"].ToString();
                user.Gender = HttpContext.Request.Form["Gender"].ToString();
                user.email = HttpContext.Request.Form["Email"].ToString();
                user.Mobile = HttpContext.Request.Form["Mobile"].ToString();
                user.CreatedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId")); ;
                var result = _userService.EditUser(user);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }
        public IActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home", new { area = "AdminConsole" });
        }



    }
}
