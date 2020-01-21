using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace NGO.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Please Enter your email.")]
        [Display(Name ="Email: ")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Please Enter your password.")]

        public string Password { get; set; }
    }
}