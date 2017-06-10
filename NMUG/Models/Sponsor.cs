using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NMUG.Models
{
    public class Sponsor
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Enter a shorter company name, please. Maximum 50 characters.")]
        [RegularExpression(@"^[A-Z].*$", ErrorMessage = "Company Name must begin with a capital letter.")]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please enter Sponsorship level- Platinum-$1500 and up, Gold-$1000-1499, Silver-$250-999 or Patron-$100-249. Maximum 50 characters.")]
        [RegularExpression(@"^[A-Z].*$", ErrorMessage = "Sponsor Level must begin with a capital letter.")]
        [Display(Name = "Sponsor Level")]
        public string SponsorLevel { get; set; }
        
    }
}
