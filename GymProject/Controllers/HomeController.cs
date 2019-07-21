using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymProject.Data;
using GymProject.Models;
using Microsoft.Extensions.Caching.Memory;
using GymProject.Logic;

namespace GymProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IMemoryCache cache;

        public HomeController(ApplicationDbContext context,IMemoryCache cache)
        {
            this.cache = cache;
            _context = context;
        }

        public async Task <IActionResult >Index()
        {
            BussinessLogic BL = new BussinessLogic(this.cache, _context);
            List<string> citiesLst = BL.GetCitiesNamesFromCache();
            List<string> traningLst = BL.GetTrainingNamesFromCache();
            ViewBag.citiesLst = citiesLst;
            ViewBag.traningLst = traningLst;
            return View(await _context.Lesson.ToListAsync());

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Active.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        public IActionResult tnxpage()
        {
           

            return View();
        }
    }
}
