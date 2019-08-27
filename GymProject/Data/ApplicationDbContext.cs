using System;
using System.Collections.Generic;
using System.Text;
using GymProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymProject.Data
{
    public class ApplicationDbContext : IdentityDbContext//CustomRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
      //  public  DbSet<GymUser> GymUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<Branch> Branch { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Registrant> Registrant { get; set; }
    }
}
