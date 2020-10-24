using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuslink.Models
{
    public class Client
    {[Key]
        public int Id { get; set; }
        public String ClientCompanyName { get; set; }
        public String ClientRateSheetID { get; set; }

        public TransportRate tr { get; set; }

        public WarehouseRate wr { get; set; }

      
    }
}
