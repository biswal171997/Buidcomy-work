using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model.Entities.AssignProjectWork;
using BUIDCo_ePMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using System.Text;

namespace BUIDCo_ePMS.Web
{
    public class AssignProjectController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
    
        readonly ServerSideValidation cl = new();
        Uri url = new Uri("http://localhost/BUIDCo_ePMS_API/api");
       
        HttpClient client;
        readonly IConfiguration _configuration;
        public AssignProjectController(IWebHostEnvironment hostingEnvironment, IConfiguration configuration)

        {
            _hostingEnvironment = hostingEnvironment;
            client = new HttpClient();
            client.BaseAddress = url;
            _configuration = configuration;
        }
        public IActionResult _AddAssignProject()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveAssignProject([FromForm] AssignProject TBL)
        {
            int x;
            try
            {
               
                if (TBL.UploadLetterdoc != null && TBL.UploadLetterdoc.Length > 0)
                {
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("LetterDoc").Value!);
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var fileName = Guid.NewGuid() + TBL.UploadLetterdoc.FileName;
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await TBL.UploadLetterdoc.CopyToAsync(stream);
                    }
                    TBL.FilePath = fileName;
                    TBL.UploadPGDocumentPath = fileName;
                    
                }

                using (var content = new MultipartFormDataContent())
                {
                    // Add regular properties (non-file properties)
                    content.Add(new StringContent(TBL.id?.ToString() ?? ""), "id");
                    content.Add(new StringContent(TBL.tenderId?.ToString() ?? ""), "tenderId");
                    content.Add(new StringContent(TBL.hiddenProjectId.ToString()), "hiddenProjectId");
                    content.Add(new StringContent(TBL.AssignTo?.ToString() ?? ""), "AssignTo");
                    content.Add(new StringContent(TBL.AgreementAmount?.ToString() ?? ""), "AgreementAmount");
                    content.Add(new StringContent(TBL.bidderId?.ToString() ?? ""), "bidderId");
                    content.Add(new StringContent(TBL.panNo ?? ""), "panNo");
                    content.Add(new StringContent(TBL.gstNo ?? ""), "gstNo");
                    content.Add(new StringContent(TBL.licenseNo ?? ""), "licenseNo");
                   // content.Add(new StringContent(TBL.phoneNo ?? ""), "phoneNo");
                    content.Add(new StringContent(TBL.faxNo ?? ""), "faxNo");
                    content.Add(new StringContent(TBL.emailId ?? ""), "emailId");
                    content.Add(new StringContent(TBL.mobileNo ?? ""), "mobileNo");
                    content.Add(new StringContent(TBL.ContactNo ?? ""), "ContactNo");
                    content.Add(new StringContent(TBL.contactPerson ?? ""), "contactPerson");
                    content.Add(new StringContent(TBL.contactPersonMobileNumber ?? ""), "contactPersonMobileNumber");
                    content.Add(new StringContent(TBL.address ?? ""), "address");
                    content.Add(new StringContent(TBL.projectDuration?.ToString() ?? ""), "projectDuration");
                    content.Add(new StringContent(TBL.startDate?.ToString("yyyy-MM-dd") ?? ""), "startDate");
                    content.Add(new StringContent(TBL.endDate?.ToString("yyyy-MM-dd") ?? ""), "endDate");
                    if (TBL.UploadLetterdoc != null && TBL.UploadLetterdoc.Length > 0)
                    {
                       
                        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), _configuration.GetSection("Path").GetSection("LetterDoc").Value!);
                        if (!Directory.Exists(uploadsFolder))
                        {
                            Directory.CreateDirectory(uploadsFolder);
                        }
                        var fileName = Guid.NewGuid() + Path.GetExtension(TBL.UploadLetterdoc.FileName);
                        var filePath = Path.Combine(uploadsFolder, fileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await TBL.UploadLetterdoc.CopyToAsync(stream);
                        }
                      
                        content.Add(new StringContent(fileName), "letterDocpath");
                    }

                    if (TBL.bankdetailsList1 != null && TBL.bankdetailsList1.Count > 0)
                    {
                        var bankDetailsJson = JsonConvert.SerializeObject(TBL.bankdetailsList1);
                        content.Add(new StringContent(bankDetailsJson, Encoding.UTF8, "application/json"), "bankdetailsList1"); content.Add(new StringContent(bankDetailsJson, Encoding.UTF8, "application/json"), "bankdetailsList1");

                    }
                    HttpResponseMessage resNew = await client.PostAsync(url + "/AssignProject/SaveAssignProject", content);
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    if (JsonResponse.data != null)
                    {
                        x = Convert.ToInt32(JsonResponse.data.result);
                    }
                    else
                    {
                        x = 0;
                    }

                    if (x == 1 || x == 2)
                    {
                        return Json(new { success = true, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "success", data = "" });
                    }
                    else if (x == 4)
                    {
                        return Json(new { success = false, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "Fail", data = "" });
                    }
                    else
                    {
                        return Json(new { success = false, responseMessage = "Something went wrong!", responseText = "Fail", data = "" });
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseMessage = ex.Message, responseText = "Error", data = "" });
            }
        }
        public IActionResult AssignProjectView(AssignProject TBL)
        {
            return View();
        }
        public IActionResult AssignProjectDetails()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetAssignViewfilter(string projectTypeidS)
        {
            try
            {

                var allData = JsonConvert.DeserializeObject<List<ViewAssignProject>>(await client.GetStringAsync(url + "/AssignProject/GetallAssignProjectView"));

                if (allData == null)
                {

                    return Json(new { success = false, responseMessage = "Invalid data format" });
                }

                var filteredData = allData.Where(x => x.projectTypeid == Convert.ToInt32(projectTypeidS)).ToList();

                if (projectTypeidS == null || projectTypeidS == "" || projectTypeidS == "0")
                {
                    return Json(JsonConvert.SerializeObject(allData));
                }
                else
                {
                    return Json(JsonConvert.SerializeObject(filteredData));
                }

            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseMessage = ex.Message });
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetAssignProject()
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
                        var data = JsonConvert.DeserializeObject<List<ViewAssignProject>>(await client.GetStringAsync(url + "/AssignProject/GetallAssignProjectView"));
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
        public async Task<JsonResult> GetProjectList()
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
                        var data = JsonConvert.DeserializeObject<List<AssignProject>>(await client.GetStringAsync(url + "/AssignProject/GetAssignProjectList"));
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
        public async Task<JsonResult> DeleteAssignProject(string Id)
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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/AssignProject/DeleteAssignProject/" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object(); ;
                        x = JsonResponse.data;
                        if (x == 3)
                        {
                            return Json(new { sucess = false, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "success", data = "" });
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
        public async Task<JsonResult> GetAssignProjectById(int Id)
        {

            
            try
            {
                List<ViewAssignProject1> lst = new List<ViewAssignProject1>();
            
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/AssignProject/GetAssignProjectById/" + Id).Result;

                string errorResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                     lst = JsonConvert.DeserializeObject<List<ViewAssignProject1>>(data)!;
                }

                return Json(lst);


            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<JsonResult> ViewDetails(int Id)
        {
            List<AssignProject> lst = new List<AssignProject>();

            try
            {
               
                HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/AssignProject/ViewDetails/" + Id).Result;

                string errorResponse = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    lst = JsonConvert.DeserializeObject<List<AssignProject>>(data)!;
                }             
                return Json(lst);


            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<JsonResult> GetAssignToList(int PId)
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
                        HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/AssignProject/GetAssignToList/" + PId).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            string errorResponse = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Error Response: " + errorResponse);
                        }
                        string jsonData = await response.Content.ReadAsStringAsync();
                        var AssignList = JsonConvert.DeserializeObject<List<ViewBidderDetails>>(jsonData);
                        return Json(AssignList);
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

        public async Task<JsonResult> GetBankComponentList()
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
                        var data = JsonConvert.DeserializeObject<List<ViewBankComponent>>(await client.GetStringAsync(url + "/AssignProject/GetBankComponentList"));
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
    }
}













