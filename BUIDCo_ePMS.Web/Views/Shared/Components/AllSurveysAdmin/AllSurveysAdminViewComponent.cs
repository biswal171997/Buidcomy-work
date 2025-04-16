using BUIDCO.Repository.Contract.Contract.AdminConsole;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BUIDCo_ePMS.Core;

using BUIDCO.Domain;



namespace BUIDCO.Web.Pages.Shared.Components.AllSurveysAdmin
{
    public class AllSurveysAdminViewComponent : ViewComponent
    {
        private IAdminConsoleRepository _IAdminConsoleRepository { get; }
        private readonly IConfiguration _config;
        private readonly UserContextService _userContextService;

        public AllSurveysAdminViewComponent(IAdminConsoleRepository IAdminConsoleRepository, IConfiguration config, UserContextService userContextService)
        {
            _IAdminConsoleRepository = IAdminConsoleRepository;
            _config = config;
            _userContextService = userContextService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string ratingControlType)
        {


            var user = HttpContext.User;
            if (user.Identity.IsAuthenticated) // Check if the user is authenticated
            {
                ViewBag.Username = _userContextService.Username;
                ViewBag.RoleId = _userContextService.RoleId;
                ViewBag.UserId = _userContextService.UserId;
                ViewBag.IntLevelDetailsId = _userContextService.IntLevelDetailsId;
                ;
            }


            //var userid = HttpContext.Session.GetInt32("userId");
            //var desgid = HttpContext.Session.GetInt32("_DesignId");
            var PId = _config.GetValue<int>("MySettings:ProjectId");
            var results = _IAdminConsoleRepository.GetLinkAccessByUserId(Convert.ToInt32(_userContextService.UserId), PId, Convert.ToInt32(_userContextService.RoleId), "ENG");
            
                var Data = results.ToList();
            if (HttpContext.Request.Query["Glink"].ToString() != "")
            {
                //Data[0].Aglinkid = Convert.ToInt32(HttpContext.Request.Query["Glink"]);
                Data.ForEach(c => c.Aglinkid = Convert.ToInt32(HttpContext.Request.Query["Glink"]));
                //HttpContext.Session.SetInt32("Glink", Convert.ToInt32(HttpContext.Request.Query["Glink"]));
                TempData["Glink"] = HttpContext.Request.Query["Glink"].ToString();
                TempData.Keep();
            }
            if (HttpContext.Request.Query["Plink"].ToString() != "")
            {
                //Data[0].Aplinkid = Convert.ToInt32(HttpContext.Request.Query["Plink"]);
                Data.ForEach(c => c.Aplinkid = Convert.ToInt32(HttpContext.Request.Query["Plink"]));
                //HttpContext.Session.SetInt32("Plink", Convert.ToInt32(HttpContext.Request.Query["Plink"]));
                TempData["Plink"] = HttpContext.Request.Query["Plink"].ToString();
                TempData.Keep();
            }
            return View("default", results);
            //var surveys = await _iDFormRepository.GetSurveys();
            //return View("default", surveys.OrderBy(x => x.ID));
        }

    

        //public async Task<IViewComponentResult> InvokeAsync(string ratingControlType)
        //{
        //    var user = HttpContext.User;
        //    if (user.Identity.IsAuthenticated) // Check if the user is authenticated
        //    {
        //        var username = _userContextService.Username;
        //        var roleId = _userContextService.RoleId;
        //        var userId = _userContextService.UserId;
        //        var intLevelDetailsId = _userContextService.IntLevelDetailsId;
        //    }
        //    //var userid = this.UserClaimsPrincipal.Claims.FirstOrDefault(x => x.Type.Equals("userid", StringComparison.OrdinalIgnoreCase))?.Value;
        //    var userid = _userContextService.UserId;
        //    var desgid = _userContextService.RoleId;
        //    var PId = _config.GetValue<int>("MySettings:ProjectId");

        //    var results = _IAdminConsoleRepository.GetLinkAccessByUserId( Convert.ToInt32(userid), PId, Convert.ToInt32(desgid),"");
        //    var Data = results.ToList();
        //    if (HttpContext.Request.Query["Glink"].ToString() != "")
        //    {
        //        //Data[0].Aglinkid = Convert.ToInt32(HttpContext.Request.Query["Glink"]);
        //        Data.ForEach(c => c.Aglinkid = Convert.ToInt32(HttpContext.Request.Query["Glink"]));
        //        //HttpContext.Session.SetInt32("Glink", Convert.ToInt32(HttpContext.Request.Query["Glink"]));
        //        TempData["Glink"] = HttpContext.Request.Query["Glink"].ToString();
        //        TempData.Keep();
        //    }
        //    if (HttpContext.Request.Query["Plink"].ToString() != "")
        //    {
        //        //Data[0].Aplinkid = Convert.ToInt32(HttpContext.Request.Query["Plink"]);
        //        Data.ForEach(c => c.Aplinkid = Convert.ToInt32(HttpContext.Request.Query["Plink"]));
        //        //HttpContext.Session.SetInt32("Plink", Convert.ToInt32(HttpContext.Request.Query["Plink"]));
        //        TempData["Plink"] = HttpContext.Request.Query["Plink"].ToString();
        //        TempData.Keep();
        //    }
        //    return View("default",results);
        //    //var surveys = await _iDFormRepository.GetSurveys();
        //    //return View("default", surveys.OrderBy(x => x.ID));
        //}
    }
}
