using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMUG.Models
{
    public class Membership
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must provide a Phone Number")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?[0-9]{3})\)[-. ]?(0-9]{3})[-. ]?(0-9]{4}$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        
        //public bool Type { get; set; }

    }
}
