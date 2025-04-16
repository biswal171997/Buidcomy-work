using BUIDCo_ePMS.Model.Entities.AdministartiveApproval;
using BUIDCo_ePMS.Model.Entities.CreateProject;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.AdministartiveApproval;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BUIDCo_ePMS.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Api/[controller]")]
    public class AdministartiveApprovalController : ControllerBase
    {
        private readonly IAdministartiveApproval _IAdministartiveApproval;

        public AdministartiveApprovalController(IAdministartiveApproval IAdministartiveApproval)
        {
            _IAdministartiveApproval = IAdministartiveApproval;
        }


        [HttpGet("GetAARecords")]
        public async Task<List<AdminApprovalViewEF>> GetAARecords()
        {

            List<AdminApprovalViewEF> lst = await _IAdministartiveApproval.GetAARecords();
            return lst;

        }
        [HttpPost("SaveAADetails")]
        public async Task<IActionResult> SaveAADetails([FromForm] AdminApprovalSaveEF model)
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
                var data = await _IAdministartiveApproval.SaveAADetails(model);
                return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
            }
        }

        [HttpPost("SaveAAUploadDetails")]
        public async Task<IActionResult> SaveAAUploadDetails(AdminApprovalSaveEF model)
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
                var data = await _IAdministartiveApproval.SaveAADetails(model);
                return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
            }

        }
        [HttpGet("GetSavedTADetails")]
        public async Task<IActionResult> GetSavedTADetails(int ProposalId)
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
                AdminApprovalSaveEF lst = await _IAdministartiveApproval.GetSavedTADetails(ProposalId);
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpGet("GetSchemeList")]
        public async Task<IActionResult> GetSchemeList()
        {
            
                List<DropdownList> lst = await _IAdministartiveApproval.GetSchemeList();
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            
        }
        
    }
}
