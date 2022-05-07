namespace RecipesApp.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Instruction { get; set; }
        public int Portions { get; set; }
        public ICollection<Ingredient>? Ingredients { get; set; }
        public ICollection<RecipeAppliance>? RecipeAppliances { get; set; }
    }
}
