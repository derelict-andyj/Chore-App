using Chore_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chore_App.DB
{
    public class ChoresContext : DbContext
    {
        public ChoresContext(DbContextOptions<ChoresContext> options)
            : base(options)
        {
        }
            public DbSet<ChoresList> Chorelist { get; set; }
    
    }
}
