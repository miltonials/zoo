using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using zoo.Models;
using database.Models;

namespace zoo.Controllers;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;

  public HomeController(ILogger<HomeController> logger)
  {
    _logger = logger;
  }

  public IActionResult Index()
  {
    return View();
  }

  public IActionResult Zoos()
  {
    Database database = new Database();
    
    return View("zoos", database);
  }

  [HttpPost]
  public IActionResult Registered(Zoo zoo)
  {
    zoo.saveZoo();
    return View(zoo);
  }
}
