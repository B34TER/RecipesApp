namespace RecipesApp.Models
{
    public class RecipeAppliance
    {
        public Recipe Recipe { get; set; }
        public Appliance Appliance { get; set; }
        public bool Necessary { get; set; }
    }
}
