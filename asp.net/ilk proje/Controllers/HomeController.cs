using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ilk_proje.Models;

namespace ilk_proje.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View(Repository.Courses);
    }

    public IActionResult contact()
    {
        return View();
    }

}
