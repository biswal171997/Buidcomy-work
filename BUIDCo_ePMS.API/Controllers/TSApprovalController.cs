using BUIDCo_ePMS.Model.Entities.Proposal;
using BUIDCo_ePMS.Model.Entities.TSApproval;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TSApproval;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BUIDCo_ePMS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TSApprovalController : ControllerBase
    {
        private readonly ITSApprovalRepository _tsApprovalRepository;
        public TSApprovalController(ITSApprovalRepository tsApprovalRepository)
        {
            _tsApprovalRepository = tsApprovalRepository;
        }
        [HttpGet("GetTSDetails")]
        public async Task<IActionResult> GetTSDetails(string searchtype)
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
                try
                {
                    TSDetails list = await _tsApprovalRepository.GetTSDetails(searchtype);
                    var jsonres = JsonConvert.SerializeObject(list);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = jsonres });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
        [HttpPost("UploadTSInformation")]
        public async Task<IActionResult> UploadTSInformation(TSApprovalUpload obj)
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
                try
                {
                    int output = await _tsApprovalRepository.UploadTSInformation(obj);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = output });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
        [HttpGet("GetTSApprovalByID")]
        public async Task<IActionResult> GetTSApprovalByID(int Id)
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
                try
                {
                    TSApprovalUpload obj = await _tsApprovalRepository.GetTSApprovalByID(Id);
                    var jsonres = JsonConvert.SerializeObject(obj);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = jsonres });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
    }
}
