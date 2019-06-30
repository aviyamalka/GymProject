using GymProject.Data;
using GymProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.Logic
{
    public class LessonLogic
    {
        private readonly ApplicationDbContext _context;
        public LessonLogic(ApplicationDbContext context)
        {
          _context = context;
        }
        public void RegisterToLesson(int UserId, int LessonId)
        {
            Lesson lsn = _context.Lesson.Where(l=>l.LessonId == LessonId).FirstOrDefault();
            User user = _context.Users.Where(u => u.UserId == UserId).FirstOrDefault();
            if (lsn.RegistrantMax == lsn.RegistrantNum)
            {
                throw new Exception("The Lesson is full and you can't registered");
            }
            else
            {
                Registrant reg = new Registrant();
                reg.LessonId = lsn;
                reg.UserId = user;
                try {
                    _context.Registrant.Add(reg);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new Exception("an error occured"+e.InnerException);
                }
            }
        }

        public void CancelRegistrant(int UserId, int LessonId)
        {
            Lesson lsn = _context.Lesson.Where(l => l.LessonId == LessonId).FirstOrDefault();
            User user = _context.Users.Where(u => u.UserId == UserId).FirstOrDefault();
            try
            {
                Registrant reg = new Registrant();
                reg.LessonId = lsn;
                reg.UserId = user;
                _context.Registrant.Remove(reg);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("an error occured" + e.InnerException); 
            }
        }
    }
}
