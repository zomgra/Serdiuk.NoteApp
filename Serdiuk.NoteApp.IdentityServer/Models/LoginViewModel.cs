﻿using System.ComponentModel.DataAnnotations;

namespace Serdiuk.NoteApp.IdentityServer.Models
{
    public class LoginViewModel
    {
            [Required]
            public string Username { get; set; }

            [Required]
            public string Password { get; set; }

            [Required]
            public string ReturnUrl { get; set; }
    }
}
