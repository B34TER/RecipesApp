namespace RecipesApp.Models
{
    public class Ingredient
    {
        public ICollection<Product> Products { get; set; }
        public Recipe Recipe { get; set; }
        public float Amount { get; set; }
        public bool Necessary { get; set; }
    }
}
