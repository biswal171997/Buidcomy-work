using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model.Entities.Proposal;
using BUIDCo_ePMS.Model.Entities.TSApproval;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;

namespace BUIDCo_ePMS.Web.Controllers
{
    [Authorize]
    public class TechnicalSanctionApprovalController : Controller
    {
        readonly Uri? url;
        readonly HttpClient client;
        readonly IConfiguration _configuration;
        readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly UserContextService _userContextService;
        public TechnicalSanctionApprovalController(IHttpClientFactory httpClientFactory, IConfiguration configuration, IWebHostEnvironment webHostEnvironment, UserContextService userContextService)
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
        public IActionResult SanctionApprovalView()
        {
            return View();
        }
        public IActionResult SanctionApprovalDetails()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<JsonResult> UploadTSInformation(TSApprovalUpload obj, IFormFile signedTSLetterFile, IFormFile boqFile)
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
                    if (signedTSLetterFile != null)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("TSLetter").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        var fileName = Guid.NewGuid() + Path.GetExtension(signedTSLetterFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await signedTSLetterFile.CopyToAsync(stream);
                        }
                        obj.signedTSLetterPath = fileName;
                    }
                    if (boqFile != null)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("TSOtherDoc").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        var fileName = Guid.NewGuid() + Path.GetExtension(boqFile.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await boqFile.CopyToAsync(stream);
                        }
                        obj.boqPath = fileName;
                    }
                    HttpResponseMessage resNew = await client.PostAsync(url + "/TSApproval/UploadTSInformation", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
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
        [HttpGet]
        public async Task<JsonResult> GetTSDetails(string? searchtype)
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
                    HttpResponseMessage resNew = await client.GetAsync(url + "/TSApproval/GetTSDetails?searchtype=" + searchtype + "");
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
        public async Task<JsonResult> GetTSApprovalByID(int Id)
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
                    HttpResponseMessage resNew = await client.GetAsync(url + "/TSApproval/GetTSApprovalByID?Id=" + Id + "");
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
