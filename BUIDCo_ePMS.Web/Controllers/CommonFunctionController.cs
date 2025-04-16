using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Model.M_Financial_Year;
using BUIDCo_ePMS.Model.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Policy;

namespace BUIDCo_ePMS.Web.Controllers
{
    [Authorize]
    public class CommonFunctionController : Controller
    {
        //common functions for all
        readonly Uri? url;
        readonly HttpClient client;
        private readonly UserContextService _userContextService;
        public CommonFunctionController(IHttpClientFactory httpClientFactory, UserContextService userContextService)
        {
            var factoryClient = httpClientFactory.CreateClient("MyApiClient");
            client = new HttpClient();
            client.BaseAddress = factoryClient.BaseAddress;
            url = client.BaseAddress;
            _userContextService = userContextService;
            var token = _userContextService.Token;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }

        //subcategory json function
        [HttpGet]
        public async Task<JsonResult> GetCategory()
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
                        var responseString = await client.GetStringAsync(url + "/CommonFunctionAPI/GetCategory");
                        var ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse>(responseString);
                        return Json(ajaxResponse);
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
        public async Task<JsonResult> GetSubCategory(int Id)
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
                        var responseString = await client.GetStringAsync(url + "/CommonFunctionAPI/GetProjectSubCategory?Id=" + Id + "");
                        var ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse>(responseString);
                        return Json(ajaxResponse);
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
        public async Task<JsonResult> GetDistrict()
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
                        var responseString = await client.GetStringAsync(url + "/CommonFunctionAPI/GetDistrict");
                        var ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse>(responseString);
                        return Json(ajaxResponse);
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
        public async Task<JsonResult> GetBlock(int Id)
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
                        var responseString = await client.GetStringAsync(url + "/CommonFunctionAPI/GetBlock?Id=" + Id + "");
                        var ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse>(responseString);
                        return Json(ajaxResponse);
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
        public async Task<JsonResult> GetWard(int Id)
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
                        var responseString = await client.GetStringAsync(url + "/CommonFunctionAPI/GetWard?Id=" + Id + "");
                        var ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse>(responseString);
                        return Json(ajaxResponse);
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
        public async Task<JsonResult> GetDirector()
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
                        var responseString = await client.GetStringAsync(url + "/CommonFunctionAPI/GetDirector");
                        var ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse>(responseString);
                        return Json(ajaxResponse);
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
        public async Task<JsonResult> GetFinancialYear()
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
                        var responseString = await client.GetStringAsync(url + "/CommonFunctionAPI/GetFinancialYear");
                        var ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse>(responseString);
                        return Json(ajaxResponse);
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
        public async Task<JsonResult> GetConsultant()
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
                        var responseString = await client.GetStringAsync(url + "/CommonFunctionAPI/GetConsultant");
                        var ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse>(responseString);
                        return Json(ajaxResponse);
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
        public async Task<JsonResult> GetClient()
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
                        var responseString = await client.GetStringAsync(url + "/CommonFunctionAPI/GetClient");
                        var ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse>(responseString);
                        return Json(ajaxResponse);
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
        public async Task<JsonResult> GetProjectType()
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
                        var responseString = await client.GetStringAsync(url + "/CommonFunctionAPI/GetProjectType");
                        var ajaxResponse = JsonConvert.DeserializeObject<AjaxResponse>(responseString);
                        return Json(ajaxResponse);
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
