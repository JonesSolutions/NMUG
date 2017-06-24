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
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Please provide a Email Address.")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please provide a Phone Number.")]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        //TODO: Add to view and controller
        [Display(Name ="Start Date")]
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString = "0:MM/yyyy")]
        public DateTime StartDate { get; internal set; }

        //TODO: Add to view and controller
        [Display(Name = "Current Member")]
        public bool IsCurrent { get; internal set; }

        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }


    }
}
