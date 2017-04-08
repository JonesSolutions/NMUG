using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NMUG.Models
{
    public class Jobs
    {
        public int JobId { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Posting Date")]
        public DateTime JobPostDate { get; set; }


        public string ShortDescription { get; set; }

        [Display(Name = "Description")]
        public string JobDescription { get; set; }

        public bool ActiveIn { get; set; }



    }
}
