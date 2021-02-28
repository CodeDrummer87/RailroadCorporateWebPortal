﻿using System.ComponentModel.DataAnnotations;

namespace RailwayPortalClassLibrary
{
    public class SignInModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
