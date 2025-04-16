using System.Text.RegularExpressions;

namespace BUIDCo_ePMS.Web.Models
{
    public class ServerSideValidation
    {
        public bool Validate_Regex_Number(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"^[0-9]*$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Validate_Regex_Alphanumeric(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z0-9 ]*$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Validate_Regex_Alphanumeric_SpecialCharacter(string value)   // Added BY Ganesh
        {
            try
            {
                if (value != null)
                {
                    if (Regex.IsMatch(value, @"^[a-zA-Z0-9*()/-]*$"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool Validate_Regex_Remark(string value)
        {
            try
            {
                return !(value.Contains('<') || value.Contains('>') || value.Contains('!') || value.Contains('@'));
                //return Regex.IsMatch(value, @"^[a-zA-Z0-9 .-]*$");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Validate_Regex_Codes(string value)
        {
            try
            {
                if (value != null)
                {
                    return value.Contains('<') || value.Contains('>') || value.Contains('!') || value.Contains('@');
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Validate_Regex_Amount(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"^[1-9]\d*(\.\d+)?$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Validate_Regex_Date(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"^[ A-Za-z0-9_@./#&+:-]*$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Validate_Regex_Email(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool Validate_Regex_Address(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"^[#.0-9a-zA-Z\s,:\\//()|-]+$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Validate_Regex_Decimal(string value)   // Added BY Goutam Prasad Bihari
        {
            try
            {
                if (Regex.IsMatch(value, @"^[0-9]+\.[0-9]*$"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool Validate_FinancialYear(string value)
        {
            try
            {
                // Regex Explanation:
                // ^           : Start of the string
                // (19|20)\d{2}: Matches years starting with 19xx or 20xx
                // -           : Hyphen separator
                // (\d{2})    : Matches exactly two digits
                // $           : End of the string
                if (Regex.IsMatch(value, @"^(19|20)\d{2}-(\d{2})$"))
                {
                    // Additional validation to ensure the second year is exactly one year after the first
                    var years = value.Split('-');
                    int startYear = int.Parse(years[0]);
                    int endYear = int.Parse(years[1]);

                    if (endYear == (startYear + 1) % 100) // Handle cases like 2024-25
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
