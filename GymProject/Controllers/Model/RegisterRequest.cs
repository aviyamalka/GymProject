using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.Controllers
{
    public class RegisterRequest
    {
       

        public string UserId { get; set; }

        public int LessonId { get; set; }

        public RegisterRequest()
        {

        }

        public RegisterRequest(string UserId, int LessonId)
        {
            this.UserId = UserId;
            this.LessonId = LessonId;
        }
    }
}
