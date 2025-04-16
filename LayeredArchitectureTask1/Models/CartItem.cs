﻿namespace LayeredArchitectureTask1.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageAltText { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
