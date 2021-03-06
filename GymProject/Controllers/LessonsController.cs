﻿using System;
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
using GymProject.Controllers.Model;

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
        public async Task<IActionResult> Index(string searchTrain = null,string searchCity = null,DateTime? searchDate=null)
        {
            List<Lesson> lessons=new List<Lesson>();
            BussinessLogic BL = new BussinessLogic(this.cache, _context);
            List<string> citiesLst = BL.GetCitiesNamesFromCache();
            List<string> traningLst = BL.GetTrainingNamesFromCache();
            ViewBag.citiesLst = citiesLst;
            ViewBag.traningLst = traningLst;
            if (!string.IsNullOrEmpty(searchTrain))
            {
                lessons = (from less in _context.Lesson
                           join train in _context.Training on less.TrainingId equals train
                           join bran in _context.Branch on less.BranchId equals bran
                           join add in _context.Addresses on bran.BranchAddress equals add
                           where less.StartTime.Date == searchDate.Value
                           && bran.BranchAddress.City == searchCity
                           && less.TrainingId.Name == searchTrain
                           select new Lesson
                           {
                               LessonId = less.LessonId
                                      ,
                               TrainingId = train,
                               BranchId = less.BranchId,
                               EndTime = less.EndTime,
                               RegistrantMax = less.RegistrantMax,
                               RegistrantNum = less.RegistrantNum,
                               StartTime = less.StartTime,
                               TeacherName = less.TeacherName

                           }).ToList();
                return View(lessons);
            }
            return View(await _context.Lesson.ToListAsync());
        }
        public List<CalendarLesson> GetAllLessons()
        {
            return (from less in _context.Lesson
                    join bran in _context.Branch on less.BranchId equals bran
                    join train in _context.Training
                    on less.TrainingId equals train
                    select new CalendarLesson
                    {
                        LessonId = less.LessonId,
                        BranchId = bran,
                        BranchName = bran.Name,
                        EndTime = less.EndTime,
                        StartTime = less.StartTime,
                        RegistrantMax = less.RegistrantMax,
                        RegistrantNum = less.RegistrantNum,
                        TeacherName = less.TeacherName,
                        TrainingId = train,
                        TrainningName = train.Name

                    }).ToList();
        }

        public dynamic GetAllLessonsGroupByBranch()
        {
            //return  _context.Lesson.Include(b => b.BranchId).GroupBy(br => br.BranchId).ToList();
            return (from less in _context.Lesson
                    group less by less.BranchId.Name into lessBranch
                    select new
                    {
                        name = lessBranch.Key,
                        count = lessBranch.Count()
                    }).ToList();
        }
        public void  Search([FromBody]SearchRequest search)
        {
            var lessons = (from less in _context.Lesson
                                  join train in  _context.Training on less.TrainingId equals train
                                  join bran in _context.Branch on less.BranchId equals bran
                                  join add in _context.Addresses on bran.BranchAddress equals add
                           where less.StartTime.Date == search.date.Date
                           && bran.BranchAddress.City == search.city
                           && less.TrainingId.Name == search.train
                           select new Lesson
                                   {
                                       LessonId = less.LessonId
                                      ,TrainingId=train,
                                       BranchId=less.BranchId,
                                       EndTime=less.EndTime,
                                       RegistrantMax=less.RegistrantMax,
                                       RegistrantNum=less.RegistrantNum,
                                       StartTime=less.StartTime,
                                       TeacherName=less.TeacherName

                                   }).ToListAsync();
        }
    // GET: Lessons/Details/5
    //public async Task<IActionResult> SearchFunc(string city, string trainning, DateTime date)
    //{
    //    var result = from d in _context.searchRes
    //                 where (d.city == city && d.Name == trainning && d.StartTime == date)
    //                 select d;
    //    return View(await result.ToListAsync());          


    //}

    //public ActionResult search(string city , DateTime date, string trainning)

    //    {
    //        IEnumerable<Lesson> lesson = _context.Lesson.Include(l => l.StartTime.Date);
    //        IEnumerable<Training> training = _context.Training.Include(t => t.Name);
    //        IEnumerable<Address> address = _context.Addresses.Include(a => a.City);

           // if (city == a.city)
            //    lesson = lesson.Where(l => l.StartTime.Contains(date));
            //if (search_from != "All" && search_from != "")
        //        training = training.Where(t => t.Name.Contains(trainning));
        //   // if (search_to != "All" && search_to != "")
        //        address = address.Where(a => a.City.Contains(city));

        //    return View(lesson.ToList());

        //}

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

        [HttpPost]
        public bool RegisterToLesson([FromBody]RegisterRequest r)
        {
            try
            {
                LessonLogic logic = new LessonLogic(_context);
                logic.RegisterToLesson(r.UserId, r.LessonId);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CancelRegistrant([FromBody]RegisterRequest r)
        {
            try
            {
                LessonLogic logic = new LessonLogic(_context);
                logic.CancelRegistrant(r.UserId, r.LessonId);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

