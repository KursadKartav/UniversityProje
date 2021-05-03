    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Contosouniversity.Models;
using Contosouniversity.Data;
using Contosouniversity.Models.SchoolViewModels;
using Microsoft.EntityFrameworkCore;
using Contosouniversity.Dto;
using Contosouniversity.Entity;

namespace Contosouniversity.Controllers
{
    public class HomeController : Controller
    {
        private readonly SchoolContext _context;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, SchoolContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Search(string search, TableType table)
        {
            List<Course> courses = new List<Course>();
            List<Student> students = new List<Student>();

            if (table == TableType.Course || table == TableType.All)
            {
                courses = _context.Courses.Where(c => c.Title.StartsWith(search)).ToList();
            }
            if (table == TableType.Student || table == TableType.All)
            {
                students = _context.Students.Where(c => c.FirstMidName.StartsWith(search)
                                                     || c.LastName.StartsWith(search)).ToList();
            }
            return View(Tuple.Create(courses, students));

            //if (string.IsNullOrWhiteSpace(search))
            //{
            //    return View();
            //}
            //else 
            //{
            //    ViewData["filter"] = search;

            //    var course = from m in _context.Courses
            //                 select m;
            //    var student = from m in _context.Students
            //                  select m;


            //    if (!String.IsNullOrEmpty(search))
            //    {
            //        course = course.Where(s => s.Title.StartsWith(search));
            //        student = student.Where(s => s.LastName.StartsWith(search));
            //    }

            //    return View(Tuple.Create(course.ToList(), student.ToList()));
        }

        public IActionResult Filter(string filtrele,Combo sec, SearchType searchType)
        {
            //if (string.IsNullOrWhiteSpace(filtrele))
            //{
            //    return View();
            //}

            //var course = _context.Courses.Where(x => x.Title.Contains(filtrele));
            //var student = _context.Students.Where(x => x.LastName.Contains(filtrele));
            List<Course> course = new List<Course>();
            List<Student> student = new List<Student>();

            if(sec == Combo.Course)
            {
                if (searchType == SearchType.Equals)
                    course = _context.Courses.Where(x => x.Title == filtrele.Trim() ).ToList();
                else if (searchType == SearchType.StartWith)
                    course = _context.Courses.Where(x => x.Title.StartsWith(filtrele) ).ToList();
                else if (searchType == SearchType.EndWith)
                    course = _context.Courses.Where(x => x.Title.EndsWith(filtrele) ).ToList();
            }
            if(sec== Combo.Student)
            {
                var tempStringWithSpaces = "    skdfj    ";
                var tempStringWithoutSpaces = tempStringWithSpaces.Trim();
                if(searchType == SearchType.Equals)
                student = _context.Students.Where(x => x.LastName == filtrele.Trim() || x.FirstMidName == filtrele.Trim()).ToList();
                else if(searchType == SearchType.StartWith)
                    student = _context.Students.Where(x => x.LastName.StartsWith(filtrele) || x.FirstMidName.StartsWith(filtrele)).ToList();
                else if (searchType == SearchType.EndWith)
                    student = _context.Students.Where(x => x.LastName.EndsWith(filtrele) || x.FirstMidName.EndsWith(filtrele)).ToList();
            }
           

            return View(Tuple.Create(course,student));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //public async Task<ActionResult> About()
        //{
        //    IQueryable<EnrollmentDateGroup> data =
        //        from student in _context.Students
        //        group student by student.EnrollmentDate into dateGroup
        //        select new EnrollmentDateGroup()
        //        {
        //            EnrollmentDate = dateGroup.Key,
        //            StudentCount = dateGroup.Count()
        //        };
        //    return View(await data.AsNoTracking().ToListAsync());
        //}
    }
}
