using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitedCalendar.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "O Nome é um campo Obrigatório.")]
        public string Nome { get; set; }
        public string? Escola { get; set; }
    }
}
