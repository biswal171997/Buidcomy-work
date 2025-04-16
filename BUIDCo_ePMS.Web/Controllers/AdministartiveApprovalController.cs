using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model.Entities.AdministartiveApproval;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using BUIDCo_ePMS.Model.Entities.CreateProject;
using static BUIDCo_ePMS.Core.Net;
using static BUIDCo_ePMS.Web.Controllers.TechnicalApprovalController;
using BUIDCo_ePMS.Model.Entities.TAapproval;
using Newtonsoft.Json.Serialization;

namespace BUIDCo_ePMS.Web.Controllers
{

    public class AdministartiveApprovalController : Controller
    {

        Uri url;
        readonly HttpClient client;
        private readonly UserContextService _userContextService;
        //IAdministartiveApproval _objAdministrativeApproval;
        readonly IConfiguration _configuration;

        public AdministartiveApprovalController(IHttpClientFactory httpClientFactory, IConfiguration Configuration, UserContextService userContextService)
        {
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
        [HttpGet]
        public async Task<IActionResult> AdministrativeList()
        {
            var user = HttpContext.User; // Get the current user
            if (!user.Identity.IsAuthenticated)
            {
                return Json(new { success = false, responseMessage = "User is not authenticated.", responseText = "Access Denied", data = "" });
            }
            var data = JsonConvert.DeserializeObject<List<AdminApprovalViewEF>>(await client.GetStringAsync(url + "/AdministartiveApproval/GetAARecords"));
            return View(data);
        }

        public IActionResult AdministrativeView()
        {
            return View();
        }

        public IActionResult AAGenerateLetter(int ProposalId)
        {
            ViewBag.ProposalId = ProposalId;
            return View();
        }
        public IActionResult UploadAdminstrativeApproval()
        {
            return View();
        }






        [HttpPost("AAGeneratePDF")]
        public async Task<IActionResult> AAGeneratePDF([FromBody] GeneratePdfRequest request1)
        {
            int x;
            AdminApprovalSaveEF obj = new AdminApprovalSaveEF();
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
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("AAGeneratedLetter").Value!);
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Generate unique PDF file name
                var fileName = Guid.NewGuid() + "_AALetter" + ".pdf";
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
                obj.ProposalId = Convert.ToInt32(proposalId);

                obj.Action = "A";
                var user = HttpContext.User; // Get the current user

                if (user.Identity.IsAuthenticated) // Check if the user is authenticated
                {
                    obj.AACreatedBy = Convert.ToInt32(_userContextService.UserId);


                }
                // Create directory if not exists


                // Create PDF

                obj.AALetterPath = fileName;
                //obj.Status = 0;
                obj.AALetterDate = DateTime.Now.ToShortDateString();

                using (var content = new MultipartFormDataContent())
                {
                    // Add text fields
                    content.Add(new StringContent(obj.Action), "Action");
                    content.Add(new StringContent(obj.ProposalId?.ToString() ?? ""), "ProposalID");
                    content.Add(new StringContent(obj.AALetterPath?.ToString() ?? ""), "AALetterPath");
                    content.Add(new StringContent(obj.AALetterDate?.ToString() ?? ""), "AALetterDate");
                    content.Add(new StringContent(obj.AACreatedBy?.ToString() ?? ""), "AACreatedBy");
                    //content.Add(new StringContent(obj.Status?.ToString() ?? ""), "Status");

                    var request = new HttpRequestMessage(HttpMethod.Post, url + "/AdministartiveApproval/SaveAADetails")
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

        [HttpGet("GetSavedTADetails")]
        public async Task<JsonResult> GetSavedTADetails(int ProposalId)
        {
            AdminApprovalSaveEF lst = new AdminApprovalSaveEF();
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
                    var data = JsonConvert.DeserializeObject<AdminApprovalSaveEF>(await client.GetStringAsync(url + "/AdministartiveApproval/GetSavedTADetails?ProposalId=" + ProposalId));
                    return Json(data);

                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetSchemeList")]
        public async Task<JsonResult> GetSchemeList()
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

                        var data = JsonConvert.DeserializeObject<List<DropdownList>>(await client.GetStringAsync(url + "/AdministartiveApproval/GetSchemeList"));
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
        public async Task<IActionResult> Save_AAUpload_Details(AdminApprovalSaveEF Model, IFormFile? fileSignedAALetter, IFormFile? fileAAOtherDocument)
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

                    Model.AACreatedBy = Convert.ToInt32(_userContextService.UserId);
                    //File Upload of Revised Amount Document
                    if (fileSignedAALetter != null && fileSignedAALetter.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("AAGeneratedLetter").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        var fileName = Guid.NewGuid() + "_AASignedLetter" + ".pdf";//fileReviseDocument.FileName;
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await fileSignedAALetter.CopyToAsync(stream);
                        }
                        Model.AALetterPath = fileName;
                        fileSignedAALetter = null;
                    }

                    if (fileAAOtherDocument != null && fileAAOtherDocument.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("AAOtherDocument").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        var fileName = Guid.NewGuid() + "_AAOtherDocument" + ".pdf";//fileReviseDocument.FileName;
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await fileAAOtherDocument.CopyToAsync(stream);
                        }
                        Model.AAOtherDocuemntPath = fileName;
                        fileAAOtherDocument = null;
                    }
                    var groups = Model.ProjectDetailsList!.TrimEnd('^').Split('^')
                         .Select(g => g.Split('|'))
                         .ToList();
                    string[] propertyNames = { "projectpart", "description","amount" };
                    var jsonObjects = groups.Select(g => new Dictionary<string, string>
                    {
                        { propertyNames[0], g.Length > 0 ? g[0] : "N/A" },  // Default "N/A" if missing
                        { propertyNames[1], g.Length > 1 ? g[1] : "N/A" },
                        { propertyNames[2], g.Length > 2 ? g[2] : "N/A" }
                    }).ToList();
                    // Convert to JSON format
                    string jsonString = JsonConvert.SerializeObject(jsonObjects);
                    Model.ProjectDetailsList = null;
                    Model.ProjectDetailsList = jsonString;

                    Model.Action = "B";

                    HttpResponseMessage resNew = await client.PostAsync(url + "/AdministartiveApproval/SaveAAUploadDetails", new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json"));

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

        public IActionResult DownloadPdf(string fileName,string rootpath)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("Invalid file name.");
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection(rootpath).Value!, fileName);
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
