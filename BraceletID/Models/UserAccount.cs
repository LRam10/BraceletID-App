using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BraceletID.Models
{
    public class UserAccount
    {
        public string Email { get; set; }

        [MinLength(6, ErrorMessage = "Minimum of 6 Characters Required")]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Compare("Password",ErrorMessage ="Password do not match")]
        public string ConfirmPassword { get; set; }
        public string REmail { set; get; }
        public bool IsEmailVerified { set; get; }
        public System.Guid ActivationCode { set; get; }
     
    }
    
}