using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using CodeGen.Model.LoginModel;
using CodeGen.Model.forgetpassmodel;
using CodeGen.Repository.Repositories.Interfaces;
using ClientsideEncryption;
using BUIDCo_ePMS.Core.Services;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Security.Policy;
using System.Text;
using BUIDCo_ePMS.Web.Models;
using Microsoft.Extensions.Hosting.Internal;
using System.Net.Http;
using Azure;
using BUIDCo_ePMS.Model.Entities.Master;
using System.Collections.Generic;
using BUIDCo_ePMS.Model.M_MileStone_Master;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using NuGet.Protocol.Plugins;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using BUIDCo_ePMS.Core;
using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Fonts;
using SixLabors.ImageSharp.Drawing.Processing;

namespace BUIDCo_ePMS.Web
{
    public class CodeGenLoginController : Controller
    {
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private static readonly Random random = new Random();
        public IConfiguration Configuration;
        private readonly ICodeGenLoginRepository _CodeGenLoginRepository;
        private readonly ISendSMSRepository _sms;
        private readonly IJwtService _jwtService;
        Uri url;// = new Uri("http://localhost/BUIDCo_ePMS_API/api");
        HttpClient client;
        private IWebHostEnvironment _hostingEnvironment;
        private readonly UserContextService _userContextService;
        readonly ServerSideValidation cl = new();
        public CodeGenLoginController(IConfiguration configuration, ICodeGenLoginRepository CodeGenLoginRepository, ISendSMSRepository sms, IJwtService jwtService, IWebHostEnvironment hostingEnvironment, IHttpClientFactory httpClientFactory, UserContextService userContextService)
        {
            Configuration = configuration;
            _CodeGenLoginRepository = CodeGenLoginRepository;
            _sms = sms;
            _jwtService = jwtService;
            _hostingEnvironment = hostingEnvironment;
            var factoryClient = httpClientFactory.CreateClient("MyApiClient");
            client = new HttpClient();
            client.BaseAddress = factoryClient.BaseAddress;
            url = client.BaseAddress;
            _userContextService = userContextService;
        }
        
        public IActionResult GenerateCaptcha()
        {
            string captchaText = GenerateCaptchaText(5);

            // Store CAPTCHA in session for validation
            HttpContext.Session.SetString("Captcha", captchaText);

            using var image = new Image<Rgba32>(130,30);
            var font = SystemFonts.CreateFont("Arial", 24);

            image.Mutate(ctx =>
            {
                //ctx.Fill(Color.LightGray);
                ctx.DrawText(captchaText, font, Color.Black, new PointF(20, 10));
            });

            using var ms = new MemoryStream();
            image.SaveAsPng(ms);
            return File(ms.ToArray(), "image/png");
        }

        private static string GenerateCaptchaText(int length)
        {
            char[] captcha = new char[length];
            for (int i = 0; i < length; i++)
            {
                captcha[i] = chars[random.Next(chars.Length)];
            }
            return new string(captcha);
        }
     
        public IActionResult ValidateCaptcha([FromBody] CaptchaValidationModel model)
        {
            var sessionCaptcha = HttpContext.Session.GetString("Captcha");

            if (string.IsNullOrEmpty(sessionCaptcha))
            {
                //GenerateCaptcha();
                return Json(new { success = false, message = "Session expired, please refresh the CAPTCHA." });
            }

            if (model.UserCaptcha.Trim().ToUpper() == sessionCaptcha.ToUpper())
            {
                return Json(new { success = true, message = "CAPTCHA verified successfully." });
            }
            else
            {
                //GenerateCaptcha();
                return Json(new { success = false, message = "Incorrect CAPTCHA, please try again." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> UserLogin(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

            // Wait before deleting cookies to ensure sign-out completion
            await Task.Delay(500);

            Response.Cookies.Delete(".AspNetCore.Cookies");
            Response.Cookies.Delete(".AspNetCore.Antiforgery");
            Response.Cookies.Delete("Authorization");
            Response.Cookies.Delete(".AspNetCore.Cookies", new CookieOptions
            {
                Path = HttpContext.Request.PathBase.HasValue ? HttpContext.Request.PathBase.Value : "/",
                Secure = true, // Use true if using HTTPS
                HttpOnly = true
            });
            

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> UserLogin([FromBody] CodeGenLogin log)
        {
           
            List<CodeGenLogin> lst = new List<CodeGenLogin>();
            try
            {
                if (!ModelState.IsValid)
                {
                    var message = string.Join("|", ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage));
                    return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
                }
                else
                {
                    log.UserName = AESEncrytDecry.DecryptStringAES(log.UserName);
                    log.Password = AESEncrytDecry.DecryptStringAES(log.Password);
                    var Antiforgerytoken = HttpContext.Request.Cookies[".AspNetCore.Antiforgery"]; // or fetch from header
                    client.DefaultRequestHeaders.Add("RequestVerificationToken", Antiforgerytoken);
                    HttpResponseMessage response = await client.PostAsync(url + "/CodeGenLogin/GetLogin", new StringContent(JsonConvert.SerializeObject(log),
  Encoding.UTF8, "application/json"));
                    string errorResponse = await response.Content.ReadAsStringAsync();


                    Console.WriteLine("Error Response: " + errorResponse);
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        var responseContent = await response.Content.ReadAsStringAsync();

                        var apiResponse = JsonConvert.DeserializeObject<LoginResponse>(responseContent);


                        var login = JsonConvert.DeserializeObject<CodeGenLogin>(apiResponse.Data);


                        var token = apiResponse?.Token;
                        var jwtSettings = Configuration.GetSection("Jwt");
                        if (!string.IsNullOrEmpty(token))
                        {
                            var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, login.VCHUSERNAME),
                                new Claim(ClaimTypes.Role, login.ROLEID.ToString()),
                                new Claim("UserId", login.INTUSERID.ToString()),
                                new Claim("Intleveldetailsid", login.INTLEVELDETAILID.ToString()),
                                new Claim("Token", token)
                            };
                            string claimsJson = JsonConvert.SerializeObject(claims);
                            var claimnsencrypt= AESEncrytDecry.EncryptData(claimsJson);
                            // Create a ClaimsIdentity using the cookie authentication scheme
                            //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            var encryptedClaims = new List<Claim>
{
    new Claim("EncryptedClaims", claimnsencrypt)
};
                            var claimsIdentity = new ClaimsIdentity(encryptedClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                            // Set authentication properties (e.g., expiration, persistence)
                            var authProperties = new AuthenticationProperties
                            {
                                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(Convert.ToDouble( jwtSettings["TokenValidityInHours"])),
                                IsPersistent = true
                            };

                            // Sign in the user by creating an authentication cookie
                            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity),
                                authProperties
                            );
                        }
                        #region MyRegion
                        //   string data = response.Content.ReadAsStringAsync().Result;
                        //dynamic JsonResponse = JsonConvert.DeserializeObject(data) ?? new object(); ;
                        // var login = JsonConvert.DeserializeObject<CodeGenLogin>(JsonResponse.data.ToString());



                        //var token = _jwtService.GenerateToken(login.VCHUSERNAME, login.ROLEID.ToString(), login.INTUSERID.ToString(), login.INTLEVELDETAILID.ToString());
                        //var handler = new JwtSecurityTokenHandler();
                        //var jwtToken = handler.ReadJwtToken(token);
                        // var claims = jwtToken.Claims.ToList();

                        // var identity = new ClaimsIdentity(claims, "jwt");
                        //var principal = new ClaimsPrincipal(identity);

                        // **Store claims in HttpContext**
                        //HttpContext.User = principal;

                        //                var claims1 = new List<Claim>
                        //{
                        //    new Claim(ClaimTypes.Name, login.VCHUSERNAME),
                        //    new Claim(ClaimTypes.Role, login.ROLEID.ToString()),
                        //    new Claim("UserId", login.INTUSERID.ToString()),
                        //    new Claim("Intleveldetailsid", login.INTLEVELDETAILID.ToString())
                        //};


                        // Create identity and principal
                        //var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        //var principal = new ClaimsPrincipal(identity);

                        //// Sign in the user with the claims
                        //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                        //x = JsonResponse.data;
                        #endregion

                      

                        return Json(new { sucess = true, responseMessage = "Login Successful..", responseText = "success", data = login });
                    }
                    else
                    {
                        var message = "Invalid UserId Or password";
                        return Json(new { sucess = false, responseMessage = message, responseText = "Login Failed !", data = "" });
                    }

                    #region MyRegion
                    JsonConvert.SerializeObject(lst);
                        ////  var data = await _CodeGenLoginRepository.GetLoginDetails(log);
                        //if (jsonres != null)
                        //{
                        //    //ADD by manoj kumar biswal for jwt token implemention;
                        //    // var token = _jwtService.GenerateToken(data.VCHUSERNAME);

                        //    //  var refreshToken = _jwtService.GenerateRefreshToken();
                        //    // Console.WriteLine(token);
                        //    /////////////////////////////
                        //    //HttpContext.Session.SetInt32("userId", data.INTUSERID);
                        //    //HttpContext.Session.SetString("UserId", Convert.ToString(data.INTUSERID));
                        //    //HttpContext.Session.SetString("UserName", data.VCHUSERNAME);
                        //    //if (data.ROLEID != 0)
                        //    //{
                        //    //    HttpContext.Session.SetInt32("roleId", (int)data.ROLEID);
                        //    //}
                        //    //if (data.INTDESIGNATIONID != 0)
                        //    //{
                        //    //    HttpContext.Session.SetInt32("DesgId", (int)data.INTDESIGNATIONID);
                        //    //}
                        //    //if (data.ROLENAME != null)
                        //    //{
                        //    //    HttpContext.Session.SetString("RoleName", data.ROLENAME);
                        //    //}
                        //    //HttpContext.Session.SetInt32("userId", data.INTUSERID);
                        //    //HttpContext.Session.SetInt32("roleId", (int)data.ROLEID);
                        //    //HttpContext.Session.SetInt32("DesgId", (int)data.INTDESIGNATIONID);
                        //    //HttpContext.Session.SetString("UserName", data.VCHUSERNAME);
                        //    //HttpContext.Session.SetString("FullName", data.VCHFULLNAME);


                        //}
                        #endregion                         //var jsonres = 
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            ViewBag.userID = HttpContext.Session.GetInt32("userId");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> ChangePassword(CodeGenLogin Upd)
        {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return Json(new { sucess = false, responseMessage = message, responseText = "Model State is invalid", data = "" });
            }
            else
            {
                var data = await _CodeGenLoginRepository.ChangePwd(Upd);
                if (data == 1)
                {
                    return Json(new { sucess = true, responseMessage = "Action taken Successfully.", responseText = "Update Successfully", data = data });

                }
                return Json(new { sucess = true, responseMessage = "Error.", responseText = "Current Password Invalid", data = data });
            }
        }
        #region Send SMS Code Added By Manoj
        public IActionResult Forgetpass()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Forgetpass(forgetpassmodel model)
        {
            var result = _CodeGenLoginRepository.GetLoginDetails(model).Result.FirstOrDefault();
            if (result != null)
            {
                ModelState.Clear();
                model.emailsent = true;
                int OTP = 0;
                Random rnd = new Random();
                OTP = rnd.Next(1000, 9999);
                model.otp = OTP;
                model.roleid = result.roleid;
                var result1 = _CodeGenLoginRepository.insertotp(model);
                sendemail(model.vchemail, model.otp);
                return Json(new { sucess = true, responseMessage = "OTP Send Succesfully.", responseText = "Success" });
            }
            else
            {
                return Json(new { sucess = false, responseMessage = "Invalid Emailid or Userid!", responseText = "error" });
            }

        }


        public string sendemail(string tomail, int otp)
        {
            var body = "Your otp for forget password is " + otp + "";
            bool Res = false;
            try
            {
                var SmtpHost = Configuration.GetValue<string>("Email:Host");// "smtp.zoho.com";
                var FromEmail = Configuration.GetValue<string>("Email:Username");
                var Password = Configuration.GetValue<string>("Email:Password");
                var toEmail = tomail;
                var Port = Configuration.GetValue<string>("Email:Port");
                var enbleSSl = true;
                MailMessage mail = new MailMessage();

                SmtpClient SmtpServer = new SmtpClient(SmtpHost);
                mail.From = new MailAddress(FromEmail);

                mail.To.Add(toEmail);

                mail.Subject = "OTP Send For Forget Password";
                //mail.Subject = "OTP Send For marraige Soumya Ranjan Das";
                mail.Body = body;

                SmtpServer.Port = Convert.ToInt32(Port);

                SmtpServer.Credentials = new System.Net.NetworkCredential(FromEmail, Password);

                SmtpServer.EnableSsl = enbleSSl;

                mail.IsBodyHtml = true;

                SmtpServer.Send(mail);

                Res = true;

                return "Mail sent successfully";
            }
            catch (Exception ex)
            {
                var error = "";
                if (ex.InnerException.Message == null)
                {
                    error = ex.Message;
                }
                else
                {
                    error = ex.InnerException.Message;
                }
                Res = false;
                return error;
            }
        }

        [HttpPost]
        public JsonResult checkotp(forgetpassmodel model)
        {
            var result = _CodeGenLoginRepository.Otpcheck(model).Result;
            if (result.otp == model.otp)
            {
                return Json(new { sucess = true, responseMessage = "OTP Verified Succesfully.", responseText = "Success" });
            }
            else
            {
                return Json(new { sucess = false, responseMessage = "Invalid OTP!", responseText = "error" });
            }

        }

        public IActionResult Newpassword(string Domainname)
        {
            ViewBag.domain = Domainname;
            return View();
        }
        [HttpPost]
        public JsonResult Newpassword(forgetpassmodel model)
        {
            var result = _CodeGenLoginRepository.NewPassword(model).Result;
            if (result == 1)
            {
                return Json(new { sucess = true, responseMessage = "Password Changed Succesfully.", responseText = "Success" });
            }
            else
            {
                return Json(new { sucess = false, responseMessage = "Something wrong happened please try again!", responseText = "error" });
            }
        }



        public IActionResult SendSMS()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendSMS(CodeGenLogin model)
        {
            var result = _CodeGenLoginRepository.validateuser(model).Result.FirstOrDefault();
            if (result != null)
            {
                ModelState.Clear();
                var templateid = "1007643220090940278";
                var message = "Dear User, a new activity with target completion date of 20-May-2023 has been added for IT department. 5T Monitoring";
                var smsresult = _sms.Sendsms(model.vchmobno, message, templateid);
                //return Json("SMS Sent Successfully.");
                return Json(smsresult.Result);
            }
            else
            {
                return Json("Invalid User!!");
            }

        }
        #endregion
        #region For Logout
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {


            // Sign out from authentication scheme
            // Sign out from authentication
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

            // Wait before deleting cookies to ensure sign-out completion
            await Task.Delay(500);

            Response.Cookies.Delete(".AspNetCore.Cookies");
            Response.Cookies.Delete(".AspNetCore.Antiforgery");
            Response.Cookies.Delete("Authorization");
            Response.Cookies.Delete(".AspNetCore.Cookies", new CookieOptions
            {
                //   Path = "/BUIDCo_ePMS.Web",
                Path = HttpContext.Request.PathBase.HasValue ? HttpContext.Request.PathBase.Value : "/",
                Secure = true, // Use true if using HTTPS
                HttpOnly = true
            });

            // Redirect to login page

            return Json(new { success = true }); // Return JSON response
        }
        #endregion
    }
}
