using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebAuslink.Services;


namespace WebAuslink.Models
{
    public class SeaContainer
    {
        [Key]
        [Display(Name ="Container No.")]
        public String ContainerNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM-dd ddd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ocean/F ETA")]
        public DateTime OceanFreightETA { get; set; }



        [Display(Name = "Day To Yard")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM-dd ddd}", ApplyFormatInEditMode = true)]
       public DateTime? TimeToYard { get; set; }


        [Required (ErrorMessage ="Please select client name")]
        [Display(Name = "Client")]
        public String ClientCompanyName { get; set; }

        [Required(ErrorMessage = "Who passed this information to you?")]
        [Display(Name = "Handler")]
        public String HandlerName { get; set; }
        [Display(Name = "Cartage ONLY")]
        public bool IfCartageOnly { get; set; }
        [Display(Name = "Deliver")]
        public bool IfRequireDelivery { get; set; }
        [Display(Name = "Storage")]
        public bool IfRequireStorage { get; set; }
        [Display(Name = "Cartage Booked")]
        public bool IfBookedCartage { get; set; }
        [Display(Name = "REF")]
        public bool Reference { get; set; }
        [Display(Name = "CC Record")]
        public bool IfEnteredCartonCloud { get; set; }
        [Display(Name = "XERO INV")]
        public bool IfInvoiced { get; set; }

        [Required(ErrorMessage = "Please put special information here. Be short but be ac")]

        public string SpecialInstruction { get; set; }
    }
}
