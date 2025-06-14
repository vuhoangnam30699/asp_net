﻿namespace ShoppingCart.Models
{
    public class Mobiles
    {
        public int Id { get; set; }
        public string? MobileName { get; set; }
        public double Price { get; set; }
        public string? Url { get; set; }
        public string? ZoomUrl { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<MobileDetails> MobileDetails { get; set; } = new List<MobileDetails>();
    }
}
