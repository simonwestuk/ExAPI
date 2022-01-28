﻿using System.ComponentModel.DataAnnotations;

namespace ExAPI.Models
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
