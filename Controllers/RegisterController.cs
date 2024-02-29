using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Sprint_Week_1.Models;
using System.Security.Cryptography;
using System.Text;

namespace Sprint_Week_1.Controllers
{
    public class RegisterController : Controller
    {
        private readonly BookStorecontext _context;
        public RegisterController( BookStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Register user)
        {
            if (ModelState.IsValid)
            {
                // Hash the password using SHA-256
                user.Password = ComputeSha256Hash(user.Password);

                _context.Registers.Add(user);
                _context.SaveChanges();

                TempData["Message"] = "Registration successful!";
                return RedirectToAction("Login");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Register user)
        {
            if (ModelState.IsValid)
            {
                // Hash the provided password
                user.Password = ComputeSha256Hash(user.Password);

                var existingUser = _context.Registers
                    .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

                if (existingUser != null)
                {
                    TempData["Message"] = "Login successful!";
                    return RedirectToAction("Create", "Module"); // Redirect to the index page of the module
                }
                else
                {
                    TempData["ErrorMessage"] = "Login failed. Please check your credentials.";
                }
            }

            return View(user);
        }

        // Helper method to compute SHA-256 hash
        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
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

