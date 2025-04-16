using BUIDCO.Domain.AdminConsole.EmailMaster;
using BUIDCO.Repository.Contract.Contract.AdminConsole.Email_Master;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace BUIDCO.Web.Areas.AdminConsole.Controllers
{
    [Area("AdminConsole")]
    public class EmailMasterController : Controller
    {
        public IEmailServiceProvider _EmailServiceProvider { get; }
        EmailMaster model = new EmailMaster();
        public EmailMasterController(IEmailServiceProvider emailServiceProvider)
        {
            _EmailServiceProvider = emailServiceProvider;
        }
        public IActionResult AddEmailMaster()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmailMaster(EmailMaster em)
        {
            try
            {
                var UserId = HttpContext.Session.GetString("UserId");
                    if (!string.IsNullOrEmpty(UserId.ToString()))
                {
                    if(em.CONFIGID==0)
                    {
                        var Result = _EmailServiceProvider.AddEmail(em);
                        if(Result.Result>0)
                        {
                            return Json(Result.Result);
                        }
                        else
                        {
                            return Json("some error ocured");
                        }
                    }
                    else
                    {
                        var Result = _EmailServiceProvider.UpdateEmail(em);
                        if (Result.Result > 0)
                        {
                            return Json(Result.Result);
                        }
                        else
                        {
                            return Json("some error ocured");
                        }
                    }
                }
                else
                {     
                   return RedirectToAction("SessionOut", "Home");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IActionResult ViewEmailMaster()
        {
            var UserId = HttpContext.Session.GetString("UserId");
            if (!string.IsNullOrEmpty(UserId.ToString()))
            {
               
                ViewBag.Emailmaster = _EmailServiceProvider.GetallEmail().Result;
                return View();
            }
            else
            {
                return RedirectToAction("Logout", "Home");
            }
        }
        [HttpGet]
        public IActionResult Getemaildetails(string configid)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("_UserId");

                if (!string.IsNullOrEmpty(UserId.ToString()))
                {
                    var result = _EmailServiceProvider.Getemailbyid(Convert.ToInt32(configid)).Result;
                    return Ok(JsonConvert.SerializeObject(result));
                }
                else
                {
                    return RedirectToAction("SessionOut", "Home");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult AddEmailMaster2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmailMaster2(EmailMaster em)
        {
            try
            {
                var UserId = HttpContext.Session.GetString("UserId");

                if (!string.IsNullOrEmpty(UserId.ToString()))
                {
                    if (em.CONFIGID == 0)
                    {
                        var Result = _EmailServiceProvider.AddEmail(em);
                        if (Result.Result > 0)
                        {
                            return Json(Result.Result);
                        }
                        else
                        {
                            return Json("some error ocured");
                        }
                    }
                    else
                    {
                        var Result = _EmailServiceProvider.UpdateEmail(em);
                        if (Result.Result > 0)
                        {
                            return Json(Result.Result);
                        }
                        else
                        {
                            return Json("some error ocured");
                        }
                    }
                }
                else
                {
                    return RedirectToAction("SessionOut", "Home");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
