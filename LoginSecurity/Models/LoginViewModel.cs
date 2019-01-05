using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LoginSecurity.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Please enter email address")]
        [EmailAddress(ErrorMessage = "Please enter valid email address")]
        [Remote("CheckExistsOrNot", "Home", HttpMethod = "POST", ErrorMessage = "EmailId is not register.")]
        public string Emailaddress { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        public string Password { get; set; }

        
    }
}