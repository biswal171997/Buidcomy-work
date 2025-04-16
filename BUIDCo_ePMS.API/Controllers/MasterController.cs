using BUIDCo_ePMS.Model.categoryIdAdd;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
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
using Microsoft.AspNetCore.Authorization;
using System.Reflection;
namespace BUIDCo_ePMS.API
{
    [Authorize]
    [ApiController]
    [Route("Api/[controller]")]
    public class MasterController : ControllerBase
    {

        //public IConfiguration Configuration;
        private readonly IMasterRepository _MasterRepository;
        //private readonly IWebHostEnvironment _hostingEnvironment;
        public MasterController(/*IConfiguration configuration,*/ IMasterRepository MasterRepository /*IWebHostEnvironment hostingEnvironment*/)
        {
            //Configuration = configuration;
            _MasterRepository = MasterRepository;

            //_hostingEnvironment = hostingEnvironment;
        }
        [HttpPost("M_Application_Status_Master")]
        public IActionResult M_Application_Status_Master(ApplicationStatus TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.statusId == 0 || TBL.statusId == null)
                {
                    var data = _MasterRepository.Insert_M_Application_Status_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = _MasterRepository.Insert_M_Application_Status_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_Application_Status_Master")]
        public async Task<IActionResult> Get_M_Application_Status_Master()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<ApplicationStatus> lst = await _MasterRepository.Getall_M_Application_Status_Master(new ApplicationStatus());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_Application_Status_Master")]
        public async Task<IActionResult> Search_M_Application_Status_Master([FromBody] ApplicationStatus BL)
        {
            List<ApplicationStatus> lst = await _MasterRepository.Search_M_Application_Status_Master(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpDelete("Delete_M_Application_Status_Master")]

        public async Task<IActionResult> Delete_M_Application_Status_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = _MasterRepository.Delete_M_Application_Status_Master(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpGet("GetByID_M_Application_Status_Master")]

        public async Task<IActionResult> GetByID_M_Application_Status_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                ApplicationStatus lst = await _MasterRepository.GetM_Application_Status_MasterById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_Assembly_Master")]
        public IActionResult M_Assembly_Master(M_Assembly_Master TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.assemblyId == 0 || TBL.assemblyId == null)
                {
                    var data = _MasterRepository.Insert_M_Assembly_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = _MasterRepository.Insert_M_Assembly_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_Assembly_Master")]
        public async Task<IActionResult> Get_M_Assembly_Master()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<M_Assembly_Master> lst = await _MasterRepository.Getall_M_Assembly_Master(new M_Assembly_Master());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_Assembly_Master")]
        public async Task<IActionResult> Search_M_Assembly_Master([FromBody] M_Assembly_Master BL)
        {
            List<M_Assembly_Master> lst = await _MasterRepository.Search_M_Assembly_Master(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpDelete("Delete_M_Assembly_Master")]

        public async Task<IActionResult> Delete_M_Assembly_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = _MasterRepository.Delete_M_Assembly_Master(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpGet("GetByID_M_Assembly_Master")]

        public async Task<IActionResult> GetByID_M_Assembly_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                M_Assembly_Master lst = await _MasterRepository.GetM_Assembly_MasterById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_Assembly_Tagging")]
        public IActionResult M_Assembly_Tagging(M_Assembly_Tagging TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.taggingId == 0 || TBL.taggingId == null)
                {
                    var data = _MasterRepository.Insert_M_Assembly_Tagging(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = _MasterRepository.Insert_M_Assembly_Tagging(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_Assembly_Tagging")]
        public async Task<IActionResult> Get_M_Assembly_Tagging()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<M_Assembly_Tagging> lst = await _MasterRepository.Getall_M_Assembly_Tagging(new M_Assembly_Tagging());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_Assembly_Tagging")]
        public async Task<IActionResult> Search_M_Assembly_Tagging([FromBody] M_Assembly_Tagging BL)
        {
            List<M_Assembly_Tagging> lst = await _MasterRepository.Search_M_Assembly_Tagging(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpDelete("Delete_M_Assembly_Tagging")]

        public async Task<IActionResult> Delete_M_Assembly_Tagging(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = _MasterRepository.Delete_M_Assembly_Tagging(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpGet("GetByID_M_Assembly_Tagging")]

        public async Task<IActionResult> GetByID_M_Assembly_Tagging(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                M_Assembly_Tagging lst = await _MasterRepository.GetM_Assembly_TaggingById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_Client_Master")]
        public IActionResult M_Client_Master(M_Client_Master TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.clientId == 0 || TBL.clientId == null)
                {
                    var data = _MasterRepository.Insert_M_Client_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = _MasterRepository.Insert_M_Client_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_Client_Master")]
        public async Task<IActionResult> Get_M_Client_Master()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<M_Client_Master> lst = await _MasterRepository.Getall_M_Client_Master(new M_Client_Master());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_Client_Master")]
        public async Task<IActionResult> Search_M_Client_Master([FromBody] M_Client_Master BL)
        {
            List<M_Client_Master> lst = await _MasterRepository.Search_M_Client_Master(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpDelete("Delete_M_Client_Master")]

        public async Task<IActionResult> Delete_M_Client_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = _MasterRepository.Delete_M_Client_Master(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpGet("GetByID_M_Client_Master")]

        public async Task<IActionResult> GetByID_M_Client_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                M_Client_Master lst = await _MasterRepository.GetM_Client_MasterById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_Constituency_Master")]
        public IActionResult M_Constituency_Master(M_Constituency_Master TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.constituencyId == 0 || TBL.constituencyId == null)
                {
                    var data = _MasterRepository.Insert_M_Constituency_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = _MasterRepository.Insert_M_Constituency_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_Constituency_Master")]
        public async Task<IActionResult> Get_M_Constituency_Master()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<M_Constituency_Master> lst = await _MasterRepository.Getall_M_Constituency_Master(new M_Constituency_Master());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_Constituency_Master")]
        public async Task<IActionResult> Search_M_Constituency_Master([FromBody] M_Constituency_Master BL)
        {
            List<M_Constituency_Master> lst = await _MasterRepository.Search_M_Constituency_Master(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpDelete("Delete_M_Constituency_Master")]

        public async Task<IActionResult> Delete_M_Constituency_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = _MasterRepository.Delete_M_Constituency_Master(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpGet("GetByID_M_Constituency_Master")]

        public async Task<IActionResult> GetByID_M_Constituency_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                M_Constituency_Master lst = await _MasterRepository.GetM_Constituency_MasterById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_Financial_Year")]
        public async Task<IActionResult> M_Financial_Year(FinancialYear TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.fyId == 0 || TBL.fyId == null)
                {
                    var data =await _MasterRepository.Insert_M_Financial_Year(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data =await _MasterRepository.Insert_M_Financial_Year(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }
       
        [HttpGet("Get_M_Financial_Year")]
        public async Task<IActionResult> Get_M_Financial_Year()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<FinancialYear> lst = await _MasterRepository.Getall_M_Financial_Year(new FinancialYear());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_Financial_Year")]
        public async Task<IActionResult> Search_M_Financial_Year([FromBody] FinancialYear BL)
        {
            List<FinancialYear> lst = await _MasterRepository.Search_M_Financial_Year(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpGet("Delete_M_Financial_Year")]

        public async Task<IActionResult> Delete_M_Financial_Year(string Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = await _MasterRepository.Delete_M_Financial_Year(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }
        [Authorize]
        [HttpGet("GetByID_M_Financial_Year")]

        public async Task<IActionResult> GetByID_M_Financial_Year(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                FinancialYear lst = await _MasterRepository.GetM_Financial_YearById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_MileStone_Master")]
        public async Task<IActionResult> M_MileStone_Master(M_MileStone_Master TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                TBL.createdBy = 1;
                TBL.updatedBy = 1;
                if (TBL.milestoneId == 0 || TBL.milestoneId == null)
                {
                    var data =await _MasterRepository.Insert_M_MileStone_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data =await _MasterRepository.Insert_M_MileStone_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_MileStone_Master")]
        public async Task<IActionResult> Get_M_MileStone_Master()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<M_MileStone_Master> lst = await _MasterRepository.Getall_M_MileStone_Master(new M_MileStone_Master());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_MileStone_Master")]
        public async Task<IActionResult> Search_M_MileStone_Master([FromBody] M_MileStone_Master BL)
        {
            List<M_MileStone_Master> lst = await _MasterRepository.Search_M_MileStone_Master(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpGet("Delete_M_MileStone_Master/{Id}")]

        public async Task<IActionResult> Delete_M_MileStone_Master(string Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data =await _MasterRepository.Delete_M_MileStone_Master(Id);
                if (data == "3") {
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
                } else
                {
                    return Ok(new { sucess = false, responseMessage = "Response Failed.", responseText = "error", data = data });
                }
               
            }
        }

        [HttpGet("GetByID_M_MileStone_Master")]

        public async Task<IActionResult> GetByID_M_MileStone_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                M_MileStone_Master lst = await _MasterRepository.GetM_MileStone_MasterById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_Module_Master")]
        public IActionResult M_Module_Master(M_Module_Master TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.moduleId == 0 || TBL.moduleId == null)
                {
                    var data = _MasterRepository.Insert_M_Module_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = _MasterRepository.Insert_M_Module_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_Module_Master")]
        public async Task<IActionResult> Get_M_Module_Master()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<M_Module_Master> lst = await _MasterRepository.Getall_M_Module_Master(new M_Module_Master());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_Module_Master")]
        public async Task<IActionResult> Search_M_Module_Master([FromBody] M_Module_Master BL)
        {
            List<M_Module_Master> lst = await _MasterRepository.Search_M_Module_Master(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpDelete("Delete_M_Module_Master")]

        public async Task<IActionResult> Delete_M_Module_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = _MasterRepository.Delete_M_Module_Master(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpGet("GetByID_M_Module_Master")]

        public async Task<IActionResult> GetByID_M_Module_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                M_Module_Master lst = await _MasterRepository.GetM_Module_MasterById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_Project_Category_Master")]
        public async Task<IActionResult> M_Project_Category_Master(ProjectCategory TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.categoryId == 0 || TBL.categoryId == null)
                {
                    var data =await _MasterRepository.Insert_M_Project_Category_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data =await _MasterRepository.Insert_M_Project_Category_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_Project_Category_Master")]
        public async Task<IActionResult> Get_M_Project_Category_Master()
        {

            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<ProjectCategory> lst = await _MasterRepository.Getall_M_Project_Category_Master(new ProjectCategory());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_Project_Category_Master")]
        public async Task<IActionResult> Search_M_Project_Category_Master([FromBody] ProjectCategory BL)
        {
            List<ProjectCategory> lst = await _MasterRepository.Search_M_Project_Category_Master(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpGet("Delete_M_Project_Category_Master")]

        public async Task<IActionResult> Delete_M_Project_Category_Master(string Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data =await _MasterRepository.Delete_M_Project_Category_Master(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpGet("GetByID_M_Project_Category_Master")]

        public async Task<IActionResult> GetByID_M_Project_Category_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                ProjectCategory lst = await _MasterRepository.GetM_Project_Category_MasterById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_Project_Part")]
        public IActionResult M_Project_Part(M_Project_Part TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.partId == 0 || TBL.partId == null)
                {
                    var data = _MasterRepository.Insert_M_Project_Part(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = _MasterRepository.Insert_M_Project_Part(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_Project_Part")]
        public async Task<IActionResult> Get_M_Project_Part()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<M_Project_Part> lst = await _MasterRepository.Getall_M_Project_Part(new M_Project_Part());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_Project_Part")]
        public async Task<IActionResult> Search_M_Project_Part([FromBody] M_Project_Part BL)
        {
            List<M_Project_Part> lst = await _MasterRepository.Search_M_Project_Part(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpDelete("Delete_M_Project_Part")]

        public async Task<IActionResult> Delete_M_Project_Part(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = _MasterRepository.Delete_M_Project_Part(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpGet("GetByID_M_Project_Part")]

        public async Task<IActionResult> GetByID_M_Project_Part(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                M_Project_Part lst = await _MasterRepository.GetM_Project_PartById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_Project_Subcategory_Master")]
        public async Task<IActionResult> M_Project_Subcategory_Master(ProjectSubcategory TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.subCategoryId == 0 || TBL.subCategoryId == null)
                {
                    var data =await _MasterRepository.Insert_M_Project_Subcategory_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data =await _MasterRepository.Insert_M_Project_Subcategory_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_Project_Subcategory_Master")]
        public async Task<IActionResult> Get_M_Project_Subcategory_Master()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<ProjectSubcategory> lst = await _MasterRepository.Getall_M_Project_Subcategory_Master(new ProjectSubcategory());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }


        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<ProjectSubcategory> lst = await _MasterRepository.GetCategory(new ProjectSubcategory());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }


        [HttpPost("SearchM_Project_Subcategory_Master")]
        public async Task<IActionResult> Search_M_Project_Subcategory_Master([FromBody] ProjectSubcategory BL)
        {
            List<ProjectSubcategory> lst = await _MasterRepository.Search_M_Project_Subcategory_Master(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpGet("Delete_M_Project_Subcategory_Master/{id}")]

        public async Task<IActionResult> Delete_M_Project_Subcategory_Master(string Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data =await _MasterRepository.Delete_M_Project_Subcategory_Master(Id);
                if (data == "3") {
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    return Ok(new { sucess = false, responseMessage = "Response Failed.", responseText = "error", data = data });
                }
               
            }
        }

        [HttpGet("GetByID_M_Project_Subcategory_Master")]

        public async Task<IActionResult> GetByID_M_Project_Subcategory_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                ProjectSubcategory lst = await _MasterRepository.GetM_Project_Subcategory_MasterById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_Project_Type_Master")]
        public async Task<IActionResult> M_Project_Type_Master(ProjectTypeMaster TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.typeId == 0 || TBL.typeId == null)
                {
                    var data = await _MasterRepository.Insert_M_Project_Type_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _MasterRepository.Insert_M_Project_Type_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_Project_Type_Master")]
        public async Task<IActionResult> Get_M_Project_Type_Master()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<ProjectTypeMaster> lst = await _MasterRepository.Getall_M_Project_Type_Master(new ProjectTypeMaster());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_Project_Type_Master")]
        public async Task<IActionResult> Search_M_Project_Type_Master([FromBody] ProjectTypeMaster BL)
        {
            List<ProjectTypeMaster> lst = await _MasterRepository.Search_M_Project_Type_Master(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpGet("Delete_M_Project_Type_Master")]

        public async Task<IActionResult> Delete_M_Project_Type_Master(string Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = await _MasterRepository.Delete_M_Project_Type_Master(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpGet("GetByID_M_Project_Type_Master")]

        public async Task<IActionResult> GetByID_M_Project_Type_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                ProjectTypeMaster lst = await _MasterRepository.GetM_Project_Type_MasterById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_Scheme_Master")]
        public IActionResult M_Scheme_Master(Scheme TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.schemeId == 0 || TBL.schemeId == null)
                {
                    var data = _MasterRepository.Insert_M_Scheme_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = _MasterRepository.Insert_M_Scheme_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_Scheme_Master")]
        public async Task<IActionResult> Get_M_Scheme_Master()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<Scheme> lst = await _MasterRepository.Getall_M_Scheme_Master(new Scheme());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_Scheme_Master")]
        public async Task<IActionResult> Search_M_Scheme_Master([FromBody] Scheme BL)
        {
            List<Scheme> lst = await _MasterRepository.Search_M_Scheme_Master(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpDelete("Delete_M_Scheme_Master")]

        public async Task<IActionResult> Delete_M_Scheme_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = _MasterRepository.Delete_M_Scheme_Master(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpGet("GetByID_M_Scheme_Master")]

        public async Task<IActionResult> GetByID_M_Scheme_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                Scheme lst = await _MasterRepository.GetM_Scheme_MasterById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_SubMileStone_Master")]
        public async Task<IActionResult> M_SubMileStone_Master(M_SubMileStone_Master TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.submilestoneId == 0 || TBL.submilestoneId == null)
                {
                    var data =await _MasterRepository.Insert_M_SubMileStone_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _MasterRepository.Insert_M_SubMileStone_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("GetMileStone/{CategoryId}")]
        public async Task<IActionResult> GetMileStone(int CategoryId)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<M_MileStone_Master> lst = await _MasterRepository.GetMilestone(CategoryId);
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }

        [HttpGet("Get_M_SubMileStone_Master")]
        public async Task<IActionResult> Get_M_SubMileStone_Master()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<M_SubMileStone_Master> lst = await _MasterRepository.Getall_M_SubMileStone_Master(new M_SubMileStone_Master());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_SubMileStone_Master")]
        public async Task<IActionResult> Search_M_SubMileStone_Master([FromBody] M_SubMileStone_Master BL)
        {
            List<M_SubMileStone_Master> lst = await _MasterRepository.Search_M_SubMileStone_Master(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpGet("Delete_M_SubMileStone_Master/{Id}")]

        public async Task<IActionResult> Delete_M_SubMileStone_Master(string Id)
        {
            //string result = string.Empty;
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = await _MasterRepository.Delete_M_SubMileStone_Master(Id);
                //var result = data;
                if (data == "3")
                {
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });

                }
                else
                {
                    return Ok(new { sucess = false, responseMessage = "Response Failed.", responseText = "error", data = data });
                }
            }
        }

        [HttpGet("GetByID_M_SubMileStone_Master")]

        public async Task<IActionResult> GetByID_M_SubMileStone_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                M_SubMileStone_Master lst = await _MasterRepository.GetM_SubMileStone_MasterById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }


        [HttpPost("M_Unit_Master")]
        public IActionResult M_Unit_Master(M_Unit_Master TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.unitId == 0 || TBL.unitId == null)
                {
                    var data = _MasterRepository.Insert_M_Unit_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = _MasterRepository.Insert_M_Unit_Master(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_M_Unit_Master")]
        public async Task<IActionResult> Get_M_Unit_Master()
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
     .SelectMany(v => v.Errors)
    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<M_Unit_Master> lst = await _MasterRepository.Getall_M_Unit_Master(new M_Unit_Master());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SearchM_Unit_Master")]
        public async Task<IActionResult> Search_M_Unit_Master([FromBody] M_Unit_Master BL)
        {
            List<M_Unit_Master> lst = await _MasterRepository.Search_M_Unit_Master(BL);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }


        [HttpDelete("Delete_M_Unit_Master")]

        public async Task<IActionResult> Delete_M_Unit_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = _MasterRepository.Delete_M_Unit_Master(Id);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpGet("GetByID_M_Unit_Master")]

        public async Task<IActionResult> GetByID_M_Unit_Master(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                M_Unit_Master lst = await _MasterRepository.GetM_Unit_MasterById(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }



        [HttpGet("BinD_categoryIdAdd")]
        public async Task<IActionResult> BinD_categoryIdAdd()
        {

            var Slots = _MasterRepository.BinD_categoryIdAdd().Result;
            return Ok(JsonConvert.SerializeObject(Slots));
        }

        [HttpPost("AddScheme")]
        public async Task<IActionResult> AddScheme(Scheme TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.schemeId == 0 || TBL.schemeId == null)
                {
                    var data = await _MasterRepository.AddScheme(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _MasterRepository.AddScheme(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_Scheme_Master")]
        public async Task<IActionResult> Get_Scheme_Master()
        {

            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<Scheme> lst = await _MasterRepository.Get_Scheme_Master(new Scheme());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        //[HttpPost("SearchProjectHead")]
        //public async Task<IActionResult> SearchProjectHead([FromBody] SchemeMaster BL)
        //{
        //    List<SchemeMaster> lst = await _MasterRepository.SearchProjectHead(BL);
        //    var jsonres = JsonConvert.SerializeObject(lst);
        //    return Ok(jsonres);
        //}
      

        [HttpGet("DeleteScheme/{Id}")]

        public async Task<IActionResult> DeleteScheme(string Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = await _MasterRepository.DeleteScheme(Id);
                if (data == "4")
                {
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    return Ok(new { sucess = false, responseMessage = "Response Failed.", responseText = "error", data = data });
                }
            }
        }

        [HttpGet("GetSchemeDetailsByID")]

        public async Task<IActionResult> GetSchemeDetailsByID(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                Scheme lst = await _MasterRepository.GetSchemeDetailsByID(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }

        [HttpPost("AddClient")]
        public async Task<IActionResult> AddClient(ClientMaster TBL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (TBL.ClientId == 0 || TBL.ClientId == null)
                {
                    var data = await _MasterRepository.AddClient(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _MasterRepository.AddClient(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }
        [HttpGet("Get_Client")]
        public async Task<IActionResult> Get_Client()
        {

            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<ClientMaster> lst = await _MasterRepository.Get_Client(new ClientMaster());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        //[HttpPost("SearchProposal")]
        //public async Task<IActionResult> SearchProposal([FromBody] ClientMaster BL)
        //{
        //    List<ClientMaster> lst = await _MasterRepository.SearchProposal(BL);
        //    var jsonres = JsonConvert.SerializeObject(lst);
        //    return Ok(jsonres);
        //}

        [HttpGet("DeleteClient/{Id}")]

        public async Task<IActionResult> DeleteClient(string Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = await _MasterRepository.DeleteClient(Id);
                if (data == "3")
                {
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    return Ok(new { sucess = false, responseMessage = "Response Failed.", responseText = "error", data = data });
                }
            }
        }

        [HttpGet("GetClientByID")]

        public async Task<IActionResult> GetClientByID(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                ClientMaster lst = await _MasterRepository.GetClientByID(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }



        #region Document


        [HttpPost("AddDocument")]
        public async Task<IActionResult> AddDocument([FromForm] AddDocument BL)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                if (BL.Id == 0 || BL.Id == null)
                {
                    var data = await _MasterRepository.AddDocument(BL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _MasterRepository.AddDocument(BL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("Get_Document")]
        public async Task<IActionResult> Get_Document(int userid)
        {

            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<AddDocument> lst = await _MasterRepository.Get_Document(new AddDocument { PendingWithUser = userid });
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);

            }

        }


        [HttpPost("ApproveDocument")]
        public async Task<IActionResult> ApproveDocument([FromBody] AddDocument BN)
        {
            try
            {
                // Check if model state is valid
                if (!ModelState.IsValid)
                {
                    var message = string.Join(" | ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    return Ok(new { success = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    // Call the repository to approve the banner
                    var data = await _MasterRepository.ApproveDocument(BN);

                    // Check the result and return appropriate response
                    if (data == "Approved Successfully")
                    {
                        return Ok(new { success = true, responseMessage = "Approved Successfully.", responseText = "Success", data = data });
                    }
                    else
                    {
                        return Ok(new { success = false, responseMessage = "Failed.", responseText = "error", data = data });
                    }
                }
            }
            catch (Exception e)
            {
                // Handle any exceptions that might occur
                return StatusCode(500, new { success = false, responseMessage = e.Message });
            }
        }



        [HttpGet("DeleteDocument/{Id}")]

        public async Task<IActionResult> DeleteBanner(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = await _MasterRepository.DeleteDocument(Id);
                if (data == "3")
                {
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    return Ok(new { sucess = false, responseMessage = "Response Failed.", responseText = "error", data = data });
                }
            }
        }

        [HttpGet("GetBannerByID")]

        public async Task<IActionResult> GetBannerByID(int Id)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                AddDocument lst = await _MasterRepository.GetDocumentByID(Id);
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }
        #endregion
    }
}
