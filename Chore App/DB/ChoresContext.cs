using Chore_App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chore_App.DB
{
    public class ChoresContext : IdentityDbContext
    {
        public ChoresContext(DbContextOptions<ChoresContext> options)
            : base(options)
        {
        }
            public DbSet<ChoresList> Chorelist { get; set; }

            //public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
        }

    }
}
