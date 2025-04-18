﻿using Dal.Models;


//בס"ד

namespace BL.Models
{
    public class BlActivity
    {
        public int ActivityId { get; set; }

        public string ActivityDescription { get; set; } = null!;

        public string? Location { get; set; }

        public int Price { get; set; }

        public int NightPrice { get; set; }

        public  ICollection<BlOrder> Orders { get; set; } = new List<BlOrder>();
    }
}
