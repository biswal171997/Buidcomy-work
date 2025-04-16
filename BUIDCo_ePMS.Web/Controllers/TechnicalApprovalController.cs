using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model.Entities.TAapproval;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Policy;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.CreateProject;
using BUIDCo_ePMS.Model.Entities.CreateProject;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TAapproval;
using BUIDCo_ePMS.Model.M_SubMileStone_Master;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Http.Headers;
using iTextSharp.text.html.simpleparser;
using BUIDCo_ePMS.Model.Entities.ProjectTender;
using static BUIDCo_ePMS.Core.Net;
using iTextSharp.tool.xml;
using System.IO;
using System.Text;
using Newtonsoft.Json.Serialization;
using BUIDCO.Domain.AdminConsole.User_Management;
namespace BUIDCo_ePMS.Web.Controllers
{
    public class TechnicalApprovalController : Controller
    {
        private readonly IWebHostEnvironment _WebHostEnvironment;
        Uri url;
        readonly HttpClient client;
        readonly IConfiguration _configuration;
        ICreateProject _objCreateObject;
        private readonly UserContextService _userContextService;
        public TechnicalApprovalController(IHttpClientFactory httpClientFactory, IConfiguration Configuration, ICreateProject objCreateObject, IWebHostEnvironment webHostEnvironment, UserContextService userContextService)
        {
            var factoryClient = httpClientFactory.CreateClient("MyApiClient");
            client = new HttpClient();
            client.BaseAddress = factoryClient.BaseAddress;
            url = client.BaseAddress!;
            _configuration = Configuration;
            _objCreateObject = objCreateObject;
            _WebHostEnvironment = webHostEnvironment;
            _userContextService = userContextService;
            var token = _userContextService.Token;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TAGenerateLetter(int Proposalid)
        {
           
            return View();
        }
        public IActionResult TechnicalApproval()
        {

            return View();
        }
        public async Task<ActionResult> SearchApproval(TASearchEF obj)
        {

            

            try
            {
                // 1️⃣ Validate Model State
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));

                    return Json(new
                    {
                        success = true,
                        responseMessage = message,
                        responseText = "Model State is invalid",
                        data = ""
                    });
                }
                var user = HttpContext.User; // Get the current user
                if (user.Identity.IsAuthenticated) // Check if the user is authenticated
                {
                    obj.CreatedBy = Convert.ToInt32(_userContextService.UserId);


                }

                // 2️⃣ Convert Object to JSON for API Request

                HttpResponseMessage response = await client.PostAsync(url + "/TAapprovalAPI/GetTAapplicationDetails", new StringContent(JsonConvert.SerializeObject(obj),
Encoding.UTF8, "application/json"));


                string errorResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error Response: " + errorResponse);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<List<TAViewEF>>(responseContent);
                   
                    return Json(data);

                   
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        responseMessage = "No records found.",
                        responseText = "",
                        data = ""
                    });
                }


            }
            catch (Exception e)
            {
                return Json(new
                {
                    success = false,
                    responseMessage = "Exception Occurred",
                    responseText = e.Message,
                    data = ""
                });
            }
        }

        public IActionResult ViewTechnicalApproval()
        {
            return View();
        }


        [HttpPost("GeneratePDF")]
        public async Task<IActionResult> GeneratePDF([FromBody] GeneratePdfRequest request1)
        {
            int x;
            TAApprovalSave obj = new TAApprovalSave();
            try
            {
                if (request1 == null || string.IsNullOrEmpty(request1.ProposalId) || string.IsNullOrEmpty(request1.HtmlContent))
                {
                    return BadRequest(new { success = false, responseText = "Invalid data", responseMessage = "ProposalId or HtmlContent is missing." });
                }

                string proposalId = request1.ProposalId;
                string htmlContent = request1.HtmlContent;
                if (string.IsNullOrEmpty(htmlContent))
                {
                    return BadRequest("Invalid data.");
                }
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("TALetter").Value!);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate unique PDF file name
                var fileName = Guid.NewGuid() + "_TALetter" + ".pdf";
                var filePath = Path.Combine(uploadsFolder, fileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Document document = new Document(PageSize.A4, 50, 50, 25, 25);
                    PdfWriter writer = PdfWriter.GetInstance(document, fileStream);
                    document.Open();

                    using (StringReader reader = new StringReader(htmlContent))
                    {
                        HTMLWorker htmlParser = new HTMLWorker(document);
                        htmlParser.Parse(reader);
                    }

                    document.Close();
                }
                obj.ProposalID = Convert.ToInt32(proposalId);

                obj.Action = "A";
                var user = HttpContext.User; // Get the current user

                if (user.Identity.IsAuthenticated) // Check if the user is authenticated
                {
                    obj.Createdby = Convert.ToInt32(_userContextService.UserId);


                }
                // Create directory if not exists


                // Create PDF

                obj.TAletterPath = fileName;
                obj.Status = 0;
                obj.TAletterDate = DateTime.Now.ToShortDateString();

                using (var content = new MultipartFormDataContent())
                {
                    // Add text fields
                    content.Add(new StringContent(obj.Action), "Action");
                    content.Add(new StringContent(obj.ProposalID?.ToString() ?? ""), "ProposalID");
                    content.Add(new StringContent(obj.TAletterPath?.ToString() ?? ""), "TAletterPath");
                    content.Add(new StringContent(obj.TAletterDate?.ToString() ?? ""), "TAletterDate");
                    content.Add(new StringContent(obj.Createdby?.ToString() ?? ""), "Createdby");
                    content.Add(new StringContent(obj.Status?.ToString() ?? ""), "Status");

                    var request = new HttpRequestMessage(HttpMethod.Post, url + "/TAapprovalAPI/SaveTADetails")
                    {
                        Content = content
                    };

                    HttpResponseMessage resNew = await client.SendAsync(request);

                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    x = JsonResponse.data;
                    if (x == 5)
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
                //    HttpResponseMessage resNew = await client.PostAsync(url + "/TAapprovalAPI/SaveTADetails", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));

                //string data = resNew.Content.ReadAsStringAsync().Result;
                //dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                //x = JsonResponse.data;

                //if (x == 5)
                //{
                //    return Json(new { sucess = true, responseMessage = "TA " + MessageHandler.GetMessageDescription(x), responseText = "success", data = "" });
                //}
                //else if (x == 4)
                //{
                //    return Json(new { sucess = false, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "error", data = "" });
                //}
                //else
                //{
                //    return Json(new { sucess = false, responseMessage = "Something went wrong!", responseText = "error", data = "" });
                //}

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        public class GeneratePdfRequest
        {
            public string ProposalId { get; set; }
            public string HtmlContent { get; set; }
        }
        public async Task<JsonResult> EditTADetails(int Id)
        {
            TASearchEF obj = new TASearchEF();
            TAViewEF lst = new TAViewEF();

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
                    HttpResponseMessage response = await client.PostAsync(url + "/TAapprovalAPI/GetTAapplicationDetails", new StringContent(JsonConvert.SerializeObject(obj),
Encoding.UTF8, "application/json"));
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<TAViewEF>(data)!;
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


        public async Task<JsonResult> GetProposalDetails(int Id)
        {
            TASearchEF obj = new TASearchEF();
            List<TAViewEF> lst = new List<TAViewEF>();

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
                    obj.TAId = Id;
                    var user = HttpContext.User; // Get the current user

                    if (user.Identity.IsAuthenticated) // Check if the user is authenticated
                    {
                        obj.CreatedBy = Convert.ToInt32(_userContextService.UserId);


                    }
                    HttpResponseMessage response = await client.PostAsync(url + "/TAapprovalAPI/GetTAapplicationDetails", new StringContent(JsonConvert.SerializeObject(obj),
Encoding.UTF8, "application/json"));
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonData = await response.Content.ReadAsStringAsync();
                        lst = JsonConvert.DeserializeObject<List<TAViewEF>>(jsonData);

                        if (lst == null || lst.Count == 0)
                        {
                            return Json(new { success = false, message = "No data found", data = "" });
                        }

                        // Return a single object if needed
                        return Json(new { success = true, data = lst.FirstOrDefault() });

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
        [HttpGet]
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


        public async Task<IActionResult> SaveTA( TAApprovalSave ta)
        {
            int x = 0;
            try
            {
                
                    string taletter = string.Empty;
                if (ta.LetterUpload != null && ta.LetterUpload.Length > 0)
                {
                    taletter = await SaveFile(ta.LetterUpload, "TALetter");
                    ta.TAletterPath = taletter;
                    ta.LetterUpload = null;
                }

                string taNazari = string.Empty;
                if (ta.NazariMapUpload != null && ta.NazariMapUpload.Length > 0)
                {
                    taNazari = await SaveFile(ta.NazariMapUpload, "TANazari");
                    ta.NazariMap = taNazari;
                    ta.NazariMapUpload = null;
                }
                string taDrawing = string.Empty;
                if (ta.DrawingUpload != null && ta.DrawingUpload.Length > 0)
                {
                    taDrawing = await SaveFile(ta.DrawingUpload, "TADesign");
                    ta.DrawingPath = taDrawing;
                    ta.DrawingUpload = null;
                }
                string taotherDoc = string.Empty;
                if (ta.OtherDocUpload != null && ta.OtherDocUpload.Length > 0)
                {
                    taotherDoc = await SaveFile(ta.OtherDocUpload, "TAOtherDoc");
                    ta.OtherDocPath = taotherDoc;
                    ta.OtherDocUpload = null;
                }




                ta.Action = "B";
                var user = HttpContext.User; // Get the current user

                if (user.Identity.IsAuthenticated) // Check if the user is authenticated
                {
                    ta.Createdby = Convert.ToInt32(_userContextService.UserId);


                }

                using (var content = new MultipartFormDataContent())
                {
                    // Add text fields
                    content.Add(new StringContent(ta.Action), "Action");
                    content.Add(new StringContent(ta.TAid?.ToString() ?? ""), "TAid");
                    content.Add(new StringContent(ta.ProposalID?.ToString() ?? ""), "ProposalID");
                    content.Add(new StringContent(ta.TAletterPath?.ToString() ?? ""), "TAletterPath");
                    content.Add(new StringContent(ta.DrawingPath?.ToString() ?? ""), "DrawingPath");
                    content.Add(new StringContent(ta.NazariMap?.ToString() ?? ""), "NazariMap");
                    content.Add(new StringContent(ta.OtherDocPath?.ToString() ?? ""), "OtherDocPath");
                    content.Add(new StringContent(ta.TAletterNo?.ToString() ?? ""), "TAletterNo");
                    content.Add(new StringContent(ta.TAletterDate?.ToString() ?? ""), "TAletterDate");
                    content.Add(new StringContent(ta.EstimattedCost?.ToString() ?? ""), "EstimattedCost");
                    content.Add(new StringContent(ta.Remarks?.ToString() ?? ""), "Remarks");
                    content.Add(new StringContent(ta.Createdby?.ToString() ?? ""), "Createdby");
                    content.Add(new StringContent(ta.Status?.ToString() ?? ""), "Status");
                        
                    var request = new HttpRequestMessage(HttpMethod.Post, url + "/TAapprovalAPI/SaveTADetails")
                    {
                        Content = content
                    };

                    HttpResponseMessage resNew = await client.SendAsync(request);

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

                    return Json(new { success = false });
                    //{

                    //    ContractResolver = new CamelCasePropertyNamesContractResolver()

                    //});

                    // HttpResponseMessage resNew = await client.PostAsync(url + "/TAapprovalAPI/SaveTADetails", new StringContent(json, Encoding.UTF8, "application/json"));
                    //    var jsonData = JsonConvert.SerializeObject(ta);
                    //var request = new HttpRequestMessage(HttpMethod.Post, url + "/TAapprovalAPI/SaveTADetails")
                    //{
                    //    Content = new StringContent(jsonData, Encoding.UTF8, "application/json")
                    //};
                    //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Optional

                    //HttpResponseMessage resNew = await client.SendAsync(request);
                    ////HttpResponseMessage resNew = await client.PostAsync(url + "/TAapprovalAPI/SaveTADetails", new StringContent(JsonConvert.SerializeObject(ta), Encoding.UTF8, "application/json"));
                    //string data = resNew.Content.ReadAsStringAsync().Result;
                    //dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    //x = JsonResponse.data;

                    //if (x == 1 || x == 2)
                    //{
                    //    return Json(new { sucess = true, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "success", data = "" });
                    //}
                    //else if (x == 4)
                    //{
                    //    return Json(new { sucess = false, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "error", data = "" });
                    //}
                    //else
                    //{
                    //    return Json(new { sucess = false, responseMessage = "Something went wrong!", responseText = "error", data = "" });
                    //}

                    //return Json(new { success = false });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        public async Task<string> SaveFile(IFormFile file,string filePath)
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


    }
}
