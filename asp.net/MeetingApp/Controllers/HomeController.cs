using MeetingApp.Controllers;
using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class HomeController : Controller
    {
        //localhost
        //localhost/home
        //localhost/home/index
        public IActionResult Index()
        {
            
            int saat = DateTime.Now.Hour;

            ViewBag.selamlama = saat > 12 ? "İyi günler" : "Günaydın";
            int UserCount = Repository.Users.Where(info => info.WillAttend == true).Count();
            // ViewBag.userN= "Zehra";
            // ViewData["Selamla"] = saat > 12 ? "İyi günler" : "Günaydın";
            // ViewData["userN"] = "Çınar";

            var meetingInfo = new MeetingInfo()
            {
                Id = 1,
                Location ="İstanbul",
                Date = new DateTime(2024, 01, 11,20, 0,0),
                NumberOfPeople =UserCount
            };

            return View(meetingInfo);
        }
    }
}