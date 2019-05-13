using System;
using System.Collections.Generic;
using System.Text;
using GymProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        DbSet<User> Users { get; set; }
        DbSet<Address> Addresses { get; set; }
    }
}
