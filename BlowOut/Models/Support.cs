using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlowOut.Models
{
    public class Support
    {
        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "PhoneNumber should contain only numbers")]
        public string SupportNumber { get; set; }
    }
}