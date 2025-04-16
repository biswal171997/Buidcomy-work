using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace BUIDCo_ePMS.Web.Controllers
{
    public class FinancialBidController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        readonly ServerSideValidation cl = new();
        Uri url;
        readonly IConfiguration _configuration;
        HttpClient client;
        private readonly UserContextService _userContextService;
        public FinancialBidController(IWebHostEnvironment hostingEnvironment, IHttpClientFactory httpClientFactory, IConfiguration Configuration, UserContextService userContextService)
        {
            _hostingEnvironment = hostingEnvironment;
            var factoryClient = httpClientFactory.CreateClient("MyApiClient");
            client = new HttpClient();
            client.BaseAddress = factoryClient.BaseAddress;
            url = client.BaseAddress;
            _configuration = Configuration;
            _userContextService = userContextService;
            var token = _userContextService.Token;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> FinancialBidView()
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
                    try
                    {
                        var data = JsonConvert.DeserializeObject<List<ViewFinancialBidModelEF>>(await client.GetStringAsync(url + "/FinancialBidAPI/ViewFinancialBid"));
                        return View(data);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult FinancialBidDetails()
        {
            return View();
        }
        public async Task<JsonResult> GetTechnicalBidders(int Id)
        {
            List<ViewFinancialBidModelEF> lst = new List<ViewFinancialBidModelEF>();
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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/FinancialBidAPI/GetTechnicalBidders/" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<List<ViewFinancialBidModelEF>>(data)!;
                    }
                    return Json(lst);
                }
    
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<JsonResult> SaveFinancialBid(FinancialBidModel model)
        {

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
                try
                {
                 
                    if(model.FiancialBidList!=null && model.FiancialBidList.Count() > 0)
                    {
                        foreach(var Mlist in model.FiancialBidList)
                        {
                            if (Mlist.IformfinancialBidDocFile != null && Mlist.IformfinancialBidDocFile.Length > 0)
                            {
                                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("FinancialBid").Value!);
                                if (!Directory.Exists(uploadsFolder))
                                {
                                    Directory.CreateDirectory(uploadsFolder);
                                }

                                var fileName = Guid.NewGuid() + Mlist.IformfinancialBidDocFile.FileName;
                                var filePath = Path.Combine(uploadsFolder, fileName);
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await Mlist.IformfinancialBidDocFile.CopyToAsync(stream);
                                }
                                Mlist.financialBidDocFile = fileName;
                                Mlist.IformfinancialBidDocFile = null;
                            }
                            if (Mlist.IformloaDocFile != null && Mlist.IformloaDocFile.Length > 0)
                            {
                                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("FinancialBid").Value!);
                                if (!Directory.Exists(uploadsFolder))
                                {
                                    Directory.CreateDirectory(uploadsFolder);
                                }

                                var fileName = Guid.NewGuid() + Mlist.IformloaDocFile.FileName;
                                var filePath = Path.Combine(uploadsFolder, fileName);
                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await Mlist.IformloaDocFile.CopyToAsync(stream);
                                }
                                Mlist.loaDocFile = fileName;
                                Mlist.IformloaDocFile = null;
                            }
                        }
                    }
                   
                    var user = HttpContext.User;
                    if (user.Identity!.IsAuthenticated)
                    {
                        model.createdBy = Convert.ToInt32(_userContextService.UserId);
                    }

                    string[] propertyNames = { "bidderID", "financialScore", "bidAmount", "financialBidDocFile", "loaDocFile", "winnerStatus" };

                    if (model.FiancialBidList != null && model.FiancialBidList.Count > 0)
                    {
                        var jsonObjects = model.FiancialBidList.Select(g => new Dictionary<string, string>
                        {
                            { propertyNames[0], g.bidderID > 0 ? g.bidderID.ToString() : "N/A" }, 
                            { propertyNames[1], g.financialScore.HasValue ? g.financialScore.Value.ToString("0.00") : "N/A" },
                            { propertyNames[2], g.bidAmount.HasValue ? g.bidAmount.Value.ToString("0.00") : "N/A" },
                            { propertyNames[3], !string.IsNullOrEmpty(g.financialBidDocFile) ? g.financialBidDocFile : "N/A" }, 
                            { propertyNames[4], !string.IsNullOrEmpty(g.loaDocFile) ? g.loaDocFile : "N/A" },
                              { propertyNames[5], g.winnerStatus.ToString() }
                        }).ToList();

                        string jsonString = JsonConvert.SerializeObject(jsonObjects);
                        model.JsonFinancialList = jsonString;
                    }
                    else
                    {
                        model.JsonFinancialList = "[]"; 
                    }

                    HttpResponseMessage resNew = await client.PostAsync(url + "/FinancialBidAPI/SaveFinancialBid", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    x = JsonResponse.data;

                    if (x == 1 || x == 2)
                    {
                        return Json(new { sucess = true, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "success", data = "" });
                    }
                    else if (x == 4)
                    {
                        return Json(new { sucess = false, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "error", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Something went wrong!", responseText = "error", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        public async Task<JsonResult> GetProjectBasicDetails(int Id)
        {
            List<ViewProject_and_Bidders> lst = new List<ViewProject_and_Bidders>();
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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/FinancialBidAPI/GetprojectBasicDetails/" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<List<ViewProject_and_Bidders>>(data)!;
                    }
                    return Json(lst);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<JsonResult> EditFinancialBid(int Id)
        {
            List<ViewFinancialBidModelEF> lst = new List<ViewFinancialBidModelEF>();
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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/FinancialBidAPI/EditFinancialBid/" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<List<ViewFinancialBidModelEF>>(data)!;
                    }
                    return Json(lst);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult DownloadPdf(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("Invalid file name.");
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("FinancialBid").Value!, fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var contentType = "application/pdf";
            return File(fileBytes, contentType, fileName);
        }
        public async Task<JsonResult> DeleteFinancialBid(int Id)
        {

            PreBidQueriesModelEF model = new PreBidQueriesModelEF();

            try
            {
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
                    model.Id = Id;
                    HttpResponseMessage response = await client.PostAsync(url + "/FinancialBidAPI/DeleteFinancialBid", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object(); ;
                        x = JsonResponse.data;
                        if (x == 3)
                        {
                            return Json(new { sucess = true, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "success", data = "" });
                        }
                        else
                        {
                            return Json(new { sucess = false, responseMessage = "Something went Wrong!", responseText = "Fail", data = "" });
                        }
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Something went Wrong!", responseText = "Fail", data = "" });
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<JsonResult> ViewFinanialDetails(int Id)
        {
            List<ViewFinancialBidModelEF> lst = new List<ViewFinancialBidModelEF>();
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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/FinancialBidAPI/ViewFinancialDetails/" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<List<ViewFinancialBidModelEF>>(data)!;
                    }
                    return Json(lst);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
