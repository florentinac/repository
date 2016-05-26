using System;

namespace StoreCore.Models
{
    public class Tranzaction
    {
        public int TranzactionNumber { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public DateTime TranzactionTime { get; set; }

    }
}
