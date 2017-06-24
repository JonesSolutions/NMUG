using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
            

namespace NMUG.Models
{
    public class Meeting
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Meeting Date")]
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date (MM/DD/YYYY)")]
        //[DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime MeetingDate { get; set; }
        
        [Display(Name = "Meeting Time")]
        [RegularExpression(@"^(0[1-9]|1[0-2]):[0-5][0-9] (am|pm|AM|PM)$", ErrorMessage = "Please enter a valid Time (HH:MM AM|PM).")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        //[DataType(DataType.Time, ErrorMessage = "Please enter a valid time (HH:MM AM|PM)")]
        public string MeetingTime { get; set; }

        [Display(Name = "Location")]
        [RegularExpression(@"^[A-Z|\d]+[a-zA-Z''-'\s]*$" , ErrorMessage = "First letter must be a capital letter or digit.")]
        public string MeetingLocation { get; set; }

        [Display(Name = "Presenter")]
        [RegularExpression(@"^[A-Z].*$", ErrorMessage = "First letter must be a capital letter.")]
        public string MeetingPresenter { get; set; }
       
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        [StringLength(5000)]
        public string MeetingDescription { get; set; }
        
        //TODO: dotnet ef migrations add -c 
        [Display(Name = "File Name")]
        public string FileName { get; set; }

        [Display(Name = "Date")]
        public string dateTime
        {
            get
            {
                return MeetingDate.Date.Month.ToString() + "/" + MeetingDate.Date.Day.ToString() + "/" + MeetingDate.Date.Year.ToString() + ", " + MeetingTime + " ";
            }
        }

    }
}
