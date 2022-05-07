using System.ComponentModel.DataAnnotations;

namespace RecipesApp.Models
{
    public class Appliance
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Owned { get; set; }
        public ICollection<RecipeAppliance> RecipeAppliances { get; set; }
    }
}
