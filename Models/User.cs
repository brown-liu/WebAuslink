using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebAuslink.Models
{
    public class User
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage ="Please Enter Your Email address")]
        [StringLength(50)]
        [Display(Name="Email Address")]
        [EmailAddress(ErrorMessage ="Please enter a valid email address")]
        
        public String Email { get; set; }


        [Required]
        [StringLength(50)]
        public String Name { get; set; }


        [Required(ErrorMessage ="Please use a strong password")]
        [Compare("ConfirmPassword",ErrorMessage ="Password not match")]
        [Display(Name="Password")]
       [DataType(DataType.Password)]
        public String Password { get; set; }


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }    

        public string Role { get; set; }
    }   
}
