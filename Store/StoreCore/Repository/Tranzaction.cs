using System;

namespace StoreCore.Repository
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
