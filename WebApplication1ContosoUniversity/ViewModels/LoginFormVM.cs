using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1ContosoUniversity.ViewModels
{
    public class LoginFormVM
    {
        [Required]
        public String Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(10, ErrorMessage = "Tidak Boleh lebih dari 10 Karakter")]
        public String Password { get; set; }
    }
}