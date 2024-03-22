using ilk_proje.Models;
using Microsoft.AspNetCore.Mvc;

namespace ilk_proje.Controllers;

//course
 public class CourseController : Controller
{
    //course
    //course/index
    // public IActionResult Index()
    // {
    //     var kurs = new Course();
    //     kurs.Id = 1;
    //     kurs.Title = "Aspnet core kursu";
    //     kurs.Description = "Güzel bir kurs";
    //     kurs.images = "avatar.png";
    //     return View(kurs);
    // }
    public IActionResult Details(int? id)
    {
        if(id == null) {
            return Redirect("/course/list");
            // return RedirectToAction("List","Course");
        }
        var kurs = Repository.GetById(id);
        return View(kurs);
    }
    //course/list
    public IActionResult List()
    {
       
        return View("CourseList",Repository.Courses);
    }
}