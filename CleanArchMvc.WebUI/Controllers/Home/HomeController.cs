using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers.HomeController;

public class HomeController : Controller
{
  [HttpGet]
  public IActionResult Index()
  {
    return View();
  }
  public IActionResult Privacy()
  {
    return View();
  }
}
