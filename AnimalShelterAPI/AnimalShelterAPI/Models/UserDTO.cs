﻿using System.ComponentModel.DataAnnotations;

namespace AnimalShelterAPI.Models
{
    public class UserDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}