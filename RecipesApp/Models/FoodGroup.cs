using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Models
{
    public class FoodGroup
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool PlantBased { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
