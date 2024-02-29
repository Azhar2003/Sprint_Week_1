using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Reflection;

namespace Sprint_Week_1.Models
{
    public class Register
    {
        public string Username { get; set; } = null!;

        public string? Password { get; set; }

        public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

        public string HashPassword()
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
