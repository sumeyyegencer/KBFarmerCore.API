using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KBHayvancılıkTakipSistemi.Response
{
    public class formalBarcodeResponse
    {
        public int Id { get; set; }
        
        public int CountryId { get; set; }
        public int DistrictId { get; set; }
        public int motherNumber { get; set; }

        public int FormalNo { get; set; }
        public DateTime DateOfTag { get; set; }



        public CountryResponse Country { get; set; }
        public DistrictResponse District { get; set; }


    }
}
