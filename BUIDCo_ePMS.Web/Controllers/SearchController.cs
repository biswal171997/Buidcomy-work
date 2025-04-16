using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using System.Net.Http;
using System;
using System.Security.Policy;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using System.Text;
using BUIDCo_ePMS.Model.Entities.Proposal;

namespace BUIDCo_ePMS.Web.Controllers
{
    [Authorize]
    public class SearchController : Controller
    {
        readonly Uri? url;
        readonly HttpClient client;
        private readonly UserContextService _userContextService;
        public SearchController(IHttpClientFactory httpClientFactory, UserContextService userContextService)
        {
            var factoryClient = httpClientFactory.CreateClient("MyApiClient");
            client = new HttpClient();
            client.BaseAddress = factoryClient.BaseAddress;
            url = client.BaseAddress;
            _userContextService = userContextService;
            var token = _userContextService.Token;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        [HttpPost]
        public async Task<JsonResult> SearchProposal(Proposal obj)
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
                    HttpResponseMessage resNew = await client.PostAsync(url + "/Search/SearchProposal", new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json"));
                    string data = resNew.Content.ReadAsStringAsync().Result;
                    //dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object();
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
