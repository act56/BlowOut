using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class Email
    {
        [Required(ErrorMessage = "Please enter a full name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}