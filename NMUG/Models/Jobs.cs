using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NMUG.Models
{
    public class Jobs
    {
        [Key]
        public int JobId { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Job Title is limited to 250 characters.")]
        [RegularExpression(@"^[A-Z].*$", ErrorMessage = "Job Title must begin with a capital letter.")]
        [Display(Name = "Job Title")]
        public string JobName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date. (MM/DD/YYYY)")]
        // [Range(typeof(DateTime),"2017/01/01","2099/12/31")] 
        [Display(Name = "Posting Date")]
        public DateTime JobPostDate { get; set; }

        [Required]
        [Display(Name = "Brief Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Active Posting")]
        public bool ActiveIn { get; set; }
        public string FileName { get; set; }
        public string MakeWork { get; set; }


    }
}
