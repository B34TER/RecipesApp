namespace RecipesApp.Models
{
    public class Ingredient
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public float Amount { get; set; }
        public bool Necessary { get; set; }

    }
}
