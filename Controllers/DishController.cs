using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _5_Chefs_N_Dishes.Models;
using Microsoft.EntityFrameworkCore;

namespace _5_Chefs_N_Dishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;
    public MyContext db;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet("dishes")]
    public IActionResult Index()
    {
        List<Dish> allDishes = db.Dishes.Include(c => c.Creator).OrderBy(c => c.CreatedAt).ToList();
        return View(allDishes);
    }

    [HttpGet("dishes/new")]
    public IActionResult New()
    {
        ViewBag.allChefs = db.Chefs.ToList();
        return View();
    }

    [HttpPost("dishes/create")]
    public IActionResult Create(Dish newdish)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.allChefs = db.Chefs.ToList();
            return View("New");
        }
        db.Dishes.Add(newdish);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
