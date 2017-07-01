using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NMUG.ValidationAttributes;

namespace NMUG.Models
{
    public class Directors
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Please enter a shorter first name. Maximum 50 characters.")]
        [RegularExpression(@"^[A-Z].*$", ErrorMessage = "First Name should start with a capital letter.")]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please enter a shorter last name. Maximum 50 characters.")]
        [RegularExpression(@"^[A-Z].*$", ErrorMessage = "Last Name should start with a capital letter.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(50, ErrorMessage = "Please enter a shorter email address. Maximum 50 characters.")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Please enter a shorter Role Description. Maximum 100 characters.")]
        [RegularExpression(@"^[A-Z].*$")]
        public string RoleDescription { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Please enter a shorter Biography. Maximum 500 characters.")]
        public string Biography { get; set; }

        [Required]
        [Display(Name ="Title")]
        public int TitleID { get; set; }
        [ForeignKey("TitleID")]
        [Display(Name = "Title")]
        [ValidTitle(ErrorMessage = "The same Title cannot be entered twice.")]
        public Title title { get; set; }
        
        [Required]
        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return  FirstName + " " +LastName;
            }
        }

        public string Image { get; set; }
        

    }
}
