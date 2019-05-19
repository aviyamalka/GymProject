using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.Models
{
    public class Registrant
    {
        public int RegistrantId{get; set;}
        public User UserId { get; set; }
        public Lesson LessonId { get; set; }
    }
}
