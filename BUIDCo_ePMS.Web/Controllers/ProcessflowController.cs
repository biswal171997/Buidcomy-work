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
using BUIDCo_ePMS.Model.Entities.Processflow;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.Processflow;
using BUIDCo_ePMS.Repository.Repositories.Repository.Processflow;
using System.Collections.Generic;
using Dapper;
namespace BUIDCo_ePMS.Web
{
    //[Authorize]
    public class ProcessflowController : Controller
    {

        private IWebHostEnvironment _hostingEnvironment;
        readonly ServerSideValidation cl = new();
        Uri url;// = new Uri("http://localhost/BUIDCo_ePMS_API/api");
        HttpClient client;
        private readonly UserContextService _userContextService;
        private readonly IProcessflowRepository _IProcessflowRepository;
        public ProcessflowController(IWebHostEnvironment hostingEnvironment, IHttpClientFactory httpClientFactory, UserContextService userContextService, IProcessflowRepository IProcessflowRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            var factoryClient = httpClientFactory.CreateClient("MyApiClient");
            client = new HttpClient();
            client.BaseAddress = factoryClient.BaseAddress;
            url = client.BaseAddress;
            _IProcessflowRepository = IProcessflowRepository;
            _userContextService = userContextService;
            var token = _userContextService.Token;

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


        }

        [HttpGet]
        public IActionResult AddProcess(int? INTPLINKID)
        {


            ViewBag.GetAllpage = _IProcessflowRepository.GetAllPages().Result;
            ViewBag.GetAllUser = _IProcessflowRepository.GetallUser().Result;
            ViewBag.GetallDesignation = _IProcessflowRepository.GetallDesignation().Result;
            List<ProcessflowModel> processList = new List<ProcessflowModel>();

            if (INTPLINKID.HasValue && INTPLINKID > 0)
            {
                // Fetch existing records if INTPLINKID is present
                processList = _IProcessflowRepository.GetProcessById(INTPLINKID.Value).Result;
            }

            ViewBag.ExistingProcessData = processList; // Pass existing records for edit
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveProcessAjax([FromBody] ProcessRequestModel request)
        {
            if (request == null || request.Processes == null || !request.Processes.Any())
            {
                return BadRequest(new { success = false, message = "No data received." });
            }

            int selectedMode = request.SelectedMode; // 1 = User, 2 = Designation

            foreach (var process in request.Processes)
            {
                if (selectedMode == 1)
                {
                    if (process.INTPLINKID > 0 && process.INTUSERID > 0)
                    {
                        var newProcess = new ProcessflowModel
                        {
                            INTPLINKID = process.INTPLINKID,
                            //INTUSERID = process.INTUSERID,
                            //LevelNO = process.LevelNO,

                        };

                        await _IProcessflowRepository.DeleteProcessAsync(newProcess); // ✅ Save data using repository
                    }
                }
                else
                {
                    if (process.INTPLINKID > 0 && process.INTDESIGID > 0)
                    {
                        var newProcess = new ProcessflowModel
                        {
                            INTPLINKID = process.INTPLINKID,
                            //INTUSERID = process.INTUSERID,
                            //LevelNO = process.LevelNO,

                        };

                        await _IProcessflowRepository.DeleteProcessAsync(newProcess); // ✅ Save data using repository
                    }

                }

            }

            foreach (var process in request.Processes)
            {
                if (selectedMode == 1)
                {
                    if (process.INTPLINKID > 0 && process.INTUSERID > 0)
                    {

                        var newProcess = new ProcessflowModel
                        {
                            INTPLINKID = process.INTPLINKID,
                            INTUSERID = process.INTUSERID,
                            LevelNO = process.LevelNO,
                            SelectedMode = selectedMode

                        };

                        await _IProcessflowRepository.AddProcessAsync(newProcess); // ✅ Save data using repository
                    }
                }
                else
                {
                    if (process.INTPLINKID > 0 && process.INTDESIGID > 0)
                    {
                        var newProcess = new ProcessflowModel
                        {
                            INTPLINKID = process.INTPLINKID,
                            INTDESIGID = process.INTDESIGID,
                            LevelNO = process.LevelNO,
                            SelectedMode = selectedMode
                        };

                        await _IProcessflowRepository.AddProcessAsync(newProcess); // ✅ Save data using repository
                    }
                }





            }

            return Json(new { success = true, message = "Data saved successfully!" });
        }


        //[HttpPost]
        //public async Task<IActionResult> SaveProcessAjax([FromBody] List<ProcessflowModel> processes)
        //{
        //    if (processes == null || !processes.Any())
        //    {
        //        return BadRequest(new { success = false, message = "No data received." });
        //    }
        //    foreach (var process in processes)
        //    {
        //        if (process.INTPLINKID > 0 && process.INTUSERID > 0)
        //        {
        //            var newProcess = new ProcessflowModel
        //            {
        //                INTPLINKID = process.INTPLINKID,
        //                INTUSERID = process.INTUSERID,
        //                LevelNO = process.LevelNO
        //            };

        //            await _IProcessflowRepository.DeleteProcessAsync(newProcess); // ✅ Save data using repository
        //        }
        //    }

        //    foreach (var process in processes)
        //    {
        //        if (process.INTPLINKID > 0 && process.INTUSERID > 0)
        //        {
        //            var newProcess = new ProcessflowModel
        //            {
        //                INTPLINKID = process.INTPLINKID,
        //                INTUSERID = process.INTUSERID,
        //                LevelNO = process.LevelNO
        //            };

        //            await _IProcessflowRepository.AddProcessAsync(newProcess); // ✅ Save data using repository
        //        }
        //    }

        //    return Json(new { success = true, message = "Data saved successfully!" });
        //}

        [HttpGet]
        public IActionResult ViewProcess()
        {


            ViewBag.Data = _IProcessflowRepository.GetalldataviewPages().Result;
            return View();

        }
        [HttpPost]
        public IActionResult UpdateDeleteFlag(int APCID)
        {
            try
            {
                ViewBag.DeleteData = _IProcessflowRepository.DeleteProcessById(APCID).Result;
                return Json(new { success = true });
                //using (var connection = new SqlConnection(_connectionString))
                //{
                //    string query = "UPDATE Approval_Config SET intDeleteflag = 1 WHERE INTPLINKID = @INTPLINKID";
                //    var parameters = new { INTPLINKID };

                //    int rowsAffected = connection.Execute(query, parameters);

                //    if (rowsAffected > 0)
                //        return Json(new { success = true });
                //    else
                //        return Json(new { success = false });
                //}
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


    }



}


