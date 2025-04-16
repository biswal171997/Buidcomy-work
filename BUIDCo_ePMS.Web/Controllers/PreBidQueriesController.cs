using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;

namespace BUIDCo_ePMS.Web.Controllers
{
    public class PreBidQueriesController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        readonly ServerSideValidation cl = new();
        Uri url;
        readonly IConfiguration _configuration;
        HttpClient client;
        private readonly UserContextService _userContextService;
        public PreBidQueriesController(IWebHostEnvironment hostingEnvironment, IHttpClientFactory httpClientFactory, IConfiguration Configuration, UserContextService userContextService)
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

        public async Task<IActionResult> PreBidQueryView()
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
                        var data = JsonConvert.DeserializeObject<List<PreBidQueriesModelEF>>(await client.GetStringAsync(url + "/PreBidQueriesAPI/ViewPreBidQueries"));
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

        public IActionResult PreBidQueryDetails()
        {
            return View();
        }
        public async Task<ActionResult> Save_TENDER_PreBidQuriues(PreBidQueriesModelEF Model, IFormFile? PreBidExcelDoc,IFormFile? PreBidpdfDoc)
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
                    //File Upload of Pre Bid Document
                    if (PreBidExcelDoc != null && PreBidExcelDoc.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("PreBidQueriesDoc").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        var fileName = Guid.NewGuid() + PreBidExcelDoc.FileName;
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await PreBidExcelDoc.CopyToAsync(stream);
                        }
                        Model.preBidexcelDoc = fileName;
                        PreBidExcelDoc = null;
                    }
                    if (PreBidpdfDoc != null && PreBidpdfDoc.Length > 0) {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("PreBidQueriesDoc").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        var fileName = Guid.NewGuid() + PreBidpdfDoc.FileName;
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await PreBidpdfDoc.CopyToAsync(stream);
                        }
                        Model.preBidpdfDoc = fileName;
                        PreBidpdfDoc = null;
                    }
                    //END File Upload of NIT Document

                    var user = HttpContext.User;
                    if (user.Identity!.IsAuthenticated)
                    {
                        Model.createdBy = Convert.ToInt32(_userContextService.UserId);
                    }
                    HttpResponseMessage resNew = await client.PostAsync(url + "/PreBidQueriesAPI/SaveTenderPreBidQueries", new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json"));

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
       
        public async Task<JsonResult> GetPreBidQueriesById(int Id)
        {

            PreBidQueriesModelEF lst = new PreBidQueriesModelEF();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/PreBidQueriesAPI/GetPreBidQueriesById/" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<PreBidQueriesModelEF>(data)!;
                    }

                    var jsonres = JsonConvert.SerializeObject(lst);
                    return Json(jsonres);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<JsonResult> DeletePreBidQueries(int Id)
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
                    HttpResponseMessage response = await client.PostAsync(url + "/PreBidQueriesAPI/DeletepreBidqueries", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
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
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("PreBidQueriesDoc").Value!, fileName);
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
