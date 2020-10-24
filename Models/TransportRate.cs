using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuslink.Models
{
    public class TransportRate
    {
        public int Id { get; set; }

        [Display(Name ="Per CBM")]
        public int ChargePerCBM { get; set; }
        
        [Display(Name = "Per PALLET")]
        public int ChargePerPLT { get; set; }

        [Display(Name = "Per Full TruckLoad")]
        public int ChargePerFullTruckLoad { get; set; }

        [Display(Name = "Special 1")]
        public string SpecialCharges1 { get; set; }
        [Display(Name = "Special 2")]
        public string SpecialCharges2 { get; set; }

    }
}
