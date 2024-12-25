﻿using System.ComponentModel.DataAnnotations;

namespace ETicaret.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; }

        public bool IsVendor { get; set; }  // Satıcı olup olmadığını belirtir
        public bool IsManager { get; set; } // Müdür olup olmadığını belirtir
        
    }


}
