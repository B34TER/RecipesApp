namespace RecipesApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Amount { get; set; }
        public Unit? Unit { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public FoodGroup FoodGroup { get; set; }
        public bool Owned { get; set; }
    }
}
