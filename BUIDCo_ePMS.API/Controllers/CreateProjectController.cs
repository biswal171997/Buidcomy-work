using BUIDCo_ePMS.Model.Entities.CreateProject;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Repository.Repositories.Interfaces.CreateProject;
using BUIDCo_ePMS.Repository.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BUIDCo_ePMS.API
{
    [Authorize]
    [ApiController]
    [Route("Api/[controller]")]
    public class CreateProjectController : ControllerBase
    {
        private readonly ICreateProject _CreateProject;

        public CreateProjectController(ICreateProject CreateProject)
        {
            _CreateProject = CreateProject;
        }

        [HttpGet("GetProposalDetails")]
       
        public async Task<IActionResult> GetProposalDetails(int ProposalId)
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
                ProposalDetail lst = await _CreateProject.GetProposalDetails(ProposalId);
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }

        [HttpGet("BindLetterNoAndSubject")]
        public async Task<IActionResult> BindLetterNoAndSubject()
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
                List<ProposalList> lst = await _CreateProject.BindLetterNoAndSubject(new ProposalList());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }

        [HttpPost("SaveProjectDetails")]
        public async Task<IActionResult> SaveProjectDetails(ProjectDetail TBL)
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
                if (TBL.ProjectId == 0)
                {
                    var data = await _CreateProject.SaveProjectDetails(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _CreateProject.SaveProjectDetails(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }

        [HttpPost("DeleteProjectDetails")]
        public async Task<IActionResult> DeleteProjectDetails(ProjectDetail TBL)
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
                                   var data = await _CreateProject.DeleteProjectDetails(TBL);
                    return Ok(new { sucess = true, responseMessage = "Deleted Successfully.", responseText = "Success", data = data });
               
            }
        }

        [HttpGet("GetCreatedProjectRecord")]
        public async Task<List<ProjectViewEF>> GetCreatedProjectRecord()
        {
            
                List<ProjectViewEF> lst = await _CreateProject.GetCreatedProjectRecord();
                return lst;

            }

        [HttpGet("GetSubmittedProjectDetails")]
        public async Task<IActionResult> GetSubmittedProjectDetails(int ProjectId)
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
                ProjectSavedDetail lst = await _CreateProject.GetSubmittedProjectDetails(ProjectId);
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
    }
}
