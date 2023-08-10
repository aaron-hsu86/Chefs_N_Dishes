using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using _5_Chefs_N_Dishes.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace _5_Chefs_N_Dishes.Controllers;

public class ChefController : Controller
{
    private readonly ILogger<ChefController> _logger;
    public MyContext db;

    public ChefController(ILogger<ChefController> logger, MyContext context)
    {
        _logger = logger;
        db = context;
    }

    [HttpGet("chefs")]
    public IActionResult Index()
    {
        List<Chef> allChefs = db.Chefs.Include(d => d.AllDishes).ToList();
        return View(allChefs);
    }

    [HttpGet("chefs/new")]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost("chefs/create")]
    public IActionResult Create(Chef newChef)
    {
        if (!ModelState.IsValid)
        {
            return View("New");
        }
        db.Chefs.Add(newChef);
        db.SaveChanges();
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
