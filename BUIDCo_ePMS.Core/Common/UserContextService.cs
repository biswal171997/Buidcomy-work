using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
namespace BUIDCo_ePMS.Core
{
    public class UserContextService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        private List<Claim> GetDecryptedClaims()
        {
            var encryptedClaimValue = _httpContextAccessor.HttpContext?.User.FindFirst("EncryptedClaims")?.Value;

            if (!string.IsNullOrEmpty(encryptedClaimValue))
            {
                // Decrypt the claim
                string decryptedJson = DecryptData(encryptedClaimValue);

                // Deserialize back to List<Claim>
                List<ClaimDto> claimDtos = JsonConvert.DeserializeObject<List<ClaimDto>>(decryptedJson);

                // Convert List<ClaimDto> to List<Claim>
                return claimDtos.Select(dto => new Claim(dto.Type, dto.Value)).ToList();
            }

            return new List<Claim>(); // Return empty list if no claims found
        }
        public class ClaimDto
        {
            public string Type { get; set; }
            public string Value { get; set; }
        }
        public string Username => GetDecryptedClaims().Find(c => c.Type == ClaimTypes.Name)?.Value;
        public string RoleId => GetDecryptedClaims().Find(c => c.Type == ClaimTypes.Role)?.Value;
        public string UserId => GetDecryptedClaims().Find(c => c.Type == "UserId")?.Value;

        public string INTDESIGNATIONID => GetDecryptedClaims().Find(c => c.Type == "INTDESIGNATIONID")?.Value;

        public string IntLevelDetailsId => GetDecryptedClaims().Find(c => c.Type == "Intleveldetailsid")?.Value;
        public string Token => GetDecryptedClaims().Find(c => c.Type == "Token")?.Value;

        public static string DecryptData(string cipherString)
        {
            if (!string.IsNullOrEmpty(cipherString))
            {
                try
                {
                    cipherString = cipherString.Replace(" ", "+");
                    byte[] keyArray;
                    byte[] toEncryptArray = Convert.FromBase64String(cipherString);
                    string key = "!@#$%^&*()_+~";
                    MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                    hashmd5.Clear();

                    using (AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider())
                    {
                        aesProvider.Key = keyArray;
                        aesProvider.Mode = CipherMode.ECB;
                        aesProvider.Padding = PaddingMode.PKCS7;

                        ICryptoTransform decryptor = aesProvider.CreateDecryptor();
                        byte[] resultArray = decryptor.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                        string decryptedText = Encoding.UTF8.GetString(resultArray);
                        return decryptedText;
                    }
                }
                catch (CryptographicException ex)
                {
                    // Log or handle the exception as needed
                    Console.WriteLine("Decryption error: " + ex.Message);
                    return ""; // or throw ex; to propagate the exception
                }
            }
            if (cipherString != "")
            {
                cipherString = cipherString.Replace(" ", "+");
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(cipherString);
                string key = "!@#$%^&*()_+~";
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
                using (AesCryptoServiceProvider tdes = new AesCryptoServiceProvider())
                {
                    tdes.Key = keyArray;
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;
                    ICryptoTransform cTransform = tdes.CreateDecryptor();
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                    tdes.Clear();
                    string decodedData = Encoding.UTF8.GetString(resultArray);
                    return decodedData;

                }
            }
            else
            {
                return "";
            }
        }

    }
}
