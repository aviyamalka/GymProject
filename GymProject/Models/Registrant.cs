using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.Models
{
    public class Registrant
    {
        public int RegistrantId{get; set;}
        [Column("UserIdId")]
        public Microsoft.AspNetCore.Identity.IdentityUser UserId { get; set; }
    [Column("LessonId1")]
        public Lesson LessonId { get; set; }
    }
}
