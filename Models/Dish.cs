#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace _5_Chefs_N_Dishes.Models;

public class Dish
{
    [Key]
    public int DishId {get;set;}

    [Required]
    [MinLength(2, ErrorMessage = "Name must be at least 2 chars")]
    public string Name {get;set;}
    
    [Required]
    [Range(0, Int32.MaxValue, ErrorMessage = "Calories must be greater than 0")]
    public int Calories {get;set;}

    [Required]
    [Range(1, 6, ErrorMessage = "Tastiness must be between 1 and 5")]
    public int Tastiness {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    [Required]
    [Display(Name = "Chef's Name")]
    public int ChefId {get;set;}
    public Chef? Creator {get;set;}
}