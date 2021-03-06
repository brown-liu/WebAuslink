﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuslink.Models
{
    public class IssueBoard
    {   [Key]
        public int id { get; set; }
        [Display(Name ="Issue Title")]
        [Required(ErrorMessage ="Please state the name of issue")]
        public string IssueTitle { get; set; }
        [Required(ErrorMessage ="need to provide name of person who raised this issue")]
        [Display(Name = "Person who made this report")]
        public string WhoRaisedThisIssue { get; set; }


        [Display(Name ="Description")]
        [Required(ErrorMessage = "need to provide details of this issue")]
        public string issueDescription { get; set; }

        [Display(Name = "Time Raised")]
        public DateTime IssueDateRaised { get; set; }

        [Display(Name = "Time Solved")]
        public DateTime? IssueSolved { get; set; }

        [Display(Name = "If this issue has been solved")]
        public bool IfIssueIsSolved { get; set; }

        [Display(Name = "Person who and how this issue was solved")]
        public string WhoSolvedIssue { get; set; }
        
        
        public IssueBoard()
    {
            this.IssueDateRaised = DateTime.Now;


    }
    }

    
}
