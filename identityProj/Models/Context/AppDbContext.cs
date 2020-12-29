using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identityProj.Models.Context
{
    public class AppDbContext:IdentityDbContext 
    {
        public AppDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        { 
        }
        public DbSet<Employee> employees { get; set; }
    }
}
