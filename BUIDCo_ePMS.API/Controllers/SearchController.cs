using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Model.Entities.Proposal;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Repository.Repositories.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BUIDCo_ePMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchRepository _searchRepository;
        public SearchController(ISearchRepository searchRepository)
        {
             _searchRepository = searchRepository;
        }
        [HttpPost("SearchProposal")]
        public async Task<IActionResult> SearchProposal(Proposal obj)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Ok(new { success = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }

            try
            {
                ProposalDetails list = await _searchRepository.SearchProposal(obj);
                var jsonres = JsonConvert.SerializeObject(list);
                return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = jsonres });
            }
            catch (Exception ex)
            {
                return Ok(new { success = false, responseMessage = ex.Message, responseText = "Fail", data = "" });
            }
        }

    }
}
