using System;

namespace Models
{
    public class Beverage
    {
        public Guid Id { get; set; }
        public string BevName { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
    }
}