using System;
using System.Security.Cryptography;
using System.Text;

namespace UnitedCalendar.Common
{
    public class Password
    {
        public string Encode(string pass)
        {
            try
            {
                byte[] bytes = Encoding.Unicode.GetBytes(pass);
                byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
                return Convert.ToBase64String(inArray);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Encode: "+ex.Message);
            }
        }
    }
}
