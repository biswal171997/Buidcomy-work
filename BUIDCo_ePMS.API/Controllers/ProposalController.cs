using BUIDCo_ePMS.Model.Responses;
using BUIDCo_ePMS.Model;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Repository.Repositories.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using BUIDCo_ePMS.Model.Entities.Proposal;
using Microsoft.AspNetCore.Authorization;

namespace BUIDCo_ePMS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        private readonly IProposalRepository _proposalRepository;
        public ProposalController(IProposalRepository proposalRepository)
        {
            _proposalRepository = proposalRepository;
        }
        [HttpPost("SaveProposal")]
        public async Task<IActionResult> SaveProposal(Proposal obj)
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
                    int output = await _proposalRepository.SaveProposal(obj);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = output });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
        [HttpGet("GetProposal")]
        public async Task<IActionResult> GetProposal(string searchtype)
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
                    ProposalDetails list = await _proposalRepository.GetProposal(searchtype);
                    var jsonres = JsonConvert.SerializeObject(list);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = jsonres });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
        [HttpGet("GetProposalByID")]
        public async Task<IActionResult> GetProposalByID(int Id)
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
                    Proposal obj = await _proposalRepository.GetProposalByID(Id);
                    var jsonres = JsonConvert.SerializeObject(obj);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = jsonres });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
        [HttpGet("GetProposalInformationByID")]
        public async Task<IActionResult> GetProposalInformationByID(int Id)
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
                    ProposalInformation obj = await _proposalRepository.GetProposalInformationByID(Id);
                    var jsonres = JsonConvert.SerializeObject(obj);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = jsonres });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
        [HttpPost("SaveProposalSite")]
        public async Task<IActionResult> SaveProposalSite(ProposalSite obj)
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
                    int output = await _proposalRepository.SaveProposalSite(obj);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = output });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
        [HttpPost("DeleteProposalSite")]
        public async Task<IActionResult> DeleteProposalSite(ProposalSite obj)
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
                    int output = await _proposalRepository.DeleteProposalSite(obj);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = output });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
        [HttpGet("GetProposalSiteByID")]
        public async Task<IActionResult> GetProposalSiteByID(int Id)
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
                    ProposalSite obj = await _proposalRepository.GetProposalSiteByID(Id);
                    var jsonres = JsonConvert.SerializeObject(obj);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = jsonres });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
        [HttpPost("SaveFDRDetails")]
        public async Task<IActionResult> SaveFDRDetails(ProposalFdr obj)
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
                    int output = await _proposalRepository.SaveFDRDetails(obj);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = output });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
        [HttpGet("GetProposalFDRByID")]
        public async Task<IActionResult> GetProposalFDRByID(int Id)
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
                    ProposalFdr obj = await _proposalRepository.GetProposalFDRByID(Id);
                    var jsonres = JsonConvert.SerializeObject(obj);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = jsonres });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }

        [HttpPost("SubmitProposal")]
        public async Task<IActionResult> SubmitProposal(Proposal obj)
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
                    int output = await _proposalRepository.SubmitProposal(obj);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = output });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
        [HttpPost("CancelProposal")]
        public async Task<IActionResult> CancelProposal(Proposal obj)
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
                    int output = await _proposalRepository.CancelProposal(obj);
                    return Ok(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Success", data = output });
                }
                catch (Exception ex)
                {
                    return Ok(new { sucess = true, responseMessage = ex.Message, responseText = "Fail", data = "" });
                }
            }
        }
    }
}
