using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGen.Model.LoginModel
{
    public class CodeGenLogin
    {
       
	    public int userID { get; set; }
	    public string? UserName { get; set; }
		public string? Password { get; set; }
        public string? FullName { get; set; }
        public string? Captcha { get; set; }
	    public string? VCHUSERNAME { get; set; }
        public string? VCHPASSWORD { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? Conformpassword { get; set; }

        public string? Domainname { get; set; }
    	public string? vchmobno { get; set; }
        
        //For AdminConsole
        public int INTUSERID { get; set; }
        public int ROLEID { get; set; }
        public int INTDESIGNATIONID { get; set; }
        public int INTLEVELDETAILID { get; set; }
        public string? ROLENAME { get; set; }
        public string? VCHFULLNAME { get; set; }
    }
    public class LoginResponse
    {
        
        public bool Success { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseText { get; set; }
        public string Token { get; set; }
        public string Data { get; set; } // This is still a JSON string and needs further deserialization
    }
    public class CaptchaValidationModel
    {
        public string UserCaptcha { get; set; }
    }
}

