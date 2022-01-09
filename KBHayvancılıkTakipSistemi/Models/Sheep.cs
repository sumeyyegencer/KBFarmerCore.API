using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KBHayvancılıkTakipSistemi.Models
{
    public partial class Sheep
    {
        public int Id { get; set; }
        public long BarcodeNo { get; set; }
        public int RaceId { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GroupId { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }

        public virtual Group Group { get; set; }
        public virtual Race Race { get; set; }
    }
}
