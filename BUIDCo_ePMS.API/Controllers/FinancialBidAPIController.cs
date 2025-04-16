using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.FinancialBid;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BUIDCo_ePMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialBidAPIController : ControllerBase
    {
        private readonly IFinancialBid _financialBid;
        public FinancialBidAPIController(IFinancialBid financialBid)
        {
            _financialBid = financialBid;
        }
        [HttpGet("GetTechnicalBidders/{Id}")]
        public async Task<IActionResult> GetTechnicalBidders(int Id)
        {
            List<ViewFinancialBidModelEF> lst = await _financialBid.GetBidders(Id);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
        [HttpPost("SaveFinancialBid")]
        public async Task<IActionResult> SaveFinancialBid(FinancialBidModel model)
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
                if (model.financialID == 0)
                {
                    var data = await _financialBid.SaveFinancialBid(model);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _financialBid.SaveFinancialBid(model);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }
            }
        }
        [HttpGet("GetprojectBasicDetails/{Id}")]
        public async Task<IActionResult> GetprojectBasicDetails(int Id)
        {
            List<ViewProject_and_Bidders> lst = await _financialBid.GetProjectDetails(Id);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
        [HttpGet("ViewFinancialBid")]
        public async Task<ActionResult> ViewFinancialBid()
        {
            List<ViewFinancialBidModelEF> lst = await _financialBid.ViewFinancialBid(new ViewFinancialBidModelEF());
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
        [HttpGet("EditFinancialBid/{Id}")]
        public async Task<IActionResult> EditFinancialBid(int Id)
        {
            List<ViewFinancialBidModelEF> lst = await _financialBid.EditFinancialBid(Id);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
        [HttpPost("DeleteFinancialBid")]
        public async Task<IActionResult> DeleteFinancialBid(FinancialBidModel model)
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
                var data = await _financialBid.DeleteFinancialBid(model);
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
        
        [HttpGet("ViewFinancialDetails/{Id}")]
        public async Task<IActionResult> ViewFinancialDetails(int Id)
        {
            List<ViewFinancialBidModelEF> lst = await _financialBid.ViewFinancialDetails(Id);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
    }
}
