using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.TenderBidder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BUIDCo_ePMS.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BiddersAPIController : ControllerBase
    {
        private readonly ITenderBidder _tenderBidder;
        public BiddersAPIController(ITenderBidder tenderBidder)
        {
            _tenderBidder = tenderBidder;
        }
        [HttpPost("Save_Tender_Bidder_Dts")]
        public async Task<IActionResult> Save_Tender_Bidder_Dts(TenderBidderModelEF model)
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
                if (model.bidderID == 0)
                {
                    var data = await _tenderBidder.Save_Tender_Bidder_Dts(model);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _tenderBidder.Save_Tender_Bidder_Dts(model);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }
            }
        }
        [HttpGet("ViewBidderDetails")]
        public async Task<ActionResult> ViewBidderDetails()
        {
            List<ViewTenderBidderModelEF> lst = await _tenderBidder.ViewBidderDetails(new ViewTenderBidderModelEF());
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
        [HttpGet("BidderDetailsById/{Id}")]
        public async Task<ActionResult> BidderDetailsById(int Id)
        {
            List<ViewTenderBidderModelEF> lst = await _tenderBidder.BidderDetailsById(Id);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
        [HttpPost("DeleteBidders")]
        public async Task<IActionResult> DeleteBidders(TenderBidderModelEF model)
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
                var data = await _tenderBidder.DeleteBidders(model);
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
        [HttpGet("GetProjectDetailsById/{PId}")]
        public async Task<IActionResult> GetProjectDetailsById(int PId)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = await _tenderBidder.GetProjectDetailsById(PId);
                var jsonres = JsonConvert.SerializeObject(data);

                return Ok(jsonres);

            }
        }
    }
}
