using BUIDCo_ePMS.Model.categoryIdAdd;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

using Newtonsoft.Json.Linq;
using BUIDCo_ePMS.Model.M_Assembly_Master;
using BUIDCo_ePMS.Model.M_Assembly_Tagging;
using BUIDCo_ePMS.Model.M_Client_Master;
using BUIDCo_ePMS.Model.M_Constituency_Master;
using BUIDCo_ePMS.Model.M_Financial_Year;
using BUIDCo_ePMS.Model.M_MileStone_Master;
using BUIDCo_ePMS.Model.M_Module_Master;
using BUIDCo_ePMS.Model.M_Project_Part;
using BUIDCo_ePMS.Model.M_SubMileStone_Master;
using BUIDCo_ePMS.Model.M_Unit_Master;
using BUIDCo_ePMS.Model.Entities.Master;
using System.Data.SqlClient;
using BUIDCo_ePMS.Web.Models;
using static BUIDCo_ePMS.Core.Net;
using BUIDCo_ePMS.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Azure;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;
using System.Net.Http.Headers;
using BUIDCO.Domain.AdminConsole.User_Management;
using System.Reflection;
using System.Configuration;
namespace BUIDCo_ePMS.Web
{
    [Authorize]
    public class MasterController : Controller
    {

        private IWebHostEnvironment _hostingEnvironment;
        readonly ServerSideValidation cl = new();
        Uri url;// = new Uri("http://localhost/BUIDCo_ePMS_API/api");
        HttpClient client;
        private readonly UserContextService _userContextService;
        public MasterController(IWebHostEnvironment hostingEnvironment, IHttpClientFactory httpClientFactory, UserContextService userContextService)
        {
            _hostingEnvironment = hostingEnvironment;
            var factoryClient = httpClientFactory.CreateClient("MyApiClient");
            client = new HttpClient();
            client.BaseAddress = factoryClient.BaseAddress;
            url = client.BaseAddress;
            _userContextService = userContextService;
            var token = _userContextService.Token;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


        }
        public IActionResult AddDocument()
        {
            return View();
        }
        //[HttpGet]
        //public IActionResult M_Application_Status_Master()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult ApplicationStatusMaster()
        {
            
            return View();
        }


        //    [HttpPost]
        //    public async Task<IActionResult> M_Application_Status_Master(ApplicationStatus TBL)
        //    {

        //        if (!ModelState.IsValid)
        //        {
        //            var message = string.Join(" | ", ModelState.Values
        //             .SelectMany(v => v.Errors)
        //            .Select(e => e.ErrorMessage));
        //            return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
        //        }
        //        else
        //        {
        //            try
        //            {
        //                TBL.createdBy = 1;
        //                TBL.updatedBy = 1;
        //                HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Application_Status_Master", new StringContent(JsonConvert.SerializeObject(TBL),
        //Encoding.UTF8, "application/json"));

        //                if (TBL.statusId == 0)
        //                {
        //                    return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
        //                }
        //                else if (TBL.statusId > 0)
        //                {
        //                    return Json(new { sucess = false, responseMessage = "Updated Saved Successfully", responseText = "Success", data = "" });
        //                }
        //                else
        //                {
        //                    return Json(new { sucess = false, responseMessage = "Record Already Exist", responseText = "Fail", data = "" });
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }
        //        }

        //    }


        [HttpPost]
        public async Task<IActionResult> ApplicationStatusMaster(ApplicationStatus TBL)
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
                    TBL.createdBy = 1;
                    TBL.updatedBy = 1;
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Application_Status_Master", new StringContent(JsonConvert.SerializeObject(TBL),
    Encoding.UTF8, "application/json"));

                    if (TBL.statusId == 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                    }
                    else if (TBL.statusId > 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Updated Saved Successfully", responseText = "Success", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Record Already Exist", responseText = "Fail", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }






        [HttpGet]
        public IActionResult ViewM_Application_Status_Master()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_Application_Status_Master()
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
                        var data = JsonConvert.DeserializeObject<List<ApplicationStatus>>(await client.GetStringAsync(url + "/Master/Get_M_Application_Status_Master"));
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
        [HttpDelete]

        public async Task<JsonResult> Delete_M_Application_Status_Master(int Id)
        {

            try
            {
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
                    HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Master/Delete_M_Application_Status_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        x = JsonConvert.DeserializeObject<int>(data);
                    }
                    return Json(x);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Application_Status_Master(int Id)
        {
            ApplicationStatus lst = new ApplicationStatus();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Application_Status_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<ApplicationStatus>(data);
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


        [HttpGet]
        public IActionResult M_Assembly_Master()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> M_Assembly_Master(M_Assembly_Master TBL)
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
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Assembly_Master", new StringContent(JsonConvert.SerializeObject(TBL),
    Encoding.UTF8, "application/json"));

                    if (TBL.assemblyId == 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                    }
                    else if (TBL.assemblyId > 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Updated Saved Successfully", responseText = "Success", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Record Already Exist", responseText = "Fail", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public IActionResult ViewM_Assembly_Master()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_Assembly_Master()
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
                        var data = JsonConvert.DeserializeObject<List<M_Assembly_Master>>(await client.GetStringAsync(url + "/Master/Get_M_Assembly_Master"));
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
        [HttpDelete]

        public async Task<JsonResult> Delete_M_Assembly_Master(int Id)
        {

            try
            {
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
                    HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Master/Delete_M_Assembly_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        x = JsonConvert.DeserializeObject<int>(data);
                    }
                    return Json(x);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Assembly_Master(int Id)
        {
            M_Assembly_Master lst = new M_Assembly_Master();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Assembly_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<M_Assembly_Master>(data);
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


        [HttpGet]
        public IActionResult M_Assembly_Tagging()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> M_Assembly_Tagging(M_Assembly_Tagging TBL)
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
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Assembly_Tagging", new StringContent(JsonConvert.SerializeObject(TBL),
    Encoding.UTF8, "application/json"));

                    if (TBL.taggingId == 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                    }
                    else if (TBL.taggingId > 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Updated Saved Successfully", responseText = "Success", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Record Already Exist", responseText = "Fail", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public IActionResult ViewM_Assembly_Tagging()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_Assembly_Tagging()
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
                        var data = JsonConvert.DeserializeObject<List<M_Assembly_Tagging>>(await client.GetStringAsync(url + "/Master/Get_M_Assembly_Tagging"));
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
        [HttpDelete]

        public async Task<JsonResult> Delete_M_Assembly_Tagging(int Id)
        {

            try
            {
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
                    HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Master/Delete_M_Assembly_Tagging?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        x = JsonConvert.DeserializeObject<int>(data);
                    }
                    return Json(x);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Assembly_Tagging(int Id)
        {
            M_Assembly_Tagging lst = new M_Assembly_Tagging();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Assembly_Tagging?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<M_Assembly_Tagging>(data);
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


        [HttpGet]
        public IActionResult M_Client_Master()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> M_Client_Master(M_Client_Master TBL)
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
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Client_Master", new StringContent(JsonConvert.SerializeObject(TBL),
    Encoding.UTF8, "application/json"));

                    if (TBL.clientId == 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                    }
                    else if (TBL.clientId > 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Updated Saved Successfully", responseText = "Success", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Record Already Exist", responseText = "Fail", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public IActionResult ViewM_Client_Master()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_Client_Master()
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
                        var data = JsonConvert.DeserializeObject<List<M_Client_Master>>(await client.GetStringAsync(url + "/Master/Get_M_Client_Master"));
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
        [HttpDelete]

        public async Task<JsonResult> Delete_M_Client_Master(int Id)
        {

            try
            {
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
                    HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Master/Delete_M_Client_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        x = JsonConvert.DeserializeObject<int>(data);
                    }
                    return Json(x);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Client_Master(int Id)
        {
            M_Client_Master lst = new M_Client_Master();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Client_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<M_Client_Master>(data);
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


        [HttpGet]
        public IActionResult M_Constituency_Master()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> M_Constituency_Master(M_Constituency_Master TBL)
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
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Constituency_Master", new StringContent(JsonConvert.SerializeObject(TBL),
    Encoding.UTF8, "application/json"));

                    if (TBL.constituencyId == 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                    }
                    else if (TBL.constituencyId > 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Updated Saved Successfully", responseText = "Success", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Record Already Exist", responseText = "Fail", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public IActionResult ViewM_Constituency_Master()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_Constituency_Master()
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
                        var data = JsonConvert.DeserializeObject<List<M_Constituency_Master>>(await client.GetStringAsync(url + "/Master/Get_M_Constituency_Master"));
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
        [HttpDelete]

        public async Task<JsonResult> Delete_M_Constituency_Master(int Id)
        {

            try
            {
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
                    HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Master/Delete_M_Constituency_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        x = JsonConvert.DeserializeObject<int>(data);
                    }
                    return Json(x);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Constituency_Master(int Id)
        {
            M_Constituency_Master lst = new M_Constituency_Master();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Constituency_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<M_Constituency_Master>(data);
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


        [HttpGet]
        public IActionResult M_Financial_Year()
        {
            var user = HttpContext.User; // Get the current user

            if (user.Identity.IsAuthenticated) // Check if the user is authenticated
            {
                var username = user.FindFirst(ClaimTypes.Name)?.Value;
                var roleId = user.FindFirst(ClaimTypes.Role)?.Value;
                var userId = user.FindFirst("UserId")?.Value;
                var intLevelDetailsId = user.FindFirst("Intleveldetailsid")?.Value;
                var token = user.FindFirst("Token")?.Value; // If needed

                ViewBag.Username = username;
                ViewBag.RoleId = roleId;
                ViewBag.UserId = userId;
                ViewBag.IntLevelDetailsId = intLevelDetailsId;

                return View();
            }

            return Unauthorized(); // Redirect to login if not authenticated
           
        }
        [HttpGet]
        public IActionResult FinancialYearMaster()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> M_Financial_Year(FinancialYear TBL)
        {
            TBL.createdBy = 1;
            int x;
            if (!cl.Validate_FinancialYear(TBL.fyName))
            {
                return Json(new { sucess = false, responseMessage = "", responseText = ""+ MessageHandler.GetMessageDescription(10) + " Financial Year(eg. 2024-25)", data = "" });
            }
            else
            {
                try
                {
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Financial_Year", new StringContent(JsonConvert.SerializeObject(TBL), Encoding.UTF8, "application/json"));

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
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public IActionResult ViewM_Financial_Year()
        {
            return View();
        }
       
        [HttpGet("Get_M_Financial_Year")]
        public async Task<JsonResult> Get_M_Financial_Year()
        {

            var user = HttpContext.User; // Get the current user

            if (user.Identity.IsAuthenticated) // Check if the user is authenticated
            {
                var username = _userContextService.Username;
                var roleId = _userContextService.RoleId;
                var userId = _userContextService.UserId;
                var intLevelDetailsId = _userContextService.IntLevelDetailsId;
                var token = user.FindFirst("Token")?.Value; // If needed

                ViewBag.Username = username;
                ViewBag.RoleId = roleId;
                ViewBag.UserId = userId;
                ViewBag.IntLevelDetailsId = intLevelDetailsId;

            }
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
                        // Retrieve the Token claim from the user's claims
                      
                        var data = JsonConvert.DeserializeObject<List<FinancialYear>>(await client.GetStringAsync(url + "/Master/Get_M_Financial_Year"));
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
        [HttpGet]

        public async Task<JsonResult> Delete_M_Financial_Year(string Id)
        {
            try
            {
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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/Delete_M_Financial_Year?Id=" + Id).Result;
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
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Financial_Year(int Id)
        {
            FinancialYear lst = new FinancialYear();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Financial_Year?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<FinancialYear>(data);
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


        [HttpGet]
        public IActionResult MileStoneMaster()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MileStoneMaster(M_MileStone_Master TBL)
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
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_MileStone_Master", new StringContent(JsonConvert.SerializeObject(TBL), Encoding.UTF8, "application/json"));

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
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public IActionResult ViewM_MileStone_Master()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_MileStone_Master()
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
                        var data = JsonConvert.DeserializeObject<List<M_MileStone_Master>>(await client.GetStringAsync(url + "/Master/Get_M_MileStone_Master"));
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

        public async Task<JsonResult> Delete_M_MileStone_Master(string Id)
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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/Delete_M_MileStone_Master/" + Id).Result;
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


        [HttpGet]

        public async Task<JsonResult> GetByID_M_MileStone_Master(int Id)
        {
            M_MileStone_Master lst = new M_MileStone_Master();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_MileStone_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<M_MileStone_Master>(data);
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


        [HttpGet]
        public IActionResult M_Module_Master()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> M_Module_Master(M_Module_Master TBL)
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
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Module_Master", new StringContent(JsonConvert.SerializeObject(TBL),
    Encoding.UTF8, "application/json"));

                    if (TBL.moduleId == 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                    }
                    else if (TBL.moduleId > 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Updated Saved Successfully", responseText = "Success", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Record Already Exist", responseText = "Fail", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public IActionResult ViewM_Module_Master()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_Module_Master()
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
                        var data = JsonConvert.DeserializeObject<List<M_Module_Master>>(await client.GetStringAsync(url + "/Master/Get_M_Module_Master"));
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
        [HttpDelete]

        public async Task<JsonResult> Delete_M_Module_Master(int Id)
        {

            try
            {
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
                    HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Master/Delete_M_Module_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        x = JsonConvert.DeserializeObject<int>(data);
                    }
                    return Json(x);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Module_Master(int Id)
        {
            M_Module_Master lst = new M_Module_Master();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Module_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<M_Module_Master>(data);
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


        [HttpGet]
        public IActionResult M_Project_Category_Master()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> M_Project_Category_Master(ProjectCategory TBL)
        {

            if (cl.Validate_Regex_Codes(TBL.categoryName))
            {
                return Json(new { sucess = false, responseMessage = "", responseText = "Please enter valid category name", data = "" });
            }

            if (cl.Validate_Regex_Codes(TBL.categoryDesc))
            {
                return Json(new { sucess = false, responseMessage = "", responseText = "Please enter valid category description", data = "" });
            }
            else
            {
                try
                {
                    TBL.createdBy = 1;
                    TBL.updatedBy = 1;
                    int x;
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Project_Category_Master", new StringContent(JsonConvert.SerializeObject(TBL), Encoding.UTF8, "application/json"));

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
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public IActionResult ViewM_Project_Category_Master()
        {
            return View();
        }
        public IActionResult ProjectCategoryMaster()
        {
            return View();
        }

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
        [HttpGet]

        public async Task<JsonResult> Delete_M_Project_Category_Master(string Id)
        {

            try
            {
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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/Delete_M_Project_Category_Master?Id=" + Id).Result;
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
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Project_Category_Master(int Id)
        {
            ProjectCategory lst = new ProjectCategory();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Project_Category_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<ProjectCategory>(data);
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


        [HttpGet]
        public IActionResult M_Project_Part()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> M_Project_Part(M_Project_Part TBL)
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
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Project_Part", new StringContent(JsonConvert.SerializeObject(TBL),
    Encoding.UTF8, "application/json"));

                    if (TBL.partId == 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                    }
                    else if (TBL.partId > 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Updated Saved Successfully", responseText = "Success", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Record Already Exist", responseText = "Fail", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public IActionResult ViewM_Project_Part()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_Project_Part()
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
                        var data = JsonConvert.DeserializeObject<List<M_Project_Part>>(await client.GetStringAsync(url + "/Master/Get_M_Project_Part"));
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
        [HttpDelete]

        public async Task<JsonResult> Delete_M_Project_Part(int Id)
        {

            try
            {
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
                    HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Master/Delete_M_Project_Part?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        x = JsonConvert.DeserializeObject<int>(data);
                    }
                    return Json(x);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Project_Part(int Id)
        {
            M_Project_Part lst = new M_Project_Part();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Project_Part?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<M_Project_Part>(data);
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


        

        public async Task<JsonResult> GetcategoryList()
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
                        var data = JsonConvert.DeserializeObject<List<ProjectSubcategory>>(await client.GetStringAsync(url + "/Master/GetCategory"));
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

        [HttpGet]
        public IActionResult ProjectSubcategory()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> ProjectSubcategory(ProjectSubcategory TBL)
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
                    int x;
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Project_Subcategory_Master", new StringContent(JsonConvert.SerializeObject(TBL),
    Encoding.UTF8, "application/json"));

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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        [HttpGet]
        public IActionResult ViewProjectSubcategory()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_Project_Subcategory_Master()
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
                        var data = JsonConvert.DeserializeObject<List<ProjectSubcategory>>(await client.GetStringAsync(url + "/Master/Get_M_Project_Subcategory_Master"));
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

        public async Task<JsonResult> Delete_M_Project_Subcategory_Master(string Id)
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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/Delete_M_Project_Subcategory_Master/" + Id).Result;
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


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Project_Subcategory_Master(int Id)
        {
            ProjectSubcategory lst = new ProjectSubcategory();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Project_Subcategory_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<ProjectSubcategory>(data);
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


        [HttpGet]
        public IActionResult M_Project_Type_Master()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ProjectTypeMaster()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> M_Project_Type_Master(ProjectTypeMaster TBL)
        {

            if (cl.Validate_Regex_Codes(TBL.projectType))
            {
                return Json(new { sucess = false, responseMessage = "", responseText = "Please enter valid category name", data = "" });
            }

            if (cl.Validate_Regex_Codes(TBL.typeDesc))
            {
                return Json(new { sucess = false, responseMessage = "", responseText = "Please enter valid category description", data = "" });
            }
            else
            {
                TBL.createdBy = 1;
                int x;
                try
                {
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Project_Type_Master", new StringContent(JsonConvert.SerializeObject(TBL), Encoding.UTF8, "application/json"));

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
                        return Json(new { sucess = false, responseMessage = "Something went wrong!", responseText = "Fail", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public IActionResult ViewM_Project_Type_Master()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_Project_Type_Master()
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
                        var data = JsonConvert.DeserializeObject<List<ProjectTypeMaster>>(await client.GetStringAsync(url + "/Master/Get_M_Project_Type_Master"));
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
        [HttpGet]

        public async Task<JsonResult> Delete_M_Project_Type_Master(string Id)
        {

            try
            {
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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/Delete_M_Project_Type_Master?Id=" + Id).Result;
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
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Project_Type_Master(int Id)
        {
            ProjectTypeMaster lst = new ProjectTypeMaster();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Project_Type_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<ProjectTypeMaster>(data);
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


        [HttpGet]
        public IActionResult M_Scheme_Master()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> M_Scheme_Master(Scheme TBL)
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
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Scheme_Master", new StringContent(JsonConvert.SerializeObject(TBL), Encoding.UTF8, "application/json"));

                    if (TBL.schemeId == 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                    }
                    else if (TBL.schemeId > 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Updated Saved Successfully", responseText = "Success", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Record Already Exist", responseText = "Fail", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public IActionResult ViewM_Scheme_Master()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_Scheme_Master()
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
                        var data = JsonConvert.DeserializeObject<List<Scheme>>(await client.GetStringAsync(url + "/Master/Get_M_Scheme_Master"));
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
        [HttpDelete]

        public async Task<JsonResult> Delete_M_Scheme_Master(int Id)
        {

            try
            {
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
                    HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Master/Delete_M_Scheme_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        x = JsonConvert.DeserializeObject<int>(data);
                    }
                    return Json(x);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Scheme_Master(int Id)
        {
            Scheme lst = new Scheme();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Scheme_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<Scheme>(data);
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


        [HttpGet]
        public IActionResult SubMileStoneMaster()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SubMileStoneMaster(M_SubMileStone_Master TBL)
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
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_SubMileStone_Master", new StringContent(JsonConvert.SerializeObject(TBL), Encoding.UTF8, "application/json"));
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object(); 
                    x = JsonResponse.data;

                    if (x==1 || x==2)
                    {
                        return Json(new { sucess = true, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "Success", data = "" });
                    }
                    //else if (TBL.submilestoneId > 0)
                    //{
                    //    return Json(new { sucess = false, responseMessage = MessageHandler.GetMessageDescription(2), responseText = "Success", data = "" });
                    //}
                    else if(x==4)
                    {
                        return Json(new { sucess = false, responseMessage = MessageHandler.GetMessageDescription(x), responseText = "Fail", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Something went wrong!", responseText = "Fail", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpPost]
        public async Task<JsonResult> GetMilestoneList(int CategoryId)
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
                        HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetMileStone/" + CategoryId).Result;
                        if (!response.IsSuccessStatusCode)
                        {
                            string errorResponse = await response.Content.ReadAsStringAsync();
                            Console.WriteLine("Error Response: " + errorResponse);
                        }
                        string jsonData = await response.Content.ReadAsStringAsync();
                        var milestoneList = JsonConvert.DeserializeObject<List<M_MileStone_Master>>(jsonData);
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

        [HttpGet]
        public IActionResult ViewM_SubMileStone_Master()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_SubMileStone_Master()
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
                        var data = JsonConvert.DeserializeObject<List<M_SubMileStone_Master>>(await client.GetStringAsync(url + "/Master/Get_M_SubMileStone_Master"));
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

        public async Task<JsonResult> Delete_M_SubMileStone_Master(string Id)
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
                    HttpResponseMessage response =  client.GetAsync( client.BaseAddress + "/Master/Delete_M_SubMileStone_Master/" + Id).Result;
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


        [HttpGet]

        public async Task<JsonResult> GetByID_M_SubMileStone_Master(int Id)
        {
            M_SubMileStone_Master lst = new M_SubMileStone_Master();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_SubMileStone_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<M_SubMileStone_Master>(data);
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


        [HttpGet]
        public IActionResult M_Unit_Master()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> M_Unit_Master(M_Unit_Master TBL)
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
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/M_Unit_Master", new StringContent(JsonConvert.SerializeObject(TBL), Encoding.UTF8, "application/json"));

                    if (TBL.unitId == 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                    }
                    else if (TBL.unitId > 0)
                    {
                        return Json(new { sucess = false, responseMessage = "Updated Saved Successfully", responseText = "Success", data = "" });
                    }
                    else
                    {
                        return Json(new { sucess = false, responseMessage = "Record Already Exist", responseText = "Fail", data = "" });
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        }
        [HttpGet]
        public IActionResult ViewM_Unit_Master()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> Get_M_Unit_Master()
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
                        var data = JsonConvert.DeserializeObject<List<M_Unit_Master>>(await client.GetStringAsync(url + "/Master/Get_M_Unit_Master"));
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
        [HttpDelete]

        public async Task<JsonResult> Delete_M_Unit_Master(int Id)
        {

            try
            {
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
                    HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/Master/Delete_M_Unit_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        x = JsonConvert.DeserializeObject<int>(data);
                    }
                    return Json(x);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }


        [HttpGet]

        public async Task<JsonResult> GetByID_M_Unit_Master(int Id)
        {
            M_Unit_Master lst = new M_Unit_Master();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetByID_M_Unit_Master?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<M_Unit_Master>(data);
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


        [HttpGet]
        public async Task<IActionResult> BinD_categoryIdAdd()
        {

            string data = null;
            string jsonres = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/BinD_categoryIdAdd").Result;
            List<categoryId_M_Project_Subcategory_Master_DBBindAdd> lstBatch = new List<categoryId_M_Project_Subcategory_Master_DBBindAdd>();
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
                lstBatch = JsonConvert.DeserializeObject<List<categoryId_M_Project_Subcategory_Master_DBBindAdd>>(data);
                jsonres = JsonConvert.SerializeObject(lstBatch);
            }
            return Ok(jsonres);
        }

        [HttpGet]
        public IActionResult SchemeMaster()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddScheme(Scheme TBL)
        {
            int x = 0;
            if (cl.Validate_Regex_Codes(TBL.SchemeName))
            {
                return Json(new { sucess = false, responseMessage = "", responseText = "Please enter valid Project Head", data = "" });
            }

            if (cl.Validate_Regex_Codes(TBL.schemeDesc))
            {
                return Json(new { sucess = false, responseMessage = "", responseText = "Please enter valid Project description", data = "" });
            }
            else
            {
                try
                {
                    TBL.createdBy = 1;
                    TBL.updatedBy = 1;
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/AddScheme", new StringContent(JsonConvert.SerializeObject(TBL), Encoding.UTF8, "application/json"));
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }



        }

        //[HttpGet]
        //public IActionResult ViewProjectHead()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<JsonResult> Get_Scheme_Master()
        {
            try
            {
                var data = JsonConvert.DeserializeObject<List<Scheme>>(await client.GetStringAsync(url + "/Master/Get_Scheme_Master"));
                return Json(JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //[HttpGet]
        //public async Task<JsonResult> GetProjectHead()
        //{
        //    try
        //    {
        //        var data = JsonConvert.DeserializeObject<List<SchemeMaster>>(await client.GetStringAsync(url + "/Master/GetProjectHead"));
        //        return Json(JsonConvert.SerializeObject(data));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        [HttpPost]

        public async Task<JsonResult> DeleteScheme(string Id)
        {

            try
            {
                string x = string.Empty;

                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {

                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/DeleteScheme/" + Id).Result;

                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        dynamic JsonResponse = JsonConvert.DeserializeObject(data);
                        x = JsonResponse.data;
                        //x = JsonConvert.DeserializeObject<int>(data);
                    }
                    return Json(x);
                }


            }
            catch (Exception e)
            {
                throw;
            }
        }


        [HttpPost]

        public async Task<JsonResult> GetSchemeByID(int Id)
        {
            Scheme lst = new Scheme();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetSchemeDetailsByID?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<Scheme>(data);
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

        //[HttpGet]
        //public IActionResult ProposalMaster()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult ClientMaster()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> AddClient(ClientMaster TBL)
        {
            int x = 0;
            if (cl.Validate_Regex_Codes(TBL.ClientName))
            {
                return Json(new { sucess = false, responseMessage = "", responseText = "Please enter valid Client Name", data = "" });
            }

            if (cl.Validate_Regex_Codes(TBL.clientDesc))
            {
                return Json(new { sucess = false, responseMessage = "", responseText = "Please enter valid  description", data = "" });
            }
            else
            {
                try
                {
                    TBL.createdBy = 1;
                    TBL.updatedBy = 1;
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Master/AddClient", new StringContent(JsonConvert.SerializeObject(TBL), Encoding.UTF8, "application/json"));
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
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        [HttpGet]
        public async Task<JsonResult> Get_Client()
        {
            try
            {
                var data = JsonConvert.DeserializeObject<List<ClientMaster>>(await client.GetStringAsync(url + "/Master/Get_Client"));
                return Json(JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]

        public async Task<JsonResult> DeleteClient(string Id)
        {

            try
            {
                string x = string.Empty;

                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {

                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/DeleteClient/" + Id).Result;

                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        dynamic JsonResponse = JsonConvert.DeserializeObject(data);
                        x = JsonResponse.data;
                        //x = JsonConvert.DeserializeObject<int>(data);
                    }
                    return Json(x);
                }


            }
            catch (Exception e)
            {
                throw;
            }
        }


        [HttpPost]

        public async Task<JsonResult> GetClientByID(int Id)
        {
            ClientMaster lst = new ClientMaster();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetClientByID?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<ClientMaster>(data);
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



        #region AddDocument


        [HttpPost]
        public async Task<IActionResult> AddDocument(AddDocument TBL)
        {
            int x = 0;

            try
            {


                HttpResponseMessage resNew = await client.PostAsync(url + "/Master/AddDocument", new MultipartFormDataContent
                {
                    { new StringContent(TBL.Id.ToString()), "Id" },
                    { new StringContent(TBL.Title ?? ""), "Title" },
                    { new StringContent(TBL.ImageDescription ?? ""), "ImageDescription" },
                    { new StringContent(TBL.ActiveTo), "ActiveTo" },
                    { new StringContent(TBL.ActiveFrom), "ActiveFrom" },
                    { new StringContent(Convert.ToString( TBL.Plink)), "Plink" },
                    { new StreamContent(TBL.ImageFile.OpenReadStream()), "ImageFile", TBL.ImageFile.FileName }
                });




                string data = resNew.Content.ReadAsStringAsync().Result;


                if (TBL.Id == 0 || TBL.Id == null)
                {
                    return Json(new { sucess = false, responseMessage = "Record Saved Successfully", responseText = "Success", data = "" });
                }
                else if (TBL.Id > 0)
                {
                    return Json(new { sucess = false, responseMessage = "Updated Saved Successfully", responseText = "Success", data = "" });
                }
                else
                {
                    return Json(new { sucess = false, responseMessage = "Record Already Exist", responseText = "Fail", data = "" });
                }





            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [HttpGet]
        public async Task<JsonResult> Get_Document()


        {
            try
            {

                var data = JsonConvert.DeserializeObject<List<AddDocument>>(await client.GetStringAsync(url + "/Master/Get_Document?userid=" + _userContextService.UserId));
                return Json(JsonConvert.SerializeObject(data));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost]
        public async Task<IActionResult> ApproveDocument([FromBody] AddDocument bn)//Plink
        {
            try
            {
                string x = string.Empty;
                bn.PendingWithUser = _userContextService.UserId.ToInt();
                var desgId = _userContextService.INTDESIGNATIONID.ToInt();
                // Check if the model state is valid
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    return Json(new { success = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    // Create the HTTP client content with the Banner object
                    var content = new StringContent(JsonConvert.SerializeObject(bn), Encoding.UTF8, "application/json");

                    // Send the POST request to the API
                    HttpResponseMessage response = await client.PostAsync(client.BaseAddress + "/Master/ApproveDocument", content);

                    // Read the response from the API
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);

                    string data = "";
                    if (response.IsSuccessStatusCode)
                    {
                        data = await response.Content.ReadAsStringAsync();
                        dynamic JsonResponse = JsonConvert.DeserializeObject(data);
                        x = JsonResponse.data;
                    }

                    return Ok(data);
                }
            }
            catch (Exception e)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, new { success = false, responseMessage = e.Message });
            }
        }

        [HttpPost]

        public async Task<JsonResult> DeleteDocument(string Id)
        {

            try
            {
                string x = string.Empty;

                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {

                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/DeleteClient/" + Id).Result;

                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        dynamic JsonResponse = JsonConvert.DeserializeObject(data);
                        x = JsonResponse.data;
                        //x = JsonConvert.DeserializeObject<int>(data);
                    }
                    return Json(x);
                }


            }
            catch (Exception e)
            {
                throw;
            }
        }


        [HttpPost]
        public async Task<JsonResult> GetDocumentByID(int Id)
        {
            ClientMaster lst = new ClientMaster();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Master/GetClientByID?Id=" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<ClientMaster>(data);
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
        #endregion

    }
}