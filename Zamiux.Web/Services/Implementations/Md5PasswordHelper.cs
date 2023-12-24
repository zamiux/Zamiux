using System.Security.Cryptography;
using System.Text;
using Zamiux.Web.Services.Interfaces;

namespace Zamiux.Web.Services.Implementations
{
    public class Md5PasswordHelper : IPasswordHelper
    {
        public string HashPassword(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
