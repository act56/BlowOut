using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class Contact
    {
        [Required(ErrorMessage ="Please enter a full name (First and Last Name")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage ="Please enter a valid Email address")]
        public string EmailAddress { get; set; }

        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "PhoneNumber should contain only numbers")]
        public string phone { get; set; }

        public string message { get; set; }

    }
}