﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebAuslink.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAuslink.Models
{
    public class SeaContainer
    {
        public SeaContainer()
        {
            this.JobFullyCompleted = false;
        }
      
        [Key]
        public int Id { get; set; }
        
        [Display(Name = "Yard")]

        public string DestinationSite { get; set; }

        public bool JobFullyCompleted { get; set; }

        
        [Display(Name ="Container No.")]
        [Remote (action:"Verify_Container_Number",controller:"SeaContainer")]
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
        [Display(Name = "Nd Deliver")]
        public bool IfRequireDelivery { get; set; }
        [Display(Name = "Nd Storage")]
        public bool IfRequireStorage { get; set; }
        [Display(Name = "Cartage Booked")]
        public bool IfBookedCartage { get; set; }
        [Display(Name = "Require Inspection")]
        public bool Reference { get; set; }
        [Display(Name = "CC Record")]
        public bool IfEnteredCartonCloud { get; set; }
        [Display(Name = "XERO INV")]
        public bool IfInvoiced { get; set; }

        [Required(ErrorMessage = "Please put special information here. Be short but be ac")]

        public string SpecialInstruction { get; set; }

        public string CCPONumber { get; set; }

        [Display(Name = "Commodity")]
        [StringLength(15)]
        public string Commodity { get; set; }
      
    }
}
