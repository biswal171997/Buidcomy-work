using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model.Entities.CreateProject;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Model.M_Financial_Year;
using BUIDCo_ePMS.Model.M_MileStone_Master;
using BUIDCo_ePMS.Model.M_Project_Part;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.CreateProject;
using BUIDCo_ePMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BUIDCo_ePMS.Web.Controllers
{
    public class CreateProjectController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        Uri url;
        readonly HttpClient client;
        readonly IConfiguration _configuration;
        ICreateProject _objCreateObject;
        private readonly UserContextService _userContextService;
        public CreateProjectController(IWebHostEnvironment hostingEnvironment, IHttpClientFactory httpClientFactory, IConfiguration Configuration, ICreateProject objCreateObject, UserContextService userContextService)
        {
            _hostingEnvironment = hostingEnvironment;
            var factoryClient = httpClientFactory.CreateClient("MyApiClient");
            client = new HttpClient();
            client.BaseAddress = factoryClient.BaseAddress;
            url = client.BaseAddress;
            _configuration = Configuration;
            _objCreateObject = objCreateObject;
            _userContextService = userContextService;
            var token = _userContextService.Token;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> CreateProjectView()
        {
            var user = HttpContext.User; // Get the current user
            if (!user.Identity.IsAuthenticated)
            {
                return Json(new { success = false, responseMessage = "User is not authenticated.", responseText = "Access Denied", data = "" });
            }
            var data = JsonConvert.DeserializeObject<List<ProjectViewEF>>(await client.GetStringAsync(url + "/CreateProject/GetCreatedProjectRecord"));
            return View(data);
        }

        public IActionResult CreateProjectAdd(int? Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Json(new { success = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }

            ViewBag.projectId = Id;
            return View();
        }

        public async Task<JsonResult> GetProposalDetails(int ProposalId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
         .SelectMany(v => v.Errors)
        .Select(e => e.ErrorMessage));
                    return Json(new { success = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
               
                var user = HttpContext.User; // Get the current user
                if (!user.Identity.IsAuthenticated)
                {
                    return Json(new { success = false, responseMessage = "User is not authenticated.", responseText = "Access Denied", data = "" });
                }
                
                var data = JsonConvert.DeserializeObject<ProposalDetail>(await client.GetStringAsync(url + "/CreateProject/GetProposalDetails?ProposalId=" + ProposalId));
                 return Json(data);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<JsonResult> BindLetterNoAndSubject()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
         .SelectMany(v => v.Errors)
        .Select(e => e.ErrorMessage));
                    return Json(new { success = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    try
                    {
                        var user = HttpContext.User; // Get the current user
                        if (!user.Identity.IsAuthenticated)
                        {
                            return Json(new { success = false, responseMessage = "User is not authenticated.", responseText = "Access Denied", data = "" });
                        }

                        var data = JsonConvert.DeserializeObject<List<ProposalList>>(await client.GetStringAsync(url + "/CreateProject/BindLetterNoAndSubject"));
                            return Json(data);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SAVE_PROJECT_Details(ProjectDetail Model, IFormFile? fileReviseDocument)
        {

            int x;
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Json(new { success = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                try
                {
                    var user = HttpContext.User; // Get the current user
                    if (!user.Identity.IsAuthenticated)
                    {
                        return Json(new { success = false, responseMessage = "User is not authenticated.", responseText = "Access Denied", data = "" });
                    }

                    Model.CreatedBy = Convert.ToInt32(_userContextService.UserId);
                    //File Upload of Revised Amount Document
                    if (fileReviseDocument != null && fileReviseDocument.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("ReviseAmountDoc").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        var fileName = Guid.NewGuid() + "_RevisedAmount";//fileReviseDocument.FileName;
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await fileReviseDocument.CopyToAsync(stream);
                        }
                        Model.ReviseAmountDocpath = fileName;
                        fileReviseDocument = null;
                    }

                    if (Model.ReviseUpdatedAmount==0)
                    {
                        Model.ReviseAmountDocpath = "";
                        Model.ReviseAmountRemarks = "";
                    }
                    HttpResponseMessage resNew = await client.PostAsync(url + "/CreateProject/SaveProjectDetails", new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json"));

                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    x = JsonResponse.data;

                    if (x == 1 || x == 2)
                    {
                        return Json(new { success = true, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "success", data = "" });
                    }
                    else if (x == 4)
                    {
                        return Json(new { success = false, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "error", data = "" });
                    }
                    else
                    {
                        return Json(new { success = false, responseMessage = "Something went wrong!", responseText = "error", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DELETE_PROJECT_Details(int ProjectId)
        {

            int x;
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Json(new { success = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                try
                {
                    var user = HttpContext.User; // Get the current user
                    if (!user.Identity.IsAuthenticated)
                    {
                        return Json(new { success = false, responseMessage = "User is not authenticated.", responseText = "Access Denied", data = "" });
                    }
                    //File Upload of NIT Document
                    ProjectDetail model = new ProjectDetail();
                    model.ProjectId = ProjectId;
                    model.CreatedBy =Convert.ToInt32(_userContextService.UserId);

                    HttpResponseMessage resNew = await client.PostAsync(url + "/CreateProject/DeleteProjectDetails", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    x = JsonResponse.data;

                    if (x == 3)
                    {
                        return Json(new { success = true, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "success", data = "" });
                    }
                    else if (x == 4)
                    {
                        return Json(new { success = false, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "error", data = "" });
                    }
                    else
                    {
                        return Json(new { success = false, responseMessage = "Something went wrong!", responseText = "error", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public IActionResult DownloadPdf(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("Invalid file name.");
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("ReviseAmountDoc").Value!, fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var contentType = "application/pdf";
            return File(fileBytes, contentType, fileName);
        }

        public async Task<JsonResult> GetCreatedProjectRecord()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
         .SelectMany(v => v.Errors)
        .Select(e => e.ErrorMessage));
                    return Json(new { success = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    try
                    {
                        var user = HttpContext.User; // Get the current user
                        if (!user.Identity.IsAuthenticated)
                        {
                            return Json(new { success = false, responseMessage = "User is not authenticated.", responseText = "Access Denied", data = "" });
                        }
                        var data = JsonConvert.DeserializeObject<List<ProposalList>>(await client.GetStringAsync(url + "/CreateProject/GetCreatedProjectRecord"));
                        return Json(data);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<JsonResult> GetSubmittedProjectDetails(int ProjectId)
        {
            ProjectSavedDetail lst = new ProjectSavedDetail();
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
         .SelectMany(v => v.Errors)
        .Select(e => e.ErrorMessage));
                    return Json(new { success = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    var user = HttpContext.User; // Get the current user
                    if (!user.Identity.IsAuthenticated)
                    {
                        return Json(new { success = false, responseMessage = "User is not authenticated.", responseText = "Access Denied", data = "" });
                    }
                    var data = JsonConvert.DeserializeObject<ProjectSavedDetail>(await client.GetStringAsync(url + "/CreateProject/GetSubmittedProjectDetails?ProjectId=" + ProjectId));
                    return Json(data);

                }

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
