using BUIDCo_ePMS.Core;
using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace BUIDCo_ePMS.Web.Controllers
{
    public class BiddersController : Controller
    {
        private IWebHostEnvironment _hostingEnvironment;
        readonly ServerSideValidation cl = new();
        Uri url;// = new Uri("http://localhost/BUIDCo_ePMS_API/api");
        HttpClient client;
        private readonly UserContextService _userContextService;
        public BiddersController(IWebHostEnvironment hostingEnvironment, IHttpClientFactory httpClientFactory, UserContextService userContextService)
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
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> BiddersView()
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
                        var data = JsonConvert.DeserializeObject<List<ViewTenderBidderModelEF>>(await client.GetStringAsync(url + "/BiddersAPI/ViewBidderDetails"));
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

        public IActionResult BiddersDetails()
        {
           return View();
        }
        public async Task<IActionResult> SAVE_PROJECT_TENDER_BIDDER_DTS(TenderBidderModelEF model)
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
                    var user = HttpContext.User;
                    if (user.Identity!.IsAuthenticated)
                    {
                        model.createdBy = Convert.ToInt32(_userContextService.UserId);
                    }

                    var groups = model.bidderDetailsList!.TrimEnd('^').Split('^')
                          .Select(g => g.Split('|'))
                          .ToList();
                    string[] propertyNames = { "bidderName", "emailId", "contactNo", "bankName", "amount" };
                    var jsonObjects = groups.Select(g => new Dictionary<string, string>
                    {
                        { propertyNames[0], g.Length > 0 ? g[0] : "N/A" },  // Default "N/A" if missing
                        { propertyNames[1], g.Length > 1 ? g[1] : "N/A" },
                        { propertyNames[2], g.Length > 2 ? g[2] : "N/A" },
                        { propertyNames[3], g.Length > 3 ? g[3] : "N/A" },
                        { propertyNames[4], g.Length > 4 ? g[4] : "N/A" }
                    }).ToList();
                    // Convert to JSON format
                    string jsonString = JsonConvert.SerializeObject(jsonObjects);
                    model.bidderDetailsList = null;
                    model.bidderDetailsList = jsonString;

                    HttpResponseMessage resNew = await client.PostAsync(url + "/BiddersAPI/Save_Tender_Bidder_Dts", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

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
        public async Task<JsonResult> BidderDetailsById(int Id)
        {

            List<ViewTenderBidderModelEF> lst = new List<ViewTenderBidderModelEF>();

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
                    HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/BiddersAPI/BidderDetailsById/" + Id).Result;
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        string data = response.Content.ReadAsStringAsync().Result;
                        lst = JsonConvert.DeserializeObject<List<ViewTenderBidderModelEF>>(data)!;
                    }
                    return Json(lst);
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<JsonResult> DeleteBidders(int Id)
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
                    var user = HttpContext.User;
                    if (user.Identity!.IsAuthenticated)
                    {
                        model.createdBy = Convert.ToInt32(_userContextService.UserId);
                    }
                    model.tenderId = Id;

                    HttpResponseMessage response = await client.PostAsync(url + "/BiddersAPI/DeleteBidders", new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));
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
                        HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/BiddersAPI/GetProjectDetailsById/" + PId).Result;
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
    }
}
