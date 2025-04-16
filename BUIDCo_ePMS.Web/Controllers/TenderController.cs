using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Model.M_MileStone_Master;
using BUIDCo_ePMS.Model.M_SubMileStone_Master;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Configuration;
using System.Security.Policy;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BUIDCo_ePMS.Web.Controllers
{
    public class TenderController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        readonly ServerSideValidation cl = new();
        Uri url;
        readonly IConfiguration _configuration;
        HttpClient client;
        public TenderController(IWebHostEnvironment hostingEnvironment, IHttpClientFactory httpClientFactory, IConfiguration Configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            var factoryClient = httpClientFactory.CreateClient("MyApiClient");
            client = new HttpClient();
            client.BaseAddress = factoryClient.BaseAddress;
            url = client.BaseAddress;
            _configuration = Configuration;
        }
        public async Task<JsonResult> GetProjectName([FromBody] string VCH_PRO)
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
                        HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ProjectTenderAPI/GetProjectName/" + VCH_PRO).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            string errorResponse = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Error Response: " + errorResponse);
                        }
                        string jsonData = await response.Content.ReadAsStringAsync();
                        var milestoneList = JsonConvert.DeserializeObject<List<Projects>>(jsonData);
                        return Json(milestoneList);
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
        public async Task<JsonResult> GetProjectDetailsById(int PId)
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
                        HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ProjectTenderAPI/GetProjectDetailsById/" + PId).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            string errorResponse = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Error Response: " + errorResponse);
                        }
                        string jsonData = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<Projects>(jsonData);
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
        public IActionResult NewTenderView()
        {
            return View();
        }

        public IActionResult NewTenderDetails()
        {
            return View();
        }
        public async Task<IActionResult> SAVE_PROJECT_TENDER(ProjectTenderEF Model, IFormFile? nitDocpathFile)
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
                    //File Upload of NIT Document
                    if (nitDocpathFile != null && nitDocpathFile.Length > 0)
                    {
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("NITDoc").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }

                        var fileName = Guid.NewGuid() + nitDocpathFile.FileName;
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await nitDocpathFile.CopyToAsync(stream);
                        }
                        Model.nitDocFileName = fileName;
                        nitDocpathFile = null;
                    }
                    //END File Upload of NIT Document
                    HttpResponseMessage resNew = await client.PostAsync(url + "/ProjectTenderAPI/SaveProjectTender", new StringContent(JsonConvert.SerializeObject(Model), Encoding.UTF8, "application/json"));

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

        [HttpGet]
        public async Task<JsonResult> Get_M_Project_Tender()
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
                        var data = JsonConvert.DeserializeObject<List<ViewProjectTenderEF>>(await client.GetStringAsync(url + "/ProjectTenderAPI/Get_M_Project_Tender"));
                        return Json(JsonConvert.SerializeObject(data));
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

        public async Task<JsonResult> Get_Project_TenderById(int Id)
        {

            ViewProjectTenderEF lst = new ViewProjectTenderEF();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ProjectTenderAPI/GetTenderDetailsById?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<ViewProjectTenderEF>(data)!;
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

        [HttpPost]
        public async Task<JsonResult> Delete_Project_Tender(int Id)
        {
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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ProjectTenderAPI/DeleteProjectTender/" + Id).Result;
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
            catch (Exception e)
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
            var possibleFolders = new List<string>
            {
                _configuration.GetSection("Path").GetSection("NITDoc").Value!,
                _configuration.GetSection("Path").GetSection("AddendumDoc").Value!,
                _configuration.GetSection("Path").GetSection("CorrigendumDoc").Value!
            };
            string? filePath = null;
            foreach (var folder in possibleFolders)
            {
                var fullPath = Path.Combine(folder, fileName);
                if (System.IO.File.Exists(fullPath))
                {
                    filePath = fullPath;
                    break;
                }
            }
            if (filePath == null)
            {
                return NotFound("File not found.");
            }
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var contentType = "application/pdf";
            return File(fileBytes, contentType, fileName);
        }
        public async Task<JsonResult> GetUserName()
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
                        var data = JsonConvert.DeserializeObject<List<UserMasterModelEF>>(await client.GetStringAsync(url + "/ProjectTenderAPI/GetUserName"));
                        return Json(JsonConvert.SerializeObject(data));
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
        [HttpPost]
        public async Task<IActionResult> Save_PROJECT_TENDER_CORRIGENDUM(ProjectTenderCorrigendumEF model, IFormFile? corrigendumIfromFile)
        {
            int x;
            model.createdBy = 1;
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
                    //File Upload of NIT Document
                    if (corrigendumIfromFile != null && corrigendumIfromFile.Length > 0)
                    {
                        if (model.corrigendumType == "1")
                        {
                            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("CorrigendumDoc").Value!);
                            if (!Directory.Exists(uploadsFolder))
                            {
                                Directory.CreateDirectory(uploadsFolder);
                            }

                            var fileName = Guid.NewGuid() + corrigendumIfromFile.FileName;
                            var filePath = Path.Combine(uploadsFolder, fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await corrigendumIfromFile.CopyToAsync(stream);
                            }
                            model.corrigendumFileName = fileName;
                            corrigendumIfromFile = null!;
                        }
                        else
                        {
                            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("AddendumDoc").Value!);
                            if (!Directory.Exists(uploadsFolder))
                            {
                                Directory.CreateDirectory(uploadsFolder);
                            }

                            var fileName = Guid.NewGuid() + corrigendumIfromFile.FileName;
                            var filePath = Path.Combine(uploadsFolder, fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await corrigendumIfromFile.CopyToAsync(stream);
                            }
                            model.corrigendumFileName = fileName;
                            corrigendumIfromFile = null!;
                        }

                    }
                    //END File Upload of NIT Document

                    var groups = model.CorrigendumList!.TrimEnd('^').Split('^')
                          .Select(g => g.Split('|'))
                          .ToList();
                    string[] propertyNames = { "refNo", "description" };
                    var jsonObjects = groups.Select(g => new Dictionary<string, string>
                    {
                        { propertyNames[0], g.Length > 0 ? g[0] : "N/A" },  // Default "N/A" if missing
                        { propertyNames[1], g.Length > 1 ? g[1] : "N/A" }
                    }).ToList();
                    // Convert to JSON format
                    string jsonString = JsonConvert.SerializeObject(jsonObjects);
                    model.CorrigendumList = null;
                    model.CorrigendumList = jsonString;


                    HttpResponseMessage resNew = await client.PostAsync(url + "/ProjectTenderAPI/SaveProjectTenderCorrigendum", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

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

        [HttpGet]
        public async Task<IActionResult> ViewProjectTenderCorrigendum(int tenderId)
        {
            //VewProjectTenderCorrigendumEF lst = new VewProjectTenderCorrigendumEF();

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


                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ProjectTenderAPI/ViewProjectTenderCorrigendum/" + tenderId).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Error Response: " + errorResponse);
                    }
                    string jsonData = await response.Content.ReadAsStringAsync();
                    var lst = JsonConvert.DeserializeObject<List<VewProjectTenderCorrigendumEF>>(jsonData)!;
                    return Json(lst);

                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<JsonResult> GetCorrigendumDtls(int Id)
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
                        HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ProjectTenderAPI/GetCorrigendumAddendumDetails/" + Id).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            string errorResponse = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Error Response: " + errorResponse);
                        }
                        string jsonData = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<List<ViewCorrigendumAddendumDetailsEF>>(jsonData);
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

        [HttpPost]
        public async Task<JsonResult> DeleteCorrigendum_Addendum(int Id)
        {
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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ProjectTenderAPI/DeleteCorrigendum/" + Id).Result;
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
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<IActionResult> EditCorrigendumAddendum(int Id)
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
                        HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/ProjectTenderAPI/EditCorrigendumAddendum/" + Id).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            string errorResponse = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Error Response: " + errorResponse);
                        }
                        string jsonData = await response.Content.ReadAsStringAsync();
                        var list = JsonConvert.DeserializeObject<VewProjectTenderCorrigendumEF>(jsonData);
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
    }
}
