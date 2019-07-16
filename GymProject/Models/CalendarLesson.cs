using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.Models
{
    public class CalendarLesson
    {
        public int LessonId { get; set; }
        public Branch BranchId { get; set; }
        public Training TrainingId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string TeacherName { get; set; }
        public int RegistrantMax { get; set; }
        public int RegistrantNum { get; set; }
        public string BranchName { get; set; }
        public string TrainningName { get; set; }
    }
}
