using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TechnicalBid;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BUIDCo_ePMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TechnicalBidAPIController : ControllerBase
    {
        private readonly ITechnicalBid _technicalBid;
        public TechnicalBidAPIController(ITechnicalBid technicalBid)
        {
            _technicalBid = technicalBid;
        }
        [HttpGet("GetProject_and_Bidders/{Id}")]
        public async Task<ActionResult> GetProject_and_Bidders(int Id)
        {
            List<ViewProject_and_Bidders> objlist;
            objlist = await _technicalBid.GetProject_and_Bidders(Id);
            var jsonres = JsonConvert.SerializeObject(objlist);
            return Ok(jsonres);
        }
        [HttpPost("Save_TechnicalBid")]
        public async Task<IActionResult> Save_TechnicalBid(TechnicalBidModelEF model)
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
                if (model.ID == 0)
                {
                    var data = await _technicalBid.Save_TechnicalBid(model);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _technicalBid.Save_TechnicalBid(model);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }
            }
        }
        [HttpGet("ViewtechnicalBid")]
        public async Task<ActionResult> ViewtechnicalBid()
        {
            List<ViewTechnicalBidModelEF> lst = await _technicalBid.ViewtechnicalBid(new ViewTechnicalBidModelEF());
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
        [HttpGet("GettechnicalBidDetailsById/{Id}")]
        public async Task<ActionResult> GettechnicalBidDetailsById(int Id)
        {
            List<ViewTechnicalBidModelEF> lst = await _technicalBid.GettechnicalBidDetailsById(Id);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
        [HttpPost("DeleteTechnicalBid")]
        public async Task<IActionResult> DeleteTechnicalBid(TechnicalBidModelEF model)
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
                var data = await _technicalBid.DeleteTechnicalBid(model);
                //var result = data;
                if (data == 3)
                {
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = data });

                }
                else
                {
                    return Ok(new { sucess = false, responseMessage = "Response Failed.", responseText = "error", data = data });
                }
            }
        }
        [HttpGet("EditTechnicalBidder/{Id}")]
        public async Task<ActionResult> EditTechnicalBidder(int Id)
        {
            List<ViewTechnicalBidModelEF> lst = await _technicalBid.EditTechnicalBidder(Id);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
    }
}
