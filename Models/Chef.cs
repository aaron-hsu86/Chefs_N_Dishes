#pragma warning disable CS8618
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace _5_Chefs_N_Dishes.Models;

public class Chef
{
    [Key]
    public int ChefId {get;set;}

    [Required]
    [Display(Name = "First Name")]
    public string FirstName {get;set;}
    [Required]
    [Display(Name = "Last Name")]
    public string LastName {get;set;}
    [Required]
    [DateMinimumAge(18, ErrorMessage = "Chef must be at least 18 years old")]
    [Display(Name = "Date of Birth")]
    public DateTime DOB {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public List<Dish> AllDishes {get;set;} = new List<Dish>();
    
}
public class DateMinimumAgeAttribute : ValidationAttribute
{
    public DateMinimumAgeAttribute(int minimumAge)
    {
        MinimumAge = minimumAge;
    }

    public override bool IsValid(object value)
    {
        DateTime date;
        if ((value != null && DateTime.TryParse(value.ToString(), out date)))
        {
            return date.AddYears(MinimumAge) < DateTime.Now;
        }

        return false;
    }

    public int MinimumAge { get; }
}