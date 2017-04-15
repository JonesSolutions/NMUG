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
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Sponsor Level")]
        public string SponsorLevel { get; set; }
    }
}
