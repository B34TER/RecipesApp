using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesApp.Models
{
    public class RecipeAppliance
    {
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int ApplianceId { get; set; }
        public Appliance Appliance { get; set; }
        public bool Necessary { get; set; }
    }
}
