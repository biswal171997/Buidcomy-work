using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Model.M_MileStone_Master;
using BUIDCo_ePMS.Model.M_SubMileStone_Master;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Repository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace BUIDCo_ePMS.API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ProjectTenderAPIController : ControllerBase
    {
        private readonly IProjectTender _ProjectTender;
        public ProjectTenderAPIController(IProjectTender IProjectTender)
        {
            _ProjectTender = IProjectTender;
        }
        [HttpGet("GetProjectName/{VCH_PRO}")]
        public async Task<IActionResult> GetProjectName(string VCH_PRO)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                List<Projects> lst = await _ProjectTender.GetProject(VCH_PRO);
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

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
                var data = await _ProjectTender.GetProjectDetailsById(PId);
                var jsonres = JsonConvert.SerializeObject(data);

                return Ok(jsonres);

            }
        }
        [HttpPost("SaveProjectTender")]
        public async Task<IActionResult> SaveProjectTender(ProjectTenderEF TBL)
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
                TBL.createdBy = 1;
                if (TBL.tenderId == 0)
                {
                    var data = await _ProjectTender.SaveProjectTender(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _ProjectTender.SaveProjectTender(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }

            }
        }
        [HttpGet("Get_M_Project_Tender")]
        public async Task<IActionResult> Get_M_Project_Tender()
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
                List<ViewProjectTenderEF> lst = await _ProjectTender.GetProjectTenderDetails(new ViewProjectTenderEF());
                var jsonres = JsonConvert.SerializeObject(lst);

                return Ok(jsonres);

            }

        }
        [HttpGet("GetTenderDetailsById")]
        public async Task<IActionResult> GetTenderDetailsById(int Id)
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
                var data = await _ProjectTender.Edit_GetTenderDetailsById(Id);
                var jsonres = JsonConvert.SerializeObject(data);

                return Ok(jsonres);

            }
        }
        [HttpGet("DeleteProjectTender/{Id}")]
        public async Task<IActionResult> DeleteProjectTender(int Id)
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
                var data = await _ProjectTender.DeleteProjectTender(Id);
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
        
        [HttpGet("GetUserName")]
        public async Task<IActionResult> GetUserName()
        {
            List<UserMasterModelEF> lst = await _ProjectTender.GetUserName(new UserMasterModelEF());
            var jsonres = JsonConvert.SerializeObject(lst);
            return Ok(jsonres);
        }
        [HttpPost("SaveProjectTenderCorrigendum")]
        public async Task<IActionResult> SaveProjectTenderCorrigendum(ProjectTenderCorrigendumEF TBL)
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
                if (TBL.corrigendumId == 0)
                {
                    var data = await _ProjectTender.SaveProjectTenderCorrigendum(TBL);
                    return Ok(new { sucess = true, responseMessage = "Inserted Successfully.", responseText = "Success", data = data });
                }
                else
                {
                    var data = await _ProjectTender.SaveProjectTenderCorrigendum(TBL);
                    return Ok(new { sucess = true, responseMessage = "Updated Successfully.", responseText = "Success", data = data });
                }
            }
        }
        [HttpGet("ViewProjectTenderCorrigendum/{tenderId}")]
        public async Task<IActionResult> ViewProjectTenderCorrigendum(int tenderId)
        {
            var data = await _ProjectTender.ViewProjectTenderCorrigendum(tenderId);
            var jsonres = JsonConvert.SerializeObject(data);
            return Ok(jsonres);
        }
        [HttpGet("GetCorrigendumAddendumDetails/{Id}")]
        public async Task<IActionResult> GetCorrigendumAddendumDetails(int Id)
        {
            var data = await _ProjectTender.GetCorrigendumAddendumDetails(Id);
            var jsonres = JsonConvert.SerializeObject(data);
            return Ok(jsonres);
        }
        [HttpGet("DeleteCorrigendum/{Id}")]
        public async Task<IActionResult> DeleteCorrigendum(int Id)
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
                var data = await _ProjectTender.DeleteCorrigeduma_Addedum(Id);
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
       
        [HttpGet("EditCorrigendumAddendum/{PId}")]
        public async Task<IActionResult> EditCorrigendumAddendum(int PId)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = await _ProjectTender.EditCorrigendumAddendum(PId);
                var jsonres = JsonConvert.SerializeObject(data);

                return Ok(jsonres);

            }
        }
    }
}
