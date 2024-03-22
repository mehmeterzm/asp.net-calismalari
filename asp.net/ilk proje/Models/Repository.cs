using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ilk_proje.Models
{
    public class Repository
    {
        private static readonly List<Course> _courses = new();

        static Repository()
        {
        _courses = new List<Course>()
        {
            new Course() {
            Id=1,
            Title="asp net kursu",
            Description = "güzel bir kurs",
            images ="avatar.png",
            Tags = new string[] {"aspnet", "web geliştirme"},
            isActive= true,
            isHome = true
            },
            new Course() {
            Id=2,
            Title="javascript kursu",
            Description = "güzel bir kurs",
            images ="js.png",
            Tags = new string[] {"javascript", "web geliştirme"},
            isActive= true,
            isHome = true
            },

            new Course() {Id=3,
            Title="phyton kursu",
            Description = "güzel bir kurs",
            images ="phyton.png",
            isActive= true,
            isHome = true
            },
            
        };
        }

        public static List<Course> Courses
        {
            get{
                return _courses;
            }
        }

        public static Course? GetById(int? id) //statici eklemezsen instance bir metod olur erişilemez çünkü oluşturduğumuz metot static
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }

    }
}