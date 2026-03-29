using System;
using System.Collections.Generic;
using System.Text;

namespace AppHotel.Models
{
    public class Accommodation
    {
        public string Description { get; set; }
        public double AmountAdult { get; set; }
        public double AmountKids { get; set; }
        public double PriceAdult { get; set; }
        public double PriceKids { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int Stay { get => EndDate.Subtract(StartDate).Days;  }

        public double TotalPrice 
        { 
            get => Stay * ((AmountKids * PriceKids) + (AmountAdult * PriceAdult));
        }
    }
}
