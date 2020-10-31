using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace WebAuslink.Models
{
    public class Client
    {[Key]
        public int Id { get; set; }
        [Display(Name = "Client Name")]
        public String ClientCompanyName { get; set; }

        //public clientEnum EnumClientCompanyName { get; set; }

        [DataType(DataType.DateTime)]
       
        public DateTime LastUpdate { get; set; }


        [Display(Name = "20FT Cartage Rate")]
        public string CartageRate20 { get; set; }

        [Display(Name = "20FT Cartage Single Leg")]
        public string CartageRateSingle20 { get; set; }

        [Display(Name = "40FT Cartage Rate")]
        public string CartageRate40 { get; set; }

        [Display(Name = "40FT Cartage Single Leg")]
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

        [Display(Name = "Manual UnPACK 20FT // 40FT")]
        public string UnpackM { get; set; }

        [Display(Name = "Palletized UnPACK 20FT // 40FT")]
        public string UnpackP { get; set; }

        [Display(Name = "Other Charges 1")]
        public string OtherCharge1 { get; set; }
        [Display(Name = "Other Charges 2")]
        public string OtherCharge2 { get; set; }
        [Display(Name = "Other Charges 3")]
        public string OtherCharge3 { get; set; }
        [Display(Name = "Other Charges 4")]
        public string OtherCharge4 { get; set; }
        [Display(Name = "Other Charges 5")]
        public string OtherCharge5 { get; set; }
        [Display(Name = "Other Charges 6")]
        public string OtherCharge6 { get; set; }
        [Display(Name = "Other Charges 7")]
        public string OtherCharge7 { get; set; }
        [Display(Name = "Other Charges 8")]
        public string OtherCharge8 { get; set; }

        [Display(Name = "Auckland Metro LCL Per CBM")]
        public int ChargePerCBM { get; set; }

        [Display(Name = "Auckland Metro LCL Per PALLET")]
        public int ChargePerPLT { get; set; }

        [Display(Name = "Auckland Metro LCL Per Full TruckLoad")]
        public int ChargePerFullTruckLoad { get; set; }

        [Display(Name = "Special 1")]
        public string SpecialCharges1 { get; set; }
        [Display(Name = "Special 2")]
        public string SpecialCharges2 { get; set; }

        public bool IfAccountIsOnHold { get; set; }

        public Client()
        {
            this.LastUpdate = DateTime.Now;
            this.IfAccountIsOnHold = false;
        }
    }
}
