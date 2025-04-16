using BUIDCo_ePMS.Model.Entities.Common;
using BUIDCo_ePMS.Model.Entities.Master;
using BUIDCo_ePMS.Model.M_Financial_Year;
using BUIDCo_ePMS.Model.M_Project_Part;
using BUIDCo_ePMS.Model.Responses;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BUIDCo_ePMS.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Api/[controller]")]
    public class CommonFunctionAPIController : ControllerBase
    {
        private readonly ICommonFunctionRepository _commonfunctionrepository; 
        public CommonFunctionAPIController(ICommonFunctionRepository commonfunctionrepository)
        {
            _commonfunctionrepository = commonfunctionrepository;
        }
        [HttpGet("GetCategory")]

        public async Task<IActionResult> GetCategory()
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
                    List<ProjectCategory> lst = await _commonfunctionrepository.GetCategory();
                    var jsonres = JsonConvert.SerializeObject(lst);
                    if (jsonres != null)
                    {
                        return Ok(new AjaxResponse { Status = 1, StatusMessage = "fetched successfully", Data = jsonres });
                    }
                    else
                    {
                        return Ok(new AjaxResponse { Status = 0, StatusMessage = "No records found", Data = jsonres });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new AjaxResponse { Status = 1, StatusMessage = ex.Message, Data = null });
                }
            }
        }
        [HttpGet("GetProjectSubCategory")]

        public async Task<IActionResult> GetProjectSubCategory(int Id)
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
                    List<ProjectSubcategory> lst = await _commonfunctionrepository.GetSubcategory(Id);
                    var jsonres = JsonConvert.SerializeObject(lst);
                    if (jsonres != null)
                    {
                        return Ok(new AjaxResponse { Status = 1, StatusMessage = "fetched successfully", Data = jsonres });
                    }
                    else
                    {
                        return Ok(new AjaxResponse { Status = 0, StatusMessage = "No records found", Data = jsonres });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new AjaxResponse { Status = 1, StatusMessage = ex.Message, Data = null });
                }
            }
        }
        [HttpGet("GetDistrict")]

        public async Task<IActionResult> GetDistrict()
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
                    List<LocationLevel> lst = await _commonfunctionrepository.GetDistrict();
                    var jsonres = JsonConvert.SerializeObject(lst);
                    if (jsonres != null)
                    {
                        return Ok(new AjaxResponse { Status = 1, StatusMessage = "fetched successfully", Data = jsonres });
                    }
                    else
                    {
                        return Ok(new AjaxResponse { Status = 0, StatusMessage = "No records found", Data = jsonres });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new AjaxResponse { Status = 1, StatusMessage = ex.Message, Data = null });
                }
            }
        }
        [HttpGet("GetBlock")]
        public async Task<IActionResult> GetBlock(int Id)
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
                    List<LocationLevel> lst = await _commonfunctionrepository.GetBlock(Id);
                    var jsonres = JsonConvert.SerializeObject(lst);
                    if (jsonres != null)
                    {
                        return Ok(new AjaxResponse { Status = 1, StatusMessage = "fetched successfully", Data = jsonres });
                    }
                    else
                    {
                        return Ok(new AjaxResponse { Status = 0, StatusMessage = "No records found", Data = jsonres });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new AjaxResponse { Status = 1, StatusMessage = ex.Message, Data = null });
                }
            }
        }
        [HttpGet("GetWard")]
        public async Task<IActionResult> GetWard(int Id)
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
                    List<LocationLevel> lst = await _commonfunctionrepository.GetWard(Id);
                    var jsonres = JsonConvert.SerializeObject(lst);
                    if (jsonres != null)
                    {
                        return Ok(new AjaxResponse { Status = 1, StatusMessage = "fetched successfully", Data = jsonres });
                    }
                    else
                    {
                        return Ok(new AjaxResponse { Status = 0, StatusMessage = "No records found", Data = jsonres });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new AjaxResponse { Status = 1, StatusMessage = ex.Message, Data = null });
                }
            }
        }
        [HttpGet("GetDirector")]
        public async Task<IActionResult> GetDirector(int Id)
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
                    List<Director> lst = await _commonfunctionrepository.GetDirector();
                    var jsonres = JsonConvert.SerializeObject(lst);
                    if (jsonres != null)
                    {
                        return Ok(new AjaxResponse { Status = 1, StatusMessage = "fetched successfully", Data = jsonres });
                    }
                    else
                    {
                        return Ok(new AjaxResponse { Status = 0, StatusMessage = "No records found", Data = jsonres });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new AjaxResponse { Status = 1, StatusMessage = ex.Message, Data = null });
                }
            }
        }
        [HttpGet("GetFinancialYear")]

        public async Task<IActionResult> GetFinancialYear()
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
                    List<FinancialYear> lst = await _commonfunctionrepository.GetFinancialYear();
                    var jsonres = JsonConvert.SerializeObject(lst);
                    if (jsonres != null)
                    {
                        return Ok(new AjaxResponse { Status = 1, StatusMessage = "fetched successfully", Data = jsonres });
                    }
                    else
                    {
                        return Ok(new AjaxResponse { Status = 0, StatusMessage = "No records found", Data = jsonres });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new AjaxResponse { Status = 1, StatusMessage = ex.Message, Data = null });
                }
            }
        }
        [HttpGet("GetConsultant")]

        public async Task<IActionResult> GetConsultant()
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
                    List<Consultant> lst = await _commonfunctionrepository.GetConsultant();
                    var jsonres = JsonConvert.SerializeObject(lst);
                    if (jsonres != null)
                    {
                        return Ok(new AjaxResponse { Status = 1, StatusMessage = "fetched successfully", Data = jsonres });
                    }
                    else
                    {
                        return Ok(new AjaxResponse { Status = 0, StatusMessage = "No records found", Data = jsonres });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new AjaxResponse { Status = 1, StatusMessage = ex.Message, Data = null });
                }
            }
        }
        [HttpGet("GetClient")]

        public async Task<IActionResult> GetClient()
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
                    List<ClientMaster> lst = await _commonfunctionrepository.GetClient();
                    var jsonres = JsonConvert.SerializeObject(lst);
                    if (jsonres != null)
                    {
                        return Ok(new AjaxResponse { Status = 1, StatusMessage = "fetched successfully", Data = jsonres });
                    }
                    else
                    {
                        return Ok(new AjaxResponse { Status = 0, StatusMessage = "No records found", Data = jsonres });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new AjaxResponse { Status = 1, StatusMessage = ex.Message, Data = null });
                }
            }
        }
        [HttpGet("GetProjectType")]
        public async Task<IActionResult> GetProjectType()
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
                    List<ProjectTypeMaster> lst = await _commonfunctionrepository.GetProjectType();
                    var jsonres = JsonConvert.SerializeObject(lst);
                    if (jsonres != null)
                    {
                        return Ok(new AjaxResponse { Status = 1, StatusMessage = "fetched successfully", Data = jsonres });
                    }
                    else
                    {
                        return Ok(new AjaxResponse { Status = 0, StatusMessage = "No records found", Data = jsonres });
                    }
                }
                catch (Exception ex)
                {
                    return Ok(new AjaxResponse { Status = 1, StatusMessage = ex.Message, Data = null });
                }
            }
        }
    }
}
