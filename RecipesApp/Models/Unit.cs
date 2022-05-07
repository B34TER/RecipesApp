﻿namespace RecipesApp.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
