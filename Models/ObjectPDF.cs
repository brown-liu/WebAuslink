using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace WebAuslink.Models
{
    //this is not a entity bacuse it is using IFORMFILE. please check class FileLoader
    public class ObjectPDF
    {
        public int Id { get; set; }
        [Display(Name = "File Title")]
        [Required]
        public string Title { get; set; }
        public string Classification { get; set; }
        public IFormFile  pdf { get; set; }
        public string pdfUrl { get; set; }

    }
}
