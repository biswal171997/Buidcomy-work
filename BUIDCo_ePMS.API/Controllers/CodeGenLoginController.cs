using CodeGen.Model.LoginModel;
using BUIDCo_ePMS.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Repository.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CodeGen.Repository.Repositories.Interfaces;
using BUIDCo_ePMS.Model.Entities.ProjectTender;
using BUIDCo_ePMS.Repository.Repositories.Repository;
using BUIDCO.Domain.AdminConsole.User_Management;
using BUIDCo_ePMS.Core.Services;
using BUIDCO.Domain.AdminConsole.Login;
using Microsoft.AspNetCore.Authorization;

namespace BUIDCo_ePMS.API.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]

    public class CodeGenLoginController : Controller
    {
        private readonly ICodeGenLoginRepository _codeGenLogin;
        private readonly IJwtService _jwtService;
        public CodeGenLoginController(ICodeGenLoginRepository CodeGenLoginRepository, IJwtService IJwtService) 
        {
            _codeGenLogin = CodeGenLoginRepository;
            _jwtService = IJwtService;
        }

        [HttpPost("GetLogin")]
        public async Task<IActionResult> GetLogin(CodeGenLogin log)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                 .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Ok(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" 
                });
            }
            else
            {
                CodeGenLogin user = await _codeGenLogin.GetLoginDetails(log);
                if (user == null)
                {
                    // Return 401 Unauthorized if credentials are invalid
                    return Unauthorized(new {
                        success = false,
                        responseMessage = "Invalid credentials.",
                        responseText = "error",
                        token = string.Empty,
                        data = string.Empty
                    });
                }

                // Generate JWT token
                var token = _jwtService.GenerateToken(
                    user.VCHUSERNAME,
                    user.ROLEID.ToString(),
                    user.INTUSERID.ToString(),
                    user.INTLEVELDETAILID.ToString()
                );

                // Serialize user details
                var jsonres = JsonConvert.SerializeObject(user);
                if (jsonres != "")
                {
                    return Ok(new
                    {
                        success = true,
                        responseMessage = "Login Successful.",
                        responseText = "Success",
                        token = token,
                        data = jsonres
                    });
                }
                else
                {
                    return Ok(new 
                    { 
                        sucess = false,
                        responseMessage = "Login Failed.",
                        responseText = "error",
                        data = jsonres 
                    });
                }
            }
        }

       
   
    
    }
}
