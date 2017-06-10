using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NMUG.Data;
using NMUG.Helpers;
using NMUG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace NMUG.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private IHostingEnvironment _environment;

        public HomeController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            
            //var meetingsOption1 = _context.Meeting.OrderByDescending(c => c.MeetingDate).Select(c => c.MeetingDate >= DateTime.Today).Take(1);

            var meetingsOption2 = _context.Meeting.OrderBy(c => c.MeetingDate).Where(m => m.MeetingDate >= DateTime.Today).Take(1);
            
            var meetingsOption3 = _context.Meeting.OrderBy(c => c.MeetingDate).Where(m => m.MeetingDate >= DateTime.Today).Take(4);
            return View(meetingsOption2);


        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult DownloadsView()
        {

            return View();
        }

        public IActionResult EducationView()
        {

            return View();
        }


        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Upload()
        {

             return View();
        }



    }



}
