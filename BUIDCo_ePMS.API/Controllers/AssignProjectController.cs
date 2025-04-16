using BUIDCo_ePMS.Model.Entities.AssignProjectWork;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Model.M_MileStone_Master;
using BUIDCo_ePMS.Model.M_SubMileStone_Master;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Repository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Security.Policy;

namespace BUIDCo_ePMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignProjectController : ControllerBase
    {
        private readonly IAssignWorkRepository _AssignWorkRepository;
        public AssignProjectController(IAssignWorkRepository AssignWorkRepository)
        {
            _AssignWorkRepository = AssignWorkRepository;
        }
        [HttpGet("GetAssignProjectList")]
        public async Task<IActionResult> GetAssignProjectList()
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
                List<AssignProject> lst = await _AssignWorkRepository.GetassignprojectList(new AssignProject());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SaveAssignProject")]
        public async Task<IActionResult> SaveAssignProject([FromForm] AssignProject TBL, [FromForm] string bankdetailsList1)
        {

            // public async Task<IActionResult> SaveAssignProject([FromBody] AssignProject TBL)
            //{

            if (string.IsNullOrEmpty(bankdetailsList1))
            {
                return BadRequest(new { success = false, message = "Bank details are required." });

            }

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
                TBL.bankdetailsList12 = bankdetailsList1;

                if (TBL.id == 0)
                {
                    var data = await _AssignWorkRepository.SaveAssignProject(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = _AssignWorkRepository.SaveAssignProject(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpGet("GetallAssignProjectView")]
        public async Task<IActionResult> GetallAssignProjectView()
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
                List<ViewAssignProject> lst = await _AssignWorkRepository.GetallAssignProjectView(new ViewAssignProject());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }

        [HttpGet("DeleteAssignProject/{Id}")]

        public async Task<IActionResult> DeleteAssignProject(string Id)
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
                var data = await _AssignWorkRepository.DeleteAssignProject(Convert.ToInt32(Id));
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

        [HttpGet("GetAssignProjectById/{Id}")]
        public async Task<IActionResult> GetAssignProjectById(string Id)
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
                List<ViewAssignProject1> lst = await _AssignWorkRepository.GetAssignProjectById(Convert.ToInt32(Id));
                var jsonres = JsonConvert.SerializeObject(lst);
                return Ok(jsonres);
            }
        }

        [HttpGet("ViewDetails/{Id}")]
        public async Task<IActionResult> ViewDetails(string Id)
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
                List<AssignProject> lst = await _AssignWorkRepository.ViewDetails(Convert.ToInt32(Id));
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);
            }
        }

        [HttpGet("GetAssignToList/{PId}")]
        public async Task<IActionResult> GetAssignToList(int PId)
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
                List<ViewBidderDetails> lst = await _AssignWorkRepository.GetAssignToList(PId);
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }

        [HttpGet("GetBankComponentList")]
        public async Task<ActionResult> GetBankComponentList()
        {
            List<ViewBankComponent> lst = await _AssignWorkRepository.GetBankComponents(new ViewBankComponent());
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
    }
}
