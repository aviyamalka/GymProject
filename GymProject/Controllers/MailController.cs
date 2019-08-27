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
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GymProject.Controllers
{
    public class MailController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();




        }


        [HttpPost]
        public bool SendMail([FromBody] MailService m)
        {
            try
            {
               
                MailService.SendEmail(m.email,"send mail","body","desc");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
