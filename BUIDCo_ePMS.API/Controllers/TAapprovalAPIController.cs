using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Model.Entities.TAapproval;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TAapproval;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BUIDCo_ePMS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [RequestSizeLimit(1_000_000)]
    [RequestFormLimits(MultipartBodyLengthLimit = 1_000_000)]
    public class TAapprovalAPIController : ControllerBase
    {
        private readonly ITAapproval _TAapproval;

        public TAapprovalAPIController(ITAapproval TAapproval)
        {
            _TAapproval = TAapproval;
        }
      
        [HttpPost("GetTAapplicationDetails")]
        public async Task<IActionResult> GetTAapplicationDetails(TASearchEF obj)
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
               List< TAViewEF> lst = await _TAapproval.GetTAapplicationDetails(obj);
                 if (lst == null)
                {
                    return NotFound(new { message = "No data found." });
                }
                var jsonres = JsonConvert.SerializeObject(lst);
                
                return Ok(jsonres);

            }

        }
        [HttpPost("SaveTADetails")]
        public async Task<IActionResult> SaveTADetails([FromForm] TAApprovalSave TBL)
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

                if (TBL.Status == 0)
                {
                    var data = await _TAapproval.SaveTAdetails(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _TAapproval.SaveTAdetails(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }
    }
}
    

