using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;





namespace WebAuslink.Controllers
{
    public class DisplayOnlyController:Controller
    {
        public IActionResult CheckList()
        {
            return View();
        }

        public IActionResult sop_main()
        { 
            return View();
        }

        public IActionResult auslink_structure()

        {
            return View();
        }


    }


}
