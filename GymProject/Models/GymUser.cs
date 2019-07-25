﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GymProject.Models
{
    public class GymUser:IdentityUser
    {
        public int userId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public Address UserAdress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ProfieImgSrc { get; set; }

    }
}