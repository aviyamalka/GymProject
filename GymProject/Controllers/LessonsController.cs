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
    public class LessonsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IMemoryCache cache;
        public LessonsController(ApplicationDbContext context, IMemoryCache cache)
        {
            this.cache = cache;
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
            BussinessLogic BL = new BussinessLogic(this.cache,_context);
            List<string> citiesLst = BL.GetCitiesNamesFromCache();
            List<string> traningLst = BL.GetTrainingNamesFromCache();
            ViewBag.citiesLst = citiesLst;
            ViewBag.traningLst = traningLst;
            return View(await _context.Lesson.ToListAsync());
        }
        public List<CalendarLesson> GetAllLessons()
        {
            return (from less in _context.Lesson
                    join bran in _context.Branch on less.BranchId equals bran
                    join train in _context.Training
                    on less.TrainingId equals train select new CalendarLesson{
                        LessonId=less.LessonId,
                        BranchId=bran,
                        BranchName=bran.Name,
                        EndTime=less.EndTime,
                        StartTime=less.StartTime,
                        RegistrantMax=less.RegistrantMax,
                        RegistrantNum=less.RegistrantNum,
                        TeacherName=less.TeacherName,
                        TrainingId=train,
                        TrainningName= train.Name

                    }).ToList();
        }
        public void Search(string city, DateTime date, string trainning)
         //public async Task<IActionResult> Search(string city,DateTime date,string trainning)
        {

            if (city != "-עיר-")
            {
            //    List<Lesson> result = (from less in _context.Lesson
            //                           join bran in _context.Branch on less.LessonId equals bran.BranchId
            //                           join add in _context.Addresses on bran.BranchAddress.AddressId equals add.AddressId
            //                           select new Lesson
            //                           {
            //                               LessonId = less.LessonId

            //                           }).ToList();
            }
            else
            {

            }
            if (trainning!="-אימון-")
            {

            }
            
        }
        // GET: Lessons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: Lessons/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lessons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LessonId,StartTime,EndTime,TeacherName,RegistrantMax,RegistrantNum")] Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lesson);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lesson);
        }

        // GET: Lessons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            return View(lesson);
        }

        // POST: Lessons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonId,StartTime,EndTime,TeacherName,RegistrantMax,RegistrantNum")] Lesson lesson)
        {
            if (id != lesson.LessonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.LessonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lesson);
        }

        // GET: Lessons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lesson
                .FirstOrDefaultAsync(m => m.LessonId == id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: Lessons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lesson = await _context.Lesson.FindAsync(id);
            _context.Lesson.Remove(lesson);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            return _context.Lesson.Any(e => e.LessonId == id);
        }

        public bool RegisterToLesson(int UserId, int LessonId)
        {
            try
            {
                LessonLogic logic = new LessonLogic(_context);
                logic.RegisterToLesson(UserId, LessonId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CancelRegistrant(int UserId, int LessonId)
        {
            try
            {
                LessonLogic logic = new LessonLogic(_context);
                logic.CancelRegistrant(UserId, LessonId);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
