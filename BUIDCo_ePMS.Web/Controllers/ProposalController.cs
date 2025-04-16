using Azure;
using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Model.Entities.Proposal;
using BUIDCo_ePMS.Model.M_Financial_Year;
using BUIDCo_ePMS.Model.Responses;
using BUIDCo_ePMS.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;

namespace BUIDCo_ePMS.Web.Controllers
{
    [Authorize]
    public class ProposalController : Controller
    {
        readonly Uri? url;
        readonly HttpClient client;
        readonly IConfiguration _configuration;
        readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly UserContextService _userContextService;
        public ProposalController(IHttpClientFactory httpClientFactory, IConfiguration configuration, IWebHostEnvironment webHostEnvironment, UserContextService userContextService)
        {
            var factoryClient = httpClientFactory.CreateClient("MyApiClient");
            client = new HttpClient();
            client.BaseAddress = factoryClient.BaseAddress;
            url = client.BaseAddress;
            _configuration = configuration;
            _WebHostEnvironment = webHostEnvironment;
            _userContextService = userContextService;
            var token = _userContextService.Token;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateProposal()
        {
            return View();
        }

        public IActionResult ViewProposal()
        {

            return View();
        }
        #region view proposal
        [HttpGet]
        public async Task<JsonResult> GetProposal(string? searchtype)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    HttpResponseMessage resNew = await client.GetAsync(url + "/Proposal/GetProposal?searchtype="+ searchtype + "");
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetProposalInformationByID(Proposal obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    HttpResponseMessage resNew = await client.GetAsync(url + "/Proposal/GetProposalInformationByID?Id="+obj.proposalid+"");
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult DownloadFiles(string filename, string filepath)
        {
            if (string.IsNullOrWhiteSpace(filename) || string.IsNullOrWhiteSpace(filepath))
            {
                return BadRequest("Filename or filepath is missing.");
            }

            // Combine the filepath and filename
            var fullPath = Path.Combine(Directory.GetCurrentDirectory(), filepath, filename);

            if (!System.IO.File.Exists(fullPath))
            {
                return NotFound("File not found.");
            }

            try
            {
                var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);
                return File(stream, "application/octet-stream", filename);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while downloading the file: {ex.Message}");
            }
        }

        #endregion
        #region add proposal
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveProposal(Proposal obj, IFormFile letterDocFile)
        {
            try
            {
                obj.createdBy = Convert.ToInt32(_userContextService.UserId);
                int x;
                //if (obj.proposalid == 0 && letterDocFile == null)
                //{
                //    ModelState.AddModelError(nameof(letterDocFile), "Please upload Proposal Letter");
                //}
                //if (!ModelState.IsValid)
                //{
                //    var message = string.Join(" | ", ModelState.Values
                //    .SelectMany(v => v.Errors)
                //    .Select(e => e.ErrorMessage));
                //    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                //}
                if(true)
                {
                    if (letterDocFile != null)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("ProposalLetter").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        var fileName = Guid.NewGuid() + Path.GetExtension(letterDocFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await letterDocFile.CopyToAsync(stream);
                        }
                        obj.letterDocPath = fileName;
                    }
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Proposal/SaveProposal", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    x = JsonResponse.data;

                    if (x == 1 || x == 2)
                    {
                        return Json(new { sucess = true, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "Success", data = "" });
                    }
                    else if (x == 4)
                    {
                        return Json(new { sucess = false, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "Fail", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Something went wrong!", responseText = "Fail", data = "" });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> SubmitProposal(Proposal obj)
        {
            try
            {
                obj.createdBy = Convert.ToInt32(_userContextService.UserId);
                int x;
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Proposal/SubmitProposal", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    x = JsonResponse.data;
                    if (x == 1)
                    {
                        return Json(new { sucess = true, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "Success", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Something went wrong!", responseText = "Fail", data = "" });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> CancelProposal(Proposal obj)
        {
            try
            {
                obj.createdBy = Convert.ToInt32(_userContextService.UserId);
                int x;
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Proposal/CancelProposal", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    x = JsonResponse.data;
                    if (x == 1)
                    {
                        return Json(new { sucess = true, responseMessage = MessageHandler.GetMessageDescription(3), responseText = "Success", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Something went wrong!", responseText = "Fail", data = "" });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetProposalByID(Proposal obj)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    HttpResponseMessage resNew = await client.GetAsync(url + "/Proposal/GetProposalByID?Id="+obj.proposalid+"");
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region add site information
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveProposalSite(ProposalSite obj, IFormFile LandNocFile, IFormFile MapplanFile, List<IFormFile> SiteDocFiles)
        {
            try
            {
                obj.createdBy = Convert.ToInt32(_userContextService.UserId);
                int x;
                obj.proposalsitedocs = new List<ProposalSiteDocument>();
                //if (obj.proposalid == 0 && letterDocFile == null)
                //{
                //    ModelState.AddModelError(nameof(letterDocFile), "Please upload Proposal Letter");
                //}
                //if (!ModelState.IsValid)
                //{
                //    var message = string.Join(" | ", ModelState.Values
                //    .SelectMany(v => v.Errors)
                //    .Select(e => e.ErrorMessage));
                //    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                //}
                if (true)
                {
                    if (LandNocFile != null)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("ProposalLetter").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        var fileName = Guid.NewGuid() + Path.GetExtension(LandNocFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await LandNocFile.CopyToAsync(stream);
                        }
                        obj.nocPath = fileName;
                    }
                    if (MapplanFile != null)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("ProposalLetter").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        var fileName = Guid.NewGuid() + Path.GetExtension(MapplanFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await MapplanFile.CopyToAsync(stream);
                        }
                        obj.plannedMap = fileName;
                    }
                    if (SiteDocFiles.Count > 0)
                    {
                        foreach(IFormFile file in SiteDocFiles)
                        {
                            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("ProposalLetter").Value!);
                            if (!Directory.Exists(uploadsFolder))
                            {
                                Directory.CreateDirectory(uploadsFolder);
                            }
                            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                            var filePath = Path.Combine(uploadsFolder, fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }
                            obj.proposalsitedocs.Add(new ProposalSiteDocument { docPath = fileName });
                        }
                        
                    }
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Proposal/SaveProposalSite", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    x = JsonResponse.data;

                    if (x == 1 || x == 2)
                    {
                        return Json(new { sucess = true, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "Success", data = "" });
                    }
                    else if (x == 4)
                    {
                        return Json(new { sucess = false, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "Fail", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Something went wrong!", responseText = "Fail", data = "" });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<JsonResult> DeleteProposalSite(ProposalSite obj)
        {
            try
            {
                obj.createdBy = Convert.ToInt32(_userContextService.UserId);
                int x = 0;
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Proposal/DeleteProposalSite", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    x = JsonResponse.data;

                    if (x == 1 || x == 2)
                    {
                        return Json(new { sucess = true, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "Success", data = "" });
                    }
                    else if (x == 4)
                    {
                        return Json(new { sucess = false, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "Fail", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Something went wrong!", responseText = "Fail", data = "" });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<JsonResult> GetProposalSiteByID(int Id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    HttpResponseMessage resNew = await client.GetAsync(url + "/Proposal/GetProposalSiteByID?Id=" + Id + "");
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region fdr information
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> SaveFDRDetails(ProposalFdr obj, IFormFile LoaLetterFile, IFormFile PPTFile, IFormFile FdrEstimateFile, IFormFile MaplayoutFile, IFormFile DesignLayoutFile)
        {
            try
            {
                obj.createdBy = Convert.ToInt32(_userContextService.UserId);
                int x;
                //if (obj.proposalid == 0 && letterDocFile == null)
                //{
                //    ModelState.AddModelError(nameof(letterDocFile), "Please upload Proposal Letter");
                //}
                //if (!ModelState.IsValid)
                //{
                //    var message = string.Join(" | ", ModelState.Values
                //    .SelectMany(v => v.Errors)
                //    .Select(e => e.ErrorMessage));
                //    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                //}
                if (true)
                {
                    if (LoaLetterFile != null)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("ProposalLetter").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        var fileName = Guid.NewGuid() + Path.GetExtension(LoaLetterFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await LoaLetterFile.CopyToAsync(stream);
                        }
                        obj.loaLetterPath = fileName;
                    }
                    if (PPTFile != null)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("ProposalLetter").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        var fileName = Guid.NewGuid() + Path.GetExtension(PPTFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await PPTFile.CopyToAsync(stream);
                        }
                        obj.pptPath = fileName;
                    }
                    if (FdrEstimateFile != null)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("ProposalLetter").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        var fileName = Guid.NewGuid() + Path.GetExtension(FdrEstimateFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await FdrEstimateFile.CopyToAsync(stream);
                        }
                        obj.fdrPath = fileName;
                    }
                    if (MaplayoutFile != null)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("ProposalLetter").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        var fileName = Guid.NewGuid() + Path.GetExtension(MaplayoutFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await MaplayoutFile.CopyToAsync(stream);
                        }
                        obj.mapPath = fileName;
                    }
                    if (DesignLayoutFile != null)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("ProposalLetter").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        var fileName = Guid.NewGuid() + Path.GetExtension(DesignLayoutFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await DesignLayoutFile.CopyToAsync(stream);
                        }
                        obj.designLayout = fileName;
                    }
                    
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Proposal/SaveFDRDetails", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    x = JsonResponse.data;

                    if (x == 1 || x == 2)
                    {
                        return Json(new { sucess = true, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "Success", data = "" });
                    }
                    else if (x == 4)
                    {
                        return Json(new { sucess = false, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "Fail", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Something went wrong!", responseText = "Fail", data = "" });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<JsonResult> GetProposalFDRByID(int Id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    HttpResponseMessage resNew = await client.GetAsync(url + "/Proposal/GetProposalFDRByID?Id=" + Id + "");
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        [HttpGet]
        public async Task<JsonResult> Get_M_Project_Category_Master()
        {
            try
            {
                var data = JsonConvert.DeserializeObject<List<ProjectCategory>>(await client.GetStringAsync(url + "/Master/Get_M_Project_Category_Master"));
                return Json(JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
