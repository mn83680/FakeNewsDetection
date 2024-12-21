using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using FND.Models;



namespace FND.ViewModel
{
    public class RegisterUserViewModel
    {
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Compare("Password")] //تقارن
        public string ConfirmPassword { get; set; }

        public int? PhoneNumber { get; set; } = 0;
        public string? Address { get; set; } = string.Empty;
    }
}
