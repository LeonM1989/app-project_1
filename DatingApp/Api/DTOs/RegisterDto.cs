using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs
{
    public class RegisterDto
    {
        [Required] 
        public string UserName {get; set;}
         
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4-8 characters")]
        [Required]
        public string Password {get; set;}
    }
}