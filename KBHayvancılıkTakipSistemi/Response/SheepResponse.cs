using KBHayvancılıkTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KBHayvancılıkTakipSistemi.Response
{
    public class SheepResponse
    {
        public int Id { get; set; }
        public long BarcodeNo { get; set; }

        public int RaceId { get; set; }
        public int GroupId { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }

        public int formalBarcodeId { get; set; }


        public RaceResponse Race { get; set; }
        public GroupResponse Group { get; set; }
       

    }

}

