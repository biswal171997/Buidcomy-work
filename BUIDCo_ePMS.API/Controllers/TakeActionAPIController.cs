using BUIDCo_ePMS.Model.Entities.TAapproval;
using BUIDCo_ePMS.Model.Entities.TakeAction;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TAapproval;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TakeAction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BUIDCo_ePMS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TakeActionAPIController : ControllerBase
    {
        private readonly ITakeAction _TakeAction;

        public TakeActionAPIController(ITakeAction TakeAction)
        {
            _TakeAction = TakeAction;
        }
        [HttpPost("GetActionPageDetails")]
        public async Task<IActionResult> GetActionPageDetails(TakeActionSearch obj)
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
                TakeActionDetails lst = await _TakeAction.GetActionPageDetails(obj);
                if (lst == null)
                {
                    return NotFound(new { message = "No data found." });
                }
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpPost("SaveTakeAction")]
        public async Task<IActionResult> SaveTakeAction([FromForm] TakeActionSave TBL)
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
                    var data = await _TakeAction.SaveTakeAction(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _TakeAction.SaveTakeAction(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }
    }
}
