using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuslink.Models
{
    public class WarehouseRate
    {
        public int Id { get; set; }

        [Display(Name ="20FT Cartage Rate")]
        public string CartageRate20 { get; set; }

        [Display(Name = "20FT Cartage Single Leg")]
        public string CartageRateSingle20 { get; set; }

        [Display(Name = "40FT Cartage Rate")]
        public string CartageRate40 { get; set; }

        [Display(Name = "20FT Cartage Single Leg")]
        public string CartageRateSingle40 { get; set; }

        [Display(Name = "FAF %")]
        public string CartageFAF { get; set; }

        [Display(Name = "VGM")]
        public string VGM { get; set; }

        [Display(Name = "ATF Charge")]
        public string ATF { get; set; }

        [Display(Name = "MPI Charge")]
        public string MPI { get; set; }
        
        [Display(Name = "VBS")]
        public string CartageVBS { get; set; }

        [Display(Name = "Manual UnPACK 20//40FT")]
        public string UnpackM { get; set; }

        [Display(Name = "Palletized UnPACK 20//40FT")]
        public string UnpackP { get; set; }

        [Display(Name = "Other Charges")]
        public string OtherCharge1 { get; set; }
        [Display(Name = "Other Charges")]
        public string OtherCharge2 { get; set; }
        [Display(Name = "Other Charges")]
        public string OtherCharge3 { get; set; }
        [Display(Name = "Other Charges")]
        public string OtherCharge4 { get; set; }
        [Display(Name = "Other Charges")]
        public string OtherCharge5 { get; set; }
        [Display(Name = "Other Charges")]
        public string OtherCharge6 { get; set; }
        [Display(Name = "Other Charges")]
        public string OtherCharge7 { get; set; }
        [Display(Name = "Other Charges")]
        public string OtherCharge8 { get; set; }

    }
}
