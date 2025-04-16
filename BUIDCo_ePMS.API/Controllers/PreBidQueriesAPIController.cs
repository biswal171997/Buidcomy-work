using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Repository.Repositories.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BUIDCo_ePMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreBidQueriesAPIController : ControllerBase
    {
        readonly IPreBidQueries _IPreBidQueries;
        public PreBidQueriesAPIController(IPreBidQueries IPreBidQueries)
        {
            _IPreBidQueries = IPreBidQueries;
        }
        [HttpGet("ViewPreBidQueries")]
        public async Task<ActionResult> ViewPreBidQueries()
        {
            List<PreBidQueriesModelEF> lst = await _IPreBidQueries.ViewPreBidQueriesDetails(new PreBidQueriesModelEF());
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
        [HttpPost("SaveTenderPreBidQueries")]
        public async Task<IActionResult> SaveTenderPreBidQueries(PreBidQueriesModelEF TBL)
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
                if (TBL.Id == 0)
                {
                    var data = await _IPreBidQueries.Save_Tender_PreBidQueries(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _IPreBidQueries.Save_Tender_PreBidQueries(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }
            }
        }
        [HttpGet("GetPreBidQueriesById/{Id}")]
        public async Task<ActionResult> GetPreBidQueriesById(int Id)
        {
            var lst = await _IPreBidQueries.GetPreBidQueriesDetailsById(Id);
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
       
        [HttpPost("DeletepreBidqueries")]
        public async Task<IActionResult> DeletepreBidqueries(PreBidQueriesModelEF model)
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
                var data = await _IPreBidQueries.DeletePreBidQueries(model);
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
    }
}
