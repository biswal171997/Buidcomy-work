using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace BUIDCo_ePMS.Web.Controllers
{
    public class TechnicalBidController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        readonly ServerSideValidation cl = new();
        Uri url;
        readonly IConfiguration _configuration;
        HttpClient client;
        private readonly UserContextService _userContextService;
        public TechnicalBidController(IWebHostEnvironment hostingEnvironment, IHttpClientFactory httpClientFactory, IConfiguration Configuration, UserContextService userContextService)
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
        public async Task<IActionResult> TechnicalBidView()
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
                        var data = JsonConvert.DeserializeObject<List<ViewTechnicalBidModelEF>>(await client.GetStringAsync(url + "/TechnicalBidAPI/ViewtechnicalBid"));
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
        public IActionResult TechnicalBidDetails()
        {
            return View();
        }
        public async Task<IActionResult> Getprojects_and_Biddersdts(int Id)
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
                        HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/TechnicalBidAPI/GetProject_and_Bidders/" + Id).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            string errorResponse = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Error Response: " + errorResponse);
                        }
                        string jsonData = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<List<ViewProject_and_Bidders>>(jsonData);
                        return Json(list);
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
        public async Task<IActionResult> Save_TechnicalBid( TechnicalBidModelEF model,IFormFile? IformFiletechnicalPath)
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
                    //File Upload of technical Bid Document
                    if (IformFiletechnicalPath != null && IformFiletechnicalPath.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("TechnicalBid").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        var fileName = Guid.NewGuid() + IformFiletechnicalPath.FileName;
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await IformFiletechnicalPath.CopyToAsync(stream);
                        }
                        model.technicalDocPath = fileName;
                        IformFiletechnicalPath = null;
                    }
                    //END File Upload of NIT Document

                    var user = HttpContext.User;
                    if (user.Identity!.IsAuthenticated)
                    {
                        model.createdBy = Convert.ToInt32(_userContextService.UserId);
                    }
                    HttpResponseMessage resNew = await client.PostAsync(url + "/TechnicalBidAPI/Save_TechnicalBid", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

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
        public async Task<JsonResult> GettechnicalBidDetailsById(int Id)
        {

            List<ViewTechnicalBidModelEF> lst = new List<ViewTechnicalBidModelEF>();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/TechnicalBidAPI/GettechnicalBidDetailsById/" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<List<ViewTechnicalBidModelEF>>(data)!;
                    }
                    return Json(lst);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<JsonResult> EditTechnicalBidById(int Id)
        {

            List<ViewTechnicalBidModelEF> lst = new List<ViewTechnicalBidModelEF>();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/TechnicalBidAPI/EditTechnicalBidder/" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<List<ViewTechnicalBidModelEF>>(data)!;
                    }
                    return Json(lst);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<JsonResult> DeleteTechnicalBid(int Id)
        {

            TechnicalBidModelEF model = new TechnicalBidModelEF();

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
                    var user = HttpContext.User;
                    if (user.Identity!.IsAuthenticated)
                    {
                        model.createdBy = Convert.ToInt32(_userContextService.UserId);
                    }
                    model.ID = Id;

                    HttpResponseMessage response = await client.PostAsync(url + "/TechnicalBidAPI/DeleteTechnicalBid", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
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
        public IActionResult DownloadPdf(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("Invalid file name.");
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("TechnicalBid").Value!, fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var contentType = "application/pdf";
            return File(fileBytes, contentType, fileName);
        }
    }
}
