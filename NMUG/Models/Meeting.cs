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
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime MeetingDate { get; set; }
        
        [Display(Name = "Meeting Time")]
        public DateTime MeetingTime { get; set; }

        [RegularExpression(@"^[\d|A-Z]+[a-zA-Z''-'\s]*$")]
        [Display(Name = "Meeting Location")]
        public string MeetingLocation { get; set; }
        
        [Display(Name = "Meeting Presenter")]
        public string MeetingPresenter { get; set; }

       
        [Display(Name = "Meeting Description")]
        [DataType(DataType.MultilineText)]
        [StringLength(5000)]
        public string MeetingDescription { get; set; }


    }
}
