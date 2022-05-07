using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
