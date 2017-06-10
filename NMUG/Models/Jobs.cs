using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NMUG.Models
{
    public class Jobs
    {
        [Key]
        public int JobId { get; set; }

        [Display(Name = "Job Title")]
        public string JobName { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Posting Date")]
        public DateTime JobPostDate { get; set; }

        [Display(Name = "Brief Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Active Posting")]
        public bool ActiveIn { get; set; }

        [Display(Name ="File Name")]
        public string FileName { get; set; }
        public string MakeWork { get; set; }

        [NotMapped]        
        public string DisplayFileName {
            get { return System.IO.Path.GetFileName(FileName); }
            private set { } }

    }
}
