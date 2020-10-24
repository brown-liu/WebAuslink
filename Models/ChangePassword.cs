using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuslink.Models
{
    public class ChangePassword
    {
        [Key]
        public int Id { get; set; }

        [Required,DataType(DataType.Password)]
        [Display(Name ="Current Password")]
        public string CurrentPassword { get; set; }
        
        
        
        [Display(Name ="New Password")]
        [Required,DataType(DataType.Password)]
        public string NewPassword { get; set; }
        

        [Display(Name ="Confirm New Password")]
        [Required,DataType(DataType.Password)]
        [Compare("NewPassword",ErrorMessage ="Confirm new password not match")]
        public string ConfirmNewPassword { get; set; }

    }
}
