using Azure;
using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Model.Entities.TakeAction;
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
    public class TakeActionController : Controller
    {
        readonly Uri? url;
        readonly HttpClient client;
        readonly IConfiguration _configuration;
        readonly IWebHostEnvironment _WebHostEnvironment;
        private readonly UserContextService _userContextService;
        public TakeActionController(IHttpClientFactory httpClientFactory, IConfiguration configuration, IWebHostEnvironment webHostEnvironment, UserContextService userContextService)
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
        public IActionResult TakeAction()
        {
            return View();
        }
        public async Task<JsonResult> GetActionPageDetails(int Id)
        {
            TakeActionSearch obj = new TakeActionSearch();
            TakeActionDetails lst = new TakeActionDetails();

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
                    obj.ProposalId = Id;
                    HttpResponseMessage response = await client.PostAsync(url + "/TakeActionAPI/GetActionPageDetails", new StringContent(JsonConvert.SerializeObject(obj),
Encoding.UTF8, "application/json"));
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = await response.Content.ReadAsStringAsync();
                        lst = JsonConvert.DeserializeObject<TakeActionDetails>(jsonData);

                        if (lst == null)
                        {
                            return Json(new { success = false, message = "No data found", data = "" });
                        }

                        // Return a single object if needed
                        return Json(new { success = true, data = lst });

                    }
                    else
                        return Json(new { success = false, message = "No data found", data = "" });
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult DownloadPdf(string fileName, string foldername)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("Invalid file name.");
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection(foldername).Value!, fileName);
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var contentType = "application/pdf";
            return File(fileBytes, contentType, fileName);
        }
        public async Task<string> SaveFile(IFormFile file, string filePath)
        {
            string fileName = string.Empty;

            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection(filePath).Value!);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                fileName = Guid.NewGuid() + Path.GetExtension(file.FileName); // Ensures correct file extension
                filePath = Path.Combine(uploadsFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return fileName; // Return filename properly
        }
        [HttpPost]

        public async Task<IActionResult> SaveTakeAction([FromForm] TakeActionSave model)
        {
            int x = 0;
            try
            {
                if (model == null)
                {
                    return BadRequest(new { success = false, message = "Invalid data." });
                }

                // ✅ File Handling (Ensure the file is saved properly)
                if (model.IformFile != null && model.IformFile.Length > 0)
                {
                    model.docPath = await SaveFile(model.IformFile, "TAActionDoc");
                }

                // ✅ User Authentication Check
                if (User.Identity != null && User.Identity.IsAuthenticated)
                {
                    model.CreatedBy = Convert.ToInt32(_userContextService.UserId);
                }
                else
                {
                    return Unauthorized(new { success = false, message = "User not authenticated." });
                }

                using (var content = new MultipartFormDataContent())
                {
                    // Add text fields
                    content.Add(new StringContent(model.ProposalId?.ToString() ?? ""), "ProposalId");
                    content.Add(new StringContent(model.ModuleId?.ToString() ?? ""), "ModuleId");
                    content.Add(new StringContent(model.Status?.ToString() ?? ""), "Status");
                    content.Add(new StringContent(model.Remarks?.ToString() ?? ""), "Remarks");

                    content.Add(new StringContent(model.docPath?.ToString() ?? ""), "docPath");

                    content.Add(new StringContent(model.CreatedBy?.ToString() ?? ""), "CreatedBy");


                    var request = new HttpRequestMessage(HttpMethod.Post, url + "/TakeActionAPI/SaveTakeAction")
                    {
                        Content = content
                    };

                    HttpResponseMessage resNew = await client.SendAsync(request);

                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    x = JsonResponse.data;
                    if (x == 6)
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

                    return Json(new { success = false });



                    // ✅ Simulating database save operation
                    var newRecord = new
                    {
                        model.ProposalId,
                        model.ModuleId,
                        model.Status,
                        model.Remarks,
                        model.docPath,
                        model.CreatedBy
                    };

                    return Ok(new { success = true, message = "Data saved successfully!", data = newRecord });


                }

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message

                });



            }
        }

    }
}
